using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲーム終了を判断

//*注意点
//これを使う際、クリア判定用のトリガーをつけること

public class JudgeGameSet : MonoBehaviour
{
    bool _isGameSet=false;//ゲーム終了したか

    public bool IsGameSet {  get { return _isGameSet; } }


    private void OnTriggerEnter(Collider other)//ちょっと変えるかも
    {
        //クリア条件
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isGameSet = true;
    }

}
