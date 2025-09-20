using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームオーバーとゲームクリアを判断する
//ゲームオーバーとゲームクリアが同時に存在しないようにする

//*注意点
//これを使う際、クリア判定用のトリガーをつけること

public class JudgeGameSet : MonoBehaviour
{
    // --- ゲームオーバー判定用に必要 --- //
    [CustomLabel("制限時間用のタイマー")] [SerializeField] 
    Timer _gameTimer;

    // --- クリア判定用に必要 --- //
    const string _tagName_Player = "Player";


    //クリア・ゲームオーバーかの取得
    EGameState _gameState=EGameState.Playing;

    public EGameState GameState {  get { return _gameState; } }



    /// <summary>
    /// ゲームオーバー条件
    /// 制限時間切れ
    /// </summary>

    /// <summary>
    /// ゲームクリア条件
    /// クリアのトリガーに触れたとき
    /// </summary>


    private void Awake()
    {
        //ゲームオーバー条件
        _gameTimer.TimeUpEvent += SwitchGameOver;
    }

    void SwitchGameOver()
    {
        SwitchState(EGameState.GameOver);
    }

    private void OnTriggerEnter(Collider other)//ちょっと変えるかも
    {
        //クリア条件
        if (!other.CompareTag(_tagName_Player)) return;

        SwitchState(EGameState.Clear);
    }

    void SwitchState(EGameState newState)
    {
        //既にゲームが終了していれば変更しない
        if (_gameState != EGameState.Playing) return;

        _gameState = newState;
    }

}
