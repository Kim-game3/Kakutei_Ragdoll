using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームクリア判定

public class JudgeGameClear : MonoBehaviour
{
    bool _judgedGameClear = false;
    const string _tagName_JudgeGameClear = "Clear";

    //public
    public bool JudgedGameClear { get { return _judgedGameClear; } }

    public event Action TriggerEvent;//ゲームクリアと判定された瞬間に呼ばれる

    //private

    private void OnTriggerEnter(Collider other)
    {
        //キャラについているクリア判定用のトリガーに接触すればクリアした判定
        if (!other.CompareTag(_tagName_JudgeGameClear)) return;

        Judge();
    }

    void Judge()
    {
        if (_judgedGameClear) return;

        _judgedGameClear = true;
        TriggerEvent?.Invoke();
    }
}
