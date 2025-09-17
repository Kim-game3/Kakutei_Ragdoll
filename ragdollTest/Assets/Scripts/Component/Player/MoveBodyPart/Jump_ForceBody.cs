using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//ジャンプ機能(試験機能)

public class Jump_ForceBody : MonoBehaviour
{
    [CustomLabel("上方向にかける力")] [SerializeField]
    float _power;

    [Tooltip("動かす部位のRigidbody")] [SerializeField]
    Rigidbody _body;

    [Tooltip("接地判定")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [Tooltip("プレイヤーの移動機能")] [SerializeField]
    Move_ForceBody _moveForceBody;

    bool _inputting = false;

    private void Awake()
    {
        _moveForceBody.OnMove += Jump;
    }

    public void Input_Jump(InputAction.CallbackContext context)
    {
        if (context.performed) _inputting = true;
        if (context.canceled) _inputting = false;
    }

    public void Jump()
    {
        bool shouldJump = _inputting && _judgeIsGround.IsGround;

        if (!shouldJump) return;

        Vector3 jumpForce = Vector3.up *_power;

        _body.AddForce(jumpForce, ForceMode.VelocityChange);
    }
}
