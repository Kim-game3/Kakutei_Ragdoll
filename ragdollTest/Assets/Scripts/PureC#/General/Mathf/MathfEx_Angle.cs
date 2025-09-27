using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//MathfExtension‚ÌŠp“xŠÖŒW

public partial class MathfExtension
{
    const float _circleAngle = 360;//‰~‚ÌŠp“x

    //---‰~‚ÌŠp“x‚ğ•Ô‚·---//
    public static float CircleAngle{ get{ return _circleAngle; }}//‰~‚ÌŠp“x‚ğ•Ô‚·

    //--- ’l‚©‚ç‚ÌŠp“x•ÏŠ· ---//

    /// <summary>
    /// min‚ğ0Amax‚ğ2ƒÎ‚Æ‚µ‚ÄAvalue‚ğŠp“x‚É•ÏŠ·‚·‚é
    /// </summary>
    
    //ŒÊ“x–@ver(rad)
    public static float ValueToRad(float value,float min,float max)
    {
        return ValueToAngle_Rate(value,min,max) * 2 * Mathf.PI;
    }

    //“x”–@ver(“x)
    public static float ValueToDeg(float value,float min,float max)
    {
        return ValueToAngle_Rate(value, min, max) * _circleAngle;
    }

    static float ValueToAngle_Rate(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        //ˆê’Umin‚ğ0‚É‡‚í‚¹‚Ä‚©‚çŠ„‡ŒvZ
        max -= min;
        float rate = Mathf.Repeat(value - min, max) / max;

        return rate;
    }
}
