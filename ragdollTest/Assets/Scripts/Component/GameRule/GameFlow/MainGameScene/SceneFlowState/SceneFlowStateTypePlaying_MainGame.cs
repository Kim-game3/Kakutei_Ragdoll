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

    // --- ゲーム終了判定 --- //
    [SerializeField] JudgeGameSet _judgeGameSet;

    // --- 制限時間タイマー --- //
    [CustomLabel("制限時間用のタイマー")] [SerializeField]
    Timer _gameTimer;

    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(PlayerInput_ActionMapName.Controllable);//プレイヤーを操作可能にする
        //タイマー開始
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
        _playerInput.SwitchCurrentActionMap(PlayerInput_ActionMapName.UnControllable);//プレイヤーを操作不可能にする
        //タイマーストップ
    }
}
