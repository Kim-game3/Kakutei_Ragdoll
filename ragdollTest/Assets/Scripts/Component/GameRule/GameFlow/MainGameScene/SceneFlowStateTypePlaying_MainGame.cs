using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//シーンの流れ(メインゲームシーン)のゲーム中ステート

public class SceneFlowStateTypePlaying_MainGame : SceneFlowStateTypeBase
{
    // --- 操作可能切り替え --- // 
    [SerializeField] PlayerInput _playerInput;
    const string _controllable_Game_ActionMapName = "Game";//ゲームの操作可能
    const string _uncontrollable_ActionMapName = "Uncontrollable";//操作不可能

    // --- ゲーム終了判定 --- //
    [SerializeField] JudgeGameSet _judgeGameSet;


    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(_controllable_Game_ActionMapName);//プレイヤーを操作可能にする
    }
    public override void OnUpdate()
    {
        if(_judgeGameSet.GameState!=EGameState.Playing)//ステートの終了
        {
            _finished = true;
        }
    }

    public override void OnExit()
    {
        _playerInput.SwitchCurrentActionMap(_uncontrollable_ActionMapName);//プレイヤーを操作不可能にする
    }
}
