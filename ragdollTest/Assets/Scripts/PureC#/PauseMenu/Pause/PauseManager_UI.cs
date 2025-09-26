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

        [CustomLabel("�Q�[������UI")] [SerializeField]
        GameObject _inGameUI;

        [CustomLabel("�|�[�Y���j���[")] [SerializeField]
        GameObject _pauseMenu;

        

        Button _resumeButton;

        public void Awake(Button resumeButton)//resumeButton=�Q�[���ĊJ�{�^��
        {
            _resumeButton = resumeButton;
        }

        public void Strat()
        {
            //�Q�[���J�n���Ƀ|�[�Y���j���[���\������Ă���A�Q�[������UI���o�Ă��Ȃ��Ƃ������Ƃ��Ȃ��悤�ɂ���
            if(!_inGameUI.activeSelf) _inGameUI.SetActive(true);
            if(_pauseMenu.activeSelf) _pauseMenu.SetActive(false);
        }

        public void OnSwitchPause(bool isPausing)
        {
            _inGameUI.SetActive(!isPausing);
            _pauseMenu.SetActive(isPausing);

            //�|�[�Y�ɂȂ�����Resume�{�^����I����Ԃɂ���
            if(isPausing) _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);
        }
    }
}
