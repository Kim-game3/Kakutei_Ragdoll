using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�t���[�����[�g���Œ�

public class SetFrameRate : MonoBehaviour
{
    [SerializeField] int _frameRate;

    private void Awake()
    {
        Application.targetFrameRate = _frameRate;
    }
}
