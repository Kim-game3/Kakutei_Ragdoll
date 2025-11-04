using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//オブジェクトのタグ名をどこからでも取得できるようにしたもの

public class ObjectTagNameDictionary
{
    /// <summary>
    /// プレイヤーのタグ名
    /// </summary>
    const string _playerTagName = "Player";

    public static string Player { get { return _playerTagName; } }


    /// <summary>
    /// 水のタグ名
    /// </summary>
    const string _waterTagName = "Water";
    
    public static string Water { get { return _waterTagName; } }


    /// <summary>
    /// 風の影響を受けるタグ名
    /// </summary>
    const string _windAffectTagName = "WindAffect";

    public static string WindAffect { get { return _windAffectTagName; } }


    /// <summary>
    /// 風のタグ名
    /// </summary>
    const string _windTagName = "Wind";
    public static string Wind { get { return _windTagName; } }


    /// <summary>
    /// 風の音を聞くタグ名
    /// </summary>
    const string _windSE_ListenerTagName = "WindSE_Listener";
    public static string WindSE_Listener { get { return _windSE_ListenerTagName; } }
}
