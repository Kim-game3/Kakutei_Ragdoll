using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

public partial class RestartManager : MonoBehaviour
{
    // --- リスタートの設定関係 --- //
    [CustomLabel("リスタート時に再生するタイムライン")] [SerializeField]
    PlayableDirector _restartTimeLine;

    [SerializeField]//リスタート時のプレイヤーを初期地点に戻す関係の処理をまとめたもの
    PlayerPosControl _playerPosControl;

    [SerializeField]//リスタート時のカメラ関係の処理をまとめたもの
    CameraControl _cameraControl;

    [SerializeField]//リスタート時の入力関係の処理をまとめたもの
    InputControl _inputControl;

    bool _isRestarting = false;//リスタート中か

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _cameraControl.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //落ちた瞬間
        _isRestarting=true;
        _inputControl.SetControllable(false);//操作不可能にする
        _cameraControl.ChangeFollow_PlayCamera(false);//カメラのプレイヤーの追跡をやめる
        _restartTimeLine.Play();//タイムラインを再生

        //この辺りで完全に暗転
        _cameraControl.SwitchRestartPointCamera(true);//リスタート地点のカメラにする

        //この辺りで完全に明転
        _playerPosControl.BackToRestartPoint();//プレイヤーをリスポーン地点に移動&スタート地点に向かってプレイヤーを投げる

        //明転が終わってから数秒後
        _cameraControl.ChangeFollow_PlayCamera(true);//カメラのプレイヤーの追跡を再開
        _cameraControl.SwitchRestartPointCamera(false);//プレイカメラに戻す

        //さらに数秒後
        _inputControl.SetControllable(true);//操作可能にする
        _isRestarting = false;


        yield return null;
    }
}
