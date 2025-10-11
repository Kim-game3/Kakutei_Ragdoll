using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�|�[�Y�̓��������w

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_InternalProcess
    {
        [SerializeField]
        PlayerInput _playerInput;

        const float _defaultTimeScale = 1;//����
        const float _pauseTimeScale = 0;//�|�[�Y���̎��Ԃ̑��x

        public void Start()
        {

            //�Q�[���J�n���Ɏ��Ԃ��~�܂邱�Ƃ��Ȃ��悤�ɂ���
            Time.timeScale = _defaultTimeScale;
        }

        public void OnSwitchPause(bool isPausing)
        {
            Time.timeScale = isPausing ? _pauseTimeScale : _defaultTimeScale;

            //�����ύX
            string newActionMap = isPausing ? ActionMapNameDictionary.UnControllable : ActionMapNameDictionary.Controllable;
            _playerInput.SwitchCurrentActionMap(newActionMap);
        }
    }
}
