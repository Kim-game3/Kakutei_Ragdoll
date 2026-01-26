using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ハードモードの解放条件

[CreateAssetMenu(fileName = "StageUnlockConditionTypeHardMode", menuName = "ScriptableObjects/StageUnlockCondition/HardMode")]
public class StageUnlockConditionTypeHardMode : StageUnlockConditionTypeBase
{
    public override bool IsUnlock()
    {
        //イージーモードがクリア済みならプレイ可能
        return PlayerDataManager.LoadStageData(EStageID.EasyMode).clearCount != 0;
    }
}
