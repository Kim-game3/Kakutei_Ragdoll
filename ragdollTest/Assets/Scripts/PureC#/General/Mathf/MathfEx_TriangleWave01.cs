using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//MathfExtension‚Ì(Ü‚èô‚İ)OŠp”g•ÏŠ·

public partial class MathfExtension
{
    /// <summary>
    /// min ‚Æ max ‚ÌŠÔ‚ÅOŠp”g‚ğ¶¬‚·‚éB
    /// min/max ‚É‹ß‚¢‚Ù‚Ç 0A’†‰›‚É‹ß‚¢‚Ù‚Ç 1 ‚ğ•Ô‚·B
    /// </summary>
    public static float TriangleWave01(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return 1f - Mathf.Abs(value - middle) / halfRange;//•ÏŠ·®
    }

    /// <summary>
    /// min ‚Æ max ‚ÌŠÔ‚Å‹tOŠp”g‚ğ¶¬‚·‚éB
    /// min/max ‚É‹ß‚¢‚Ù‚Ç 1A’†‰›‚É‹ß‚¢‚Ù‚Ç 0 ‚ğ•Ô‚·B
    /// </summary>
    public static float InverseTriangleWave01(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        float halfRange = (max - min) * 0.5f;
        float middle = min + halfRange;

        return Mathf.Abs(value - middle) / halfRange;//•ÏŠ·®
    }
}
