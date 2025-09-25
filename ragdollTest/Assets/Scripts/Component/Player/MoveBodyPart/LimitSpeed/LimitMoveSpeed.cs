using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�ړ��X�s�[�h�̐���

public class LimitMoveSpeed : MonoBehaviour
{
    [CustomLabel("���݂̃v���C���[�̑��x���f�o�b�O�\�����邩")] [SerializeField]
    bool _showDebug_Speed;

    [CustomLabel("�ő�ړ����x")] [SerializeField]
    float _maxSpeed;

    [Tooltip("�ڒn����")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [SerializeField]
    Move_ForceBody _move_ForceBody;

    Rigidbody _body;

    void Limit()
    {
        Vector3 velocity = _body.velocity;

        bool isGround=_judgeIsGround.IsGround;

        velocity.y = isGround ? velocity.y : 0;

        if (_showDebug_Speed) Debug.Log(velocity.magnitude);//���x�̃f�o�b�O�\��

        if (velocity.magnitude > _maxSpeed)
        {
            Debug.Log("������");
            velocity = velocity.normalized * _maxSpeed;
            if(!isGround) velocity.y=_body.velocity.y;
            _body.velocity = velocity;
        }
    }

    private void Awake()
    {
        _body=_move_ForceBody.Body;
    }

    private void FixedUpdate()
    {
        Limit();
    }
}
