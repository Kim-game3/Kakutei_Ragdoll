using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

//作成者:杉山
//リスタートの処理

public partial class RespawnProcess : MonoBehaviour
{
    [Tooltip("リスタートごとの要素")] [SerializeField]
    RespawnElement[] _restartElements;

    [CustomLabel("リスタート時に再生するタイムライン")] [SerializeField]
    PlayableDirector _restartTimeLine;

    [SerializeField]//リスタート時のプレイヤーを初期地点に戻す関係の処理をまとめたもの
    PlayerPosControl _playerPosControl;

    [SerializeField]//リスタート時のカメラ関係の処理をまとめたもの
    CameraControl _cameraControl;

    [SerializeField]//リスタート時の入力関係の処理をまとめたもの
    InputControl _inputControl;

    [SerializeField]//リスタート時のプレイヤーの表示の処理をまとめたもの
    PlayerMeshControl _playerMeshControl;

    [SerializeField]//シャチの位置の処理をまとめたもの
    OrcaPosControl _orcaPosControl;

    bool _isRestarting = false;//リスタート中か
    bool _finishedFadeOut = true;//フェードアウトが終わったか
    bool _finishedFadeIn = true;//フェードインが終わったか

    public event Action OnFadeOut;
    public event Action OnFadeIn;

    public bool IsRestarting { get { return _isRestarting; } }

    public void SetFinish_FadeOut()
    {
        _finishedFadeOut = true;
        OnFadeOut?.Invoke();
    }

    public void SetFinish_FadeIn()
    {
        _finishedFadeIn=true;
        OnFadeIn?.Invoke();
    }

    public void RestartTrigger(int checkPointIndex)//リスタート処理を行う
    {
        //警告
        if(checkPointIndex>=_restartElements.Length)
        {
            Debug.Log("範囲外のチェックポイントです！");
            return;
        }

        StartCoroutine(OnRestart(checkPointIndex));
    }

    IEnumerator OnRestart(int checkPointIndex)
    {
        InitOnRestart(checkPointIndex);//初期化処理

        //落ちた瞬間
        _isRestarting=true;
        _finishedFadeOut=false;
        _finishedFadeIn=false;

        _inputControl.ProcessOnFallToWater();//操作不可能にする
        _cameraControl.ChangeFollow_PlayCamera(false);//カメラのプレイヤーの追跡をやめる
        PlayTimelineFromBeginning();

        yield return new WaitUntil(() => _finishedFadeOut);//完全に暗転するまで待つ
        _cameraControl.ProcessOnFinishFadeOut();//暗転直後のカメラ処理
        _playerPosControl.BackToRestartPoint();//プレイヤーをリスタート地点に戻す
        _playerMeshControl.ChangeMeshEnabled(false);//プレイヤーを非表示にする
        _orcaPosControl.ChangePos(_restartElements[checkPointIndex]._orcaSpawnPos);//シャチを指定位置に移動


        yield return new WaitUntil(() => _finishedFadeIn);//完全に明転するまで待つ
        _playerMeshControl.ChangeMeshEnabled(true);//プレイヤーを表示する
        _playerPosControl.ThrowPlayer();//プレイヤーをリスポーン地点に移動&スタート地点に向かってプレイヤーを投げる
        StartCoroutine(_inputControl.CoroutineOnFinishFadeIn());//ちょっと待ってから操作可能にする
        StartCoroutine(_cameraControl.CoroutineOnFinishFadeIn());//ちょっと待ってからカメラを切り替える

        //全ての処理が終わるまで待つ
        yield return new WaitUntil(() => IsFinishedProcess());

        _isRestarting = false;
    }

    bool IsFinishedProcess()//全ての(コルーチン)処理が終わったか
    {
        return _cameraControl.IsFinished && _inputControl.IsFinished;
    }

    void PlayTimelineFromBeginning()//タイムラインを最初から再生
    {
        _restartTimeLine.time = 0;
        _restartTimeLine.Evaluate();
        _restartTimeLine.Play();
    }

    void InitOnRestart(int checkPointIndex)//リスタート開始の度に呼ぶ初期化処理
    {
        RespawnElement re=_restartElements[checkPointIndex];

        _cameraControl.InitOnRestart(re.restartPointCamera, re.defaultVerticalValue_PlayCamera, re.defaultHorizontalValue_PlayCamera);
        _playerPosControl.InitOnRestart(re.restartPoint, re.power);
    }
}
