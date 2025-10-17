using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風を出す機能

public class Wind : MonoBehaviour
{
    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _windCycle.Update();

        Debug.Log(_windCycle.IsActive);
    }
}
