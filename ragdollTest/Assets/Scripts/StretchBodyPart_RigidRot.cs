using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�g�̂̃p�[�c�ɂ���RigidBody���g���Ĉ��̊p�x�܂ŐL�΂�
public class StretchBodyPart_RigidRot : MonoBehaviour
{
    [Header("���̈ʒu")]
    [SerializeField] Transform _headTransform;
    [Header("�������������ʂ�RigidBody")]
    [SerializeField] Rigidbody _bodyPartRb_Stretch;

    [Header("�L�΂��Ƃ��̐��l")]
    [Tooltip("�L�΂��Ƃ��̑��x")]
    [SerializeField] float _rotationCorrectionSpeed = 8f;// ��]�␳���x
    [Tooltip("�L�΂��Ƃ��̉�]�̕␳")]
    [SerializeField] float _rotationThreshold = 1f;// �O�ɐL�΂���Ԃ̉�]�������l

    bool _stretching = false;//�L�΂��Ă��邩�̃t���O

    public bool Stretching//true�ɂȂ��Ă�Ԃ͐L�΂��悤�ɂ���
    {
        get { return _stretching; }
        set { _stretching = value; }
    }

    private void FixedUpdate()
    {
        CheckStretchFlag();
    }

    void CheckStretchFlag()//�L�΂����̃t���O���m�F���āA�t���O��true�ɂȂ��Ă���L�΂�
    {
        if (!_stretching) return;
        
        ApplyForwardRotation();
    }

    void ApplyForwardRotation()// �O(���̌��������)�ɂ܂������L�΂����߂̉�]��K�p
    {
        if(_headTransform == null)//���̈ʒu���ݒ肳��Ă��Ȃ�
        {
            Debug.Log("���̈ʒu���ݒ肳��Ă��܂���");
            return;
        }
        
        Quaternion targetRotation = TargetRotation();//�ڕW�l(�p�x)

        float rotationDistance = Quaternion.Angle(_bodyPartRb_Stretch.rotation, targetRotation);//�ڕW�l(�p�x)�Ƃ̍����Z�o

        if (!ShouldMoveRot(rotationDistance, _rotationThreshold)) return;//�������l�ƖڕW�l�Ƃ̍����r���āA�������K�v���Ȃ������炱���ŏ������I����
        
        MoveBodyPartRot(targetRotation);//�g�̂̃p�[�c�𓮂���
    }

    Quaternion TargetRotation()//�g�̂̃p�[�c�𓮂����Ƃ��̖ڕW�p�x
    {
        Vector3 forward = _headTransform.forward;// ���̑O���i�ڂ̑O�j�����
        return Quaternion.LookRotation(forward, Vector3.up);
    }

    bool ShouldMoveRot(float distance,float threshold)//�ڕW�l�Ƃ̍��Ƃ������l���r���āA���̍����������l���傫����Γ�����(true��Ԃ�)
    {
        return distance > threshold;
    }

    void MoveBodyPartRot(Quaternion targetRot)//�g�̂̃p�[�c�̊p�x�𓮂���(targetRot�͖ڕW�p�x)
    {
        Quaternion newRotation = Quaternion.Slerp(_bodyPartRb_Stretch.rotation, targetRot, Time.fixedDeltaTime * _rotationCorrectionSpeed);
        _bodyPartRb_Stretch.MoveRotation(newRotation);
    }
}
