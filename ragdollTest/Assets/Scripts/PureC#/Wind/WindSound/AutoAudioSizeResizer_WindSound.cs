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

    const float _minRate = 1f;
    const float _maxRate = 2.5f;

    public void OnValidate(Transform windZoneTrs,AudioSource windAudio)
    {
        if (!_autoSize) return;
        if (windZoneTrs == null || windAudio == null) return;

        float size = Mathf.Max(windZoneTrs.localScale.x, windZoneTrs.localScale.y);

        windAudio.minDistance = size * _minRate;
        windAudio.maxDistance = size * _maxRate;
    }
}
