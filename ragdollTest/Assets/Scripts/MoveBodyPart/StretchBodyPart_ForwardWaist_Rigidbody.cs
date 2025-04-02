using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�g�̂̃p�[�c�𓷂̑O�������ɐL�΂�
//�p�[�c�𓮂������ۂ���enable��؂�ւ��čs��
public class StretchBodyPart_ForwardWaist_Rigidbody : MonoBehaviour
{
    [Header("�������p�[�c")]
    [SerializeField] Rigidbody _movePart;
    [Header("�L�΂������̃p�[�c�̈ʒu")]
    [SerializeField] Transform _pos_Stretched_Transform;
    [Header("�L�΂�����")]
    [SerializeField] float _stretchSpeed;

    //�p�[�c�𓮂����ꍇ�́A�p�[�c���������Z�œ����Ȃ��悤�ɂ��āA�p�[�c��C�ӂ̈ʒu�܂œ�����
    //�������Ȃ��ꍇ�́A�p�[�c���������Z�œ����悤�ɂ���

    private void FixedUpdate()
    {
        MovePart();
    }

    private void OnEnable()
    {
        SwitchKinematic_RigidbodyMovePart(true);
    }

    private void OnDisable()
    {
        SwitchKinematic_RigidbodyMovePart(false);
    }

    //�������p�[�c��kinematic��؂�ւ���
    void SwitchKinematic_RigidbodyMovePart(bool active)
    {
        _movePart.isKinematic = active;
    }

    //�p�[�c��C�ӂ̈ʒu�܂œ�����
    void MovePart()
    {
        Vector3 moveDirection = (_pos_Stretched_Transform.position - _movePart.position).normalized;//�p�[�c�̈ʒu���瓮�����ڕW�ʒu�܂ł̒P�ʃx�N�g��(����)

        Vector3 moveVec = moveDirection * _stretchSpeed*Time.fixedDeltaTime;

        _movePart.MovePosition(_movePart.position+moveVec);
    }
}
