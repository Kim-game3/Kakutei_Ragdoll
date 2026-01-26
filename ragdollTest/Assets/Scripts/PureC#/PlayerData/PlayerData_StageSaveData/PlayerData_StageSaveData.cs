using System.IO;
using UnityEngine;

//作成者:杉山
//プレイヤーデータのステージごとのセーブデータ
//ステージごとに最速クリアタイム、総プレイ時間、トータルデス数、クリア回数を記録

public partial class PlayerDataManager
{
    static string _path = Path.Combine(Application.persistentDataPath, "stageSaveData.json");

    public static StageSaveData Load(EStageID stageID)//指定ステージのセーブデータのロード(取得)
    {
        StageSaveDataList dataList = GetAllData();

        //指定IDのステージデータを探す
        StageSaveData data = dataList.stageSaveDataList.Find(d => d.stageID == stageID);

        if(data==null)//初回(まだ指定IDのステージデータを作っていない)の場合
        {
            data = new StageSaveData();
            data.stageID = stageID;
        }

        return data;
    }

    public static void Save(StageSaveData newData)//セーブ、クリア回数などの計算はこっちでしないため、呼び出し側で行うこと(newDataの中に入れる)
    {
        StageSaveDataList dataList = GetAllData();

        //指定IDのステージデータを探す
        int index = dataList.stageSaveDataList.FindIndex(d => d.stageID == newData.stageID);

        if (index < 0)//初回(まだ指定IDのステージデータを作っていない)の場合
        {
            dataList.stageSaveDataList.Add(newData);
        }
        else//既にある場合
        {
            dataList.stageSaveDataList[index] = newData;
        }

        string json = JsonUtility.ToJson(dataList, true);
        File.WriteAllText(_path, json);
    }

    static StageSaveDataList GetAllData()
    {
        if (!File.Exists(_path))
        {
            return new StageSaveDataList();
        }

        string json = File.ReadAllText(_path);

        try
        {
            return JsonUtility.FromJson<StageSaveDataList>(json);
        }
        catch
        {
            return new StageSaveDataList();
        }
    }
}
