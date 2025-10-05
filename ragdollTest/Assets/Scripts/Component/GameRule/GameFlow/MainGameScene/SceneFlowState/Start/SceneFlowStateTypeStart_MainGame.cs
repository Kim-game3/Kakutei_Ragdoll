using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//シーンの流れ(メインゲームシーン)の開始ステート

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [SerializeField]
    GameStartMovieSequence _gameStartMovieSequence;

    [SerializeField]
    PlayerInput _playerInput;

    public override void OnEnter() 
    {
        _gameStartMovieSequence.Play();//開始演出を再生
        _finished = false;
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.UnControllable);//操作不可能にする
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {

    }

    private void Awake()
    {
        _gameStartMovieSequence.OnMovieFinished += SetStateFinished;
    }

    void SetStateFinished()
    {
        _finished = true;
    }
}
