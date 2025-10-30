using Cinemachine;
using UnityEngine;

//作成者:杉山
//指定のVirtualCameraがtrueになった瞬間にドリーカメラを動かすコンポーネント
//注意:PositionUnitsの設定をNormalにして使ってください

public class MoveDollyCamera : MonoBehaviour
{
    [SerializeField]
    CinemachineBrain _brain;

    [SerializeField]
    CinemachineVirtualCamera _dollyCamera;

    [Tooltip("何秒で完走するか")] [SerializeField]
    float _runDuration;

    float _current = 0;

    CinemachineTrackedDolly _dolly;//ドリー

    public bool Running { get { return _current<_runDuration; } }//動いている状態か

    private void Awake()
    {
        _brain.m_CameraActivatedEvent.AddListener(OnCameraChanged);

        _dolly =_dollyCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        _dolly.m_PathPosition = 0;

        //いきなりドリーカメラが動かないようにする
        _current = _runDuration;
    }

    void OnCameraChanged(ICinemachineCamera newCam, ICinemachineCamera oldCam)
    {
        //ドリー用のカメラに切り替わった瞬間に呼ぶ
        if (newCam.VirtualCameraGameObject != _dollyCamera.gameObject) return;

        _current = 0;
    }

    void UpdateDollyPos()
    {
        if (!Running) return;

        _current+= Time.deltaTime;

        if(_runDuration==0)
        {
            Debug.Log("RunDurationは0より大きくしてください");
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
