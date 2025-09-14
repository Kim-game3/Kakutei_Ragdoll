using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//タイマーの状態

public enum TimerState
{
    Off,//動いていない
    On,//動いている
    Stop,//一時停止中
    TimeUp,//タイムアップ

    Length//長さ(これ以降に要素を追加しないこと)
}