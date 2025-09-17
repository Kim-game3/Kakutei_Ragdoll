using System.Collections;
using System.Collections.Generic;
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

    [Tooltip("ジャンプ機能")] [SerializeField]
    Jump_ForceBody _jump;

    [Tooltip("かける力を足場の角度に沿わせる設定")] [SerializeField]
    FollowVectorToScaffold _followVectorToScaffold;

    [Header("試験的機能")]

    [CustomLabel("上方向にかける力")] [SerializeField]
    float _upPower;

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        //入力ベクトルをベースの方向(y方向は無視、z方向のみ)に向ける
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        Vector3 force = forceDirection * _power;

        //試験機能(少し上にも力をかけるようにする)
        force += Vector3.up * _upPower;
        //

        force = _followVectorToScaffold.Follow(force);//力をかける方向を足場の角度に沿わせる

        if (_jump != null) force += _jump.JumpPower();//削除予定

        _body.AddForce(force,ForceMode.VelocityChange);
    }
}
