using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーとの距離を測る

public class CalcPlayerDistance : MonoBehaviour
{
    [SerializeField]
    TransformReference _playerPos;

    public float CalcSqrt(Vector3 position)//距離を2乗の状態のまま返す(処理はこちらの方が比較的軽い)
    {
        return (_playerPos.Transform.position - position).sqrMagnitude;
    }

    public float Calc(Vector3 position)//距離を返す(処理はこちらの方が比較的重い)
    {
        return Vector3.Distance(_playerPos.Transform.position,position);
    }

}
