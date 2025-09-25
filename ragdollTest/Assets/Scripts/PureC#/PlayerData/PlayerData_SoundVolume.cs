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
        if (!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("音量データの取得に失敗");
            return false;
        }

        return PlayerPrefs.HasKey(volumeName);
    }

    public static float GetSoundVolume(ESoundType soundType)//音量データの取得
    {
        if(!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("音量データの取得に失敗");
            return _errorVolume;
        }

        float ret = PlayerPrefs.GetFloat(volumeName);

        return ret;
    }

    public static void SetSoundVolume(ESoundType soundType,float volume)//音量データの書き換え
    {
        if (!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("存在しない音量データです");
            return;
        }

        PlayerPrefs.SetFloat(volumeName, volume);
    }

    
}
