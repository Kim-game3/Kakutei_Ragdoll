using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//前のシーンのパスを取得する

public class BeforeSceneMemo : MonoBehaviour
{
    static string _beforeScenePath;

    public static string BeforeScenePath
    {
        get { return _beforeScenePath; }
        set { _beforeScenePath = value; }
    }
}
