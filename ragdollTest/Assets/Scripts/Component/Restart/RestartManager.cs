using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public partial class RestartManager : MonoBehaviour
{
    // --- ���X�^�[�g�̐ݒ�֌W --- //
    [CustomLabel("���X�^�[�g���ɍĐ�����^�C�����C��")] [SerializeField]
    PlayableDirector _restartTimeLine;

    [SerializeField]//���X�^�[�g���̃v���C���[�������n�_�ɖ߂��֌W�̏������܂Ƃ߂�����
    PlayerPosControl _playerPosControl;

    [SerializeField]//���X�^�[�g���̃J�����֌W�̏������܂Ƃ߂�����
    CameraControl _cameraControl;

    [SerializeField]//���X�^�[�g���̓��͊֌W�̏������܂Ƃ߂�����
    InputControl _inputControl;

    bool _isRestarting = false;//���X�^�[�g����

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _cameraControl.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //�������u��
        _isRestarting=true;
        _inputControl.SetControllable(false);//����s�\�ɂ���
        _cameraControl.ChangeFollow_PlayCamera(false);//�J�����̃v���C���[�̒ǐՂ���߂�
        _restartTimeLine.Play();//�^�C�����C�����Đ�

        //���̕ӂ�Ŋ��S�ɈÓ]
        _cameraControl.SwitchRestartPointCamera(true);//���X�^�[�g�n�_�̃J�����ɂ���

        //���̕ӂ�Ŋ��S�ɖ��]
        _playerPosControl.BackToRestartPoint();//�v���C���[�����X�|�[���n�_�Ɉړ�&�X�^�[�g�n�_�Ɍ������ăv���C���[�𓊂���

        //���]���I����Ă��琔�b��
        _cameraControl.ChangeFollow_PlayCamera(true);//�J�����̃v���C���[�̒ǐՂ��ĊJ
        _cameraControl.SwitchRestartPointCamera(false);//�v���C�J�����ɖ߂�

        //����ɐ��b��
        _inputControl.SetControllable(true);//����\�ɂ���
        _isRestarting = false;


        yield return null;
    }
}
