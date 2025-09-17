using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーの移動速度が上限を超えてないか見る

[System.Serializable]
public class JudgeIsValidSpeed
{
    [CustomLabel("現在のプレイヤーの速度をデバッグ表示するか")] [SerializeField]
    bool _showDebug_Speed;

    [CustomLabel("最大移動速度")] [SerializeField]
    float _maxSpeed;

    [Tooltip("接地判定")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    Rigidbody _body;

    public void Init(Rigidbody body)//初期化(body=対象部位のRigidbody)
    {
        _body = body;
    }

    public bool IsValidSpeed()//移動速度は範囲内か
    {
        Vector3 velocity= _body.velocity;
        velocity.y= _judgeIsGround.IsGround ? _body.velocity.y : 0;

        if(_showDebug_Speed) Debug.Log(velocity.magnitude);//速度のデバッグ表示

        return velocity.magnitude <= _maxSpeed;
    }
}
