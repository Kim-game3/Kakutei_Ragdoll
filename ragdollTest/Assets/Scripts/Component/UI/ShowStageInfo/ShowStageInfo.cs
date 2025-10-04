using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

//作成者:杉山
//ステージごとの情報を表示する

public class ShowStageInfo : MonoBehaviour
{
    [Tooltip("ステージの情報")] [SerializeField]
    StageInfoData _stageInfoData;

    [CustomLabel("ステージ名")] [SerializeField]
    TextMeshProUGUI _stageName;

    [CustomLabel("ステージのイメージ画像")] [SerializeField]
    Image _stageImage;

    [CustomLabel("クリアタイム")] [SerializeField]
    TextMeshProUGUI _clearTimeText;

    [CustomLabel("落ちた回数")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    const string _noScore = "-";

    public void UpdateStageInfo(int stageID)//表示するステージの情報の更新
    {
        //指定ステージのハイスコアを取得
        ScoreData highScoreData = PlayerDataManager.GetHighScore(stageID);

        //指定ステージの情報を取得
        StageInfo stageInfo=_stageInfoData.GetStageInfo(stageID);

        if (stageInfo == null)
        {
            Debug.Log("ステージの情報の取得に失敗");
            return;
        }

        //情報を書き換え
        _stageName.text = stageInfo.StageName;
        _stageImage.sprite =stageInfo.StageSprite;

        //未クリアの場合はスコアを表記しない
        if(highScoreData==null)
        {
            _clearTimeText.text = _noScore;
            _deathCountText.text = _noScore;
        }
        else
        {
            _clearTimeText.text = highScoreData.ClearTime.ToString("0");
            _deathCountText.text = highScoreData.DeathCount.ToString("0");
        }
    }
}
