using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//Mathfクラスに足りない機能をここに追加可能

public class MathfExtension : MonoBehaviour
{
    const float _circleAngle = 360;

    //---円の角度を返す---//
    public static float CircleAngle{ get{ return _circleAngle; }}//円の角度を返す



    //--- (折り畳み)三角波変換 ---//

    /// <summary>
    /// min と max の間で三角波を生成する。
    /// min/max に近いほど 0、中央に近いほど 1 を返す。
    /// </summary>
    public static float TriangleWave01(float value, float min, float max)
    {
        NormalizeRange(ref min, ref max, ref value);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return 1f - Mathf.Abs(value - middle) / (max - min);//変換式
    }

    /// <summary>
    /// min と max の間で逆三角波を生成する。
    /// min/max に近いほど 1、中央に近いほど 0 を返す。
    /// </summary>
    public static float InverseTriangleWave01(float value, float min, float max)
    {
        NormalizeRange(ref min, ref max, ref value);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return Mathf.Abs(value - middle) / (max - min);//変換式
    }

    /// <summary>
    /// min/max を正しくし、value を範囲内に収める。
    /// </summary>
    private static void NormalizeRange(ref float min, ref float max, ref float value)
    {
        if (min > max)
        {
            (min, max) = (max, min);
        }

        value = Mathf.Clamp(value, min, max);
    }



    //--- 三角関数系 ---//
    public static float Cos01(float f)//rはラジアン、cosの結果の-1～1を0～1に変換して返す
    {
        float ret = Mathf.Cos(f);
        ret = ret * 0.5f + 0.5f;//変換式
        return ret;
    }

    public static float Sin01(float f)//rはラジアン、sinの結果の-1～1を0～1に変換して返す
    {
        float ret = Mathf.Sin(f);
        ret = ret * 0.5f + 0.5f;//変換式
        return ret;
    }
}
