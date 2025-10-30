using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//トグルからのカメラの反転設定の変更

public class ChangeCameraInvert_Toggle : MonoBehaviour
{
    [Tooltip("カメラの軸の種類")] [SerializeField]
    ECameraAxis _axis;

    [Tooltip("使用するトグル")] [SerializeField]
    Toggle _toggle;

    [Tooltip("カメラの反転設定を変更する機能\nない場合は入れなくてもよい")] [SerializeField]
    SetInvertCameraControl _setInvertCameraControl;

    [Tooltip("デフォルトのカメラ設定")] [SerializeField]
    DefaultCameraSettingData _defaultCameraSettingData;

    public void Change(bool value)
    {
        if(_setInvertCameraControl!=null) _setInvertCameraControl.SetInvert(_axis, value);

        PlayerDataManager.SetInvertCameraSetting(_axis, value);//セーブデータにも保存
    }

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(Change);
    }


    void Start()
    {
        //トグルの状態を初期化
        InvertCameraControlData saveData = PlayerDataManager.GetInvertCameraSetting(_axis);

        _toggle.isOn = (saveData != null) ? saveData.Value : _defaultCameraSettingData.IsInvert(_axis);
    }
}
