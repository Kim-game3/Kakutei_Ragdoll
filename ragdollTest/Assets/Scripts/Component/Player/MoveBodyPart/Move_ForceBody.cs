using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//身体に力をかけて移動させるコンポ―ネント

public class Move_ForceBody : MonoBehaviour
{
    [Tooltip("動かすキャラの身体のパーツ")] [SerializeField] Rigidbody _body;
    [Tooltip("かける力")] [SerializeField] float _power;
    [Tooltip("上の方にかけられる力")] [SerializeField] float _up;
    [Tooltip("このオブジェクトの前方向に力が加えられる")] [SerializeField] Transform _baseDirection;//これのz方向が前とする
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
        if(_shouldJump) forceDirection.y = _up;

        _body.AddForce(forceDirection*_power,ForceMode.VelocityChange);
    }
}
