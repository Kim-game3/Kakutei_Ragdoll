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

    float _current = 0f;
    bool _isForward = true;
    bool _isActive = false; // Playerが触れているかどうか

    void Update()
    {
        if (_isActive)
        {
            Move();
        }
        else
        {
            // 非起動時はリセット
            _current = 0f;
            _isForward = true;
            if (_target != null && _start != null)
                _target.position = _start.position;
        }
    }

    private void Move()
    {
        if (_target == null || _start == null || _end == null) return;

        if (_isForward)
        {
            _current += Time.deltaTime;
            float t = Mathf.Clamp01(_current / _cycleForward);
            _target.position = Vector3.Lerp(_start.position, _end.position, t);

            if (_current >= _cycleForward)
            {
                _current = 0f;
                _isForward = false; // 折り返し
            }
        }
        else
        {
            _current += Time.deltaTime;
            float t = Mathf.Clamp01(_current / _cycleBackward);
            _target.position = Vector3.Lerp(_end.position, _start.position, t);

            if (_current >= _cycleBackward)
            {
                _current = 0f;
                _isForward = true; // 再び行きへ
            }
        }
    }

    // Playerが触れている間のみ動作
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isActive = false;
        }
    }
}
