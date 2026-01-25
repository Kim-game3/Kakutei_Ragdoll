using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージが解放されているか(プレイ可能)かを判断

public abstract class StageUnlockConditionTypeBase : ScriptableObject
{
    public abstract bool IsUnlock();//そのステージがプレイ可能か
}
