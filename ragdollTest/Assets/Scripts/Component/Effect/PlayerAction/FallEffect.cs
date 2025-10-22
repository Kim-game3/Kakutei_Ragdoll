using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//落下時の演出(効果音を入れる)

public class FallEffect : MonoBehaviour
{
    [Header("通常の落下")]
    [SerializeField]
    AudioClip _normalFallClip;

    [SerializeField]
    AudioSource _normalAudioSource;

    [Header("高所からの落下")]
    [SerializeField]
    AudioClip _highFallClip;

    [SerializeField]
    AudioSource _highAudioSource;

    [SerializeField]
    MeasureFall _measureFall;

    [Tooltip("この速度以上で落ちると落下判定")] [SerializeField]
    float _judgeFallSpeed;

    [Tooltip("この速度以上で落ちると高所からの落下判定")] [SerializeField]
    float _judgeHighFallSpeed;

    private void Awake()
    {
        _measureFall.OnLanding += OnFall;

        if(_judgeFallSpeed>=_judgeHighFallSpeed)
        {
            Debug.Log("JudgeFallSpeedをJudgeHighFallSpeed未満にしてください！");
        }
    }

    void OnFall(float fallSpeed)
    {
        //一定速度以下であれば無視
        if (-fallSpeed <= _judgeFallSpeed) return;

        if(fallSpeed <= -_judgeHighFallSpeed)
        {
            _highAudioSource.PlayOneShot(_highFallClip);
        }
        else
        {
            _normalAudioSource.PlayOneShot(_normalFallClip);
        }
    }
}
