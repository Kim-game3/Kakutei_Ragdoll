using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

//作成者:杉山
//リスタート処理

public partial class RestartManager : MonoBehaviour
{
    [Tooltip("明転してから何秒後にカメラがプレイヤーをまた追跡するようになるか")] [SerializeField]
    float _waitDuration_FromFinishFadeIn;

    [Tooltip("カメラがプレイヤーを追従するようになってから何秒後に操作が可能になるようにするか")] [SerializeField]
    float _waitDuration_FromCameraFollowPlayer;

    [CustomLabel("リスタート時に再生するタイムライン")] [SerializeField]
    PlayableDirector _restartTimeLine;

    [SerializeField] [Tooltip("リスタートゾーンのトリガー")]
    OnTriggerDetect _restartZoneTrigger;

    [SerializeField]//リスタート時のプレイヤーを初期地点に戻す関係の処理をまとめたもの
    PlayerPosControl _playerPosControl;

    [SerializeField]//リスタート時のカメラ関係の処理をまとめたもの
    CameraControl _cameraControl;

    [SerializeField]//リスタート時の入力関係の処理をまとめたもの
    InputControl _inputControl;

    bool _isRestarting = false;//リスタート中か
    bool _finishedFadeOut = true;//フェードアウトが終わったか
    bool _finishedFadeIn = true;//フェードインが終わったか

    public event Action OnRestrat;//水に落ちた瞬間に呼ぶ

    public bool IsRestarting { get { return _isRestarting; } }

    public void SetFinish_FadeOut()
    {
        _finishedFadeOut = true;
    }

    public void SetFinish_FadeIn()
    {
        _finishedFadeIn=true;
    }

    //private
    private void Awake()
    {
        _cameraControl.Init();
        _restartZoneTrigger.OnEnter += OnHit_RestartTrigger;
    }

    private void OnHit_RestartTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //落ちた瞬間
        _isRestarting=true;
        OnRestrat?.Invoke();
        _finishedFadeOut=false;
        _finishedFadeIn=false;
        _inputControl.SetControllable(false);//操作不可能にする
        _cameraControl.ChangeFollow_PlayCamera(false);//カメラのプレイヤーの追跡をやめる
        _restartTimeLine.Play();//タイムラインを再生


        yield return new WaitUntil(() => _finishedFadeOut);//完全に暗転するまで待つ
        _cameraControl.SwitchRestartPointCamera(true);//リスタート地点のカメラにする
        _playerPosControl.StopPlayerMove();//プレイヤーの変な動きを抑える
        _cameraControl.SetDefault_PlayeCamera();//操作カメラの向きを初期に戻す


        yield return new WaitUntil(() => _finishedFadeIn);//完全に明転するまで待つ
        _playerPosControl.BackToRestartPoint();//プレイヤーをリスポーン地点に移動&スタート地点に向かってプレイヤーを投げる


        yield return new WaitForSeconds(_waitDuration_FromFinishFadeIn);//完全に明転してから数秒待つ
        _cameraControl.ChangeFollow_PlayCamera(true);//カメラのプレイヤーの追跡を再開
        _cameraControl.SwitchRestartPointCamera(false);//プレイカメラに戻す


        yield return new WaitForSeconds(_waitDuration_FromCameraFollowPlayer);//さらに数秒待つ
        _inputControl.SetControllable(true);//操作可能にする
        _isRestarting = false;
    }
}
