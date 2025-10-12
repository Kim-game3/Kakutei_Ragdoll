using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//カメラの操作反転設定のデータ

public class InvertCameraControlData
{
    bool _value;

    public bool Value { get { return _value; } }

    public InvertCameraControlData(bool value)
    {
        _value = value;
    }
}
