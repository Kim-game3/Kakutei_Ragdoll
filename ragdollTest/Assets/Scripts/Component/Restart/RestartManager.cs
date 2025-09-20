using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RestartManager : MonoBehaviour
{
    [SerializeField] PlayerInput _playerInput;
    [SerializeField] CinemachineVirtualCamera _gameCamera;

    const string _tagName_Player = "Player";

    //�v���C���[�����삷��J�����̒Ǐ]�Ώ�
    Transform _gameCameraFollow;
    Transform _gameCameraLookAt;

    bool _isRestarting = false;//���X�^�[�g����

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _gameCameraFollow = _gameCamera.Follow;
        _gameCameraLookAt = _gameCamera.LookAt;
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
        //ChangeGameCameraTarget(null, null);//�J�����̒ǐՂ���߂�

        //���]�܂ő҂�

        //���]���I���������

        _isRestarting = false;


        yield return null;
    }

    void ChangeGameCameraTarget(Transform newFollow,Transform newLookAt)
    {
        _gameCamera.Follow=newFollow;
        _gameCameraLookAt=newLookAt;
    }
}
