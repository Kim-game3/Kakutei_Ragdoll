using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̂̃p�[�c����]���ɂ����Ȃ�悤�ɂ���
//(�������邱�ƂŐg�̂̃p�[�c���r�Ԃ�̂��~�߂邱�Ƃ��o����)

public class StopMovePartRotate : MonoBehaviour
{
    [CustomLabel("�g�̂̃p�[�c��Rigidbody")] [SerializeField]
    Rigidbody[] _bodyPartRbs;
    [Tooltip("1���ƕω��Ȃ�")] [CustomLabel("��]�̂��ɂ���")] [SerializeField]
    float _rotationalInertia;

    Vector3[] _defaultInertiaTensors;//�����̊����e���\���̒l

    private void Awake()
    {
        _defaultInertiaTensors = new Vector3[_bodyPartRbs.Length];

        //�����̊����e���\���̒l���L�^
        for(int i=0; i<_defaultInertiaTensors.Length ;i++)
        {
            _defaultInertiaTensors[i] = _bodyPartRbs[i].inertiaTensor;
        }
    }

    void Start()
    {
        StopRotate();
    }

    private void OnValidate()
    {
        StopRotate();
    }

    void StopRotate()//�g�̂̃p�[�c����]���ɂ�������
    {
        if (_defaultInertiaTensors == null || _bodyPartRbs==null) return;

        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor = _defaultInertiaTensors[i]*_rotationalInertia;
        }
    }
}
