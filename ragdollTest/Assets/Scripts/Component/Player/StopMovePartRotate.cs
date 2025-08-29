using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//身体のパーツが回転しにくくなるようにする
//(そうすることで身体のパーツが荒ぶるのを止めることが出来る)

public class StopMovePartRotate : MonoBehaviour
{
    [Tooltip("身体のパーツのRigidbody")] [SerializeField] Rigidbody[] _bodyPartRbs;
    [Tooltip("回転のしにくさ")] [SerializeField] float _rotationalInertia;


    void Start()
    {
        StopRotate();
    }

    void StopRotate()//身体のパーツを回転しにくくする
    {
        for (int i = 0; i < _bodyPartRbs.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor *= _rotationalInertia;
        }
    }
}
