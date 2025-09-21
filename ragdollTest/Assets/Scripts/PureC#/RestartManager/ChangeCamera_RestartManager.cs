using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g�ɕK�v�ȃQ�[���J�����֌W�̏���

public partial class RestartManager
{
    [System.Serializable]
    class ChangeCamera
    {
        [CustomLabel("�Q�[�����ɑ��삷��J����")] [SerializeField]
        CinemachineVirtualCamera _playCamera;

        [CustomLabel("���X�^�[�g�n�_�̃J����")] [SerializeField]
        CinemachineVirtualCamera _restartPointCamera;

        //�v���C���[�����삷��J�����̒Ǐ]�Ώ�
        Transform _playCameraFollow;
        Transform _playCameraLookAt;

        public void Init()//������
        {
            _playCameraFollow=_playCamera.Follow;
            _playCameraLookAt=_playCamera.LookAt;
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//�v���C���[�����삷��J�����̒Ǐ]�ݒ�̕ύX�AfollowPlayer�̓v���C���[��Ǐ]���邩
        {
            Transform newFollow=followPlayer? _playCameraFollow: null;
            Transform newLookAt=followPlayer? _playCameraLookAt: null;

            _playCamera.Follow=newFollow;
            _playCameraLookAt=newLookAt;
        }

        public void SwitchRestartPointCamera(bool activeRestart)//���X�^�[�g�J�����ƃv���C�J�����̐؂�ւ��AactiveRestart�̓��X�^�[�g�J�����ɐ؂�ւ��邩
        {
            _restartPointCamera.enabled=activeRestart;
            _playCamera.enabled=!activeRestart;
        }
    }
}
