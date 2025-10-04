using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

//�쐬��:���R
//MathfExtension�̔ėp�I�Ɏg����֐�

public partial class MathfExtension
{
    /// <summary>
    /// min/max �𐳂�������(int�^)
    /// </summary>
    public static void EnsureMinMax(ref int min, ref int max)
    {
        int a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }

    /// <summary>
    /// min/max �𐳂�������(float�^)
    /// </summary>
    public static void EnsureMinMax(ref float min, ref float max)
    {
        float a = min, b = max;
        min = Mathf.Min(a, b);
        max = Mathf.Max(a, b);
    }




    /// <summary>
    /// min��max�̊Ԃ�(min��max���܂�)
    /// �l���͈͓�����Ԃ�(int�^)
    /// </summary>
     
    public static bool IsInRange(int value,int min,int max)
    {
        EnsureMinMax(ref min, ref max);

        return (value>=min) && (value<=max);
    }

    /// <summary>
    /// min��max�̊Ԃ�(min��max���܂�)
    /// �l���͈͓�����Ԃ�(float�^)
    /// </summary>

    public static bool IsInRange(float value, float min, float max)
    {
        EnsureMinMax(ref min, ref max);

        return (value >= min) && (value <= max);
    }
}
