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

    public bool BrokeRecord {  get { return _brokeRecord; }}

    private void Awake()
    {
        Judge();
    }

    void Judge()
    {
        //今回のスコアを取得
        ScoreData thisScoreData = ResultManager.Score;

        if (thisScoreData == null)//そもそもクリアしていない(通常では起こりえない)
        {
            _brokeRecord = false;
            return;
        }

        //今までのハイスコアを取得
        ScoreData highScoreData = PlayerDataManager.GetScoreRecord(thisScoreData.StageID);
        
        if (highScoreData == null)//初クリア
        {
            UpdateHighScore(thisScoreData);
        }
        else if (thisScoreData.ClearTime < highScoreData.ClearTime)//二度目以降のクリアで、クリアタイム更新
        {
            UpdateHighScore(thisScoreData);
        }
        else//クリアタイム更新ならず
        {
            UpdateClearCount(thisScoreData.StageID,thisScoreData.ClearCount);
        }
    }

    void UpdateHighScore(ScoreData thisScoreData)//ハイスコア更新処理
    {
        _brokeRecord = true;
        PlayerDataManager.SetScoreRecord(thisScoreData);
    }

    void UpdateClearCount(int stageID,int clearCount)//クリア回数のみ更新(ハイスコア更新しなかった時)
    {
        _brokeRecord = false;
        PlayerDataManager.SetScoreRecord(stageID,clearCount);
    }
}
