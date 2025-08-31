using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//ゲーム終了判定

public class JudgeGameSet : MonoBehaviour
{
    [Tooltip("ゲームクリア判定")] [SerializeField] JudgeGameClear _judgeGameClear;
    [Tooltip("ゲームオーバー判定")] [SerializeField] JudgeGameOver _judgeGameOver;

    //(仮のプログラム)
    [SerializeField] SceneReference _gameOverScene;
    [SerializeField] SceneReference _gameClearScene;

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

        SceneManager.LoadScene(_gameClearScene.ScenePath);//(仮)
    }

    void GameOver()
    {
        //既にゲームクリア状態であれば何もしない
        if (_judgeGameClear.JudgedGameClear) return;

        GameOverEvent?.Invoke();

        SceneManager.LoadScene(_gameOverScene.ScenePath);//(仮)
    }
}
