using System.Collections;
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

    [Tooltip("クリア回数を表示する文字")] [SerializeField]
    TextMeshProUGUI _clearCountText;

    [SerializeField]
    JudgeResultIsHighScore _judgeResultIsHighScore;

    IEnumerator Start()
    {
        yield return null;//JudgeResultIsHighScoreのスコア更新処理を待つ

        if (_judgeResultIsHighScore.BrokeRecord)
        {
#if UNITY_EDITOR
            Debug.Log("記録更新！");
#endif
        }

        ScoreData thisScore = ResultManager.Score;

        if (thisScore == null) yield break;

        MathfExtension.ConvertTime(thisScore.ClearTime, out float hour, out float min, out float second);

        _clearTimeText.text = $"{hour:00}:{min:00}:{second:00}";
        _deathCountText.text = thisScore.DeathCount.ToString("0") + "回";
        _clearCountText.text = thisScore.ClearCount.ToString("0") + "回目の帰宅！";
    }
}
