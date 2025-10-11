using Cinemachine;
using UnityEngine;

//作成者:杉山
//リスタート時のカメラ関係の処理

public partial class RestartProcess
{
    [System.Serializable]
    class CameraControl
    {
        [CustomLabel("ゲーム中に操作するカメラ")] [SerializeField]
        CinemachineVirtualCamera _playCamera;

        CinemachineVirtualCamera _restartPointCamera;//リスタート地点のカメラ

        //プレイヤーが操作するカメラの追従対象
        Transform _playCameraFollow;
        Transform _playCameraLookAt;
        
        //操作カメラのPOV
        CinemachinePOV _pov;

        //プレイヤーが操作するカメラの初期向き
        float _defaultVerticalValue_PlayCamera;
        float _defaultHorizontalValue_PlayCamera;

        public void Init()//初期化
        {
            //操作カメラの初期追従対象を記憶
            _playCameraFollow=_playCamera.Follow;
            _playCameraLookAt=_playCamera.LookAt;

            //操作カメラの初期向きを記憶
            _pov = _playCamera.GetCinemachineComponent<CinemachinePOV>();

            if (_pov == null)
            {
                Debug.Log("プレイヤーのカメラのAimがPOVに設定されていません！");
                return;
            }

            _defaultVerticalValue_PlayCamera = _pov.m_VerticalAxis.Value;
            _defaultHorizontalValue_PlayCamera = _pov.m_HorizontalAxis.Value;
        }

        //リスタートが始まった瞬間に呼ばれる
        public void InitOnRestart(CinemachineVirtualCamera restartPointCamera, float defaultVerticalValue_PlayCamera, float defaultHorizontalValue_PlayCamera)
        {
            _restartPointCamera = restartPointCamera;
            _defaultVerticalValue_PlayCamera= defaultVerticalValue_PlayCamera;
            _defaultHorizontalValue_PlayCamera=defaultHorizontalValue_PlayCamera;
        }

        public void SetDefault_PlayeCamera()//プレイヤーが操作するカメラを初期の向きに戻す
        {
            _pov.m_VerticalAxis.Value = _defaultVerticalValue_PlayCamera;
            _pov.m_HorizontalAxis.Value = _defaultHorizontalValue_PlayCamera;
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//プレイヤーが操作するカメラの追従設定の変更、followPlayerはプレイヤーを追従するか
        {
            Transform newFollow=followPlayer? _playCameraFollow: null;
            Transform newLookAt=followPlayer? _playCameraLookAt: null;

            _playCamera.Follow=newFollow;
            _playCamera.LookAt=newLookAt;
        }

        public void SwitchRestartPointCamera(bool activeRestart)//リスタートカメラとプレイカメラの切り替え、activeRestartはリスタートカメラに切り替えるか
        {
            _restartPointCamera.enabled=activeRestart;
            _playCamera.enabled=!activeRestart;
        }
    }
}
