using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//リスタート時のプレイヤーの位置を初期地点に戻す処理

public partial class RestartProcess
{
    [System.Serializable]
    class PlayerPosControl
    {
        Transform _restartPoint;//リスタート地点&方向

        [CustomLabel("プレイヤーの位置情報")] [Tooltip("プレイヤーの一番上の階層のTransformを入れてください")] [SerializeField]
        TransformReference _playerTrs;

        [CustomLabel("プレイヤーのRigidbody")] [SerializeField]//プレイヤーをスタート地点に投げ飛ばす際に使う
        RigidbodyReference _body;

        float _power;//かける力の大きさ

        //リスタートが始まった瞬間に呼ばれる
        public void InitOnRestart(Transform restartPoint,float power)
        {
            _restartPoint=restartPoint;
            _power=power;
        }

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
