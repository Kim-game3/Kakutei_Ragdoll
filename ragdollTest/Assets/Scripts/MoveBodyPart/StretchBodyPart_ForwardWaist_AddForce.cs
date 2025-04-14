using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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

    public void Stretch()//伸ばす
    {
        AddForce_MovePart();
    }

    public void Stretch(InputAction.CallbackContext context)//伸ばす(InputSystemから呼び出す用)
    {
        if (!context.performed) return;

        AddForce_MovePart();
    }

    void AddForce_MovePart()//動かす部位に力を加える
    {
        Vector3 moveDirection = (_pos_Stretched_Transform.position - _movePart.position).normalized;//パーツの位置から動かす目標位置までの単位ベクトル(方向)

        Vector3 moveVec = moveDirection * _stretchPower;

        _movePart.AddForce(moveVec, ForceMode.Impulse);

        Debug.Log("動いたよ");
    }
}
