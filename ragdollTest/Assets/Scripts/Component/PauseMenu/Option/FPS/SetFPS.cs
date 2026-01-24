using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//シーン開始時にFPSを設定

public class SetFPS : MonoBehaviour
{
    [SerializeField]
    FPSSetiingData _fpsSettingData;

    private void Start()
    {
        int fps;

        if(PlayerDataManager.TryGetFPSMode(out var mode))//既にセーブデータの中にFPSの設定があった場合
        {
            fps = GetFPS(_fpsSettingData.GetFPSData(mode));
        }
        else//無かった場合、デフォルトの値を入れる
        {
            fps = GetDefaultFPS();
        }

        Application.targetFrameRate = fps;
        return;
    }

    int GetFPS(FPSSetiingData.FPSData fpsData)
    {
        if(fpsData != null)
        {
            return fpsData.FPS;
        }
        else
        {
            return GetDefaultFPS();
        }
    }

    int GetDefaultFPS()
    {
        var data = _fpsSettingData.GetDefaultFPSData;
        return data.FPS;
    }
}
