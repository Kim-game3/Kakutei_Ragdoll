using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�n�C�X�R�A�f�[�^

public class ScoreData
{
    float _clearTime;
    int _deathCount;

    public ScoreData(float clearTime,int deathCount)
    {
        _clearTime = clearTime;
        _deathCount = deathCount;
    }

    public float ClearTime { get { return _clearTime; } }
    public int Death {  get { return _deathCount; } }
}
