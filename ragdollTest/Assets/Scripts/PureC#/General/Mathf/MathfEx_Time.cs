using System;

//�쐬��:���R
//MathfExtension�̎��Ԋ֌W

public partial class MathfExtension
{

    /// <summary>
    /// �����ŗ^����ꂽ����(value�b)��
    /// ����(h)�A��(m)�A�b(s)�ɕϊ����ĕԂ��B
    /// </summary>
    public static void ConvertTime(float value,out float h,out float m,out float s)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);

        h = time.Hours;
        m=time.Minutes;
        s = time.Seconds;
    }
}
