using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//シーンの流れ(メインゲームシーン)の開始ステート

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [CustomLabel("制限時間用のタイマー")] [SerializeField]
    Timer _gameTimer;

    public override void OnEnter() 
    {
        _finished = true;//とりあえず開始の演出は無しで
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {
        _gameTimer.TimerStart();
    }
}
