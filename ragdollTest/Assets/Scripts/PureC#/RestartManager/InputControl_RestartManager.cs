using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//���X�^�[�g���̃v���C���[�̓��͑���̐؂�ւ�����

public partial class RestartManager
{
    [System.Serializable]
    class InputControl
    {
        [SerializeField]
        PlayerInput _playerInput;

        public void SetControllable(bool isControllable)//����\��Ԃ̐؂�ւ�
        {
            string newActionMapName = isControllable ? ActionMapNameDictionary.Controllable : ActionMapNameDictionary.UnControllable; 

            _playerInput.SwitchCurrentActionMap(newActionMapName);
        }
    }
}
