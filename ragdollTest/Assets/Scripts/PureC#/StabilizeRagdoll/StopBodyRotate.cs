using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//身体のパーツが回転しにくくなるようにする
//(そうすることで身体のパーツが荒ぶるのを止めることが出来る)

[System.Serializable]
public class StopBodyRotate
{
    [Tooltip("デフォルトは1")] [CustomLabel("回転のしにくさ")] [SerializeField]
    float _rotationalInertia;

    Vector3[] _defaultInertiaTensors;//初期の慣性テンソルの値

    public void Init(Rigidbody[] _bodyPartRbs)//初期化処理
    {
        _defaultInertiaTensors = new Vector3[_bodyPartRbs.Length];

        //初期の慣性テンソルの値を記録
        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _defaultInertiaTensors[i] = _bodyPartRbs[i].inertiaTensor;
        }
    }

    public void StopRotate(Rigidbody[] _bodyPartRbs)//身体のパーツの回転を止める
    {
        if (_defaultInertiaTensors == null || _bodyPartRbs == null) return;

        for (int i = 0; i < _defaultInertiaTensors.Length; i++)
        {
            _bodyPartRbs[i].inertiaTensor = _defaultInertiaTensors[i] * _rotationalInertia;
        }
    }
}
