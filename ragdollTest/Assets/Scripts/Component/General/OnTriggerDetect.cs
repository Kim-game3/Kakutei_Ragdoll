using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//コールバック形式でOnTriggerにイベントを登録できる

public class OnTriggerDetect : MonoBehaviour
{
    public event Action<Collider> OnStay;
    public event Action<Collider> OnEnter;
    public event Action<Collider> OnExit;

    private void OnTriggerStay(Collider other)
    {
        OnStay?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke(other);
    }
}
