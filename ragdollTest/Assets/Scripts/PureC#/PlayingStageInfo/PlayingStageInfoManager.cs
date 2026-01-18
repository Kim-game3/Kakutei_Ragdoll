using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//プレイ中のステージの情報を管理
//ステージIDを変えたい時は一度破棄して作り直してから設定すること

public class PlayingStageInfoManager
{
    static PlayingStageInfoManager _instance;

    public static PlayingStageInfoManager Instance { get { return _instance; } }

    public PlayingStageData Data { get { return _data; } }

    PlayingStageData _data;

    public static void Instantiate()
    {
        if (_instance != null) return;

        _instance = new PlayingStageInfoManager();
    }

    public static void Destroy()
    {
        _instance = null;
    }

    public void SetData(EStageID stageID)
    {
        if (_data != null) return;//既にデータの実体があったら書き換え不可能

        _data = new PlayingStageData(stageID);
    }
}
