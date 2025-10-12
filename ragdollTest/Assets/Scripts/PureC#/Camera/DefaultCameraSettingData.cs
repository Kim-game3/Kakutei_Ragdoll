using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//デフォルトのカメラ操作設定

[CreateAssetMenu(fileName = "DefaultCameraSettingData", menuName = "ScriptableObjects/DefaultCameraSettingData")]
public class DefaultCameraSettingData : ScriptableObject
{
    //カメラの操作反転設定

    [Tooltip("X軸のデフォルトの反転設定")] [SerializeField]
    bool _isInvert_X;

    [Tooltip("Y軸のデフォルトの反転設定")] [SerializeField]
    bool _isInvert_Y;

    public bool IsInvert(ECameraAxis axis)
    {
        switch(axis)
        {
            case ECameraAxis.X:
                return _isInvert_X;
            case ECameraAxis.Y:
                return _isInvert_Y;
            default:
                Debug.Log("不正な呼び出しです");
                return false;
        }
    }
}
