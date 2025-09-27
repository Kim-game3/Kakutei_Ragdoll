using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//MathfExtension��(�܂���)�O�p�g�ϊ�

public partial class MathfExtension
{
    /// <summary>
    /// min �� max �̊ԂŎO�p�g�𐶐�����B
    /// min/max �ɋ߂��ق� 0�A�����ɋ߂��ق� 1 ��Ԃ��B
    /// </summary>
    public static float TriangleWave01(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

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
        EnsureMinMax(ref min, ref max);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return Mathf.Abs(value - middle) / halfRange;//�ϊ���
    }
}
