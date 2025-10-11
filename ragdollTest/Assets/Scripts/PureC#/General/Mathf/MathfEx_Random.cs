using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//MathfExtension�̃����_���n

public partial class MathfExtension
{
    /// <summary>
    /// min�ȏ�Amax�ȉ��̊Ԃ�
    /// �����_���ɒl��Ԃ�(float�^)
    /// min��max���傫���Ă��A�����I�ɏC�����Ă��̏�ŕԂ��Ă����
    /// </summary>
    public static float RandomRange(float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        return Random.Range(min, max);
    }


    /// <summary>
    /// min�ȏ�Amax�����̊Ԃ�
    /// �����_���ɒl��Ԃ�(int�^)
    /// min��max���傫���Ă��A�����I�ɏC�����Ă��̏�ŕԂ��Ă����
    /// </summary>
    public static int RandomRange(int min, int max)
    {
        EnsureMinMax(ref min, ref max);

        return Random.Range(min, max);
    }
}
