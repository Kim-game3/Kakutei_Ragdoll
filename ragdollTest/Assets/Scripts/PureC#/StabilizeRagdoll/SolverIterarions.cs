using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//��������̉������[�v�̉񐔂�ύX����
//(����ɂ��A�����j�����ۂɈ����߂���鏈�������艻����)

[System.Serializable]
public class SolverIterarions
{
    [Tooltip("�f�t�H���g��6\n���̒l��������قǁA���O�h�[���̓��������艻���邪�A���̕��d���Ȃ�")]
    [CustomLabel("��������̉������[�v�̉�")] [Min(6)] [SerializeField]
    int _count;

    public void Change(Rigidbody[] _bodyPartRbs)
    {
        if (_bodyPartRbs == null) return;

        for (int i = 0; i < _bodyPartRbs.Length; i++)
        {
            _bodyPartRbs[i].solverIterations = _count;
            _bodyPartRbs[i].solverVelocityIterations = _count;
        }
    }
}
