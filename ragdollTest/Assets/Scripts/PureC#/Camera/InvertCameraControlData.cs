using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�J�����̑��씽�]�ݒ�̃f�[�^

public class InvertCameraControlData
{
    bool _value;

    public bool Value { get { return _value; } }

    public InvertCameraControlData(bool value)
    {
        _value = value;
    }
}
