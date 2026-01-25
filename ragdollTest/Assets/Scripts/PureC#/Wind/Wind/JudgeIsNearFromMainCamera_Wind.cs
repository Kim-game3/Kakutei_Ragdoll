using System;
using UnityEngine;

//ì¬ŽÒ:™ŽR
//•—‚ÌƒJƒƒ‰‚É‹ß‚¢‚©‚ð”»’è‚·‚éˆ—

[System.Serializable]
public class JudgeIsNearFromMainCamera_Wind
{
    [Tooltip("‹ß‚¢‚Æ”»’f‚·‚é‹——£")]
    [SerializeField] float _distanceLimit;

    [Tooltip("Ž©•ª‚ÌˆÊ’uî•ñ(•—‚Ì“–‚½‚è”»’è‚ð“ü‚ê‚é)")]
    [SerializeField] Transform _myTrs;

    public event Action OnClose;
    public event Action OnFar;

    Transform _cameraTrs;
    bool _isClose;

    public bool IsClose => _isClose;

    public void Awake()
    {
        _cameraTrs = Camera.main.transform;
    }

    public void Update()
    {
        bool prevIsClose = _isClose;

        Vector3 myPos = GetMyCenterPosition();
        float sqrDistance = (_cameraTrs.position - myPos).sqrMagnitude;
        float sqrLimit = _distanceLimit * _distanceLimit;

        _isClose = sqrDistance <= sqrLimit;

        if (_isClose == prevIsClose) return;

        if (_isClose) OnClose?.Invoke();
        else OnFar?.Invoke();
    }

    Vector3 GetMyCenterPosition()
    {
        float halfDepth = _myTrs.lossyScale.z * 0.5f;
        return _myTrs.position + _myTrs.forward * halfDepth;
    }
}
