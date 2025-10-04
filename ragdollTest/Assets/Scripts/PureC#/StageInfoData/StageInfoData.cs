using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージごとの情報を取得するデータベースクラス

[CreateAssetMenu(fileName = "StageInfoData", menuName = "ScriptableObjects/StageInfoData")]
public class StageInfoData : ScriptableObject
{
    [Tooltip("ステージごとの情報\n配列の要素番号がステージのIDになります")] [SerializeField]
    StageInfo[] _stageInfos;

    public int StageLength { get { return _stageInfos.Length; } }//登録されているステージの数

    public StageInfo GetStageInfo(int stageID)
    {
        if (!MathfExtension.IsInRange(stageID,0,_stageInfos.Length-1))
        {
            Debug.Log("範囲外の値です！");
            return null;
        }

        return _stageInfos[stageID];
    }
}
