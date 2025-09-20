using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

//作成者:杉山
//リスタートに必要なゲームカメラ関係の処理

public partial class RestartManager
{
    [System.Serializable]
    class ChangeCamera
    {
        [CustomLabel("ゲーム中に操作するカメラ")] [SerializeField]
        CinemachineVirtualCamera _playCamera;

        [CustomLabel("リスタート地点のカメラ")] [SerializeField]
        CinemachineVirtualCamera _restartPointCamera;

        //プレイヤーが操作するカメラの追従対象
        Transform _gameCameraFollow;
        Transform _gameCameraLookAt;

        //初期化

        //ゲームカメラがプレイヤーを追従しないようにする

        //ゲームカメラがプレイヤーを追従するようにする

        //リスタート地点のカメラを
    }
}
