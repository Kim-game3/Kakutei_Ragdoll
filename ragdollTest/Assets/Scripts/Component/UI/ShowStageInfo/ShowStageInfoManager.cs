using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

//作成者:杉山
//ステージごとの情報を表示する

public class ShowStageInfoManager : MonoBehaviour
{
    [Tooltip("ステージの情報")] [SerializeField]
    StageInfoData _stageInfoData;

    [Tooltip("ステージ名")] [SerializeField]
    TextMeshProUGUI _stageName;

    [Tooltip("イメージアイコン")] [SerializeField]
    Image _imageIcon;

    [Tooltip("キャラの名前")] [SerializeField]
    TextMeshProUGUI _charaName;

    [Tooltip("コメント")] [SerializeField]
    TextMeshProUGUI _comment;

    //チェックポイント数
    [Tooltip("チェックポイント数のテキスト")] [SerializeField]
    TextMeshProUGUI _checkPointText;

    //ステージレコード関係
    [Tooltip("クリアタイム")] [SerializeField]
    TextMeshProUGUI _bestClearTimeText;

    [Tooltip("プレイ時間")] [SerializeField]
    TextMeshProUGUI _totalPlayTimeText;

    [Tooltip("落ちた回数")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    [Tooltip("クリア回数")] [SerializeField]
    TextMeshProUGUI _clearCountText;

    [Tooltip("鳴いた回数")] [SerializeField]
    TextMeshProUGUI _screamCountText;

    const string _noScore = "-";

    Dictionary<EStageID,StageSaveData> _stageSaveDatas = new();

    public void UpdateStageInfo(EStageID stageID)//表示するステージの情報の更新
    {
        //指定ステージのセーブデータを取得
        if(!_stageSaveDatas.TryGetValue(stageID,out var stageSaveData))
        {
            stageSaveData = PlayerDataManager.LoadStageData(stageID);
            _stageSaveDatas.Add(stageID, stageSaveData);
        }

        //指定ステージの情報を取得
        StageInfo stageInfo=_stageInfoData.GetStageInfo(stageID);

        if (stageInfo == null)
        {
            Debug.Log("ステージの情報の取得に失敗");
            return;
        }

        SetStageInfoText(stageInfo);

        SetScoreRecordText(stageSaveData);
    }

    void SetStageInfoText(StageInfo stageInfo)//ステージの情報のテキストを書き換え
    {
        _stageName.text = stageInfo.StageName;
        _imageIcon.sprite = stageInfo.ImageIcon;
        _charaName.text = stageInfo.CharaName;
        _comment.text = stageInfo.Comment;

        //チェックポイント数のテキスト書き換え
        _checkPointText.text = stageInfo.CheckPointTextValue;
        _checkPointText.color = stageInfo.CheckPointValueTextColor;
    }

    void SetScoreRecordText(StageSaveData stageSaveData)//スコアレコード関係のテキスト書き換え
    {
        //未クリアの場合は最速記録を表記しない
        if (stageSaveData.clearCount == 0)
        {
            _bestClearTimeText.text = _noScore;
        }
        else
        {
            _bestClearTimeText.text = BestClearTimeText(stageSaveData.bestClearTime);
        }

        _totalPlayTimeText.text = PlayTimeText(stageSaveData.totalPlayTime);
        _deathCountText.text = stageSaveData.totalDeathCount.ToString("0") + "回";
        _clearCountText.text = stageSaveData.clearCount.ToString("0") + "回";
        _screamCountText.text = stageSaveData.totalScreamCount.ToString("0") + "回";
    }

    string BestClearTimeText(float bestClearTime)
    {
        MathfExtension.ConvertTime(bestClearTime, out float hour, out float min, out float second);

        return $"{hour:00}:{min:00}:{second:00}";
    }

    string PlayTimeText(long playTime)
    {
        MathfExtension.ConvertTime(playTime, out float hour, out float min, out float second);

        return $"{hour:00}:{min:00}:{second:00}";
    }
}
