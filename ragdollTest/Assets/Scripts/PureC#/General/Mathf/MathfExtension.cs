using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//Mathf�N���X�ɑ���Ȃ��@�\�������ɒǉ��\

public class MathfExtension : MonoBehaviour
{
    const float _circleAngle = 360;

    //---�~�̊p�x��Ԃ�---//
    public static float CircleAngle{ get{ return _circleAngle; }}//�~�̊p�x��Ԃ�



    //--- (�܂���)�O�p�g�ϊ� ---//

    /// <summary>
    /// min �� max �̊ԂŎO�p�g�𐶐�����B
    /// min/max �ɋ߂��ق� 0�A�����ɋ߂��ق� 1 ��Ԃ��B
    /// </summary>
    public static float TriangleWave01(float value, float min, float max)
    {
        NormalizeRange(ref min, ref max, ref value);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return 1f - Mathf.Abs(value - middle) / halfRange;//�ϊ���
    }

    /// <summary>
    /// min �� max �̊Ԃŋt�O�p�g�𐶐�����B
    /// min/max �ɋ߂��ق� 1�A�����ɋ߂��ق� 0 ��Ԃ��B
    /// </summary>
    public static float InverseTriangleWave01(float value, float min, float max)
    {
        NormalizeRange(ref min, ref max, ref value);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return Mathf.Abs(value - middle) / halfRange;//�ϊ���
    }

    /// <summary>
    /// min/max �𐳂������Avalue ��͈͓��Ɏ��߂�B
    /// </summary>
    private static void NormalizeRange(ref float min, ref float max, ref float value)
    {
        if (min > max)
        {
            (min, max) = (max, min);
        }

        value = Mathf.Clamp(value, min, max);
    }



    //--- �O�p�֐��n ---//
    public static float Cos01(float f)//r�̓��W�A���Acos�̌��ʂ�-1�`1��0�`1�ɕϊ����ĕԂ�
    {
        float ret = Mathf.Cos(f);
        ret = ret * 0.5f + 0.5f;//�ϊ���
        return ret;
    }

    public static float Sin01(float f)//r�̓��W�A���Asin�̌��ʂ�-1�`1��0�`1�ɕϊ����ĕԂ�
    {
        float ret = Mathf.Sin(f);
        ret = ret * 0.5f + 0.5f;//�ϊ���
        return ret;
    }
}
