using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//どのチェックポイントまで行ったかを把握する
//チェックポイントの数も把握

public class CheckPointManager : MonoBehaviour
{
    [Tooltip("チェックポイント更新のトリガー\n要素番号がチェックポイントの数字")] [SerializeField]
    OnTriggerDetect[] _checkPointZones;

    CheckPointUpdateTrigger[] _checkPointUpdateTriggers;

    int _currentCheckPointIndex = 0;//現在のチェックポイント番号

    public int CurrentCheckPointIndex { get { return _currentCheckPointIndex; } }

    public int CheckPointLength { get { return _checkPointUpdateTriggers.Length; } }

    public void UpdateCheckPoint(int newCheckPointIndex)//チェックポイントの更新
    {
        if (newCheckPointIndex <= _currentCheckPointIndex) return;

        _currentCheckPointIndex=newCheckPointIndex;
    }

    private void Awake()
    {
        _checkPointUpdateTriggers = new CheckPointUpdateTrigger[_checkPointZones.Length];

        for (int i = 0; i<_checkPointUpdateTriggers.Length ; i++)
        {
            _checkPointUpdateTriggers[i]=new CheckPointUpdateTrigger(i, _checkPointZones[i]);
            _checkPointUpdateTriggers[i].OnEnter += UpdateCheckPoint;
        }
    }
}
