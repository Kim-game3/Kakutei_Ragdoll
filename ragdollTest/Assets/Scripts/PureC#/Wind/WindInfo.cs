using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̏��

public class WindInfo
{
    Vector3 _direction;//���[���h�
    float _power;

    public WindInfo(Vector3 direction, float power)
    {
        _direction = direction;
        _power = power;
    }

    public Vector3 ForceVec { get { return Direction * Power; } }

    public Vector3 Direction 
    { 
        get { return _direction.normalized; }
        set {  _direction = value; }
    }

    public float Power
    {
        get { return _power; } 
        set { _power = value; }
    }
}
