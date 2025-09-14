using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//タイマー機能

public class Timer : MonoBehaviour
{
    [Tooltip("計る時間")] [SerializeField] float _duration;
    [Tooltip("開始時にタイマーを開始するか")] [SerializeField] bool _startOnAwake;
    float _remainingTime;//残り時間
    TimerState _state = TimerState.Off;//タイマーの状態

    //public

    public event Action ResetEvent;//タイマーのリセット時
    public event Action TimeUpEvent;//残り時間が0になった時
    public event Action StartEvent;//タイマーが開始された時
    public event Action PauseEvent;//タイマーの一時停止時
    public event Action ResumeEvent;//タイマーが再開した時

    public float RemainingTime { get { return _remainingTime; } }//タイマーの残り時間を返す

    public TimerState State { get { return _state; } }//タイマーの状態

    public float Duration//タイマーの測る時間
    {
        get { return _duration; }
        set { _remainingTime = value; }
    }

    public void ResetTimer()//タイマーの状態をリセット
    {
        _state=TimerState.Off;
        _remainingTime=_duration;
        ResetEvent?.Invoke();
    }

    public void SwitchStartStop()//タイマー開始、タイマーの停止、タイマーの再開操作が出来る
    {
        switch(_state)
        {
            case TimerState.Off://オフ→オン
                _state=TimerState.On;
                _remainingTime = _duration;
                StartEvent?.Invoke();
                break;

            case TimerState.On://オン→一時停止
                _state=TimerState.Stop;
                PauseEvent?.Invoke();
                break;

            case TimerState.Stop://一時停止→オン
                _state = TimerState.On;
                ResumeEvent?.Invoke();
                break;

            default:
                Debug.Log("タイマーの状態の切り替えに失敗しました！");
                break;
        }
    }

    

    //private

    private void Start()
    {
        ResetTimer();//タイマーの状態をリセット
        
        if (_startOnAwake) SwitchStartStop();//オンの状態になる
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

        if (!timeUp) return;

        //時間切れになった時の処理
        _state = TimerState.TimeUp;
        TimeUpEvent?.Invoke();
    }
}
