using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーのいる方向を常に見続ける(y軸回転でのみ)

public class LookPlayer_OnlyYAxis : MonoBehaviour
{
    [SerializeField]
    Transform _myTrs;

    [SerializeField]
    TransformReference _target;

    private void OnValidate()
    {
        var hipRef = GameObject.FindWithTag(ObjectTagNameDictionary.PlayerHipRef);

        if (hipRef == null) return;

        var hipTrs = hipRef.GetComponent<TransformReference>();

        if (hipTrs == null) return;

        _target = hipTrs;
    }

    private void Update()
    {
        if (_myTrs == null || _target == null) return;

        // プレイヤーとの差分ベクトルを取得
        Vector3 direction = _target.Transform.position - _myTrs.position;

        // Y軸の回転のみにしたいので、高さ成分を無視
        direction.y = 0f;

        // 方向がゼロでなければ回転
        if (direction.sqrMagnitude <= 0f) return;

        // Y軸回転角度のみ計算
        float targetYAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;

        // 元の回転を保持しつつ Y だけ変更
        Vector3 euler = transform.eulerAngles;
        euler.y = targetYAngle;
        transform.eulerAngles = euler;
    }
}
