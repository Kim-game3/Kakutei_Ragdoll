using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//リザルトデータ(シーンを跨いで渡す用)
//注意点:遷移シーン先で一度も使わないと、データがリセットされます

[CreateAssetMenu(fileName = "ResultData", menuName = "ScriptableObjects/ResultData")]
public class ResultData : ScriptableObject
{
    float _clearTime;//クリアタイム
    int _deathCount;//デス数(水に落ちた回数)

    public float ClearTime
    {
        get { return _clearTime; }
        set { _clearTime = value; }
    }

    public int DeathCount
    {
        get { return _deathCount; }
        set { _deathCount = value; }
    }
}
