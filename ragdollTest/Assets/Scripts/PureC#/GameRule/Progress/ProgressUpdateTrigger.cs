using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//進行度を更新するトリガーのふるまい

public class ProgressUpdateTrigger
{
    int _progressIndex;
    public event Action<int> OnEnter;

    public ProgressUpdateTrigger(int progressIndex,OnTriggerDetect progressTrigger)
    {
        _progressIndex = progressIndex;
        progressTrigger.OnEnter += OnEnterTrigger;
    }

    void OnEnterTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;
        OnEnter?.Invoke(_progressIndex);
    }
}
