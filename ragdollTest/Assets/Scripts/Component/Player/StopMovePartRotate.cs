using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̂̃p�[�c����]���ɂ����Ȃ�悤�ɂ���
//(�������邱�ƂŐg�̂̃p�[�c���r�Ԃ�̂��~�߂邱�Ƃ��o����)

public class StopMovePartRotate : MonoBehaviour
{
    [Tooltip("�g�̂̃p�[�c��Rigidbody")] [SerializeField] Rigidbody[] _bodyPartRbs;
    [Tooltip("��]�̂��ɂ���")] [SerializeField] float _rotationalInertia;


    void Start()
    {
        StopRotate();
    }

    void StopRotate()//�g�̂̃p�[�c����]���ɂ�������
    {
        for (int i = 0; i < _bodyPartRbs.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor *= _rotationalInertia;
        }
    }
}
