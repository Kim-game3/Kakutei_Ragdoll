using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�I�v�V������ʂ̏���

public partial class OptionManager : MonoBehaviour
{
    [CustomLabel("�I�v�V�������J���{�^��")] [SerializeField]
    Button _openOptionButton;

    [CustomLabel("�I�v�V���������{�^��")] [SerializeField]
    Button _closeOptionButton;

    [Tooltip("UI�֌W")] [SerializeField]
    OptionManager_UI _uiProcess;

    public void OnOpen()//�I�v�V�������j���[���J����
    {
        _uiProcess.OnOpen();
    }

    public void OnClose()//�I�v�V�������j���[����鎞
    {
        _uiProcess.OnClose();
    }



    private void OnDisable()
    {
        _uiProcess.OnDisable();
    }

    private void Awake()
    {
        _uiProcess.Awake(_openOptionButton,_closeOptionButton);

        _openOptionButton.onClick.AddListener(OnOpen);
        _closeOptionButton.onClick.AddListener(OnClose);
    }

    // Start is called before the first frame update
    void Start()
    {
        _uiProcess.Start();
    }
}
