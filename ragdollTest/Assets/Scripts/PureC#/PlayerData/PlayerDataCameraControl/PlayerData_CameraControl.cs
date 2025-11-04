using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーデータのカメラ操作部分

public partial class PlayerDataManager
{
    //---カメラ操作の反転設定---//

    readonly static Dictionary<ECameraAxis, string> _cameraInvertDataNameDic
        = new Dictionary<ECameraAxis, string>(){
            { ECameraAxis.X,"X_INVERT"},//X軸操作の反転状態のデータ名
            { ECameraAxis.Y,"Y_INVERT"},//Y軸操作の反転状態のデータ名
    };

    const int _trueNum = 1;//bool型とint型で変換する時、この値であればtrueとする
    const int _falseNum = 0;//逆にこの値であればfalseとする

    public static InvertCameraControlData GetInvertCameraSetting(ECameraAxis axis)//操作の反転設定の取得(一度も書き換えたことがない場合はnullを返す)
    {
        if (!IsValidCameraAxis(axis, out var dataName)) return null;

        InvertCameraControlData ret= null;

        if (PlayerPrefs.HasKey(dataName))
        {
            //bool型とint型を変換して使う
            bool _isInvert = (PlayerPrefs.GetInt(dataName) ==_trueNum);
            ret = new InvertCameraControlData(_isInvert);
        }

        return ret;
    }

    public static void SetInvertCameraSetting(ECameraAxis axis,bool value)//操作の反転設定の書き換え
    {
        if (!IsValidCameraAxis(axis, out var dataName)) return;

        int data = value ? _trueNum : _falseNum;

        PlayerPrefs.SetInt(dataName, data);
    }

    static bool IsValidCameraAxis(ECameraAxis axis, out string dataName)//存在するカメラの操作軸の種類か見る(なかったら警告)
    {
        if (!_cameraInvertDataNameDic.TryGetValue(axis, out dataName))
        {
            Debug.Log("処理に失敗");
            return false;
        }

        return true;
    }
}
