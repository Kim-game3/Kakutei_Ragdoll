using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬��:���R
//�N���W�b�g��UI����

public partial class CreditManager
{
    [System.Serializable]
    class CreditManager_UI
    {
        [SerializeField]
        EventSystem _eventSystem;

        [CustomLabel("�N���W�b�g���j���[���J���@�\")] [SerializeField]
        ShowUITypeBase _openOption;

        [CustomLabel("�N���W�b�g���j���[�����@�\")] [SerializeField]
        HideUITypeBase _closeOption;

        Button _openButton;//�N���W�b�g���j���[���J���{�^��
        Button _closeButton;//�N���W�b�g���j���[�����{�^��

        public void Awake(Button openButton, Button closeButton)
        {
            _openButton = openButton;
            _closeButton = closeButton;
        }

        public void Start()
        {
            _closeOption.Hide();
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
    }
}
