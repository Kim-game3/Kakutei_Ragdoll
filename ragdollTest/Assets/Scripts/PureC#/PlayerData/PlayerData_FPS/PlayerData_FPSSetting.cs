//作成者:杉山
//プレイヤーデータのFPSの設定

using System;
using UnityEngine;

//作成者:杉山
//プレイヤーデータのFPS設定部分

public partial class PlayerDataManager
{
    const string _fpsDataName = "FPS_MODE";

    public static bool TryGetFPSMode(out E_FPSMode mode)
    {
        mode = E_FPSMode.FPS144;

        if (!PlayerPrefs.HasKey(_fpsDataName)) return false;

        int fpsMode = PlayerPrefs.GetInt(_fpsDataName);

        mode = (E_FPSMode)fpsMode;
        return true;
    }

    public static void SetFPSMode(E_FPSMode mode)
    {
        if (mode == E_FPSMode.Length || !Enum.IsDefined(typeof(E_FPSMode), mode)) return;

        PlayerPrefs.SetInt(_fpsDataName, (int)mode);
    }
}
