using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の効果音を流すAudioSourceの位置をプレイヤーに聞こえるように動かす機能

[System.Serializable]
public class SetPosition_WindSound
{
    [SerializeField]
    float _threshold = 0.01f;

    Transform _listenerTrs;
    Transform _myTrs;
    Transform _windZoneTrs;

    public void Awake(Transform myTrs,Transform windZoneTrs)
    {
        _myTrs = myTrs;
        _windZoneTrs = windZoneTrs;

        GetAudioListenerTransform();
    }

    void GetAudioListenerTransform()
    {
        var audioListenerObject = GameObject.FindWithTag(ObjectTagNameDictionary.AudioListener);

        if (audioListenerObject == null) return;

        _listenerTrs = audioListenerObject.transform;
    }

    public void Update()
    {
        if (_listenerTrs == null || _myTrs == null || _windZoneTrs == null) return;

        Vector3 dir = _myTrs.forward.normalized;

        // 基準点 → 任意の点
        Vector3 v = _listenerTrs.position - _myTrs.position;

        // 射影の長さ
        float t = Vector3.Dot(v, dir);

        if (MathfExtension.IsInRange(t, -_threshold, _threshold)) return;

        // 直線上の最近点（垂線の足）
        Vector3 closestPointOnLine = _myTrs.position + dir * t;

        _myTrs.position = closestPointOnLine;

        //位置を範囲内に制限
        Vector3 localMyPos = _myTrs.localPosition;

        float min = _windZoneTrs.localPosition.z;
        float max = min + _windZoneTrs.localScale.z;
        localMyPos.z = Mathf.Clamp(localMyPos.z, min, max);

        _myTrs.localPosition = localMyPos;
    }
}
