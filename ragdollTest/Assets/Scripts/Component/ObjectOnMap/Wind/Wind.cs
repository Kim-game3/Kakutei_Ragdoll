using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����o���@�\
//WindZone�������I�u�W�F�N�g�̒��S��������̕����Ɍ������Ďl�p�`�^�̕�������

public class Wind : MonoBehaviour
{
    [Tooltip("���̋���")] [SerializeField]
    float _windPower;

    [Tooltip("�J�����Ƃ̋����𑪂�@�\\n�����͕�����������E�����ɂȂ�̂ŁAwindHitZone�̃g���K�[�����L�߂Ɏ���Ă����Ƃ悢")] [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("�����o������")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("�G�t�F�N�g�֌W")] [SerializeField]
    WindEffect _windEffect;

    [Tooltip("���̓����蔻��")] [SerializeField]
    WindHitZone _windZone;

    [Tooltip("�v���C���[�ɕ��̉e����^����@�\")] [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo;

    private void Awake()
    {
        if (_playerWindAffect == null) _playerWindAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect).GetComponent<WindAffectBody>();

        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;

        _myWindInfo = new WindInfo(_windZone.transform.forward,_windPower);
    }

    private void Start()
    {
        _judgeIsNearFromMainCamera.Update();

        Debug.Log(_judgeIsNearFromMainCamera.IsClose);

        if (_judgeIsNearFromMainCamera.IsClose) OnClose();
        else OnFar();
    }

    private void OnValidate()
    {
        if (_myWindInfo == null) return;

        _myWindInfo.Direction = _windZone.transform.forward;
        _myWindInfo.Power = _windPower;
    }

    void OnClose()
    {
        _windEffect.Switchvisible(true);

        if (_windCycle.IsActive) _windEffect.Play();
        else _windEffect.Stop();
    }

    void OnFar()
    {
        _windEffect.Switchvisible(false);
    }

    private void OnBlowWind()//���������n�߂���
    {
        _windEffect.Play();
    }

    private void OnStopWind()//�����~�񂾎�
    {
        _windEffect.Stop();
    }

    private void Update()
    {
        _judgeIsNearFromMainCamera.Update();

        //�v���C���[���߂��ɗ������������S�̂̏���������
        if (!_judgeIsNearFromMainCamera.IsClose) return;

        _windCycle.Update();

        if (!_windCycle.IsActive) return;//���������ĂȂ���΂����őł��؂�

        _windZone.IsHit(out Vector3 hitPos, out bool isHitPlayer);

        if(isHitPlayer)//�v���C���[�ɓ������Ă�����A�v���C���[�𕗂Ő�����΂�
        {
            _playerWindAffect.AddWind(_myWindInfo);
        }
    }
}
