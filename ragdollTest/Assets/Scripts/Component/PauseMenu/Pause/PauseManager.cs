using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

//�쐬��:���R
//�|�[�Y���̏���

public partial class PauseManager : MonoBehaviour
{
    [CustomLabel("�|�[�Y�����{�^��")] [SerializeField]
    Button _resumeButton;

    [Tooltip("���������֌W")] [SerializeField]
    PauseManager_InternalProcess _internalProcess;

    [Tooltip("UI�����֌W")] [SerializeField]
    PauseManager_UI _uiProcess;

    bool _isPausing=false;

    //�|�[�Y��Ԃ̐؂�ւ�
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
    }

    private void Start()
    {
        _uiProcess.OnStrat();
        _internalProcess.OnStart();
    }

    void SwitchPauseProcess()//�|�[�Y��Ԑ؂�ւ�
    {
        _isPausing = !_isPausing;

        _internalProcess.OnSwitchPause(_isPausing);
        _uiProcess.OnSwitchPause(_isPausing);
    }

}
