using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ノーマルモードの解放条件

[CreateAssetMenu(fileName = "StageUnlockConditionTypeNormalMode", menuName = "ScriptableObjects/StageUnlockCondition/NormalMode")]
public class StageUnlockConditionTypeNormalMode : StageUnlockConditionTypeBase
{
    public override bool IsUnlock()
    {
        //イージーモードがクリア済みならプレイ可能
        return PlayerDataManager.Load(EStageID.EasyMode).clearCount != 0;
    }
}
