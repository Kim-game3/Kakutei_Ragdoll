using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//身体のパーツを胴の前方方向に伸ばす
//パーツを動かすか否かはenableを切り替えて行う
public class StretchForwardWaist_BodyPart : MonoBehaviour
{
    [Header("動かすパーツ")]
    [SerializeField] Rigidbody _movePart;
    [Header("新たな動かすパーツの向き")]
    [Tooltip("動かすパーツの向いてる方向が想定と違っていてパーツが動かせない場合に、これを使うことで新たに向きを定義することが出来る。\n" +
        "何も入れなければ上の動かすパーツ(MovePart)の向きを使用して処理を行う。")]
    [SerializeField] Transform _newDirection_MovePart;
    [Header("胴の位置")]
    [SerializeField] Transform _waistTransform;
    [Header("伸ばす速さ")]
    [SerializeField] float _stretchSpeed;

    private void FixedUpdate()
    {
        Stretch();
    }

    void Stretch()
    {
        Quaternion from = From();//現在の向き

        Quaternion to = _waistTransform.rotation;//胴の前方方向を目標とする

        float rotateSpeed = _stretchSpeed * Time.deltaTime;//回転スピード

        Quaternion rotate = Quaternion.RotateTowards(from, to, rotateSpeed);//回転クォータニオン

        _movePart.rotation = rotate;
    }

    Quaternion From()
    {
        if (_newDirection_MovePart == null)//新たな動かすパーツの向きが定義されていない場合、動かすパーツの向きをそのまま使う
        {
            return _movePart.transform.rotation;
        }

        return _newDirection_MovePart.rotation;
    }
}
