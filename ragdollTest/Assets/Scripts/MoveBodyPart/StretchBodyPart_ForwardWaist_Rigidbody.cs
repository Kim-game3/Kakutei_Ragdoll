using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//身体のパーツを胴の前方方向に伸ばす
//パーツを動かすか否かはenableを切り替えて行う
public class StretchBodyPart_ForwardWaist_Rigidbody : MonoBehaviour
{
    [Header("動かすパーツ")]
    [SerializeField] Rigidbody _movePart;
    [Header("伸ばした時のパーツの位置")]
    [SerializeField] Transform _pos_Stretched_Transform;
    [Header("伸ばす速さ")]
    [SerializeField] float _stretchSpeed;

    //パーツを動かす場合は、パーツが物理演算で動かないようにして、パーツを任意の位置まで動かす
    //動かさない場合は、パーツが物理演算で動くようにする

    private void FixedUpdate()
    {
        MovePart();
    }

    private void OnEnable()
    {
        SwitchKinematic_RigidbodyMovePart(true);
    }

    private void OnDisable()
    {
        SwitchKinematic_RigidbodyMovePart(false);
    }

    //動かすパーツのkinematicを切り替える
    void SwitchKinematic_RigidbodyMovePart(bool active)
    {
        _movePart.isKinematic = active;
    }

    //パーツを任意の位置まで動かす
    void MovePart()
    {
        Vector3 moveDirection = (_pos_Stretched_Transform.position - _movePart.position).normalized;//パーツの位置から動かす目標位置までの単位ベクトル(方向)

        Vector3 moveVec = moveDirection * _stretchSpeed*Time.fixedDeltaTime;

        _movePart.MovePosition(_movePart.position+moveVec);
    }
}
