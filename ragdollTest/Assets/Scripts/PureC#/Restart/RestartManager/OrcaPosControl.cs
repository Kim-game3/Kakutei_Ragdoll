using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�V���`�̏ꏊ��ύX����

public partial class RestartProcess
{
    [System.Serializable]
    class OrcaPosControl
    {
        [Tooltip("�V���`�̈ʒu���")] [SerializeField] 
        Transform _orcaTrs;

        //�V���`�̈ʒu�ƌ�����ύX
        public void ChangePos(Transform spawnPos)
        {
            _orcaTrs.position = spawnPos.position;
            _orcaTrs.rotation = spawnPos.rotation;
        }
    }
}
