using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//身体に力をかけて移動させるコンポ―ネント

public class Move_ForceBody : MonoBehaviour
{
    [CustomLabel("動かすキャラの身体のパーツ")] [SerializeField]
    Rigidbody _body;

    [CustomLabel("かける力")] [SerializeField]
    float _power;

    [Tooltip("このオブジェクトの前方向に力が加えられる")] [CustomLabel("基準の方向")] [SerializeField]//このオブジェクトの地面に平行な+Z方向を前とする
    Transform _baseDirection;

    [CustomLabel("速度制限機能")] [SerializeField]
    JudgeIsValidSpeed _judgeIsValidSpeed;

    [Tooltip("かける力を足場の角度に沿わせる設定")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;


    [CustomLabel("現在のプレイヤーの速度をデバッグ表示するか")]
    [SerializeField]
    bool _showDebug_Speed;

    [CustomLabel("最大移動速度")]
    [SerializeField]
    float _maxSpeed;

    [Tooltip("接地判定")]
    [SerializeField]
    JudgeIsGround _judgeIsGround;

    //移動時に呼ばれる(Vector3は加速方向が入る)
    public event Action OnMove;
    public event Action<Vector3> OnMove_Vec;//引数に加速方向の3Dベクトルが入る

    public Rigidbody Body { get { return _body; } }//動かす身体のパーツ

    public void Input_Move(InputAction.CallbackContext context)//移動入力
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }


    //private

    private void Move(Vector2 input)
    {
        OnMove?.Invoke();

        //if (!_judgeIsValidSpeed.IsValidSpeed())//速度が一定以上超えてたらこれ以上加速させない
        //{
        //    OnMove_Vec?.Invoke(Vector3.zero);
        //    return;
        //}

        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y).normalized;

        //入力ベクトルをベースの方向(y方向は無視、z方向のみ)に向ける
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        Vector3 force = forceDirection * _power;

        force = _followVectorToScaffold.Follow(force);//力をかける方向を足場の角度に沿わせる

        _body.AddForce(force,ForceMode.VelocityChange);

        OnMove_Vec?.Invoke(forceDirection);

        Debug.Log("動いてるよ");
    }

    private void FixedUpdate()
    {
        LimitSpeed();
    }

    void LimitSpeed()
    {
        Vector3 velocity = _body.velocity;

        if (_judgeIsGround.IsGround)
        {
            if (_showDebug_Speed) Debug.Log(velocity.magnitude);//速度のデバッグ表示

            if(velocity.magnitude > _maxSpeed)
            {
                Debug.Log("制限中");
                velocity=velocity.normalized*_maxSpeed;
                _body.velocity=velocity;
            }
        }
        else
        {
            velocity.y = 0;
            if (_showDebug_Speed) Debug.Log(velocity.magnitude);//速度のデバッグ表示

            if(velocity.magnitude > _maxSpeed)
            {
                Debug.Log("制限中");
                velocity = velocity.normalized*_maxSpeed;
                velocity.y = _body.velocity.y;
                _body.velocity=velocity;
            }
        }
    }

    private void Awake()
    {
        _judgeIsValidSpeed.Init(_body);
    }
}
