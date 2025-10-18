using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

//作成者:杉山
//風の範囲(当たり判定機能)
//負荷軽減のため、プレイヤーがトリガー内に入ってきた時だけ風の当たり判定をするようにする
//中心から青い矢印の方向に向かって四角形型の風が吹く

public class WindHitZone : MonoBehaviour
{
    [Tooltip("プレイヤーが近づいてきたのを感知する機能\nこの範囲内にいないと、当たり判定をしないので十分に大きくすることをお勧めする")] [SerializeField]
    OnTriggerDetect _playerDetect;

    [SerializeField]
    WindCastHit _windCastHit;

    bool _isPlayer_InWindableZone = false;//プレイヤーが風の当たり判定をする範囲(この範囲外にいたら当たり判定もしない)

    public void IsHit(out bool isHitPlayer, out RaycastHit[] hits)//プレイヤーに衝突したか(isHitPlayer)、当たったコライダー(hits)
    {
        isHitPlayer = false;
        hits = null;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out isHitPlayer, out hits);//レイを飛ばす
    }

    public void IsHit(out RaycastHit[] hits)//当たったコライダー(hits)
    {
        hits = null;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out bool isHitPlayer, out hits);//レイを飛ばす
    }

    public void IsHit(out bool isHitPlayer)//プレイヤーに衝突したか(isHitPlayer)
    {
        isHitPlayer = false;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out isHitPlayer, out RaycastHit[] hits);//レイを飛ばす
    }



    //private
    private void Awake()
    {
        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;

        _windCastHit.Awake(transform);
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
