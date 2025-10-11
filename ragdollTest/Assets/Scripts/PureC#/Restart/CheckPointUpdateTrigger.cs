using UnityEngine;
using System;

public class CheckPointUpdateTrigger
{
    int _checkPointIndex;
    public event Action<int> OnEnter;

    public CheckPointUpdateTrigger(int checkPointIndex,OnTriggerDetect checkPointTrigger)
    {
        _checkPointIndex = checkPointIndex;
        checkPointTrigger.OnEnter += OnEnterTrigger;
    }

    void OnEnterTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;
        OnEnter?.Invoke(_checkPointIndex);
    }
}
