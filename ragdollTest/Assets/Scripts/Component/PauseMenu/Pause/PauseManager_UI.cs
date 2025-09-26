using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�|�[�Y��UI�w(�v���C���[�̖ڂɌ����镔��)

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_UI
    {
        [CustomLabel("�Q�[������UI")] [SerializeField]
        GameObject _inGameUI;

        [CustomLabel("�|�[�Y���j���[")] [SerializeField]
        GameObject _pauseMenu;

        public void OnStrat()//�Q�[���J�n��
        {
            //�Q�[���J�n���Ƀ|�[�Y���j���[���\������Ă���A�Q�[������UI���o�Ă��Ȃ��Ƃ������Ƃ��Ȃ��悤�ɂ���
            if(!_inGameUI.activeSelf) _inGameUI.SetActive(true);
            if(_pauseMenu.activeSelf) _pauseMenu.SetActive(false);
        }

        public void OnSwitchPause(bool isPausing)
        {
            _inGameUI.SetActive(!isPausing);
            _pauseMenu.SetActive(isPausing);
        }
    }
}
