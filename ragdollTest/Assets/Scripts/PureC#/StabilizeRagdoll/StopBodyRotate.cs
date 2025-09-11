using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̂̃p�[�c����]���ɂ����Ȃ�悤�ɂ���
//(�������邱�ƂŐg�̂̃p�[�c���r�Ԃ�̂��~�߂邱�Ƃ��o����)

[System.Serializable]
public class StopBodyRotate
{
    [Tooltip("�f�t�H���g��1")] [CustomLabel("��]�̂��ɂ���")] [SerializeField]
    float _rotationalInertia;

    Vector3[] _defaultInertiaTensors;//�����̊����e���\���̒l

    public void Init(Rigidbody[] _bodyPartRbs)//����������
    {
        _defaultInertiaTensors = new Vector3[_bodyPartRbs.Length];

        //�����̊����e���\���̒l���L�^
        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _defaultInertiaTensors[i] = _bodyPartRbs[i].inertiaTensor;
        }
    }

    public void StopRotate(Rigidbody[] _bodyPartRbs)//�g�̂̃p�[�c�̉�]���~�߂�
    {
        if (_defaultInertiaTensors == null || _bodyPartRbs == null) return;

        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor = _defaultInertiaTensors[i] * _rotationalInertia;
        }
    }
}
