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

    public ScoreData(int stageID,float clearTime,int deathCount)
    {
        _clearTime = clearTime;
        _deathCount = deathCount;
    }

    public int StageID { get { return _stageID; } }//ステージID
    public float ClearTime { get { return _clearTime; } }//クリアタイム
    public int DeathCount {  get { return _deathCount; } }//落ちた回数
}
