using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//ストップウォッチ機能

public class StopWatch : MonoBehaviour
{
    [Tooltip("開始時に計測を開始するか")] [SerializeField] 
    bool _startOnAwake;

    float _elapsedTime;//経過時間
    StopWatchState _state = StopWatchState.Off;//タイマーの状態

    const float _resetTime = 0;//リセットしたときに経過時間が0になるようにする

    //public

    public event Action OnReset;//ストップウォッチのリセット時
    public event Action OnStart;//ストップウォッチが開始された時
    public event Action OnPause;//ストップウォッチの一時停止時
    public event Action OnResume;//ストップウォッチが再開した時

    public float ElapsedTime { get { return _elapsedTime; } }

    public StopWatchState State { get { return _state; } }

    public void ResetStopWatch()//タイマーの状態をリセット
    {
        _state = StopWatchState.Off;
        _elapsedTime = _resetTime;
        OnReset?.Invoke();
    }

    public void SwitchStartStop()//開始、停止、再開操作が出来る
    {
        switch (_state)
        {
            case StopWatchState.Off://オフ→オン
                _state = StopWatchState.On;
                OnStart?.Invoke();
                break;

            case StopWatchState.On://オン→一時停止
                _state = StopWatchState.Stop;
                OnPause?.Invoke();
                break;

            case StopWatchState.Stop://一時停止→オン
                _state = StopWatchState.On;
                OnResume?.Invoke();
                break;

            default:
                Debug.Log("ストップウォッチの状態の切り替えに失敗しました！");
                break;
        }
    }

    //private
    private void Awake()
    {
        //ストップウォッチの状態をリセット
        _state = StopWatchState.Off;
        _elapsedTime = _resetTime;
    }

    private void Start()
    {
        if (_startOnAwake) SwitchStartStop();
    }

    private void Update()
    {
        UpdateRemainingTime();
    }

    void UpdateRemainingTime()
    {
        if (_state != StopWatchState.On) return;

        _elapsedTime += Time.deltaTime;
    }
}
