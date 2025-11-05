using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//進行度の管理

public class ProgressManager : MonoBehaviour
{
    [Tooltip("進行度更新のトリガー\n基本的にはチェックポイントのトリガーと同じで良い")] [SerializeField]
    OnTriggerDetect[] _progressZones;

    ProgressUpdateTrigger[] _progressUpdateTriggers;

    int _currentProgressIndex = 0;

    public int CurrentProgressIndex { get { return _currentProgressIndex; } }
    public int ProgressLength { get { return _progressUpdateTriggers.Length; } }

    public float Progress { get { return (float)CurrentProgressIndex / (ProgressLength - 1); } } //進行度(最大1で表す)

    public event Action<float> OnUpdateProgress;

    void UpdateProgress(int newProgressIndex)
    {
        if (newProgressIndex == _currentProgressIndex) return;

        _currentProgressIndex=newProgressIndex;
        OnUpdateProgress(Progress);
    }

    private void Awake()
    {
        _progressUpdateTriggers = new ProgressUpdateTrigger[_progressZones.Length];

        for(int i=0; i<_progressUpdateTriggers.Length ;i++)
        {
            _progressUpdateTriggers[i] = new ProgressUpdateTrigger(i, _progressZones[i]);
            _progressUpdateTriggers[i].OnEnter += UpdateProgress;
        }
    }
}
