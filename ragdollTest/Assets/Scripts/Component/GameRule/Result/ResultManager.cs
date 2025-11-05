using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームの結果(スコア)
//スコアの書き込みと伝達をするクラス、インゲームのみに置く

public class ResultManager : MonoBehaviour
{
    //--- スコアの算出に必要な機能 ---//
    [Tooltip("現在プレイしているステージの情報の取得に失敗した時に入れるステージID")] [SerializeField]
    int _defaultStageID=0;

    [Tooltip("水に落ちた回数を数える機能")] [SerializeField]
    CountDeath _countDeath;

    [Tooltip("クリアタイムを測る機能")] [SerializeField]
    StopWatch _stopWatch;

    //--- スコア ---//
    static ScoreData _score;

    public static ScoreData Score { get { return _score; } }//スコアの取得(スコアが確定していない場合はnullが返されるので注意)、クリア回数は何回目のクリアかを入れる

    private void Awake()
    {
        _score = null;//スコア初期化
    }

    //スコアの確定(書き込み)
    public void ConfirmResult()
    {
        int stageID = GetStageID();

        ScoreData record = PlayerDataManager.GetScoreRecord(stageID);

        int clearCountRecord = (record != null) ? record.ClearCount : 0; //今までのクリア回数を取得
        clearCountRecord++;//クリア回数を加算

        _score = new ScoreData(stageID,_stopWatch.ElapsedTime, _countDeath.Count,clearCountRecord);
    }

    int GetStageID()
    {
        //プレイ中のステージの情報を管理するクラスの実体が無かったら今ここで作ってから、ステージIDを渡す
        //既にあったらそのままステージIDを取得して渡す

        if (PlayingStageInfoManager.Instance == null)
        {
            PlayingStageInfoManager.Instantiate();
            PlayingStageInfoManager.Instance.SetData(_defaultStageID);
        }
        else if(PlayingStageInfoManager.Instance.Data == null)
        {
            PlayingStageInfoManager.Instance.SetData(_defaultStageID);
        }

        return PlayingStageInfoManager.Instance.Data.StageID;
    }
}
