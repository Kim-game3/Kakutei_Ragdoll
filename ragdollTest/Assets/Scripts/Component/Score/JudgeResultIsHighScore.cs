using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�n�C�X�R�A���X�V����
/// <summary>
/// ���S�񐔂Ɍ��炸�A�N���A�^�C����������΍X�V
/// </summary>

public class JudgeResultIsHighScore : MonoBehaviour
{
    bool _brokeRecord;//�L�^���X�V������

    public bool BrokeRecord {  get { return _brokeRecord; }}

    private void Awake()
    {
        Judge();
    }

    void Judge()
    {
        //����̃X�R�A���擾
        ScoreData thisScoreData = ResultManager.Score;

        //���܂ł̃n�C�X�R�A���擾
        ScoreData highScoreData = PlayerDataManager.GetHighScore(thisScoreData.StageID);

        if (thisScoreData==null)//���������N���A���Ă��Ȃ�
        {
            _brokeRecord = false;
        }
        else if (highScoreData == null)//���N���A
        {
            UpdateHighScore(thisScoreData);
        }
        else if (thisScoreData.ClearTime < highScoreData.ClearTime)//��x�ڈȍ~�̃N���A�ŁA�N���A�^�C���X�V
        {
            UpdateHighScore(thisScoreData);
        }
        else//�N���A�^�C���X�V�Ȃ炸
        {
            _brokeRecord = false;
        }
    }

    void UpdateHighScore(ScoreData thisScoreData)//�n�C�X�R�A�X�V����
    {
        _brokeRecord = true;

        PlayerDataManager.SetHighScore(thisScoreData);
    }
}
