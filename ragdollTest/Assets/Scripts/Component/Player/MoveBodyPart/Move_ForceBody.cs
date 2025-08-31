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
    [CustomLabel("上の方にかける力")] [SerializeField]
    float _up;
    [Tooltip("このオブジェクトの前方向に力が加えられる")][CustomLabel("基準の方向")] [SerializeField]
    Transform _baseDirection;//このオブジェクトの地面に平行な+Z方向を前とする

    [SerializeField] FollowVectorToScaffold _followVectorToScaffold;
    [SerializeField] bool _activate_Follow;

    bool _shouldJump=false;

    public void Input_Move(InputAction.CallbackContext context)
    {
        if (!context.performed) return;//ボタンを押した瞬間発動

        Vector2 getVec = context.ReadValue<Vector2>();

        Debug.Log(getVec);

        Move(getVec);
    }

    public void Input_Jump(InputAction.CallbackContext context)
    {
        if (context.performed) _shouldJump = true;
        if(context.canceled) _shouldJump = false;
    }

    private void Move(Vector2 input)
    {
        Vector3 inputVec_3D = new Vector3(input.x, 0, input.y);

        //入力ベクトルをベースの方向(y方向は無視、z方向のみ)に向ける
        Vector3 forwardDirection = _baseDirection.forward;
        forwardDirection.y = 0;//床に対して水平

        Quaternion lookForward = Quaternion.LookRotation(forwardDirection);

        Vector3 forceDirection = lookForward * inputVec_3D;

        if(_activate_Follow) forceDirection = _followVectorToScaffold.Follow(forceDirection);//力をかける方向を足場の角度に沿わせる

        if(_shouldJump) forceDirection.y += _up;

        _body.AddForce(forceDirection*_power,ForceMode.VelocityChange);
    }
}
