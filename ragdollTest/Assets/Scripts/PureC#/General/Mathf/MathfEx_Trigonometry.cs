using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//MathfExtension‚ÌOŠpŠÖ”ŠÖŒW

public partial class MathfExtension
{
    public static float Cos01(float f)//r‚Íƒ‰ƒWƒAƒ“Acos‚ÌŒ‹‰Ê‚Ì-1`1‚ğ0`1‚É•ÏŠ·‚µ‚Ä•Ô‚·
    {
        float ret = Mathf.Cos(f);
        ret = ret * 0.5f + 0.5f;//•ÏŠ·®
        return ret;
    }

    public static float Sin01(float f)//r‚Íƒ‰ƒWƒAƒ“Asin‚ÌŒ‹‰Ê‚Ì-1`1‚ğ0`1‚É•ÏŠ·‚µ‚Ä•Ô‚·
    {
        float ret = Mathf.Sin(f);
        ret = ret * 0.5f + 0.5f;//•ÏŠ·®
        return ret;
    }
}
