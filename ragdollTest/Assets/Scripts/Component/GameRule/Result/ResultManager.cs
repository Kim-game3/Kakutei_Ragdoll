using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���̌���(�X�R�A)
//�X�R�A�̏������݂Ɠ`�B������N���X�A�C���Q�[���݂̂ɒu��

public class ResultManager : MonoBehaviour
{
    //--- �X�R�A�̎Z�o�ɕK�v�ȋ@�\ ---//
    [Tooltip("���ɗ������񐔂𐔂���@�\")] [SerializeField]
    CountDeath _countDeath;

    [Tooltip("�N���A�^�C���𑪂�@�\")] [SerializeField]
    StopWatch _stopWatch;

    //--- �X�R�A ---//
    static ScoreData _score;

    public static ScoreData Score { get { return _score; } }//�X�R�A�̎擾(�X�R�A���m�肵�Ă��Ȃ��ꍇ��null���Ԃ����̂Œ���)

    private void Awake()
    {
        _score = null;//�X�R�A������
    }

    //�X�R�A�̊m��(��������)
    public void ConfirmResult()
    {
        _score = new ScoreData(_stopWatch.ElapsedTime, _countDeath.Count);
    }
}
