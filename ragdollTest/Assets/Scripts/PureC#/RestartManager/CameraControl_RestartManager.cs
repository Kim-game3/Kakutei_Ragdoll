using Cinemachine;
using UnityEngine;

//作成者:杉山
//リスタート時のカメラ関係の処理

public partial class RestartManager
{
    [System.Serializable]
    class CameraControl
    {
        [CustomLabel("ゲーム中に操作するカメラ")] [SerializeField]
        CinemachineVirtualCamera _playCamera;

        [CustomLabel("リスタート地点のカメラ")] [SerializeField]
        CinemachineVirtualCamera _restartPointCamera;

        //プレイヤーが操作するカメラの追従対象
        Transform _playCameraFollow;
        Transform _playCameraLookAt;

        public void Init()//初期化
        {
            _playCameraFollow=_playCamera.Follow;
            _playCameraLookAt=_playCamera.LookAt;
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//プレイヤーが操作するカメラの追従設定の変更、followPlayerはプレイヤーを追従するか
        {
            Transform newFollow=followPlayer? _playCameraFollow: null;
            Transform newLookAt=followPlayer? _playCameraLookAt: null;

            _playCamera.Follow=newFollow;
            _playCameraLookAt=newLookAt;
        }

        public void SwitchRestartPointCamera(bool activeRestart)//リスタートカメラとプレイカメラの切り替え、activeRestartはリスタートカメラに切り替えるか
        {
            _restartPointCamera.enabled=activeRestart;
            _playCamera.enabled=!activeRestart;
        }
    }
}
