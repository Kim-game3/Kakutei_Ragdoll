using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�����o���@�\

public class Wind : MonoBehaviour
{
    [Tooltip("�����o������")] [SerializeField]
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
