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

    [SerializeField]
    WindHitZone _windZone;

    [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo;

    private void Awake()
    {
        if (_playerWindAffect == null) _playerWindAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect).GetComponent<WindAffectBody>();

        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _myWindInfo = new WindInfo(_windZone.transform.forward,_windPower);
    }

    private void OnValidate()
    {
        if (_myWindInfo == null) return;

        _myWindInfo.Direction = _windZone.transform.forward;
        _myWindInfo.Power = _windPower;
    }

    private void OnBlowWind()//���������n�߂���
    {
        Debug.Log("��������");
    }

    private void OnStopWind()//�����~�񂾎�
    {
        Debug.Log("�����~��");
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
