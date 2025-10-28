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

    [Tooltip("�J�����Ƃ̋����𑪂�@�\\n�����͕��̕`�拗���ɂȂ�̂ŁAwindHitZone�̃g���K�[�����L�߂Ɏ���Ă����Ƃ悢")] [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("�����o������")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("�G�t�F�N�g�֌W")] [SerializeField]
    WindEffect _windEffect;

    [Tooltip("���̓����蔻��")] [SerializeField]
    WindHitZone _windZone;

    [Tooltip("�v���C���[�ɕ��̉e����^����@�\")] [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo=new WindInfo();

    private void Awake()
    {
        GetWindAffectBody();

        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _judgeIsNearFromMainCamera.Awake();

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;

        _windEffect.Awake();
    }

    private void Start()
    {
        _judgeIsNearFromMainCamera.Update();

        if (_judgeIsNearFromMainCamera.IsClose) OnClose();
        else OnFar();
    }

    private void OnValidate()
    {
        GetWindAffectBody();
    }

    void GetWindAffectBody()//�v���C���[��WindAffectBody���擾
    {
        if (_playerWindAffect != null) return;

        GameObject windAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect);

        if (windAffect == null) return;

        WindAffectBody get = windAffect.GetComponent<WindAffectBody>();

        if (get == null) return;

        _playerWindAffect = get;
    }

    void SetWindInfo()
    {
        if (_myWindInfo == null)
        {
            Debug.Log("���̏�񂪃C���X�^���X������Ă��܂���I");
            return;
        }

        _myWindInfo.Direction = _windZone.transform.forward;
        _myWindInfo.Power = _windPower;
    }

    void OnClose()//�߂��Ȃ�����
    {
        _windEffect.Switchvisible(true);

        if (_windCycle.IsActive) _windEffect.Play();
        else _windEffect.Stop();
    }

    void OnFar()//�����Ȃ�����
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

        _windCycle.Update();

        if (!_windCycle.IsActive) return;//���������ĂȂ���΂����őł��؂�

        _windZone.IsHit(out bool isHitPlayer);

        if (isHitPlayer)//�v���C���[�ɓ������Ă�����A�v���C���[�𕗂Ő�����΂�
        {
            SetWindInfo();
            _playerWindAffect.AddWind(_myWindInfo);
        }
    }
}
