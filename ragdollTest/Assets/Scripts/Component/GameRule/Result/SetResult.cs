using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームの結果(スコア)を確定させる

public class SetResult : MonoBehaviour
{
    [SerializeField]
    CountDeath _countDeath;

    [SerializeField]
    StopWatch _stopWatch;

    [SerializeField]
    ResultData _resultData;

    public void Set()//結果の書き込み
    {
        //死亡回数を確定
        _resultData.DeathCount = _countDeath.Count;

        //クリアタイムを確定
        _resultData.ClearTime = _stopWatch.ElapsedTime;
    }
}
