using TMPro;
using UnityEngine;

//作成者:杉山
//リザルトシーンのスコアを表示

public class ShowResult_ResultScene : MonoBehaviour
{
    [CustomLabel("クリアタイムを表示する文字")] [SerializeField]
    TextMeshProUGUI _clearTimeText;

    [CustomLabel("落ちた回数を表示")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    [SerializeField]
    JudgeResultIsHighScore _judgeResultIsHighScore;

    void Start()
    {
        if (_judgeResultIsHighScore.BrokeRecord)
        {
            Debug.Log("記録更新！");
        }

        ScoreData thisScore = ResultManager.Score;

        if (thisScore == null) return;

        _clearTimeText.text=thisScore.ClearTime.ToString("0");
        _deathCountText.text=thisScore.DeathCount.ToString("0");
    }
}
