using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�N���W�b�g��ʂ̏���

public partial class CreditManager : MonoBehaviour
{
    [CustomLabel("�N���W�b�g���J���@�\")] [SerializeField]
    Button _openCreditButton;

    [CustomLabel("�N���W�b�g�����@�\")] [SerializeField]
    Button _closeCreditButton;

    [Tooltip("UI�֌W")] [SerializeField]
    CreditManager_UI _uiProcess;

    public void OnOpen()//�N���W�b�g���j���[���J����
    {
        _uiProcess.OnOpen();
    }

    public void OnClose()//�N���W�b�g���j���[����鎞
    {
        _uiProcess.OnClose();
    }

    private void Awake()
    {
        _uiProcess.Awake(_openCreditButton, _closeCreditButton);

        _openCreditButton.onClick.AddListener(OnOpen);
        _closeCreditButton.onClick.AddListener(OnClose);
    }

    // Start is called before the first frame update
    void Start()
    {
        _uiProcess.Start();
    }
}
