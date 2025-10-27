using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//カメラの操作方向を変更する
//操作カメラの存在するゲームシーンに置いてください

public class SetInvertCameraControl : MonoBehaviour
{
    [Tooltip("操作カメラ")] [SerializeField]
    CinemachineVirtualCamera _playCamera;

    [Tooltip("デフォルトのカメラ設定")] [SerializeField]
    DefaultCameraSettingData _defaultCameraSettingData;

    CinemachinePOV _pov;

    private void Awake()
    {
        _pov=_playCamera.GetCinemachineComponent<CinemachinePOV>();

        if (_pov == null) Debug.Log("VcamからPOVが取得できませんでした");//取得に失敗した時に警告しておく
    }

    public void SetInvert(ECameraAxis axis,bool _isInvert)//反転設定の書き換え、セーブデータへの記録は呼び出し側で行う
    {
        switch(axis)
        {
            case ECameraAxis.X:
                _pov.m_HorizontalAxis.m_InvertInput=_isInvert;
                break;

            case ECameraAxis.Y:
                _pov.m_VerticalAxis.m_InvertInput=_isInvert;
                break;

            default:
                Debug.Log("想定外の処理です。");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //操作カメラの初期化

        //X軸
        InvertCameraControlData saveData_X = PlayerDataManager.GetInvertCameraSetting(ECameraAxis.X);
        _pov.m_HorizontalAxis.m_InvertInput = (saveData_X != null) ? saveData_X.Value : _defaultCameraSettingData.IsInvert(ECameraAxis.X);

        //Y軸
        InvertCameraControlData saveData_Y = PlayerDataManager.GetInvertCameraSetting(ECameraAxis.Y);
        _pov.m_VerticalAxis.m_InvertInput = (saveData_Y != null) ? saveData_Y.Value : _defaultCameraSettingData.IsInvert(ECameraAxis.Y);

    }
}
