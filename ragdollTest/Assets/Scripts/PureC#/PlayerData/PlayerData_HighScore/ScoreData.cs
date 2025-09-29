using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ハイスコアデータ

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
    public int DeathCount {  get { return _deathCount; } }
}
