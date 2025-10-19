using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ストップウォッチの状態

public enum StopWatchState
{
    Off,//動いていない
    On,//動いている
    Stop,//一時停止中

    Length//長さ(これ以降に要素を追加しないこと)
}