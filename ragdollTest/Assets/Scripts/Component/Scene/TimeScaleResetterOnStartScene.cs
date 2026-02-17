using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//シーン開始時にTimeScaleを1に戻す

public class TimeScaleResetterOnStartScene : MonoBehaviour
{
    const float _defaultTimeScale = 1;

    void Start()
    {
        ResetTimeScale();
    }

    void ResetTimeScale()
    {
        Time.timeScale = _defaultTimeScale;
    }
}
