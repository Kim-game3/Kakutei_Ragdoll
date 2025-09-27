using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//MathfExtension�̊p�x�֌W

public partial class MathfExtension
{
    const float _circleAngle = 360;//�~�̊p�x

    //---�~�̊p�x��Ԃ�---//
    public static float CircleAngle{ get{ return _circleAngle; }}//�~�̊p�x��Ԃ�

    //--- �l����̊p�x�ϊ� ---//

    /// <summary>
    /// min��0�Amax��2�΂Ƃ��āAvalue���p�x�ɕϊ�����
    /// </summary>
    
    //�ʓx�@ver(rad)
    public static float ValueToRad(float value,float min,float max)
    {
        return ValueToAngle_Rate(value,min,max) * 2 * Mathf.PI;
    }

    //�x���@ver(�x)
    public static float ValueToDeg(float value,float min,float max)
    {
        return ValueToAngle_Rate(value, min, max) * _circleAngle;
    }

    static float ValueToAngle_Rate(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        //��Umin��0�ɍ��킹�Ă��犄���v�Z
        max -= min;
        float rate = Mathf.Repeat(value - min, max) / max;

        return rate;
    }
}
