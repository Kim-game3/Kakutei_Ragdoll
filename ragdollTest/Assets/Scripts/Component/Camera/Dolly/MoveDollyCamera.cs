using Cinemachine;
using UnityEngine;

//�쐬��:���R
//�w���VirtualCamera��true�ɂȂ����u�ԂɃh���[�J�����𓮂����R���|�[�l���g
//����:PositionUnits�̐ݒ��Normal�ɂ��Ďg���Ă�������

public class MoveDollyCamera : MonoBehaviour
{
    [SerializeField]
    CinemachineBrain _brain;

    [SerializeField]
    CinemachineVirtualCamera _dollyCamera;

    [Tooltip("���b�Ŋ������邩")] [SerializeField]
    float _runDuration;

    float _current = 0;

    CinemachineTrackedDolly _dolly;//�h���[

    public bool Running { get { return _current<_runDuration; } }//�����Ă����Ԃ�

    private void Awake()
    {
        _brain.m_CameraActivatedEvent.AddListener(OnCameraChanged);

        _dolly =_dollyCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        _dolly.m_PathPosition = 0;

        //�����Ȃ�h���[�J�����������Ȃ��悤�ɂ���
        _current = _runDuration;
    }

    void OnCameraChanged(ICinemachineCamera newCam, ICinemachineCamera oldCam)
    {
        //�h���[�p�̃J�����ɐ؂�ւ�����u�ԂɌĂ�
        if (newCam.VirtualCameraGameObject != _dollyCamera.gameObject) return;

        _current = 0;
    }

    void UpdateDollyPos()
    {
        if (!Running) return;

        _current+= Time.deltaTime;

        if(_runDuration==0)
        {
            Debug.Log("RunDuration��0���傫�����Ă�������");
            return;
        }

        _dolly.m_PathPosition = _current / _runDuration;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDollyPos();
    }
}
