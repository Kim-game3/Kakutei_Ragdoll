using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

//�쐬��:���R
//���X�^�[�g����

public partial class RestartManager : MonoBehaviour
{
    [Tooltip("���]���Ă��牽�b��ɃJ�������v���C���[���܂��ǐՂ���悤�ɂȂ邩")] [SerializeField]
    float _waitDuration_FromFinishFadeIn;

    [Tooltip("�J�������v���C���[��Ǐ]����悤�ɂȂ��Ă��牽�b��ɑ��삪�\�ɂȂ�悤�ɂ��邩")] [SerializeField]
    float _waitDuration_FromCameraFollowPlayer;

    [CustomLabel("���X�^�[�g���ɍĐ�����^�C�����C��")] [SerializeField]
    PlayableDirector _restartTimeLine;

    [SerializeField]//���X�^�[�g���̃v���C���[�������n�_�ɖ߂��֌W�̏������܂Ƃ߂�����
    PlayerPosControl _playerPosControl;

    [SerializeField]//���X�^�[�g���̃J�����֌W�̏������܂Ƃ߂�����
    CameraControl _cameraControl;

    [SerializeField]//���X�^�[�g���̓��͊֌W�̏������܂Ƃ߂�����
    InputControl _inputControl;

    bool _isRestarting = false;//���X�^�[�g����
    bool _finishedFadeOut = true;//�t�F�[�h�A�E�g���I�������
    bool _finishedFadeIn = true;//�t�F�[�h�C�����I�������

    public bool IsRestarting { get { return _isRestarting; } }

    public void SetFinish_FadeOut()
    {
        _finishedFadeOut = true;
    }

    public void SetFinish_FadeIn()
    {
        _finishedFadeIn=true;
    }

    //private
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
        _finishedFadeOut=false;
        _finishedFadeIn=false;
        _inputControl.SetControllable(false);//����s�\�ɂ���
        _cameraControl.ChangeFollow_PlayCamera(false);//�J�����̃v���C���[�̒ǐՂ���߂�
        _restartTimeLine.Play();//�^�C�����C�����Đ�


        yield return new WaitUntil(() => _finishedFadeOut);//���S�ɈÓ]����܂ő҂�
        _cameraControl.SwitchRestartPointCamera(true);//���X�^�[�g�n�_�̃J�����ɂ���


        yield return new WaitUntil(() => _finishedFadeIn);//���S�ɖ��]����܂ő҂�
        _playerPosControl.BackToRestartPoint();//�v���C���[�����X�|�[���n�_�Ɉړ�&�X�^�[�g�n�_�Ɍ������ăv���C���[�𓊂���


        yield return new WaitForSeconds(_waitDuration_FromFinishFadeIn);//���S�ɖ��]���Ă��琔�b�҂�
        _cameraControl.ChangeFollow_PlayCamera(true);//�J�����̃v���C���[�̒ǐՂ��ĊJ
        _cameraControl.SwitchRestartPointCamera(false);//�v���C�J�����ɖ߂�


        yield return new WaitForSeconds(_waitDuration_FromCameraFollowPlayer);//����ɐ��b�҂�
        _inputControl.SetControllable(true);//����\�ɂ���
        _isRestarting = false;
    }
}
