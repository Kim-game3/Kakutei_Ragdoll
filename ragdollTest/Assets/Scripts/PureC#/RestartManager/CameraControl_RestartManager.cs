using Cinemachine;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g���̃J�����֌W�̏���

public partial class RestartManager
{
    [System.Serializable]
    class CameraControl
    {
        [CustomLabel("�Q�[�����ɑ��삷��J����")] [SerializeField]
        CinemachineVirtualCamera _playCamera;

        [CustomLabel("���X�^�[�g�n�_�̃J����")] [SerializeField]
        CinemachineVirtualCamera _restartPointCamera;

        //�v���C���[�����삷��J�����̒Ǐ]�Ώ�
        Transform _playCameraFollow;
        Transform _playCameraLookAt;
        
        //����J������POV
        CinemachinePOV _pov;

        //�v���C���[�����삷��J�����̏�������
        float _defaultVerticalValue_PlayCamera;
        float _defaultHorizontalValue_PlayCamera;

        public void Init()//������
        {
            //����J�����̏����Ǐ]�Ώۂ��L��
            _playCameraFollow=_playCamera.Follow;
            _playCameraLookAt=_playCamera.LookAt;

            //����J�����̏����������L��
            _pov = _playCamera.GetCinemachineComponent<CinemachinePOV>();

            if (_pov == null)
            {
                Debug.Log("�v���C���[�̃J������Aim��POV�ɐݒ肳��Ă��܂���I");
                return;
            }

            _defaultVerticalValue_PlayCamera = _pov.m_VerticalAxis.Value;
            _defaultHorizontalValue_PlayCamera = _pov.m_HorizontalAxis.Value;
        }

        public void SetDefault_PlayeCamera()//�v���C���[�����삷��J�����������̌����ɖ߂�
        {
            _pov.m_VerticalAxis.Value = _defaultVerticalValue_PlayCamera;
            _pov.m_HorizontalAxis.Value = _defaultHorizontalValue_PlayCamera;
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//�v���C���[�����삷��J�����̒Ǐ]�ݒ�̕ύX�AfollowPlayer�̓v���C���[��Ǐ]���邩
        {
            Transform newFollow=followPlayer? _playCameraFollow: null;
            Transform newLookAt=followPlayer? _playCameraLookAt: null;

            _playCamera.Follow=newFollow;
            _playCamera.LookAt=newLookAt;
        }

        public void SwitchRestartPointCamera(bool activeRestart)//���X�^�[�g�J�����ƃv���C�J�����̐؂�ւ��AactiveRestart�̓��X�^�[�g�J�����ɐ؂�ւ��邩
        {
            _restartPointCamera.enabled=activeRestart;
            _playCamera.enabled=!activeRestart;
        }
    }
}
