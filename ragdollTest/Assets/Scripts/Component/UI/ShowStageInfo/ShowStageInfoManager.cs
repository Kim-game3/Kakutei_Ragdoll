using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

//作成者:杉山
//ステージごとの情報を表示する

public class ShowStageInfoManager : MonoBehaviour
{
    [Tooltip("ステージの情報")] [SerializeField]
    StageInfoData _stageInfoData;

    [CustomLabel("ステージ名")] [SerializeField]
    TextMeshProUGUI _stageName;

    [Tooltip("イメージアイコン")] [SerializeField]
    Image _imageIcon;

    [Tooltip("キャラの名前")] [SerializeField]
    TextMeshProUGUI _charaName;

    [Tooltip("コメント")] [SerializeField]
    TextMeshProUGUI _comment;

    //ステージレコード関係
    [CustomLabel("クリアタイム")] [SerializeField]
    TextMeshProUGUI _clearTimeText;

    [CustomLabel("落ちた回数")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    [Tooltip("クリア回数")] [SerializeField]
    TextMeshProUGUI _clearCountText;

    const string _noScore = "-";

    public void UpdateStageInfo(EStageID stageID)//表示するステージの情報の更新
    {
        //指定ステージのスコアレコードを取得
        ScoreData scoreRecordData = PlayerDataManager.GetScoreRecord(stageID);

        //指定ステージの情報を取得
        StageInfo stageInfo=_stageInfoData.GetStageInfo(stageID);

        if (stageInfo == null)
        {
            Debug.Log("ステージの情報の取得に失敗");
            return;
        }

        //情報を書き換え
        _stageName.text = stageInfo.StageName;
        _imageIcon.sprite = stageInfo.ImageIcon;
        _charaName.text = stageInfo.CharaName;
        _comment.text = stageInfo.Comment;

        //未クリアの場合はスコアを表記しない
        if(scoreRecordData==null)
        {
            _clearTimeText.text = _noScore;
            _deathCountText.text = _noScore;
            _clearCountText.text = _noScore;
        }
        else
        {
            MathfExtension.ConvertTime(scoreRecordData.ClearTime, out float hour, out float min, out float second);

            _clearTimeText.text = $"{hour:00}:{min:00}:{second:00}";
            _deathCountText.text = scoreRecordData.DeathCount.ToString("0")+"回";
            _clearCountText.text = scoreRecordData.ClearCount.ToString("0") + "回";
        }
    }
}
