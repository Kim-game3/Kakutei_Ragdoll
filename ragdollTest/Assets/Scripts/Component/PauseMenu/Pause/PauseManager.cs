using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System;

//作成者:杉山
//ポーズ時の処理

public partial class PauseManager : MonoBehaviour
{
    [CustomLabel("ポーズ解除ボタン")] [SerializeField]
    Button _resumeButton;

    [Tooltip("内部処理関係")] [SerializeField]
    PauseManager_InternalProcess _internalProcess;

    [Tooltip("UI処理関係")] [SerializeField]
    PauseManager_UI _uiProcess;

    bool _isPausing=false;

    public event Action OnPause;
    public event Action OnResume;

    //ポーズ状態の切り替え
    public void SwitchPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SwitchPauseProcess();
    }

    public void SwitchPause()
    {
        SwitchPauseProcess();
    }


    //private

    private void Awake()
    {
        _resumeButton.onClick.AddListener(SwitchPause);

        _uiProcess.Awake(_resumeButton);
    }

    private void Start()
    {
        _uiProcess.Start();
        _internalProcess.Start();
    }

    void SwitchPauseProcess()//ポーズ状態切り替え
    {
        _isPausing = !_isPausing;

        _internalProcess.OnSwitchPause(_isPausing);
        _uiProcess.OnSwitchPause(_isPausing);

        if (_isPausing)
        {
            OnPause?.Invoke();
        }
        else
        {
            OnResume?.Invoke();
        }
    }

}
