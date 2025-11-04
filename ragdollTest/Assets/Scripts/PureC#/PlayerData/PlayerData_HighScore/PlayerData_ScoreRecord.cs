using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーデータのスコアレコード部分
//ステージごとに最速クリアタイム、その時のデス数、クリア回数を記録

public partial class PlayerDataManager
{
    //---スコア関係---//
    const string _fastestClearTimeDataName = "FASTEST_CLEARTIME";//最速クリアタイムのデータ名
    const string _deathCountDataName = "DEATHCOUNT";//デス数のデータ名
    const string _clearCountDataName = "CLEARCOUNT";//クリアタイムのデータ名

    public static ScoreData GetScoreRecord(int stageID)//スコアレコードの取得(一度も書き換えたことがない場合はnullを返す)
    {
        //ハイスコアデータを取得するのに必要なキー
        GetScoreDataKey(stageID, out string fastestClearTimeKey, out string deathCountKey,out string clearCountKey);

        ScoreData ret = null;

        if(PlayerPrefs.HasKey(fastestClearTimeKey))
        {
            float clearTime=PlayerPrefs.GetFloat(fastestClearTimeKey);
            int deathCount = PlayerPrefs.GetInt(deathCountKey);
            int clearCount=PlayerPrefs.GetInt(clearCountKey);

            ret=new ScoreData(stageID,clearTime, deathCount,clearCount);
        }

        return ret;
    }

    public static void SetScoreRecord(ScoreData scoreData)//スコアレコード(ハイスコアごと)の書き換え、クリア回数はこっちで計算などはしないため、呼び出し側で行うこと(ScoreDataの中に入れる)
    {
        GetScoreDataKey(scoreData.StageID, out string fastestClearTimeKey, out string deathCountKey, out string clearCountKey);

        //スコアレコードの書き換え処理
        PlayerPrefs.SetFloat(fastestClearTimeKey, scoreData.ClearTime);
        PlayerPrefs.SetInt(deathCountKey, scoreData.DeathCount);
        PlayerPrefs.SetInt(clearCountKey, scoreData.ClearCount);
    }

    public static void SetScoreRecord(int stageID, int newClearCount)//スコアレコード(クリア回数のみ)の書き換え、クリア回数はこっちで計算などはしないため、呼び出し側で行うこと
    {
        GetScoreDataKey(stageID, out string clearCountKey);

        //クリア回数の書き換え処理
        PlayerPrefs.SetInt(clearCountKey, newClearCount);
    }





    //スコアデータを取得するためのキーを取得(文字列)
    static void GetScoreDataKey(int stageID, out string fastestClearTimeKey,out string deathCountKey,out string clearCountKey)
    {
        fastestClearTimeKey = _fastestClearTimeDataName + stageID.ToString();
        deathCountKey=_deathCountDataName + stageID.ToString();
        clearCountKey=_clearCountDataName + stageID.ToString();
    }

    static void GetScoreDataKey(int stageID,out string clearCountKey)
    {
        clearCountKey = _clearCountDataName + stageID.ToString();
    }
}
