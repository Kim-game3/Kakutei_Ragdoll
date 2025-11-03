using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 作成者: 荒井
// Playerタグが触れている間だけ、_target を始点と終点の間で往復移動させる
// 行き・帰りの時間を個別設定可能

[RequireComponent(typeof(Collider))]
public class MoveTwoPointsAnother_Object : MonoBehaviour
{
    [CustomLabel("行きの周期(秒)")]
    [SerializeField]
    float _cycleForward = 1f;

    [CustomLabel("帰りの周期(秒)")]
    [SerializeField]
    float _cycleBackward = 1f;

    [CustomLabel("始点")]
    [SerializeField]
    Transform _start;

    [CustomLabel("終点")]
    [SerializeField]
    Transform _end;

    [CustomLabel("動かす対象")]
    [SerializeField]
    Transform _target;

    [SerializeField]
    RestartProcess _restartProcess;

    bool _isPlayerInRange=false;

    const float _maxTime = 1f;
    const float _minTime = 0f;
    float _time = _minTime;

    private void Awake()
    {
        _restartProcess.OnFadeOut += ResetPos;//フェードアウト中に位置を元に戻す
    }

    void Update()
    {
        Move();
    }

    void ResetPos()
    {
        if (_target == null || _start == null) return;

        _time = 0f;
        _target.position = _start.position;
    }

    private void Move()
    {
        if (_target == null || _start == null || _end == null) return;

        float t;

        if(_isPlayerInRange)
        {
            if (_time >= _maxTime) return;

            //_endに向かう
            t = Time.deltaTime / _cycleForward;
        }
        else
        {
            if (_time <= _minTime) return;

            //_startに向かう
            t = -Time.deltaTime / _cycleBackward;
        }

        SetTime(t);
        _target.position = Vector3.Lerp(_start.position, _end.position, _time);
    }

    void SetTime(float delta)
    {
        _time += delta;

        Mathf.Clamp01(_time);
    }

    // Playerが触れている間のみ動作
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _isPlayerInRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        _isPlayerInRange = false;
    }
}
