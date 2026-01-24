using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//FPSの設定データ

[CreateAssetMenu(fileName = "FPSSetiingData", menuName = "ScriptableObjects/FPSSetiingData")]
public class FPSSetiingData : ScriptableObject
{
    [System.Serializable]
    public class FPSData
    {
        [Tooltip("FPSの値")] [SerializeField]
        int _fpsNum;

        [Tooltip("FPS項目名")] [SerializeField]
        string _fpsName;

        public int FPS { get { return _fpsNum; } }
        public string FPSName { get { return _fpsName; } }
    }

    [SerializeField]
    E_FPSMode _defaultFPSMode;

    [SerializeField]
    SerializableDictionary<E_FPSMode, FPSData> _fpsMode;

    public E_FPSMode GetDefaultFPSMode { get { return _defaultFPSMode; } }

    public FPSData GetDefaultFPSData { get { return _fpsMode[_defaultFPSMode]; } }//取得に失敗した場合はnullを返す

    public FPSData GetFPSData(E_FPSMode mode)
    {
        return _fpsMode[mode];
    }

    public List<KeyValuePair<E_FPSMode, FPSData>> GetAllFPSModeData()
    {
        // Dictionaryはindexを持たないため、一度Listに変換する
        var list = new List<KeyValuePair<E_FPSMode, FPSData>>(_fpsMode);

        List<KeyValuePair<E_FPSMode, FPSData>> result = new List<KeyValuePair<E_FPSMode, FPSData>>();

        for (int i = 0; i < list.Count; i++)
        {
            result.Add(list[i]);
        }

        return result;
    }
}
