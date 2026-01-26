using System.Collections.Generic;

//作成者:杉山
//ステージごとのセーブデータリスト(JSONとのやり取りのため、フィールドをpublicにしている)

[System.Serializable]
public class StageSaveDataList
{
    public List<StageSaveData> stageSaveDataList = new List<StageSaveData>();
}
