using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーデータの音量部分

public partial class PlayerDataManager
{
    //---音量関係---//
    readonly static Dictionary<ESoundType, string> _soundTypeNameDic
        = new Dictionary<ESoundType, string>(){
            { ESoundType.Master,"MasterVolume"},//マスター音量のデータ名
            { ESoundType.SE,"SEVolume"},//SE音量のデータ名
            {ESoundType.BGM,"BGMVolume"},//BGM音量のデータ名
    };

    const float _errorVolume = 0f;//エラー時にとりあえず返す音量の値

    public static bool HaveSetSoundVolume(ESoundType soundType)//一度でも書き換えがあったか
    {
        if (!IsValidSoundType(soundType, out var volumeName)) return false;

        return PlayerPrefs.HasKey(volumeName);
    }

    public static float GetSoundVolume(ESoundType soundType)//音量データの取得
    {
        if (!IsValidSoundType(soundType, out var volumeName)) return _errorVolume;

        float ret = PlayerPrefs.GetFloat(volumeName);

        return ret;
    }

    public static void SetSoundVolume(ESoundType soundType,float volume)//音量データの書き換え
    {
        if (!IsValidSoundType(soundType, out var volumeName)) return;   

        PlayerPrefs.SetFloat(volumeName, volume);
    }

    static bool IsValidSoundType(ESoundType soundType, out string volumeName)//存在する音の種類か見る(なかったら警告)
    {
        if (!_soundTypeNameDic.TryGetValue(soundType,out volumeName))
        {
            Debug.Log("処理に失敗");
            return false;
        }

        return true;
    }

    
}
