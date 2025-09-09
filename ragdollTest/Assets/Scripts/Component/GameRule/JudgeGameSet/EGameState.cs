using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//クリア・ゲームオーバー・プレイ中を判断できる

public enum EGameState
{
    Playing,//プレイ中
    Clear,//クリア
    GameOver,//ゲームオーバー

    Legnth//長さ(これ以降には要素を追加しないでください)
}