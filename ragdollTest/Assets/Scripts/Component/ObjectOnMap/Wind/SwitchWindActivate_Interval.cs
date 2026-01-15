using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//周期で風のアクティブ状態を切り替える

public class SwitchWindActivate_Interval : MonoBehaviour
{
    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    [SerializeField]
    Wind _wind;

    private void OnEnable()
    {
        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;
    }

    private void OnDisable()
    {
        _windCycle.OnTrue -= OnBlowWind;
        _windCycle.OnFalse -= OnStopWind;
    }

    private void OnBlowWind()//風が吹き始める
    {
        _wind.enabled = true;
    }

    private void OnStopWind()//風が止む
    {
        _wind.enabled = false;
    }

    private void Update()
    {
        _windCycle.Update();
    }
}
