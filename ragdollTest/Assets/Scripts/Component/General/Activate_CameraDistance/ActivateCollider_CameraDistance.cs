using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//カメラとの距離に応じてColliderのenableを切り替える機能

public class ActivateCollider_CameraDistance : MonoBehaviour
{
    [Tooltip("カメラとの距離を測る機能")]
    [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("カメラとの距離に応じてアクティブ状態を切り替えるRenderer\nカメラに近づいたら自動的にenableがtrueになる")]
    [SerializeField]
    Collider[] _colliders;

    private void Awake()
    {
        _judgeIsNearFromMainCamera.Awake();

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;
    }

    void OnClose()//カメラと近くなった時
    {
        SetEnabled(true);
    }

    void OnFar()//カメラと遠くなった時
    {
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        for (int i = 0; i < _colliders.Length; i++)
        {
            if (_colliders[i] == null) continue;

            _colliders[i].enabled = enabled;
        }
    }

    void Start()
    {
        _judgeIsNearFromMainCamera.Update();

        bool enabled = _judgeIsNearFromMainCamera.IsClose;

        SetEnabled(enabled);
    }

    void Update()
    {
        _judgeIsNearFromMainCamera.Update();
    }
}
