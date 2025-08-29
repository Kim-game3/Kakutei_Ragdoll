using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームオーバーの判断

public class JudgeGameOver : MonoBehaviour 
{
    [SerializeField] Timer _timer;
    bool _judgedGameOver=false;

    //public
    public bool JudgedGameOver { get { return _judgedGameOver; } }

    public event Action TriggerEvent;//ゲームオーバーと判定された瞬間に呼ばれる

    void Awake()
    {
        _timer.TimeUpEvent += Judge;//タイムアップ時にゲームオーバーと判断
    }

    //private
    void Judge()//ゲームオーバーと判断
    {
        if (_judgedGameOver) return;

        _judgedGameOver = true;
        TriggerEvent?.Invoke();
    }

}
