using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//リスタート時のプレイヤーの位置を初期地点に戻す処理

public partial class RestartManager
{
    [System.Serializable]
    class PlayerPosControl
    {
        [CustomLabel("リスタート地点&方向")] [Tooltip("プレイヤーがこの地点に出現＆この方向に向かって投げ飛ばされる")] [SerializeField]
        Transform _restartPoint;

        [CustomLabel("プレイヤーの位置情報")] [Tooltip("プレイヤーの一番上の階層のTransformを入れてください")] [SerializeField]
        TransformReference _playerTrs;

        [CustomLabel("プレイヤーのRigidbody")] [SerializeField]//プレイヤーをスタート地点に投げ飛ばす際に使う
        RigidbodyReference _body;

        [CustomLabel("かける力の大きさ")] [SerializeField]
        float _power;

        public void BackToRestartPoint()//プレイヤーをリスタート地点に移動させる
        {
            _body.Rigidbody.isKinematic = true;
            _playerTrs.Transform.position = _restartPoint.position;
        }

        public void ThrowPlayer()//初期地点に戻るように投げ飛ばす
        {
            _body.Rigidbody.isKinematic=false;
            Vector3 force = _restartPoint.forward * _power;
            _body.Rigidbody.AddForce(force,ForceMode.VelocityChange);
        }
    }
}
