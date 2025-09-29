using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�f�[�^�̃X�R�A����
//�X�e�[�W���Ƃ̍ő��N���A�^�C���Ƃ��̎��̃f�X�����L�^

public partial class PlayerDataManager
{
    //---�X�R�A�֌W---//
    const string _fastestClearTimeDataName = "FastestClearTime";//�ő��N���A�^�C���̃f�[�^��
    const string _deathCountDataName = "DeathCount";//�f�X���̃f�[�^��

    public static ScoreData GetHighScore(int stageNum)//�n�C�X�R�A�̎擾(��x���������������Ƃ��Ȃ��ꍇ��null��Ԃ�)
    {
        //�n�C�X�R�A�f�[�^���擾����̂ɕK�v�ȃL�[
        GetHighScoreKey(stageNum, out string fastestClearTimeKey, out string deathCountKey);

        ScoreData ret = null;

        if(PlayerPrefs.HasKey(fastestClearTimeKey))
        {
            float clearTime=PlayerPrefs.GetFloat(fastestClearTimeKey);
            int deathCount = PlayerPrefs.GetInt(deathCountKey);

            ret=new ScoreData(clearTime, deathCount);
        }

        return ret;
    }

    public static void SetHighScore(int stageNum,float fastestClearTime,int deathCount)//�n�C�X�R�A�̏�������
    {
        GetHighScoreKey(stageNum, out string fastestClearTimeKey, out string deathCountKey);

        PlayerPrefs.SetFloat(fastestClearTimeKey, fastestClearTime);
        PlayerPrefs.SetInt(deathCountKey, deathCount);
    }

    //�n�C�X�R�A�f�[�^���擾���邽�߂̃L�[���擾(������)
    static void GetHighScoreKey(int stageNum, out string fastestClearTimeKey,out string deathCountKey)
    {
        fastestClearTimeKey = _fastestClearTimeDataName + stageNum.ToString();
        deathCountKey=_deathCountDataName + stageNum.ToString();
    }
}
