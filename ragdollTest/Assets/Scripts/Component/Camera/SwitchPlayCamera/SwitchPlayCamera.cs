using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//����J�������v���C���[�̂���ꏊ�ɂ���Đ؂�ւ���
//����J�������Ƌ@�\���Ȃ��悤�ɂ������ꍇ�́A����J�����B�̐e��PlayCameraObjects��Active���I�t�ɂ��邱�Ƃŉ\

public class SwitchPlayCamera : MonoBehaviour
{
    [System.Serializable]
    struct AreaPlayCamera
    {
        public CinemachineVirtualCamera playCamera;

        public SwitchCameraZone switchCameraZone;
    }

    [Tooltip("�f�t�H���g�̃J����")] [SerializeField]
    CinemachineVirtualCamera _defaultPlayCamera;

    [Tooltip("�؂�ւ���J�����B")] [SerializeField]
    AreaPlayCamera[] _areaPlayCameras;

    [SerializeField]
    RestartProcess _restartProcess;

    CinemachineVirtualCamera[] _playCameras;
    CinemachinePOV[] _povs;
    int _currentCameraIndex;

    const int _defaultCameraIndex = 0;//�f�t�H���g�̑���J�����̔ԍ�

    //�N�����̑���J������VirtualCamera���擾
    public CinemachineVirtualCamera CurrentCamera { get { return _playCameras[_currentCameraIndex]; } }

    //�N�����̑���J������POV���擾(POV���g���Ă��Ȃ��ꍇ�Anull������)
    public CinemachinePOV CurrentPOV { get { return _povs[_currentCameraIndex]; } }

    //�S�Ă̑���J������VirtualCamera���擾
    public CinemachineVirtualCamera[] AllCameras { get { return _playCameras; } }

    //�S�Ă̑���J������POV���擾(POV���g���Ă��Ȃ��ꍇ�Anull������)
    public CinemachinePOV[] AllPOVs { get { return _povs; } }

    public void SwitchDefaultCamera()//�f�t�H���g�̃J�����ɐ؂�ւ���
    {
        ActivatePlayCamera(_defaultCameraIndex);
    }

    private void Awake()
    {
        //�S�Ă̑���J�������i�[

        //�f�t�H���g�̑���J���������܂߂�1�𑫂�
        _playCameras = new CinemachineVirtualCamera[_areaPlayCameras.Length + 1];
        _povs=new CinemachinePOV[_areaPlayCameras.Length + 1];

        _playCameras[_defaultCameraIndex] = _defaultPlayCamera;
        _povs[_defaultCameraIndex] = _playCameras[_defaultCameraIndex].GetCinemachineComponent<CinemachinePOV>();

        for(int i=0; i<_areaPlayCameras.Length ;i++)
        {
            int index = i + 1;

            if (_areaPlayCameras[i].playCamera==null || _areaPlayCameras[i].switchCameraZone==null)
            {
                Debug.Log(i+"�Ԃ̗v�f���������ݒ肳��Ă��܂���I");
                continue;
            }

            _playCameras[index] = _areaPlayCameras[i].playCamera;
            _povs[index] = _playCameras[index].GetCinemachineComponent<CinemachinePOV>();

            SwitchCameraZone zone = _areaPlayCameras[i].switchCameraZone;

            zone.CameraIndex = index;//�J�����ԍ���ݒ�

            //�R�[���o�b�N��ݒ�
            zone.OnEnterPlayer += OnPlayerEnterSwitchZone;
            zone.OnExitPlayer += OnPlayerExitSwitchZone;
        }
    }

    private void Start()
    {
        //�����̓f�t�H���g�̃J�����ɐݒ�
        ActivatePlayCamera(_defaultCameraIndex);
    }

    void OnPlayerEnterSwitchZone(int cameraIndex)//�J�����؂�ւ��]�[���Ƀv���C���[���N��������
    {
        if (_restartProcess.IsRestarting) return;//���X�^�[�g���Ȃ疳��

        ActivatePlayCamera(cameraIndex);
    }

    void OnPlayerExitSwitchZone(int cameraIndex)//�J�����؂�ւ��]�[������v���C���[���E�o������
    {
        if (_restartProcess.IsRestarting) return;//���X�^�[�g���Ȃ疳��

        //�f�t�H���g�̃J�����ɖ߂�
        ActivatePlayCamera(_defaultCameraIndex);
    }

    void ActivatePlayCamera(int cameraIndex)
    {
        CameraAxisHandOver(cameraIndex);

        _currentCameraIndex = cameraIndex;

        //�w�肳�ꂽ�ԍ��ȊO�̑���J�����͔�A�N�e�B�u�ɂ���
        for(int i=0; i<_playCameras.Length ;i++)
        {
            _playCameras[i].enabled = (i == cameraIndex);
        }
    }

    void CameraAxisHandOver(int newCameraIndex)//�J�����̌�����V�����J�����Ɉ����p��(�l���R�s�[����)
    {
        CinemachinePOV currentPOV = _povs[_currentCameraIndex];
        CinemachinePOV newPOV = _povs[newCameraIndex];

        if (currentPOV == null || newPOV == null) return;

        newPOV.m_VerticalAxis.Value = currentPOV.m_VerticalAxis.Value;
        newPOV.m_HorizontalAxis.Value=currentPOV.m_HorizontalAxis.Value;
    }
}
