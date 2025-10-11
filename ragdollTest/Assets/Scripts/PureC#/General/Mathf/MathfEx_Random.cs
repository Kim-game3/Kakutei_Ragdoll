using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//MathfExtensionのランダム系

public partial class MathfExtension
{
    /// <summary>
    /// min以上、max以下の間で
    /// ランダムに値を返す(float型)
    /// minがmaxより大きくても、自動的に修正してその上で返してくれる
    /// </summary>
    public static float RandomRange(float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        return Random.Range(min, max);
    }


    /// <summary>
    /// min以上、max未満の間で
    /// ランダムに値を返す(int型)
    /// minがmaxより大きくても、自動的に修正してその上で返してくれる
    /// </summary>
    public static int RandomRange(int min, int max)
    {
        EnsureMinMax(ref min, ref max);

        return Random.Range(min, max);
    }
}
