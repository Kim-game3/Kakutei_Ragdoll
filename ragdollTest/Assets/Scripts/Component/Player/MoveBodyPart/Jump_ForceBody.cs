using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�W�����v�@�\(�����@�\)

public class Jump_ForceBody : MonoBehaviour
{
    [CustomLabel("������ɂ������")] [SerializeField]
    float _power;

    Rigidbody _body;//���������ʂ�Rigidbody

    [Tooltip("�ڒn����")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [Tooltip("�v���C���[�̈ړ��@�\")] [SerializeField]
    Move_ForceBody _moveForceBody;

    bool _inputting = false;

    public void Input_Jump(InputAction.CallbackContext context)
    {
        if (context.performed) _inputting = true;
        if (context.canceled) _inputting = false;
    }

    //private

    private void Awake()
    {
        _moveForceBody.OnMove += Jump;
        _body=_moveForceBody.Body;
    }

    void Jump()
    {
        bool shouldJump = _inputting && _judgeIsGround.IsGround;

        if (!shouldJump) return;

        Vector3 jumpForce = Vector3.up *_power;

        _body.AddForce(jumpForce, ForceMode.VelocityChange);
    }
}
