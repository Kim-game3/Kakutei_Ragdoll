using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//MathfExtension�̎O�p�֐��֌W

public partial class MathfExtension
{
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
