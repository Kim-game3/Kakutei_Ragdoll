using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����Ƃ��Ƀ��O�h�[������]������(��������������)�@�\

public class AddTorqueOnMove : MonoBehaviour
{
    [CustomLabel("������͂̑傫��")] [SerializeField]
    float _force;

    [Tooltip("�ړ��@�\")] [SerializeField]
    Move_ForceBody _move_ForceBody;

    Rigidbody _body;//���������ʂ�Rigidbody

    //private

    private void Awake()
    {
        _body=_move_ForceBody.Body;
        _move_ForceBody.OnMove_Vec += AddTorqueToBody;
    }

    void AddTorqueToBody(Vector3 forceDirection)
    {
        Quaternion axisRot= Quaternion.AngleAxis(90,Vector3.up);
        Vector3 axis = axisRot * forceDirection;

        Debug.DrawLine(_body.transform.position, _body.transform.position + axis, Color.green,5f);

        _body.AddTorque(axis*_force,ForceMode.VelocityChange);
    }

}
