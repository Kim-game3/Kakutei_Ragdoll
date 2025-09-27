using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//MathfExtensionの汎用的に使える関数

public partial class MathfExtension
{
    /// <summary>
    /// min/max を正しくする
    /// </summary>
    public static void EnsureMinMax(ref float min, ref float max)
    {
        float a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }
}
