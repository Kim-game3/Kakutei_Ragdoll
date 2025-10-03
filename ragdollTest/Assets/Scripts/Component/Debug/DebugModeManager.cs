using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�f�o�b�O���[�h

public class DebugModeManager : MonoBehaviour
{
    [Header("���[�v�|�C���g\n�S�܂Ń��[�v�|�C���g��ݒ�ł��܂�")]
    [SerializeField] Transform _upWarpPoint;
    [SerializeField] Transform _leftWarpPoint;
    [SerializeField] Transform _downWarpPoint;
    [SerializeField] Transform _rightWarpPoint;

    [Space]
    [CustomLabel("�v���C���[�̈ʒu���")] [Tooltip("�v���C���[�̈�ԏ�̊K�w��Transform�����Ă�������")] [SerializeField]
    Transform _playerTrs;

    [CustomLabel("�v���C���[��Rigidbody")] [SerializeField]//�v���C���[���X�^�[�g�n�_�ɓ�����΂��ۂɎg��
    Rigidbody _body;

    [SerializeField]
    CanvasGroup _debugWindow;

    bool _isDebugMode = false;

    const float _showAlpha = 1;
    const float _hideAlpha = 0;

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
            Debug.Log("���̃��[�v�|�C���g�͐ݒ肳��Ă��܂���I");
            yield break;
        }

        _body.isKinematic = true;
        _playerTrs.position = warpPoint.position;
        yield return null;
        _body.isKinematic = false;
    }

    private void Start()
    {
        _debugWindow.alpha = _hideAlpha;
    }
}
