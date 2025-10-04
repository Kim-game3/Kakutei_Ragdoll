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

    [Tooltip("かける力を足場の角度に沿わせる設定")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;

    //移動時に呼ばれる(Vector3は加速方向が入る)
    public event Action OnMove;
    public event Action<Vector3> OnMove_Vec;//引数に加速方向の3Dベクトルが入る

    public Rigidbody Body { get { return _body; } }//動かす身体のパーツ

    public void Input_Move(InputAction.CallbackContext context)//移動入力
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

#if UNITY_EDITOR
        Debug.Log(getVec);
#endif

        Move(getVec);
    }


    //private

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y).normalized;

        //入力ベクトルをベースの方向(y方向は無視、z方向のみ)に向ける
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        forceDirection = _followVectorToScaffold.Follow(forceDirection);//力をかける方向を足場の角度に沿わせる

        Vector3 force = forceDirection * _power;

        _body.AddForce(force,ForceMode.VelocityChange);

        OnMove?.Invoke();
        OnMove_Vec?.Invoke(forceDirection);
    }
}
