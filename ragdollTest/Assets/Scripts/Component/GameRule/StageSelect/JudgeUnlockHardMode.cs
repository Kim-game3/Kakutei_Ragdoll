using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//ハードモードに挑戦可能かを判断する

public class JudgeUnlockHardMode : MonoBehaviour
{
    [Tooltip("ハードモードのボタン")] [SerializeField]
    Button _hardModeButton;

    [Tooltip("ハードモードの挑戦条件を表示するテキスト")] [SerializeField]
    TextMeshProUGUI _textShowChallengeConditions;

    const int _normalModeStageID = 0;

    // Start is called before the first frame update
    void Start()
    {
        //ノーマル(いつもの帰宅)モードをクリアしていたらハード(絶対帰さない)モードをプレイ可能になる
        bool isClearNormalMode = (PlayerDataManager.GetScoreRecord(_normalModeStageID) != null);

        _textShowChallengeConditions.enabled = !isClearNormalMode;

        _hardModeButton.interactable = isClearNormalMode;
    }
}
