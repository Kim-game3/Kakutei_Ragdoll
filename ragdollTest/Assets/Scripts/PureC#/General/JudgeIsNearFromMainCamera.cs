using UnityEngine;
using System;

//作成者:杉山
//カメラに近いかを判定する

[System.Serializable]
public class JudgeIsNearFromMainCamera
{
    [Tooltip("近いと判断する距離")] [SerializeField]
    float _distanceLimit;

    [Tooltip("自分の位置情報")] [SerializeField]
    Transform _myTrs;

    public event Action OnClose;//カメラとの距離が近くなった
    public event Action OnFar;//カメラとの距離が遠くなった

    float _sqrtDistanceFromCamera;
    bool _isClose;

    public bool IsClose { get { return _isClose; } }

    public void Update()
    {
        bool isCloseBefore=_isClose;

        _sqrtDistanceFromCamera = (Camera.main.transform.position - _myTrs.position).sqrMagnitude;

        _isClose = _sqrtDistanceFromCamera <= _distanceLimit * _distanceLimit;

        if (_isClose == isCloseBefore) return;

        if(_isClose) OnClose?.Invoke();
        else OnFar?.Invoke();
    }
}
