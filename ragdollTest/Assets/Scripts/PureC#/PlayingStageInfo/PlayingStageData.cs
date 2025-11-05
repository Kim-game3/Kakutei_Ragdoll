using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイ中のステージの情報(ステージID)

public class PlayingStageData
{
    int _stageID;

    public PlayingStageData(int stageID)
    {
        _stageID = stageID;
    }

    public int StageID { get { return _stageID; } }
}
