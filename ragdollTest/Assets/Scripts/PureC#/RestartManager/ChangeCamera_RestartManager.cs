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
        Transform _gameCameraFollow;
        Transform _gameCameraLookAt;

        //������

        //�Q�[���J�������v���C���[��Ǐ]���Ȃ��悤�ɂ���

        //�Q�[���J�������v���C���[��Ǐ]����悤�ɂ���

        //���X�^�[�g�n�_�̃J������
    }
}
