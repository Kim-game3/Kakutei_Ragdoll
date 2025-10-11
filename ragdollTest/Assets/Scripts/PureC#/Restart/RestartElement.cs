using Cinemachine;
using UnityEngine;

//�쐬��:���R
//�`�F�b�N�|�C���g���Ƃ̃��X�^�[�g�ɕK�v�ȗv�f

[System.Serializable]
public struct RestartElement
{
    //--- �J�����֌W ---//
    [CustomLabel("���X�^�[�g�n�_�̃J����")]
    public CinemachineVirtualCamera restartPointCamera;

    [Header("�v���C���[�����삷��J�����̃f�t�H���g�̌���")]
    public float defaultVerticalValue_PlayCamera;
    public float defaultHorizontalValue_PlayCamera;
    [Space]

    //--- ���X�^�[�g�֌W ---//
    [CustomLabel("���X�^�[�g�n�_&����")] [Tooltip("�v���C���[�����̒n�_�ɏo�������̕����Ɍ������ē�����΂����")]
    public Transform restartPoint;

    [CustomLabel("������͂̑傫��")]
    public float power;
}

