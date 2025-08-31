using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//身体のパーツが回転しにくくなるようにする
//(そうすることで身体のパーツが荒ぶるのを止めることが出来る)

public class StopMovePartRotate : MonoBehaviour
{
    [CustomLabel("身体のパーツのRigidbody")] [SerializeField]
    Rigidbody[] _bodyPartRbs;
    [Tooltip("1だと変化なし")] [CustomLabel("回転のしにくさ")] [SerializeField]
    float _rotationalInertia;

    Vector3[] _defaultInertiaTensors;//初期の慣性テンソルの値

    private void Awake()
    {
        _defaultInertiaTensors = new Vector3[_bodyPartRbs.Length];

        //初期の慣性テンソルの値を記録
        for(int i=0; i<_defaultInertiaTensors.Length ;i++)
        {
            _defaultInertiaTensors[i] = _bodyPartRbs[i].inertiaTensor;
        }
    }

    void Start()
    {
        StopRotate();
    }

    //private void OnValidate()
    //{
    //    StopRotate();
    //}

    void StopRotate()//身体のパーツを回転しにくくする
    {
        if (_defaultInertiaTensors == null || _bodyPartRbs==null) return;

        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor = _defaultInertiaTensors[i]*_rotationalInertia;
        }
    }
}
