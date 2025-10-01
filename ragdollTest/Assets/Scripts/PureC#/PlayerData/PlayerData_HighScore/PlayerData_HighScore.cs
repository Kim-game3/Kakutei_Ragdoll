using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーデータのスコア部分
//ステージごとの最速クリアタイムとその時のデス数を記録

public partial class PlayerDataManager
{
    //---スコア関係---//
    const string _fastestClearTimeDataName = "FastestClearTime";//最速クリアタイムのデータ名
    const string _deathCountDataName = "DeathCount";//デス数のデータ名

    public static ScoreData GetHighScore(int stageNum)//ハイスコアの取得(一度も書き換えたことがない場合はnullを返す)
    {
        //ハイスコアデータを取得するのに必要なキー
        GetHighScoreKey(stageNum, out string fastestClearTimeKey, out string deathCountKey);

        ScoreData ret = null;

        if(PlayerPrefs.HasKey(fastestClearTimeKey))
        {
            float clearTime=PlayerPrefs.GetFloat(fastestClearTimeKey);
            int deathCount = PlayerPrefs.GetInt(deathCountKey);

            ret=new ScoreData(clearTime, deathCount);
        }

        return ret;
    }

    public static void SetHighScore(int stageNum,ScoreData scoreData)//ハイスコアの書き換え
    {
        GetHighScoreKey(stageNum, out string fastestClearTimeKey, out string deathCountKey);

        PlayerPrefs.SetFloat(fastestClearTimeKey, scoreData.ClearTime);
        PlayerPrefs.SetInt(deathCountKey, scoreData.DeathCount);
    }

    //ハイスコアデータを取得するためのキーを取得(文字列)
    static void GetHighScoreKey(int stageNum, out string fastestClearTimeKey,out string deathCountKey)
    {
        fastestClearTimeKey = _fastestClearTimeDataName + stageNum.ToString();
        deathCountKey=_deathCountDataName + stageNum.ToString();
    }
}
