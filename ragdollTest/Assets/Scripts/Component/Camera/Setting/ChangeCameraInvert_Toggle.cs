using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�g�O������̃J�����̔��]�ݒ�̕ύX

public class ChangeCameraInvert_Toggle : MonoBehaviour
{
    [Tooltip("�J�����̎��̎��")] [SerializeField]
    ECameraAxis _axis;

    [Tooltip("�g�p����g�O��")] [SerializeField]
    Toggle _toggle;

    [Tooltip("�J�����̔��]�ݒ��ύX����@�\\n�Ȃ��ꍇ�͓���Ȃ��Ă��悢")] [SerializeField]
    SetInvertCameraControl _setInvertCameraControl;

    [Tooltip("�f�t�H���g�̃J�����ݒ�")] [SerializeField]
    DefaultCameraSettingData _defaultCameraSettingData;

    public void Change(bool value)
    {
        if(_setInvertCameraControl!=null) _setInvertCameraControl.SetInvert(_axis, value);

        PlayerDataManager.SetInvertCameraSetting(_axis, value);//�Z�[�u�f�[�^�ɂ��ۑ�
    }

    private void Awake()
    {
        _toggle.onValueChanged.AddListener(Change);
    }


    void Start()
    {
        //�g�O���̏�Ԃ�������
        InvertCameraControlData saveData = PlayerDataManager.GetInvertCameraSetting(_axis);

        _toggle.isOn = (saveData != null) ? saveData.Value : _defaultCameraSettingData.IsInvert(_axis);
    }
}
