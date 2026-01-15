using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

//作成者:杉山
//前方向(青矢印)の軸に沿って、カメラに対して最短距離の位置に居続ける機能

public class SetPositionShortestDistanceFromCameraByForwardAxis : MonoBehaviour
{
    [SerializeField]
    Transform _myTrs;

    [SerializeField]
    float _threshold = 0.01f;

    Transform _cameraTrs;

    private void Awake()
    {
        _cameraTrs = Camera.main.transform;
    }

    void Update()
    {
        if (_cameraTrs == null || _myTrs == null) return;

        Vector3 dir = _myTrs.forward.normalized;

        // 基準点 → 任意の点
        Vector3 v = _cameraTrs.position - _myTrs.position;

        // 射影の長さ
        float t = Vector3.Dot(v, dir);

        if (MathfExtension.IsInRange(t, -_threshold, _threshold)) return;

        // 直線上の最近点（垂線の足）
        Vector3 closestPointOnLine = _myTrs.position + dir * t;

        _myTrs.position = closestPointOnLine;
    }
}
