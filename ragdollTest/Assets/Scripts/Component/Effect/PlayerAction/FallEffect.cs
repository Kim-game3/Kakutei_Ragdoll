using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�������̉��o(���ʉ�������)

public class FallEffect : MonoBehaviour
{
    [Header("�ʏ�̗���")]
    [SerializeField]
    AudioClip _normalFallClip;

    [SerializeField]
    AudioSource _normalAudioSource;

    [Header("��������̗���")]
    [SerializeField]
    AudioClip _highFallClip;

    [SerializeField]
    AudioSource _highAudioSource;

    [SerializeField]
    MeasureFall _measureFall;

    [Tooltip("���̑��x�ȏ�ŗ�����Ɨ�������")] [SerializeField]
    float _judgeFallSpeed;

    [Tooltip("���̑��x�ȏ�ŗ�����ƍ�������̗�������")] [SerializeField]
    float _judgeHighFallSpeed;

    private void Awake()
    {
        _measureFall.OnLanding += OnFall;

        if(_judgeFallSpeed>=_judgeHighFallSpeed)
        {
            Debug.Log("JudgeFallSpeed��JudgeHighFallSpeed�����ɂ��Ă��������I");
        }
    }

    void OnFall(float fallSpeed)
    {
        //��葬�x�ȉ��ł���Ζ���
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
