using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//ステージのアンロックをする

public class StageUnlocker : MonoBehaviour
{
    [SerializeField]
    StartGameStageButton _stageButtonInfo;

    [Tooltip("挑戦条件を表示するテキスト")] [SerializeField]
    TextMeshProUGUI _textShowChallengeConditions;

    [SerializeField]
    StageInfoData _stageInfoData;

    // Start is called before the first frame update
    void Start()
    {
        //挑戦可能かを取得
        var stageInfo = _stageInfoData.GetStageInfo(_stageButtonInfo.StageID);
        if (stageInfo == null) return;

        var stageUnlockCondition = stageInfo.StageUnlockCondition;
        bool isChallengable = (stageUnlockCondition != null) ? stageUnlockCondition.IsUnlock() : true;//アンロック条件が特になければプレイ可能にする
        
        //挑戦可能かを表示
        if(_textShowChallengeConditions!=null) _textShowChallengeConditions.enabled = !isChallengable;
        _stageButtonInfo.StageButton.interactable = isChallengable;
    }
}
