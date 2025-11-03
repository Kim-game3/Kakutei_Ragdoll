using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFirstClear : MonoBehaviour
{
    [SerializeField] ShowUITypeBase _showFirstClear;
    [SerializeField] HideUITypeBase _hideFirstClear;
    const int _firstClearCount = 1;
    
    IEnumerator Start()
    {
        yield return null;//JudgeResultIsHighScoreのスコア更新処理を待つ

        //今回のスコアを取得
        ScoreData thisScoreData = ResultManager.Score;

        if (thisScoreData == null)//そもそもクリアしていない(通常では起こりえない)
        {
            _hideFirstClear.Hide();
            yield break;
        }

        if (thisScoreData.ClearCount == _firstClearCount) _showFirstClear.Show();
        else _hideFirstClear.Hide();
    }
}
