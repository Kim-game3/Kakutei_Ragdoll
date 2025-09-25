using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//移動スピードの制限

public class LimitMoveSpeed : MonoBehaviour
{
    [CustomLabel("現在のプレイヤーの速度をデバッグ表示するか")] [SerializeField]
    bool _showDebug_Speed;

    [CustomLabel("最大移動速度")] [SerializeField]
    float _maxSpeed;

    [Tooltip("接地判定")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [SerializeField]
    Move_ForceBody _move_ForceBody;

    Rigidbody _body;

    void Limit()
    {
        Vector3 velocity = _body.velocity;

        bool isGround=_judgeIsGround.IsGround;

        velocity.y = isGround ? velocity.y : 0;

        if (_showDebug_Speed) Debug.Log(velocity.magnitude);//速度のデバッグ表示

        if (velocity.magnitude > _maxSpeed)
        {
            Debug.Log("制限中");
            velocity = velocity.normalized * _maxSpeed;
            if(!isGround) velocity.y=_body.velocity.y;
            _body.velocity = velocity;
        }
    }

    private void Awake()
    {
        _body=_move_ForceBody.Body;
    }

    private void FixedUpdate()
    {
        Limit();
    }
}
