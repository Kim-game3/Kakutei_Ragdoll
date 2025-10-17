using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����o���@�\
//���׌y���̂��߁A�v���C���[��������x�߂Â��Ă������ɕ��������悤�ɂ���
//���S��������̕����Ɍ������Ďl�p�`�^�̕�������

public class Wind : MonoBehaviour
{
    [SerializeField]
    float _windPower;

    [Tooltip("���̉e�����󂯂郌�C���[")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("�v���C���[�̃��C���[")] [SerializeField]
    LayerMask _playerLayer;

    [Tooltip("�����o������")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("�v���C���[���߂Â��Ă����̂����m����@�\\n�\���ɑ傫�����邱�Ƃ������߂���")] [SerializeField]
    OnTriggerDetect _playerDetect;

    const float _boxcastSizeZ = 0.01f;
    bool _isNearPlayer = false;
    WindAffectBody _playerWindAffect;
    WindInfo _myWindInfo;

    private void Awake()
    {
        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;

        _myWindInfo = new WindInfo(transform.forward,_windPower);
    }

    private void OnValidate()
    {
        if (_myWindInfo == null) return;

        _myWindInfo.Direction = transform.forward;
        _myWindInfo.Power = _windPower;
    }

    private void OnBlowWind()//���������n�߂���
    {
        if (!_isNearPlayer) return;

        Debug.Log("��������");
    }

    private void OnStopWind()//�����~�񂾎�
    {
        if (!_isNearPlayer) return;

        Debug.Log("�����~��");
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = true;

        if (_windCycle.IsActive) OnBlowWind();
        else OnStopWind();
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = false;
    }

    private void Update()
    {
        //�v���C���[���߂��ɗ��������������o���悤�ɂ���
        if (!_isNearPlayer) return;

        _windCycle.Update();

        if (!_windCycle.IsActive) return;

        //���������Ă��鎞�̏���
        WindCast();
    }

    void WindCast()
    {
        Vector3 boxcastSize = transform.localScale / 2;
        boxcastSize.z = _boxcastSizeZ;

        //��������̃��C���΂�
        if (!Physics.BoxCast(transform.position, boxcastSize, transform.forward, out RaycastHit hit, transform.rotation, transform.localScale.z, _affectableWindLayer)) return;

        //���������̂��v���C���[�ł���΃v���C���[�����̕��̉e�����󂯂�悤�ɂ���
        if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) return;

        if (_playerWindAffect == null) _playerWindAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect).GetComponent<WindAffectBody>();

        _playerWindAffect.AddWind(_myWindInfo);
    }

}
