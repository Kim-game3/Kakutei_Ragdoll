using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFirstClear : MonoBehaviour
{
    [SerializeField] ShowUITypeBase _showFirstClear;
    [SerializeField] HideUITypeBase _hideFirstClear;
    [SerializeField] JudgeResultIsHighScore _judgeResultIsHighScore;
    
    IEnumerator Start()
    {
        yield return null;//JudgeResultIsHighScoreのスコア更新処理を待つ

        if (_judgeResultIsHighScore.IsFirstClear) _showFirstClear.Show();
        else _hideFirstClear.Hide();
    }
}
