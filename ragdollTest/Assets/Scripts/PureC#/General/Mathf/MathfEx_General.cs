using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//作成者:杉山
//MathfExtensionの汎用的に使える関数

public partial class MathfExtension
{
    /// <summary>
    /// min/max を正しくする(int型)
    /// </summary>
    public static void EnsureMinMax(ref int min, ref int max)
    {
        int a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }

    /// <summary>
    /// min/max を正しくする(float型)
    /// </summary>
    public static void EnsureMinMax(ref float min, ref float max)
    {
        float a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }




    /// <summary>
    /// minとmaxの間で(minとmaxも含む)
    /// 値が範囲内かを返す(int型)
    /// </summary>
     
    public static bool IsInRange(int value,int min,int max)
    {
        EnsureMinMax(ref min, ref max);

        return (value>=min) && (value<=max);
    }

    /// <summary>
    /// minとmaxの間で(minとmaxも含む)
    /// 値が範囲内かを返す(float型)
    /// </summary>

    public static bool IsInRange(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        return (value >= min) && (value <= max);
    }
}
