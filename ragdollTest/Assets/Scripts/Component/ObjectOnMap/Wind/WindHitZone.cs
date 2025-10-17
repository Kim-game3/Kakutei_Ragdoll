using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の範囲(当たり判定機能)
//負荷軽減のため、プレイヤーがトリガー内に入ってきた時だけ風の当たり判定をするようにする
//中心から青い矢印の方向に向かって四角形型の風が吹く

public class WindHitZone : MonoBehaviour
{
    [Tooltip("風の影響を受けるレイヤー")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("プレイヤーのレイヤー")] [SerializeField]
    LayerMask _playerLayer;

    [Tooltip("プレイヤーが近づいてきたのを感知する機能\nこの範囲内にいないと、当たり判定をしないので十分に大きくすることをお勧めする")] [SerializeField]
    OnTriggerDetect _playerDetect;

    const float _boxcastSizeZ = 0.01f;
    bool _isPlayer_InWindableZone = false;//プレイヤーが風の当たり判定をする範囲(この範囲外にいたら当たり判定もしない)

    public bool IsHit(out Vector3 hitPos, out bool isHitPlayer)//何かに当たったか(衝突地点(hitPos)とプレイヤーに衝突したか(isHitPlayer)も教える)
    {
        hitPos = Vector3.zero;
        isHitPlayer = false;

        if (!_isPlayer_InWindableZone) return false;

        Vector3 boxcastSize = transform.localScale / 2;
        boxcastSize.z = _boxcastSizeZ;

        //平たい板状のレイを飛ばす
        if (!Physics.BoxCast(transform.position, boxcastSize, transform.forward, out RaycastHit hit, transform.rotation, transform.localScale.z, _affectableWindLayer)) return false;

        hitPos = hit.point;

        //何かに当たった
        if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) return true;

        //当たったのがプレイヤーであればプレイヤーがその風の影響を受けるようにする
        isHitPlayer = true;
        return true;
    }

    private void Awake()
    {
        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isPlayer_InWindableZone = true;
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isPlayer_InWindableZone = false;
    }
}
