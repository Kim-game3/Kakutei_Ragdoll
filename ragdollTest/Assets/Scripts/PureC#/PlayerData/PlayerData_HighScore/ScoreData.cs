using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�n�C�X�R�A�f�[�^

public class ScoreData
{
    int _stageID;
    float _clearTime;
    int _deathCount;

    public ScoreData(int stageID,float clearTime,int deathCount)
    {
        _clearTime = clearTime;
        _deathCount = deathCount;
    }

    public int StageID { get { return _stageID; } }//�X�e�[�WID
    public float ClearTime { get { return _clearTime; } }//�N���A�^�C��
    public int DeathCount {  get { return _deathCount; } }//��������
}
