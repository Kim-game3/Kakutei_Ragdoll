using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

//作成者:杉山
//無操作の状態が一定時間続いたことを検知する機能

public class InputIdleChecker : MonoBehaviour
{
    [SerializeField] float _idleTime = 30f;

    float _lastInputTime;
    bool _isIdle = false;

    IDisposable _disposable;

    public event Action OnIdle;//無操作になった瞬間に呼ばれるイベント

    void OnEnable()
    {
        _lastInputTime = Time.time;
        _isIdle = false;

        _disposable = InputSystem.onAnyButtonPress.Call(control => OnAnyInput(control));
    }

    void OnDisable()
    {
        _disposable?.Dispose();
    }

    void OnAnyInput(InputControl control)
    {
        _lastInputTime = Time.time;

        // 入力があったら「無操作状態」を解除
        _isIdle = false;
    }

    void Update()
    {
        bool isOverIdleTime = Time.time - _lastInputTime >= _idleTime;

        if (!_isIdle && isOverIdleTime)
        {
            _isIdle = true;

            OnIdle?.Invoke(); //コールバック発火
        }
    }
}