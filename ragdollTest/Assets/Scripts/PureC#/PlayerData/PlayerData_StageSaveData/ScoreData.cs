using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//スコアデータ

public class ScoreData
{
    EStageID _stageID;
    float _clearTime;
    int _deathCount;
    int _screamCount;

    public ScoreData(EStageID stageID,float clearTime,int deathCount,int screamCount)
    {
        _stageID = stageID;
        _clearTime = clearTime;
        _deathCount = deathCount;
        _screamCount = screamCount;
    }

    public EStageID StageID { get { return _stageID; } }//ステージID
    public float ClearTime { get { return _clearTime; } }//クリアタイム
    public int DeathCount { get { return _deathCount; } }//落ちた回数
    public int ScreamCount { get { return _screamCount; } }//鳴いた回数
}
