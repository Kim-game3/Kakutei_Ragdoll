using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//フレームレートを固定

public class SetFrameRate : MonoBehaviour
{
    [SerializeField] int _frameRate;

    private void Awake()
    {
        Application.targetFrameRate = _frameRate;
    }
}
