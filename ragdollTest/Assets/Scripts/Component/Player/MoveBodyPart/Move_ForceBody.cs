using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g�̂ɗ͂������Ĉړ�������R���|�\�l���g

public class Move_ForceBody : MonoBehaviour
{
    [CustomLabel("�������L�����̐g�̂̃p�[�c")] [SerializeField]
    Rigidbody _body;

    [CustomLabel("�������")] [SerializeField]
    float _power;

    [Tooltip("���̃I�u�W�F�N�g�̑O�����ɗ͂���������")] [CustomLabel("��̕���")] [SerializeField]//���̃I�u�W�F�N�g�̒n�ʂɕ��s��+Z������O�Ƃ���
    Transform _baseDirection;

    [CustomLabel("���x�����@�\")] [SerializeField]
    JudgeIsValidSpeed _judgeIsValidSpeed;

    [Tooltip("������͂𑫏�̊p�x�ɉ��킹��ݒ�")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;

    //�ړ����ɌĂ΂��(Vector2�͓��̓x�N�g��������)
    public event Action OnMove;
    public event Action<Vector2> OnMove_Vec;

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }


    //private

    private void Move(Vector2 input)
    {
        OnMove?.Invoke();
        OnMove_Vec?.Invoke(input);

        if (!_judgeIsValidSpeed.IsValidSpeed()) return;//���x�����ȏ㒴���Ă��炱��ȏ���������Ȃ�

        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        //���̓x�N�g�����x�[�X�̕���(y�����͖����Az�����̂�)�Ɍ�����
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        Vector3 force = forceDirection * _power;

        force = _followVectorToScaffold.Follow(force);//�͂�����������𑫏�̊p�x�ɉ��킹��

        _body.AddForce(force,ForceMode.VelocityChange);
    }

    private void Awake()
    {
        _judgeIsValidSpeed.Init(_body);
    }
}
