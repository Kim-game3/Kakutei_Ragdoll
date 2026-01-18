using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイ中のステージの情報(ステージID)

public class PlayingStageData
{
    EStageID _stageID;

    public PlayingStageData(EStageID stageID)
    {
        _stageID = stageID;
    }

    public EStageID StageID { get { return _stageID; } }
}
