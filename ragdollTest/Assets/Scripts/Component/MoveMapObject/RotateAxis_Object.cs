using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//このコンポーネントをつけたオブジェクトのZ軸(青矢印)を軸に逆時計回りに回転させる

public class RotateAxis_Object : MonoBehaviour
{
    [CustomLabel("周期(秒)")] [SerializeField]
    float _cycle;

    [CustomLabel("動かす対象")] [SerializeField]
    Transform _target;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rate = Time.deltaTime / _cycle;

        float angle=MathfExtension.CircleAngle*rate;

        _target.Rotate(transform.forward, angle);
    }
}
