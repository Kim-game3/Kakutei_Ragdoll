using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//動くときにラグドールを回転させる(動きをつけさせる)機能

public class AddTorqueOnMove : MonoBehaviour
{
    [CustomLabel("かける力の大きさ")] [SerializeField]
    float _force;

    [Tooltip("移動機能")] [SerializeField]
    Move_ForceBody _move_ForceBody;

    Rigidbody _body;//動かす部位のRigidbody

    //private

    private void Awake()
    {
        _body=_move_ForceBody.Body;
        _move_ForceBody.OnMove_Vec += AddTorqueToBody;
    }

    void AddTorqueToBody(Vector3 forceDirection)
    {
        Quaternion axisRot= Quaternion.AngleAxis(90,Vector3.up);
        Vector3 axis = axisRot * forceDirection;

        Debug.DrawLine(_body.transform.position, _body.transform.position + axis, Color.green,5f);

        _body.AddTorque(axis*_force,ForceMode.VelocityChange);
    }

}
