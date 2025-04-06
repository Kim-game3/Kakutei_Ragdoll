using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������g�̂̃p�[�c�ɑ΂��ĖړI�̕����ɗ͂�����������
//���������ǂ�����enable��؂�ւ��čs��
public class StretchBodyPart_ForwardWaist_AddForce : MonoBehaviour
{
    [Header("�������p�[�c")]
    [SerializeField] Rigidbody _movePart;
    [Header("�L�΂������̃p�[�c�̈ʒu")]
    [SerializeField] Transform _pos_Stretched_Transform;
    [Header("�L�΂����ɂ������")]
    [SerializeField] float _stretchPower;

    private void FixedUpdate()
    {
        MovePart();
    }

    void MovePart()
    {
        Vector3 moveDirection = (_pos_Stretched_Transform.position - _movePart.position).normalized;//�p�[�c�̈ʒu���瓮�����ڕW�ʒu�܂ł̒P�ʃx�N�g��(����)

        Vector3 moveVec = moveDirection * _stretchPower;

        _movePart.AddForce(moveVec,ForceMode.Force);

        Debug.Log("�����Ă܂�");
    }
}
