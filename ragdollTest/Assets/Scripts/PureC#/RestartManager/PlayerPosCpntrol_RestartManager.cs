using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g���̃v���C���[�̈ʒu�������n�_�ɖ߂�����

public partial class RestartManager
{
    [System.Serializable]
    class PlayerPosControl
    {
        [CustomLabel("���X�^�[�g�n�_&����")] [Tooltip("�v���C���[�����̒n�_�ɏo�������̕����Ɍ������ē�����΂����")] [SerializeField]
        Transform _restartPoint;

        [CustomLabel("�v���C���[�̈ʒu���")] [Tooltip("�v���C���[�̈�ԏ�̊K�w��Transform�����Ă�������")] [SerializeField]
        TransformReference _playerTrs;

        [CustomLabel("�v���C���[��Rigidbody")] [SerializeField]//�v���C���[���X�^�[�g�n�_�ɓ�����΂��ۂɎg��
        RigidbodyReference _body;

        [CustomLabel("������͂̑傫��")] [SerializeField]
        float _power;

        public void BackToRestartPoint()//�v���C���[�����X�^�[�g�n�_�Ɉړ�������
        {
            _body.Rigidbody.isKinematic = true;
            _playerTrs.Transform.position = _restartPoint.position;
        }

        public void ThrowPlayer()//�����n�_�ɖ߂�悤�ɓ�����΂�
        {
            _body.Rigidbody.isKinematic=false;
            Vector3 force = _restartPoint.forward * _power;
            _body.Rigidbody.AddForce(force,ForceMode.VelocityChange);
        }
    }
}
