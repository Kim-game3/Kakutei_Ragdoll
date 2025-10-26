using UnityEngine;
using System;

//�쐬��:���R
//�J�����ɋ߂����𔻒肷��

[System.Serializable]
public class JudgeIsNearFromMainCamera
{
    [Tooltip("�߂��Ɣ��f���鋗��")] [SerializeField]
    float _distanceLimit;

    [Tooltip("�����̈ʒu���")] [SerializeField]
    Transform _myTrs;

    public event Action OnClose;//�J�����Ƃ̋������߂��Ȃ���
    public event Action OnFar;//�J�����Ƃ̋����������Ȃ���

    float _sqrtDistanceFromCamera;
    bool _isClose;

    Transform _cameraTrs;

    public bool IsClose { get { return _isClose; } }

    public void Awake()
    {
        _cameraTrs = Camera.main.transform;
    }

    public void Update()
    {
        bool isCloseBefore=_isClose;

        _sqrtDistanceFromCamera = (_cameraTrs.position - _myTrs.position).sqrMagnitude;

        _isClose = _sqrtDistanceFromCamera <= _distanceLimit * _distanceLimit;

        if (_isClose == isCloseBefore) return;

        if(_isClose) OnClose?.Invoke();
        else OnFar?.Invoke();
    }
}
