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

    [CustomLabel("ストップウォッチ")] [SerializeField]
    StopWatch _stopWatch;

    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.Controllable);//プレイヤーを操作可能にする
        _stopWatch.SwitchStartStop();//ストップウォッチ開始
    }
    public override void OnUpdate()
    {
        if(_judgeGameSet.IsGameSet)//ステートの終了
        {
            _finished = true;
        }
    }

    public override void OnExit()
    {
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.UnControllable);//プレイヤーを操作不可能にする
        _stopWatch.SwitchStartStop();//ストップウォッチ停止
    }
}
