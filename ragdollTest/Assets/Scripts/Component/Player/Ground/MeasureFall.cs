using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//地面に衝突した際の落下速度を測る

public class MeasureFall : MonoBehaviour
{
    [Tooltip("設置判定")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [SerializeField]
    TransformReference _playerPos;

    [Tooltip("何秒前の高さと比較するか")] [SerializeField]
    float _sampleInterval;

    float _currentElapsedTime = 0;

    Vector3 _currentSamplePos;
    Vector3 _previousSamplePos;

    public event Action<float> OnLanding;//接地した瞬間に1s秒間の変位を教える(落ちて地面に衝突したのであれば負の値が返される)

    private void Awake()
    {
        _previousSamplePos = _playerPos.Transform.position;
        _currentSamplePos = _previousSamplePos;

        _judgeIsGround.OnEnter += HandleGroundEnter;
    }

    private void HandleGroundEnter()
    {
        if(_sampleInterval<=0f)
        {
            Debug.Log("SampleIntervalは0より大きくしてください！");
            return;
        }

        //位置の差（前の位置 - 現在位置）
        float posDifference = _currentSamplePos.y - _previousSamplePos.y;

        float ret = posDifference / _sampleInterval;
        OnLanding?.Invoke(ret);
        //Debug.Log(ret);
    }

    private void Update()
    {
        UpdatePosInfo();
    }

    void UpdatePosInfo()
    {
        _currentElapsedTime += Time.deltaTime;

        if (_currentElapsedTime <= _sampleInterval) return;//指定時間分経過したら現在の高さとその前の高さの記録を更新

        _currentElapsedTime = 0f;
        _previousSamplePos = _currentSamplePos;
        _currentSamplePos = _playerPos.Transform.position;
    }
}
