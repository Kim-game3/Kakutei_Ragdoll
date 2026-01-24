using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//自動でAudioSourceの音の聞こえる範囲の大きさを調整してくれる機能

[System.Serializable]
public class AutoAudioDistanceResizer_WindSound
{
    [Tooltip("自動大きさ調整機能をオンにするか")] [SerializeField]
    bool _autoSize = true;

    [SerializeField]
    Wind3DSoundDistanceCurve _distanceCurve;

    public void OnValidate(Transform windZoneTrs,AudioSource windAudio)
    {
        if (!_autoSize) return;
        if (windZoneTrs == null || windAudio == null || _distanceCurve == null) return;

        float size = Mathf.Max(windZoneTrs.lossyScale.x, windZoneTrs.lossyScale.y);

        windAudio.minDistance = _distanceCurve.GetValueMinDistance(size);
        windAudio.maxDistance = _distanceCurve.GetValueMaxDistance(size);
    }
}
