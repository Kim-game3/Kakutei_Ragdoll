using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����o���@�\
//���׌y���̂��߁A�v���C���[��������x�߂Â��Ă������ɕ��������悤�ɂ���

public class Wind : MonoBehaviour
{
    [Tooltip("�����o������")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("�v���C���[���߂Â��Ă����̂����m����@�\\n�\���ɑ傫�����邱�Ƃ������߂���")] [SerializeField]
    OnTriggerDetect _playerDetect;

    bool _isNearPlayer = false;

    private void Awake()
    {
        _windCycle.OnTrue += Tr;
        _windCycle.OnFalse += Fr;

        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Tr()
    {
        if (!_isNearPlayer) return;

        Debug.Log("��������");
    }

    private void Fr()
    {
        if (!_isNearPlayer) return;

        Debug.Log("�����~��");
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = true;

        if (_windCycle.IsActive) Tr();
        else Fr();
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = false;
    }

    private void Update()
    {
        if (!_isNearPlayer) return;

        _windCycle.Update();
    }


}
