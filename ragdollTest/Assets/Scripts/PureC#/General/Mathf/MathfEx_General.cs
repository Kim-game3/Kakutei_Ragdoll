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



    /// <summary>
    /// 値を範囲内で循環させる
    /// 範囲最小(rangeMin)以上、範囲最大(rangeMax)以下を範囲とする
    /// </summary>
    public static int CircularWrapping(int num, int rangeMax)//範囲最小が0
    {
        return CircularWrapping(num, 0, rangeMax);
    }

    public static int CircularWrapping(int num, int rangeMin, int rangeMax)//範囲最小も指定可能
    {
        EnsureMinMax(ref rangeMin, ref rangeMax);

        int range = rangeMax - rangeMin + 1;

        num -= rangeMin;//範囲最小を0にした時に合わせる

        num %= range;
        num = (num + range) % range;

        num += rangeMin;//元に戻す

        return num;
    }



    /// <summary>
    /// 値を増加・減少させ、変化後の値を範囲内で循環させる
    /// /// 範囲最小(rangeMin)以上、範囲最大(rangeMax)以下を範囲とする
    /// </summary>
    public static int CircularWrapping_Delta(int num, int delta, int rangeMax)//範囲最小が0
    {
        return CircularWrapping_Delta(num, delta, 0, rangeMax);
    }

    public static int CircularWrapping_Delta(int num, int delta, int rangeMin, int rangeMax)//範囲最小も指定可能
    {
        EnsureMinMax(ref rangeMin, ref rangeMax);

        int range = rangeMax - rangeMin + 1;

        delta %= range;
        num += delta;

        return CircularWrapping(num, rangeMin, rangeMax);
    }
}
