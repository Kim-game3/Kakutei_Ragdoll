using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//����

public class SoundVolumeData
{
    float _value;//����

    public SoundVolumeData(float value)
    {
        _value = value;
    }

    public float Value
    {
        get { return _value; }
        set {  _value = value; }
    }
}
