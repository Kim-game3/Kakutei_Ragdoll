using Cinemachine;
using UnityEngine;

//作成者:杉山
//リスタート時のカメラ関係の処理

public partial class RespawnProcess
{
    [System.Serializable]
    class CameraControl
    {
        [Tooltip("プレイヤーのいる場所によってカメラを切り替える機能")] [SerializeField]
        SwitchPlayCamera _switchPlayCamera;

        [Tooltip("プレイ用のカメラをまとめたもの")] [SerializeField]
        GameObject _playCameraObjects;

        [Header("操作カメラの追従対象")]//プレイヤーを入れて問題ない
        [SerializeField]
        Transform _playCameraFollow;

        [SerializeField]
        Transform _playCameraLookAt;

        CinemachineVirtualCamera _restartPointCamera;//リスタート地点のカメラ

        //プレイヤーが操作するカメラの初期向き
        float _defaultVerticalValue_PlayCamera;
        float _defaultHorizontalValue_PlayCamera;

        //リスタートが始まった瞬間に呼ばれる
        public void InitOnRestart(CinemachineVirtualCamera restartPointCamera, float defaultVerticalValue_PlayCamera, float defaultHorizontalValue_PlayCamera)
        {
            _restartPointCamera = restartPointCamera;
            _defaultVerticalValue_PlayCamera= defaultVerticalValue_PlayCamera;
            _defaultHorizontalValue_PlayCamera=defaultHorizontalValue_PlayCamera;
        }

        //暗転直後に行う処理
        public void ProcessImmediatelyAfterDark()
        {
            SwitchRestartPointCamera(true);//リスタート地点のカメラにする
            SetDefault_PlayeCamera();//操作カメラの向きを初期に戻す
        }

        //明転してからしばらくの後に行う処理
        public void ProcessLaterAfterLight()
        {
            ChangeFollow_PlayCamera(true);//カメラのプレイヤーの追跡を再開
            SwitchRestartPointCamera(false);//プレイカメラに戻す
            _switchPlayCamera.SwitchDefaultCamera();//デフォルトのカメラに戻す
        }

        public void ChangeFollow_PlayCamera(bool followPlayer)//プレイヤーが操作するカメラの追従設定の変更、followPlayerはプレイヤーを追従するか
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

        void SetDefault_PlayeCamera()//全てのプレイヤーが操作するカメラを初期の向きに戻す
        {
            var povs = _switchPlayCamera.AllPOVs;

            for(int i=0; i<povs.Length ;i++)
            {
                if(povs==null) continue;

                povs[i].m_VerticalAxis.Value = _defaultVerticalValue_PlayCamera;
                povs[i].m_HorizontalAxis.Value = _defaultHorizontalValue_PlayCamera;
            }
        }

        void SwitchRestartPointCamera(bool activeRestart)//リスタートカメラとプレイカメラの切り替え、activeRestartはリスタートカメラに切り替えるか
        {
            _restartPointCamera.enabled=activeRestart;
            _playCameraObjects.SetActive(!activeRestart);
        }
    }
}
