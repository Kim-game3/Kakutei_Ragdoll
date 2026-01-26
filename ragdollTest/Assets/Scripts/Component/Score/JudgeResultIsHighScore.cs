using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ハイスコアを更新する
/// <summary>
/// 死亡回数に限らず、クリアタイムが早ければ更新
/// </summary>

public class JudgeResultIsHighScore : MonoBehaviour
{
    bool _brokeRecord;//記録を更新したか
    bool _isFirstClear;//初めてのクリアか

    public bool BrokeRecord {  get { return _brokeRecord; } }
    public bool IsFirstClear {  get{ return _isFirstClear; } }

    private void Awake()
    {
        Judge();
    }

    void Judge()
    {
        _brokeRecord = false;
        _isFirstClear = false;

        //今回のスコアを取得
        ScoreData thisScoreData = ResultManager.Score;

        if (thisScoreData == null)//そもそもクリアしていない(通常では起こりえない)
        {
            _brokeRecord = false;
            return;
        }

        //ステージのセーブデータを取得
        var stageSaveData = PlayerDataManager.Load(thisScoreData.StageID);

        if (stageSaveData.clearCount == 0)//初クリアか二度目以降のクリアでクリアタイム更新した時
        {
            _isFirstClear = true;
            UpdateBestRecord(thisScoreData, stageSaveData);
        }
        else if (thisScoreData.ClearTime < stageSaveData.bestClearTime)//二度目以降のクリアで、クリアタイム更新
        {
            UpdateBestRecord(thisScoreData, stageSaveData);
        }
        else//クリアタイム更新ならず
        {
            UpdateClear(thisScoreData, stageSaveData);
        }
    }

    void UpdateBestRecord(ScoreData thisScoreData,StageSaveData stageSaveData)
    {
        _brokeRecord = true;

        stageSaveData.bestClearTime = thisScoreData.ClearTime;

        stageSaveData.totalPlayTime += (long)thisScoreData.ClearTime;
        stageSaveData.totalDeathCount += thisScoreData.DeathCount;
        stageSaveData.clearCount++;

        PlayerDataManager.Save(stageSaveData);
    }

    void UpdateClear(ScoreData thisScoreData, StageSaveData stageSaveData)
    {
        stageSaveData.totalPlayTime += (long)thisScoreData.ClearTime;
        stageSaveData.totalDeathCount += thisScoreData.DeathCount;
        stageSaveData.clearCount++;

        PlayerDataManager.Save(stageSaveData);
    }
}
