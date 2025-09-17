using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����Ƃ��Ƀ��O�h�[������]������(��������������)�@�\

public class AddTorqueOnMove : MonoBehaviour
{
    [Header("����:�͈͓��̃����_���ȗ͂̑傫���œ������Ă܂�")]

    [CustomLabel("������ŏ��̗͂̑傫��")] [SerializeField]
    float _minForce;

    [CustomLabel("������͂̑傫���̍�")] [SerializeField]
    float _gapForce;

    [Tooltip("�ړ��@�\")] [SerializeField]
    Move_ForceBody _move_ForceBody;

    Rigidbody _body;//���������ʂ�Rigidbody

    const float _rightAngle = 90;//���p�̊p�x
    //private

    private void Awake()
    {
        _body=_move_ForceBody.Body;
        _move_ForceBody.OnMove_Vec += AddTorqueToBody;
    }

    void AddTorqueToBody(Vector3 forceDirection)
    {
        //���̕��������߂�
        Quaternion axisRot= Quaternion.AngleAxis(_rightAngle,Vector3.up);
        Vector3 axis = axisRot * forceDirection;

        //������͂̑傫�������߂�
        float maxForce = _minForce + _gapForce;
        float force = Random.Range(_minForce, maxForce);

        _body.AddTorque(axis*force,ForceMode.VelocityChange);
    }

}
