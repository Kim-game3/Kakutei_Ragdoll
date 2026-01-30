using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//操作カメラをプレイヤーのいる場所によって切り替える
//操作カメラごと機能しないようにしたい場合は、操作カメラ達の親のPlayCameraObjectsのActiveをオフにすることで可能

public class SwitchPlayCamera : MonoBehaviour
{
    [System.Serializable]
    struct AreaPlayCamera
    {
        public CinemachineVirtualCamera playCamera;

        public SwitchCameraZone switchCameraZone;
    }

    [Tooltip("デフォルトのカメラ")] [SerializeField]
    CinemachineVirtualCamera _defaultPlayCamera;

    [Tooltip("切り替えるカメラ達")] [SerializeField]
    AreaPlayCamera[] _areaPlayCameras;

    [SerializeField]
    RespawnProcess _restartProcess;

    CinemachineVirtualCamera[] _playCameras;
    CinemachinePOV[] _povs;
    int _currentCameraIndex;

    const int _defaultCameraIndex = 0;//デフォルトの操作カメラの番号

    //起動中の操作カメラのVirtualCameraを取得
    public CinemachineVirtualCamera CurrentCamera { get { return _playCameras[_currentCameraIndex]; } }

    //起動中の操作カメラのPOVを取得(POVを使っていない場合、nullが入る)
    public CinemachinePOV CurrentPOV { get { return _povs[_currentCameraIndex]; } }

    //全ての操作カメラのVirtualCameraを取得
    public CinemachineVirtualCamera[] AllCameras { get { return _playCameras; } }

    //全ての操作カメラのPOVを取得(POVを使っていない場合、nullが入る)
    public CinemachinePOV[] AllPOVs { get { return _povs; } }

    public void SwitchDefaultCamera()//デフォルトのカメラに切り替える
    {
        ActivatePlayCamera(_defaultCameraIndex);
    }

    private void Awake()
    {
        //全ての操作カメラを格納

        //デフォルトの操作カメラ分も含めて1を足す
        _playCameras = new CinemachineVirtualCamera[_areaPlayCameras.Length + 1];
        _povs=new CinemachinePOV[_areaPlayCameras.Length + 1];

        _playCameras[_defaultCameraIndex] = _defaultPlayCamera;
        _povs[_defaultCameraIndex] = _playCameras[_defaultCameraIndex].GetCinemachineComponent<CinemachinePOV>();

        for(int i=0; i<_areaPlayCameras.Length ;i++)
        {
            int index = i + 1;

            if (_areaPlayCameras[i].playCamera==null || _areaPlayCameras[i].switchCameraZone==null)
            {
                Debug.Log(i+"番の要素が正しく設定されていません！");
                continue;
            }

            _playCameras[index] = _areaPlayCameras[i].playCamera;
            _povs[index] = _playCameras[index].GetCinemachineComponent<CinemachinePOV>();

            SwitchCameraZone zone = _areaPlayCameras[i].switchCameraZone;

            zone.CameraIndex = index;//カメラ番号を設定

            //コールバックを設定
            zone.OnEnterPlayer += OnPlayerEnterSwitchZone;
            zone.OnExitPlayer += OnPlayerExitSwitchZone;
        }
    }

    private void Start()
    {
        //初期はデフォルトのカメラに設定
        ActivatePlayCamera(_defaultCameraIndex);
    }

    void OnPlayerEnterSwitchZone(int cameraIndex)//カメラ切り替えゾーンにプレイヤーが侵入した時
    {
        if (_restartProcess.IsRestarting) return;//リスタート中なら無視

        ActivatePlayCamera(cameraIndex);
    }

    void OnPlayerExitSwitchZone(int cameraIndex)//カメラ切り替えゾーンからプレイヤーが脱出した時
    {
        if (_restartProcess.IsRestarting) return;//リスタート中なら無視

        //デフォルトのカメラに戻す
        ActivatePlayCamera(_defaultCameraIndex);
    }

    void ActivatePlayCamera(int cameraIndex)
    {
        CameraAxisHandOver(cameraIndex);

        _currentCameraIndex = cameraIndex;

        //指定された番号以外の操作カメラは非アクティブにする
        for(int i=0; i<_playCameras.Length ;i++)
        {
            _playCameras[i].enabled = (i == cameraIndex);
        }
    }

    void CameraAxisHandOver(int newCameraIndex)//カメラの向きを新しいカメラに引き継ぐ(値をコピーする)
    {
        CinemachinePOV currentPOV = _povs[_currentCameraIndex];
        CinemachinePOV newPOV = _povs[newCameraIndex];

        if (currentPOV == null || newPOV == null) return;

        newPOV.m_VerticalAxis.Value = currentPOV.m_VerticalAxis.Value;
        newPOV.m_HorizontalAxis.Value=currentPOV.m_HorizontalAxis.Value;
    }
}
