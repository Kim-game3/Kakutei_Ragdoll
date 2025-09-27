using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//MathfExtension�̔ėp�I�Ɏg����֐�

public partial class MathfExtension
{
    /// <summary>
    /// min/max �𐳂�������
    /// </summary>
    public static void EnsureMinMax(ref float min, ref float max)
    {
        float a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }
}
