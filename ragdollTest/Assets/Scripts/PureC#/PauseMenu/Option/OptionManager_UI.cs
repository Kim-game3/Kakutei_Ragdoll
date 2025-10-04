using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//�쐬��:���R
//�I�v�V������UI����

public partial class OptionManager
{
    [System.Serializable]
    class OptionManager_UI
    {
        [SerializeField]
        EventSystem _eventSystem;

        [CustomLabel("�I�v�V�������j���[���J���@�\")] [SerializeField]
        ShowUITypeBase _openOption;

        [CustomLabel("�I�v�V�������j���[�����@�\")] [SerializeField]
        HideUITypeBase _closeOption;

        Button _openButton;//�I�v�V�������j���[���J���{�^��
        Button _closeButton;//�I�v�V�������j���[�����{�^��

        public void Awake(Button openButton,Button closeButton)
        {
            _openButton = openButton;
            _closeButton = closeButton;
        }

        public void Start()
        {
            _closeOption.Hide();//�Q�[���J�n���ɂ̓I�v�V�������j���[�͕��Ă���
        }

        public void OnOpen()
        {
            _openOption.Show();
            _eventSystem.SetSelectedGameObject(_closeButton.gameObject);//�I���{�^�������{�^���ɐݒ�
        }

        public void OnClose()
        {
            _closeOption.Hide();
            _eventSystem?.SetSelectedGameObject(_openButton.gameObject);//�I���{�^�����J���{�^���ɐݒ�
        }

        public void OnDisable()
        {
            if(_closeOption != null) _closeOption.Hide();
        }
    }
    
}
