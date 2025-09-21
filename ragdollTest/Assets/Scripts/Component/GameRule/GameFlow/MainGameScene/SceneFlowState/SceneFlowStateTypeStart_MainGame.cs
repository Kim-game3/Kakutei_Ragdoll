using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//シーンの流れ(メインゲームシーン)の開始ステート

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [CustomLabel("最初の方に再生するタイムライン")] [SerializeField]
    PlayableDirector _playableDirector;

    [SerializeField]
    PlayerInput _playerInput;

    [CustomLabel("開始演出が終わるまで待つ時間")] [SerializeField]
    float _waitDuration;

    public override void OnEnter() 
    {
        _finished = false;
        _playableDirector.Play();//タイムラインを再生
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.UnControllable);//操作不可能にする
        StartCoroutine(Wait_FinishStartEvent());
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {

    }

    IEnumerator Wait_FinishStartEvent()//開始演出が終わるまで待つ
    {
        yield return new WaitForSeconds(_waitDuration);

        _finished = true;
    }
}
