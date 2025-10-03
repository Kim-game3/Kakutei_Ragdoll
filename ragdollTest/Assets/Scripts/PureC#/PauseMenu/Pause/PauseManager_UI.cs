using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//�쐬��:���R
//�|�[�Y��UI�w(�v���C���[�̖ڂɌ����镔��)

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_UI
    {
        [SerializeField] 
        EventSystem _eventSystem;

        [Header("�Q�[������UI�֘A")]

        [CustomLabel("�Q�[������UI���J���@�\")] [SerializeField]
        ShowUITypeBase _openInGameUI;

        [CustomLabel("�Q�[������UI�����@�\")] [SerializeField]
        HideUITypeBase _closeInGameUI;

        [Header("�|�[�Y���j���[�֘A")]

        [CustomLabel("�|�[�Y���j���[���J���@�\")] [SerializeField]
        ShowUITypeBase _openPauseMenu;

        [CustomLabel("�|�[�Y���j���[�����@�\")] [SerializeField]
        HideUITypeBase _closePauseMenu;

        [Tooltip("��ԏ�̊K�w��CanvasGroup")] [SerializeField]
        CanvasGroup _canvas;

        Button _resumeButton;

        public void Awake(Button resumeButton)//resumeButton=�Q�[���ĊJ�{�^��
        {
            _resumeButton = resumeButton;
        }

        public void Start()
        {
            OnResume();
        }

        public void OnSwitchPause(bool isPausing)
        {
            if (isPausing) OnPause();

            else OnResume();
        }

        void OnPause()
        {
            _closeInGameUI.Hide();
            _openPauseMenu.Show();
            _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);//Resume�{�^����I����Ԃɂ���
        }

        void OnResume()
        {
            _closePauseMenu.Hide();
            _openInGameUI.Show();
            _eventSystem.SetSelectedGameObject(null);//�ǂ̃{�^�����I����Ԃɂ��Ȃ�
        }
    }
}
