using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ハイスコアデータ

public class ScoreData
{
    int _stageID;
    float _clearTime;
    int _deathCount;
    int _clearCount;

    public ScoreData(int stageID,float clearTime,int deathCount,int clearCount)
    {
        _clearTime = clearTime;
        _deathCount = deathCount;
        _clearCount = clearCount;
    }

    public int StageID { get { return _stageID; } }//ステージID
    public float ClearTime { get { return _clearTime; } }//クリアタイム
    public int DeathCount { get { return _deathCount; } }//落ちた回数
    public int ClearCount { get { return _clearCount; } }//クリア回数
}
