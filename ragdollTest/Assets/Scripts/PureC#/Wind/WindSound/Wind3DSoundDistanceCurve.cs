using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//•—‚Ì‘å‚«‚³(size)‚É‘Î‚µ‚Ä‚Ì‰¹‚Ì•·‚±‚¦‚é‹——£‚Ìİ’è

[CreateAssetMenu(fileName = "Wind3DSoundDistanceCurve", menuName = "ScriptableObjects/Wind3DSoundDistanceCurve")]
public class Wind3DSoundDistanceCurve : ScriptableObject
{
    [Tooltip("X(‰¡)²•—‚Ì‘å‚«‚³\nY(c)²‚»‚ê‚É‘Î‚·‚éAudioSource‚Ì3DSoundSettings‚ÌminDistance‚Ì’l")] [SerializeField]
    AnimationCurve _minDistanceCurve;

    [Tooltip("X(‰¡)²•—‚Ì‘å‚«‚³\nY(c)²‚»‚ê‚É‘Î‚·‚éAudioSource‚Ì3DSoundSettings‚ÌmaxDistance‚Ì’l")] [SerializeField]
    AnimationCurve _maxDistanceCurve;

    public float GetValueMinDistance(float size)
    {
        return _minDistanceCurve.Evaluate(size);
    }

    public float GetValueMaxDistance(float size)
    {
        return _maxDistanceCurve.Evaluate(size);
    }
}
