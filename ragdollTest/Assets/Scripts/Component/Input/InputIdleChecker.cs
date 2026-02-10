using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

//作成者:杉山
//無操作の状態が一定時間続いたことを検知する機能

public class InputIdleChecker : MonoBehaviour
{
    [SerializeField] float idleTime = 30f;

    float lastInputTime;
    bool isIdle = false;

    IDisposable disposable;

    public event Action OnIdle;//無操作になった瞬間に呼ばれるイベント

    void OnEnable()
    {
        lastInputTime = Time.time;
        isIdle = false;

        disposable = InputSystem.onAnyButtonPress.Call(control => OnAnyInput(control));
    }

    void OnDisable()
    {
        disposable?.Dispose();
    }

    void OnAnyInput(InputControl control)
    {
        lastInputTime = Time.time;

        // 入力があったら「無操作状態」を解除
        isIdle = false;
    }

    void Update()
    {
        bool isOverIdleTime = Time.time - lastInputTime >= idleTime;

        if (!isIdle && isOverIdleTime)
        {
            isIdle = true;

            OnIdle?.Invoke(); //コールバック発火
        }
    }
}