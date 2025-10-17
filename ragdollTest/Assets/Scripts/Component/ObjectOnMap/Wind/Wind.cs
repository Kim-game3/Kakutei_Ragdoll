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

    [Tooltip("���������鋗�����E\n(WindHitZone�̃g���K�[���)���Ȃ�L�߂ɂƂ邱�Ƃ��������߂���")] [SerializeField]
    float _visibleDistanceLimit;

    [Tooltip("�����o������")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("�����̈ʒu")] [SerializeField]
    Transform _myTrs;

    [SerializeField]
    WindHitZone _windZone;

    [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo;
    float _sqrtDistanceFromCamera;

    public bool IsInRangeVisibleWind { get { return (_sqrtDistanceFromCamera <= _visibleDistanceLimit * _visibleDistanceLimit); } }

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
        if (!IsInRangeVisibleWind) return;

        Debug.Log("��������");
    }

    private void OnStopWind()//�����~�񂾎�
    {
        if (!IsInRangeVisibleWind) return;

        Debug.Log("�����~��");
    }

    

    private void Update()
    {
        _sqrtDistanceFromCamera = (Camera.main.transform.position-_myTrs.position).sqrMagnitude;

        //�v���C���[���߂��ɗ������������S�̂̏���������
        if (!IsInRangeVisibleWind) return;

        _windCycle.Update();

        if (!_windCycle.IsActive) return;//���������ĂȂ���΂����őł��؂�

        _windZone.IsHit(out Vector3 hitPos, out bool isHitPlayer);

        if(isHitPlayer)//�v���C���[�ɓ������Ă�����A�v���C���[�𕗂Ő�����΂�
        {
            AffectWindToPlayer();
        }
    }

    void AffectWindToPlayer()
    {
        _playerWindAffect.AddWind(_myWindInfo);
    }

}
