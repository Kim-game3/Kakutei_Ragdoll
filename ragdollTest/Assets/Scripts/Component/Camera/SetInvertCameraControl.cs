using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�J�����̑��������ύX����
//����J�����̑��݂���Q�[���V�[���ɒu���Ă�������

public class SetInvertCameraControl : MonoBehaviour
{
    [Tooltip("����J����")] [SerializeField]
    CinemachineVirtualCamera _playCamera;

    [Tooltip("�f�t�H���g�̃J�����ݒ�")] [SerializeField]
    DefaultCameraSettingData _defaultCameraSettingData;

    CinemachinePOV _pov;

    private void Awake()
    {
        _pov=_playCamera.GetCinemachineComponent<CinemachinePOV>();

        if (_pov == null) Debug.Log("Vcam����POV���擾�ł��܂���ł���");//�擾�Ɏ��s�������Ɍx�����Ă���
    }

    public void SetInvert(ECameraAxis axis,bool _isInvert)//���]�ݒ�̏��������A�Z�[�u�f�[�^�ւ̋L�^�͌Ăяo�����ōs��
    {
        switch(axis)
        {
            case ECameraAxis.X:
                _pov.m_HorizontalAxis.m_InvertInput=_isInvert;
                break;

            case ECameraAxis.Y:
                _pov.m_VerticalAxis.m_InvertInput=_isInvert;
                break;

            default:
                Debug.Log("�z��O�̏����ł��B");
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //����J�����̏�����

        //X��
        InvertCameraControlData saveData_X = PlayerDataManager.GetInvertCameraSetting(ECameraAxis.X);
        _pov.m_HorizontalAxis.m_InvertInput = (saveData_X != null) ? saveData_X.Value : _defaultCameraSettingData.IsInvert(ECameraAxis.X);

        //Y��
        InvertCameraControlData saveData_Y = PlayerDataManager.GetInvertCameraSetting(ECameraAxis.Y);
        _pov.m_VerticalAxis.m_InvertInput = (saveData_Y != null) ? saveData_Y.Value : _defaultCameraSettingData.IsInvert(ECameraAxis.Y);

    }
}
