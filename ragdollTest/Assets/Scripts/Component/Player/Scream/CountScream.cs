using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//アザラシの叫んだ回数を数える機能

public class CountScream : MonoBehaviour
{
    [SerializeField]
    Scream _scream;

    int _count = 0;

    public int Count { get { return _count; } }

    private void OnEnable()
    {
        _scream.OnScream += AddCount;
    }

    private void OnDisable()
    {
        _scream.OnScream -= AddCount;
    }

    void AddCount()
    {
        _count++;
    }
}
