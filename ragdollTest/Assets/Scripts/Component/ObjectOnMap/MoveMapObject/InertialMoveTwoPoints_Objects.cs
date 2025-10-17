using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//このコンポーネントをつけたオブジェクトに指定した二点間を行き来させる(慣性ありver)

public class InertialMoveTwoPoints_Objects : MonoBehaviour
{
    [CustomLabel("周期(秒)")] [SerializeField]
    float _cycle;

    [CustomLabel("始点")] [SerializeField]
    Transform _start;

    [CustomLabel("終点")] [SerializeField]
    Transform _end;

    [CustomLabel("動かす対象")] [SerializeField]
    Transform _target;

    float _current = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _current += Time.deltaTime;
        _current %= _cycle;

        float t = MathfExtension.Cos01(MathfExtension.ValueToRad(_current,0,_cycle));

        Vector3 newPosition = Vector3.Lerp(_end.position, _start.position, t);
        _target.position = newPosition;
    }
}
