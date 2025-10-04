using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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

    [Tooltip("������͂𑫏�̊p�x�ɉ��킹��ݒ�")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;

    //�ړ����ɌĂ΂��(Vector3�͉�������������)
    public event Action OnMove;
    public event Action<Vector3> OnMove_Vec;//�����ɉ���������3D�x�N�g��������

    public Rigidbody Body { get { return _body; } }//�������g�̂̃p�[�c

    public void Input_Move(InputAction.CallbackContext context)//�ړ�����
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

#if UNITY_EDITOR
        Debug.Log(getVec);
#endif

        Move(getVec);
    }


    //private

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y).normalized;

        //���̓x�N�g�����x�[�X�̕���(y�����͖����Az�����̂�)�Ɍ�����
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        forceDirection = _followVectorToScaffold.Follow(forceDirection);//�͂�����������𑫏�̊p�x�ɉ��킹��

        Vector3 force = forceDirection * _power;

        _body.AddForce(force,ForceMode.VelocityChange);

        OnMove?.Invoke();
        OnMove_Vec?.Invoke(forceDirection);
    }
}
