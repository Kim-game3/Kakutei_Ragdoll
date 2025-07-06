using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//タイマー

public class Timer : MonoBehaviour
{
    [Tooltip("計る時間")] [SerializeField] float _duration;
    [Tooltip("開始時にタイマーを開始するか")] [SerializeField] bool _startOnAwake;
    float _remainingTime;//残り時間
    TimerState _state = TimerState.Off; //タイマーの状態

    //public

    public event Action TimeUpEvent;//タイマーが0になった時に呼ばれるイベント
    public event Action TimerStartEvent;//タイマーが開始された時に呼ばれるイベント
    public event Action PauseEvent;//タイマーが一時停止になった時に呼ばれるイベント
    public event Action ResumeEvent;//タイマーが再開した時に呼ばれるイベント

    //タイマーを最初から開始する
    public void TimerStart()
    {
        //既にオンになってたら警告だけして何もしない
        if(_state==TimerState.On)
        {
            Debug.Log("既にタイマーを開始しています！");
            return;
        }

        _state= TimerState.On;
        TimerStartEvent?.Invoke();
        _remainingTime = _duration;
    }

    public float RemainingTime { get { return _remainingTime; } }//タイマーの残り時間を返す

    public TimerState State { get { return _state; } }//タイマーの状態

    public float Duration//タイマーの測る時間
    {
        get { return _duration; }
        set { _remainingTime = value; }
    }

    
    public bool SwitchPauseResume() //タイマーの一時停止・再開の切り替え
    {
        //そもそも動いていなかったら警告してfalseを返す
        if(_state==TimerState.Off)
        {
            Debug.Log("タイマーが動いてません！");
            return false;
        }

        //タイマーが動いている状態であったら一時停止にする
        else if(_state==TimerState.On)
        {
            _state = TimerState.Pause;
            PauseEvent?.Invoke();
            return true;
        }

        //タイマーが一時停止状態であったら再開する
        else
        {
            _state= TimerState.On;
            ResumeEvent?.Invoke();
            return true;
        }
    }

    //private

    private void Start()
    {
        if (_startOnAwake) TimerStart();
    }

    private void Update()
    {
        UpdateRemainingTime();
    }

    void UpdateRemainingTime()
    {
        if (_state != TimerState.On) return;

        _remainingTime -= Time.deltaTime;

        bool timeUp=_remainingTime < 0;//時間切れになった

        if(timeUp)
        {
            //時間切れになった時の処理
            _state = TimerState.Off;
            TimeUpEvent?.Invoke();
        }
    }
}
