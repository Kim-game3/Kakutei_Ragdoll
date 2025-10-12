using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�f�t�H���g�̃J��������ݒ�

[CreateAssetMenu(fileName = "DefaultCameraSettingData", menuName = "ScriptableObjects/DefaultCameraSettingData")]
public class DefaultCameraSettingData : ScriptableObject
{
    //�J�����̑��씽�]�ݒ�

    [Tooltip("X���̃f�t�H���g�̔��]�ݒ�")] [SerializeField]
    bool _isInvert_X;

    [Tooltip("Y���̃f�t�H���g�̔��]�ݒ�")] [SerializeField]
    bool _isInvert_Y;

    public bool IsInvert(ECameraAxis axis)
    {
        switch(axis)
        {
            case ECameraAxis.X:
                return _isInvert_X;
            case ECameraAxis.Y:
                return _isInvert_Y;
            default:
                Debug.Log("�s���ȌĂяo���ł�");
                return false;
        }
    }
}
