using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class RestartManager : MonoBehaviour
{
    // --- ���X�^�[�g�̐ݒ�֌W --- //
    [CustomLabel("���X�^�[�g�n�_&����")] [Tooltip("���]�I����A�v���C���[�����̒n�_�ɏo�������̕����Ɍ������ē�����΂����")] [SerializeField]
    Transform _restartPoint;



    [CustomLabel("���X�^�[�g���̃J�����̐؂�ւ��֌W")] [SerializeField]
    ChangeCamera _changeCamera;

    [SerializeField] 
    PlayerInput _playerInput;

    const string _tagName_Player = "Player";

    bool _isRestarting = false;//���X�^�[�g����

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _changeCamera.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_tagName_Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //���������u��
        //���X�|�[�������I���ɂ���
        //�J�����̒ǐՂ���߂�(Follow��LookAt��null�ɂ���)
        //������o���Ȃ�����
        //���V���`���U�p���Əo�Ă���
        //���Ó]
        //�����]
        //�v���C���[���C�̒��̃��X�|�[���n�_�ɖ߂�
        //����̕����ɗ͂�������
        //���X�|�[���n�_�p�̃J�������I���ɂ���
        //�J�����̒ǐ�(Follow��LookAt�Ƀv���C���[������)
        //���V���`����u����o���ĊC�ɖ߂�
        //��(��s��)
        //�J�����̒ǐՂ��I���ɂ���
        //��(���b��)
        //����\��
        //���X�|�[�������I�t��

        //�������u��
        _isRestarting=true;
        //_playerInput.SwitchCurrentActionMap();//����s�\�ɂ���
        _changeCamera.ChangeFollow_PlayCamera(false);//�J�����̃v���C���[�̒ǐՂ���߂�

        //���]�܂ő҂�

        //���]���I���������
        _changeCamera.SwitchRestartPointCamera(true);//���X�^�[�g�n�_�̃J�����ɂ���

        //���]���I����Ă��琔�b��
        _changeCamera.ChangeFollow_PlayCamera(true);//�J�����̃v���C���[�̒ǐՂ��ĊJ
        _changeCamera.SwitchRestartPointCamera(false);//�v���C�J�����ɖ߂�

        //����ɐ��b��
        //_playerInput.SwitchCurrentActionMap();//����s�\�ɂ���
        _isRestarting = false;


        yield return null;
    }
}
