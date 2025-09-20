using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class RestartManager : MonoBehaviour
{
    // --- リスタートの設定関係 --- //
    [CustomLabel("リスタート地点&方向")] [Tooltip("明転終了後、プレイヤーがこの地点に出現＆この方向に向かって投げ飛ばされる")] [SerializeField]
    Transform _restartPoint;



    [SerializeField] 
    PlayerInput _playerInput;

    [SerializeField] 
    CinemachineVirtualCamera _gameCamera;

    const string _tagName_Player = "Player";

    //プレイヤーが操作するカメラの追従対象
    Transform _gameCameraFollow;
    Transform _gameCameraLookAt;

    bool _isRestarting = false;//リスタート中か

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _gameCameraFollow = _gameCamera.Follow;
        _gameCameraLookAt = _gameCamera.LookAt;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(_tagName_Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //☆落ちた瞬間
        //リスポーン中をオンにする
        //カメラの追跡をやめる(FollowとLookAtをnullにする)
        //操作を出来なくする
        //☆シャチがザパっと出てくる
        //☆暗転
        //☆明転
        //プレイヤーを海の中のリスポーン地点に戻す
        //特定の方向に力をかける
        //リスポーン地点用のカメラをオンにする
        //カメラの追跡(FollowとLookAtにプレイヤーを入れる)
        //☆シャチが一瞬顔を出して海に戻る
        //☆(数s後)
        //カメラの追跡をオンにする
        //☆(数秒後)
        //操作可能に
        //リスポーン中をオフに

        //落ちた瞬間
        _isRestarting=true;
        //_playerInput.SwitchCurrentActionMap();//操作不可能にする
        //ChangeGameCameraTarget(null, null);//カメラの追跡をやめる

        //明転まで待つ

        //明転が終わった直後

        //明転が終わってから数秒後
        //ChangeGameCameraTarget(_gameCameraFollow, _gameCameraLookAt);

        //さらに数秒後
        //_playerInput.SwitchCurrentActionMap();//操作不可能にする
        _isRestarting = false;


        yield return null;
    }

    void ChangeGameCameraTarget(Transform newFollow,Transform newLookAt)
    {
        _gameCamera.Follow=newFollow;
        _gameCameraLookAt=newLookAt;
    }
}
