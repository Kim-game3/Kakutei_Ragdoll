//作成者:杉山
//ステージごとのセーブデータ(JSONとのやり取りのため、フィールドをpublicにしている)

[System.Serializable]
public class StageSaveData
{
    public EStageID stageID;//ステージID
    public float bestClearTime = 0;//最速クリアタイム
    public long totalPlayTime = 0;//総プレイ時間
    public int totalDeathCount = 0;//総死亡回数
    public int clearCount = 0;//クリア回数
    public int totalScreamCount = 0;//鳴いた合計回数
}
