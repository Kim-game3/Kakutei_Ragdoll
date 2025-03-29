using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�g�̂̃p�[�c�𓷂̑O�������ɐL�΂�
//�p�[�c�𓮂������ۂ���enable��؂�ւ��čs��
public class StretchForwardWaist_BodyPart : MonoBehaviour
{
    [Header("�������p�[�c")]
    [SerializeField] Rigidbody _movePart;
    [Header("�V���ȓ������p�[�c�̌���")]
    [Tooltip("�������p�[�c�̌����Ă�������z��ƈ���Ă��ăp�[�c���������Ȃ��ꍇ�ɁA������g�����ƂŐV���Ɍ������`���邱�Ƃ��o����B\n" +
        "��������Ȃ���Ώ�̓������p�[�c(MovePart)�̌������g�p���ď������s���B")]
    [SerializeField] Transform _newDirection_MovePart;
    [Header("���̈ʒu")]
    [SerializeField] Transform _waistTransform;
    [Header("�L�΂�����")]
    [SerializeField] float _stretchSpeed;

    private void FixedUpdate()
    {
        Stretch();
    }

    void Stretch()
    {
        Quaternion from = From();//���݂̌���

        Quaternion to = _waistTransform.rotation;//���̑O��������ڕW�Ƃ���

        float rotateSpeed = _stretchSpeed * Time.deltaTime;//��]�X�s�[�h

        Quaternion rotate = Quaternion.RotateTowards(from, to, rotateSpeed);//��]�N�H�[�^�j�I��

        _movePart.rotation = rotate;
    }

    Quaternion From()
    {
        if (_newDirection_MovePart == null)//�V���ȓ������p�[�c�̌�������`����Ă��Ȃ��ꍇ�A�������p�[�c�̌��������̂܂܎g��
        {
            return _movePart.transform.rotation;
        }

        return _newDirection_MovePart.rotation;
    }
}
