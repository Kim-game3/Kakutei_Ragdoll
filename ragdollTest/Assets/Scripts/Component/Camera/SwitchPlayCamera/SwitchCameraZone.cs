using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//作成者:杉山
//プレイヤーのカメラ切り替えゾーンの侵入・脱出を検知する機能

public class SwitchCameraZone : MonoBehaviour
{
    public event Action<int> OnEnterPlayer;//プレイヤーがカメラ切り替えゾーンに侵入したことを通知
    public event Action<int> OnExitPlayer;//プレイヤーがカメラ切り替えゾーンから脱出したことを通知

    int _cameraIndex;

    public int CameraIndex
    {
        get { return _cameraIndex; }
        set { _cameraIndex = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        OnEnterPlayer?.Invoke(_cameraIndex);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        OnExitPlayer?.Invoke(_cameraIndex);
    }
}
