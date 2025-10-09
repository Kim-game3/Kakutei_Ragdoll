using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//デバッグモード

public class DebugModeManager : MonoBehaviour
{
    [Header("ワープポイント\n４つまでワープポイントを設定できます")]
    [SerializeField] Transform _upWarpPoint;
    [SerializeField] Transform _leftWarpPoint;
    [SerializeField] Transform _downWarpPoint;
    [SerializeField] Transform _rightWarpPoint;

    [Space]
    [CustomLabel("プレイヤーの位置情報")] [Tooltip("プレイヤーの一番上の階層のTransformを入れてください")] [SerializeField]
    TransformReference _playerTrs;

    [CustomLabel("プレイヤーのRigidbody")] [SerializeField]//プレイヤーをスタート地点に投げ飛ばす際に使う
    RigidbodyReference _body;

    [SerializeField]
    CanvasGroup _debugWindow;

    bool _isDebugMode = false;

    const float _showAlpha = 1;
    const float _hideAlpha = 0;

    const int _waitFrame = 10;

    public void DebugModeOn(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        _debugWindow.alpha = _showAlpha;

        _isDebugMode = true;
    }

    public void Up(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!_isDebugMode) return;

        StartCoroutine(Warp(_upWarpPoint));
    }

    public void Left(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!_isDebugMode) return;

        StartCoroutine(Warp(_leftWarpPoint));
    }

    public void Down(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!_isDebugMode) return;

        StartCoroutine(Warp(_downWarpPoint));
    }

    public void Right(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        if (!_isDebugMode) return;

        StartCoroutine(Warp(_rightWarpPoint));
    }

    IEnumerator Warp(Transform warpPoint)
    {
        if (warpPoint == null)
        {
            Debug.Log("そのワープポイントは設定されていません！");
            yield break;
        }

        _body.Rigidbody.isKinematic = true;
        _playerTrs.Transform.position = warpPoint.position;

        for(int i=0; i< _waitFrame; i++)
        {
            yield return null;
        }
        
        _body.Rigidbody.isKinematic = false;
    }

    private void Start()
    {
        _debugWindow.alpha = _hideAlpha;
    }
}
