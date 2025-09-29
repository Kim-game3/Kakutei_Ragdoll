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
    [CustomLabel("ステージ番号")][SerializeField] int _stageNum;

    bool _brokeRecord;//記録を更新したか

    public bool BrokeRecord {  get { return _brokeRecord; }}

    private void Awake()
    {
        Judge();
    }

    void Judge()
    {
        //今までのハイスコアを取得
        ScoreData highScoreData = PlayerDataManager.GetHighScore(_stageNum);

        //今回のスコアを取得
        ScoreData thisScoreData = ResultManager.Score;

        if(thisScoreData==null)//そもそもクリアしていない
        {
            _brokeRecord = false;
        }
        else if (highScoreData == null)//初クリア
        {
            UpdateHighScore(thisScoreData);
        }
        else if (thisScoreData.ClearTime < highScoreData.ClearTime)//二度目以降のクリアで、クリアタイム更新
        {
            UpdateHighScore(thisScoreData);
        }
        else//クリアタイム更新ならず
        {
            _brokeRecord = false;
        }
    }

    void UpdateHighScore(ScoreData thisScoreData)//ハイスコア更新処理
    {
        _brokeRecord = true;

        PlayerDataManager.SetHighScore(_stageNum, thisScoreData);
    }
}
