using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���̌���(�X�R�A)���m�肳����

public class SetResult : MonoBehaviour
{
    [SerializeField]
    CountDeath _countDeath;

    [SerializeField]
    StopWatch _stopWatch;

    [SerializeField]
    ResultData _resultData;

    public void Set()//���ʂ̏�������
    {
        //���S�񐔂��m��
        _resultData.DeathCount = _countDeath.Count;

        //�N���A�^�C�����m��
        _resultData.ClearTime = _stopWatch.ElapsedTime;
    }
}
