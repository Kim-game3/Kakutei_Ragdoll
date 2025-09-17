using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�̈ړ����x������𒴂��ĂȂ�������

[System.Serializable]
public class JudgeIsValidSpeed
{
    [CustomLabel("���݂̃v���C���[�̑��x���f�o�b�O�\�����邩")] [SerializeField]
    bool _showDebug_Speed;

    [CustomLabel("�ő�ړ����x")] [SerializeField]
    float _maxSpeed;

    [Tooltip("�ڒn����")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    Rigidbody _body;

    public void Init(Rigidbody body)//������(body=�Ώە��ʂ�Rigidbody)
    {
        _body = body;
    }

    public bool IsValidSpeed()//�ړ����x�͔͈͓���
    {
        Vector3 velocity= _body.velocity;
        velocity.y= _judgeIsGround.IsGround ? _body.velocity.y : 0;

        if(_showDebug_Speed) Debug.Log(velocity.magnitude);//���x�̃f�o�b�O�\��

        return velocity.magnitude <= _maxSpeed;
    }
}
