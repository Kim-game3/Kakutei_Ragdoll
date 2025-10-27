using Cinemachine;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g���̃J�����֌W�̏���

public partial class RestartProcess
{
    [System.Serializable]
    class CameraControl
    {
        [Tooltip("�v���C���[�̂���ꏊ�ɂ���ăJ������؂�ւ���@�\")] [SerializeField]
        SwitchPlayCamera _switchPlayCamera;

        [Tooltip("�v���C�p�̃J�������܂Ƃ߂�����")] [SerializeField]
        GameObject _playCameraObjects;

        [Header("����J�����̒Ǐ]�Ώ�")]//�v���C���[�����Ė��Ȃ�
        [SerializeField]
        Transform _playCameraFollow;

        [SerializeField]
        Transform _playCameraLookAt;

        CinemachineVirtualCamera _restartPointCamera;//���X�^�[�g�n�_�̃J����

        //�v���C���[�����삷��J�����̏�������
        float _defaultVerticalValue_PlayCamera;
        float _defaultHorizontalValue_PlayCamera;

        //���X�^�[�g���n�܂����u�ԂɌĂ΂��
        public void InitOnRestart(CinemachineVirtualCamera restartPointCamera, float defaultVerticalValue_PlayCamera, float defaultHorizontalValue_PlayCamera)
        {
            _restartPointCamera = restartPointCamera;
            _defaultVerticalValue_PlayCamera= defaultVerticalValue_PlayCamera;
            _defaultHorizontalValue_PlayCamera=defaultHorizontalValue_PlayCamera;
        }

        //�Ó]����ɍs������
        public void ProcessImmediatelyAfterDark()
        {
            SwitchRestartPointCamera(true);//���X�^�[�g�n�_�̃J�����ɂ���
            SetDefault_PlayeCamera();//����J�����̌����������ɖ߂�
        }

        //���]���Ă��炵�΂炭�̌�ɍs������
        public void ProcessLaterAfterLight()
        {
            ChangeFollow_PlayCamera(true);//�J�����̃v���C���[�̒ǐՂ��ĊJ
            SwitchRestartPointCamera(false);//�v���C�J�����ɖ߂�
            _switchPlayCamera.SwitchDefaultCamera();//�f�t�H���g�̃J�����ɖ߂�
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//�v���C���[�����삷��J�����̒Ǐ]�ݒ�̕ύX�AfollowPlayer�̓v���C���[��Ǐ]���邩
        {
            Transform newFollow = followPlayer ? _playCameraFollow : null;
            Transform newLookAt = followPlayer ? _playCameraLookAt : null;

            var cameras =_switchPlayCamera.AllCameras;

            for(int i=0; i<cameras.Length ;i++)
            {
                cameras[i].Follow = newFollow;
                cameras[i].LookAt = newLookAt;
            }
        }

        void SetDefault_PlayeCamera()//�S�Ẵv���C���[�����삷��J�����������̌����ɖ߂�
        {
            var povs = _switchPlayCamera.AllPOVs;

            for(int i=0; i<povs.Length ;i++)
            {
                if(povs==null) continue;

                povs[i].m_VerticalAxis.Value = _defaultVerticalValue_PlayCamera;
                povs[i].m_HorizontalAxis.Value = _defaultHorizontalValue_PlayCamera;
            }
        }

        void SwitchRestartPointCamera(bool activeRestart)//���X�^�[�g�J�����ƃv���C�J�����̐؂�ւ��AactiveRestart�̓��X�^�[�g�J�����ɐ؂�ւ��邩
        {
            _restartPointCamera.enabled=activeRestart;
            _playCameraObjects.SetActive(!activeRestart);
        }
    }
}
