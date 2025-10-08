using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g���̃v���C���[�̃��b�V���\���̏���

public partial class RestartManager
{
    [System.Serializable]
    class PlayerMeshControl
    {
        [Tooltip("�v���C���[�̃��b�V��")] [SerializeField]
        SkinnedMeshRenderer[] _playerMeshs;

        //�v���C���[�̕\����Ԃ�ύX
        public void ChangeMeshEnabled(bool enabled)
        {
            for(int i=0; i<_playerMeshs.Length ;i++)
            {
                _playerMeshs[i].enabled = enabled;
            }
        }
    }
}
