using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリアせずに今やっているのをやめる時にセーブ処理

public class SaveUtilityOnQuitNowPlaying : MonoBehaviour
{
    [Tooltip("水に落ちた回数を数える機能")] [SerializeField]
    CountDeath _countDeath;

    [Tooltip("タイムを測る機能")] [SerializeField]
    StopWatch _stopWatch;

    public void Save()
    {
        var stageID = PlayingStageInfoManager.Instance.Data.StageID;

        var stageSaveData = PlayerDataManager.Load(stageID);

        stageSaveData.totalDeathCount += _countDeath.Count;
        stageSaveData.totalPlayTime += (long)_stopWatch.ElapsedTime;

        PlayerDataManager.Save(stageSaveData);
    }
}
