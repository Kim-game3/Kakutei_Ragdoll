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
    [Tooltip("�ڒn����")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    bool _inputting = false;

    public void Input_Jump(InputAction.CallbackContext context)
    {
        if (context.performed) _inputting = true;
        if (context.canceled) _inputting = false;
    }

    public Vector3 JumpPower()
    {
        bool shouldJump = _inputting && _judgeIsGround.IsGround;
        
        return shouldJump ? new Vector3(0,_power,0) : Vector3.zero;
    }
}
