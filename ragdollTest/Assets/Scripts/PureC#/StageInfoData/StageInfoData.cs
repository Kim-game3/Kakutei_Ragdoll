using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

//作成者:杉山
//ステージごとの情報を取得するデータベースクラス

[CreateAssetMenu(fileName = "StageInfoData", menuName = "ScriptableObjects/StageInfoData")]
public class StageInfoData : ScriptableObject
{
    [Tooltip("ステージごとの情報\n配列の要素番号がステージのIDになります")] [SerializeField]
    SerializableDictionary<EStageID, StageInfo> _stageInfos;

    public int StageLength { get { return _stageInfos.Count; } }//登録されているステージの数

    public StageInfo GetStageInfo(EStageID stageID)//存在しないIDの場合は、nullが返される
    {
        if (stageID == EStageID.Length || !System.Enum.IsDefined(typeof(EStageID), stageID)) return null;//存在しないIDであれば弾く
        if (!_stageInfos.TryGetValue(stageID,out var stageInfo)) return null;//ステージのデータが見つからなければ無視

        return stageInfo;
    }
}
