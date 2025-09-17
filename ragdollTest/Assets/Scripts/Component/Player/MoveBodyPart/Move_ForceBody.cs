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

    [Tooltip("�W�����v�@�\")] [SerializeField]
    Jump_ForceBody _jump;

    [Tooltip("������͂𑫏�̊p�x�ɉ��킹��ݒ�")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;

    [Header("�����I�@�\")]

    [CustomLabel("������ɂ������")] [SerializeField]
    float _upPower;

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        //���̓x�N�g�����x�[�X�̕���(y�����͖����Az�����̂�)�Ɍ�����
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        Vector3 force = forceDirection * _power;

        //�����@�\(������ɂ��͂�������悤�ɂ���)
        force += Vector3.up * _upPower;
        //

        force = _followVectorToScaffold.Follow(force);//�͂�����������𑫏�̊p�x�ɉ��킹��

        if (_jump != null) force += _jump.JumpPower();//�폜�\��

        _body.AddForce(force,ForceMode.VelocityChange);
    }
}
