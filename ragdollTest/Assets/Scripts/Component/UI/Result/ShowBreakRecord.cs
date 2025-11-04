using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//記録更新を表示

public class ShowBreakRecord : MonoBehaviour
{
    [SerializeField] ShowUITypeBase _showBreakRecord;
    [SerializeField] HideUITypeBase _hideBreakRecord;
    [SerializeField] JudgeResultIsHighScore _judgeResultIsHighScore;

    IEnumerator Start()
    {
        yield return null;//JudgeResultIsHighScoreのスコア更新処理を待つ

        if (_judgeResultIsHighScore.BrokeRecord)
        {
            _showBreakRecord.Show();
        }
        else
        {
            _hideBreakRecord.Hide();
        }
    }
}
