using System;

//ì¬Ò:™R
//MathfExtension‚ÌŠÔŠÖŒW

public partial class MathfExtension
{

    /// <summary>
    /// ˆø”‚Å—^‚¦‚ç‚ê‚½ŠÔ(value•b)‚ğ
    /// ŠÔ(h)A•ª(m)A•b(s)‚É•ÏŠ·‚µ‚Ä•Ô‚·B
    /// </summary>
    public static void ConvertTime(float value,out float h,out float m,out float s)
    {
        TimeSpan time = TimeSpan.FromSeconds(value);

        h = time.Hours;
        m=time.Minutes;
        s = time.Seconds + (value % 1f);//•b‚¾‚¯¬”“_‚àŠÜ‚ß‚Ä•Ô‚·
    }
}
