using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���O�h�[���̓����̈��艻�̃R���|�[�l���g

public class StabilizeRagdoll : MonoBehaviour
{
    [CustomLabel("�g�̂̃p�[�c��Rigidbody")] [SerializeField]
    Rigidbody[] _bodyPartRbs;

    [CustomLabel("�g�̂̃p�[�c�̉�]�̂�������}����@�\")] [SerializeField]
    StopBodyRotate _stopBodyRotate;

    [CustomLabel("�����j�����ۂ̈����߂���������������@�\")] [SerializeField]
    SolverIterarions _solverIterarions;

    private void Awake()
    {
        _stopBodyRotate.Init(_bodyPartRbs);
    }

    private void Start()
    {
        _stopBodyRotate.StopRotate(_bodyPartRbs);
        _solverIterarions.Change(_bodyPartRbs);
    }
    private void OnValidate()
    {
        if (!Application.isPlaying) return;//�Đ����̂ݕύX�������s��

            _stopBodyRotate.StopRotate(_bodyPartRbs);
        _solverIterarions.Change(_bodyPartRbs);
    }
}
