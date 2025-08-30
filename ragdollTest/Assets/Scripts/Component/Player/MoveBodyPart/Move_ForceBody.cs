using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�g�̂ɗ͂������Ĉړ�������R���|�\�l���g

public class Move_ForceBody : MonoBehaviour
{
    [Tooltip("�������L�����̐g�̂̃p�[�c")] [SerializeField] Rigidbody _body;
    [Tooltip("�������")] [SerializeField] float _power;
    [Tooltip("��̕��ɂ��������")] [SerializeField] float _up;
    [Tooltip("���̃I�u�W�F�N�g�̑O�����ɗ͂���������")] [SerializeField] Transform _baseDirection;//�����z�������O�Ƃ���
    bool _shouldJump=false;

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;//�{�^�����������u�Ԕ���

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }

    public void Input_Jump(InputAction.CallbackContext context)
    {
        if (context.performed) _shouldJump = true;
        if(context.canceled) _shouldJump = false;
    }

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        //���̓x�N�g�����x�[�X�̕���(y�����͖����Az�����̂�)�Ɍ�����
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;//���ɑ΂��Đ���

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;
        if(_shouldJump) forceDirection.y = _up;

        _body.AddForce(forceDirection*_power,ForceMode.VelocityChange);
    }
}
