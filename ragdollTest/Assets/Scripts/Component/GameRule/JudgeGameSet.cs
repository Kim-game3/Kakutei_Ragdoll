using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//ゲーム終了判定

public class JudgeGameSet : MonoBehaviour
{
    [Tooltip("ゲームクリア判定")] [SerializeField] JudgeGameClear _judgeGameClear;
    [Tooltip("ゲームオーバー判定")] [SerializeField] JudgeGameOver _judgeGameOver;

    //public

    public event Action GameClearEvent;//ゲームクリア時に呼ばれるイベント
    public event Action GameOverEvent;//ゲームオーバー時に呼ばれるイベント

    //private 

    private void Awake()
    {
        //イベントを設定
        _judgeGameClear.TriggerEvent += GameClear;
        _judgeGameOver.TriggerEvent += GameOver;
    }

    void GameClear()
    {
        //既にゲームオーバー状態であれば、何もしない
        if (_judgeGameOver.JudgedGameOver) return;

        GameClearEvent?.Invoke();
    }

    void GameOver()
    {
        //既にゲームクリア状態であれば何もしない
        if (_judgeGameClear.JudgedGameClear) return;

        GameOverEvent?.Invoke();
    }
}
