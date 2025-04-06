using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//動かす身体のパーツに対して目的の方向に力を加え続ける
//動かすかどうかはenableを切り替えて行う
public class StretchBodyPart_ForwardWaist_AddForce : MonoBehaviour
{
    [Header("動かすパーツ")]
    [SerializeField] Rigidbody _movePart;
    [Header("伸ばした時のパーツの位置")]
    [SerializeField] Transform _pos_Stretched_Transform;
    [Header("伸ばす時にかける力")]
    [SerializeField] float _stretchPower;

    private void FixedUpdate()
    {
        MovePart();
    }

    void MovePart()
    {
        Vector3 moveDirection = (_pos_Stretched_Transform.position - _movePart.position).normalized;//パーツの位置から動かす目標位置までの単位ベクトル(方向)

        Vector3 moveVec = moveDirection * _stretchPower;

        _movePart.AddForce(moveVec,ForceMode.Force);

        Debug.Log("押してます");
    }
}
