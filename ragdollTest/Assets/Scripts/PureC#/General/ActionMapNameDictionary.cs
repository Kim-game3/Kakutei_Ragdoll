using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//PlayerInputのアクションマップ名をどこからでも取得出来るようにしたもの

public class ActionMapNameDictionary
{
    /// <summary>
    ///ゲームシーンのプレイヤー操作が可能な状態のActionMap名
    /// </summary>
    const string _controllableActionMapName = "Game";  

    public static string Controllable {  get { return _controllableActionMapName; } }


    /// <summary>
    ///ゲームシーンのプレイヤー操作が不可能な状態のActionMap名
    /// </summary>
    const string _uncontrollableActionMapName = "UnControllable";

    public static string UnControllable { get { return _uncontrollableActionMapName; } }
}
