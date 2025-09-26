using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//このコンポーネントをつけたオブジェクトのZ軸(青矢印)を軸に回転させる

public class RotateAxis_Object : MonoBehaviour
{
    [CustomLabel("周期(秒)")] [SerializeField]
    float _cycle;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rate = Time.deltaTime / _cycle;

        float angle=MathfExtension.CircleAngle*rate;

        transform.Rotate(transform.forward, angle);
    }
}
