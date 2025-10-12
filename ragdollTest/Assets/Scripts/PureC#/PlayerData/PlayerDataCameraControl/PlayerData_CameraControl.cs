using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�f�[�^�̃J�������암��

public partial class PlayerDataManager
{
    //---�J��������̔��]�ݒ�---//

    readonly static Dictionary<ECameraAxis, string> _cameraInvertDataNameDic
        = new Dictionary<ECameraAxis, string>(){
            { ECameraAxis.X,"X_Invert"},//X������̔��]��Ԃ̃f�[�^��
            { ECameraAxis.Y,"Y_Invert"},//Y������̔��]��Ԃ̃f�[�^��
    };

    const int _trueNum = 1;//bool�^��int�^�ŕϊ����鎞�A���̒l�ł����true�Ƃ���
    const int _falseNum = 0;//�t�ɂ��̒l�ł����false�Ƃ���

    public static InvertCameraControlData GetInvertCameraSetting(ECameraAxis axis)//����̔��]�ݒ�̎擾(��x���������������Ƃ��Ȃ��ꍇ��null��Ԃ�)
    {
        if (!IsValidCameraAxis(axis, out var dataName)) return null;

        InvertCameraControlData ret= null;

        if (PlayerPrefs.HasKey(dataName))
        {
            //bool�^��int�^��ϊ����Ďg��
            bool _isInvert = (PlayerPrefs.GetInt(dataName) ==_trueNum);
            ret = new InvertCameraControlData(_isInvert);
        }

        return ret;
    }

    public static void SetInvertCameraSetting(ECameraAxis axis,bool value)//����̔��]�ݒ�̏�������
    {
        if (!IsValidCameraAxis(axis, out var dataName)) return;

        int data = value ? _trueNum : _falseNum;

        PlayerPrefs.SetInt(dataName, data);
    }

    static bool IsValidCameraAxis(ECameraAxis axis, out string dataName)//���݂���J�����̑��쎲�̎�ނ�����(�Ȃ�������x��)
    {
        if (!_cameraInvertDataNameDic.TryGetValue(axis, out dataName))
        {
            Debug.Log("�����Ɏ��s");
            return false;
        }

        return true;
    }
}
