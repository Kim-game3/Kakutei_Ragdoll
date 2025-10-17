using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風を出す機能
//負荷軽減のため、プレイヤーがある程度近づいてきた時に風が吹くようにする
//中心から青い矢印の方向に向かって四角形型の風が吹く

public class Wind : MonoBehaviour
{
    [SerializeField]
    float _windPower;

    [Tooltip("風の影響を受けるレイヤー")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("プレイヤーのレイヤー")] [SerializeField]
    LayerMask _playerLayer;

    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("プレイヤーが近づいてきたのを感知する機能\n十分に大きくすることをお勧めする")] [SerializeField]
    OnTriggerDetect _playerDetect;

    const float _boxcastSizeZ = 0.01f;
    bool _isNearPlayer = false;
    WindAffectBody _playerWindAffect;
    WindInfo _myWindInfo;

    private void Awake()
    {
        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;

        _myWindInfo = new WindInfo(transform.forward,_windPower);
    }

    private void OnValidate()
    {
        if (_myWindInfo == null) return;

        _myWindInfo.Direction = transform.forward;
        _myWindInfo.Power = _windPower;
    }

    private void OnBlowWind()//風が吹き始めた時
    {
        if (!_isNearPlayer) return;

        Debug.Log("風が吹く");
    }

    private void OnStopWind()//風が止んだ時
    {
        if (!_isNearPlayer) return;

        Debug.Log("風が止む");
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = true;

        if (_windCycle.IsActive) OnBlowWind();
        else OnStopWind();
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = false;
    }

    private void Update()
    {
        //プレイヤーが近くに来た時だけ風を出すようにする
        if (!_isNearPlayer) return;

        _windCycle.Update();

        if (!_windCycle.IsActive) return;

        //風が吹いている時の処理
        WindCast();
    }

    void WindCast()
    {
        Vector3 boxcastSize = transform.localScale / 2;
        boxcastSize.z = _boxcastSizeZ;

        //平たい板状のレイを飛ばす
        if (!Physics.BoxCast(transform.position, boxcastSize, transform.forward, out RaycastHit hit, transform.rotation, transform.localScale.z, _affectableWindLayer)) return;

        //当たったのがプレイヤーであればプレイヤーがその風の影響を受けるようにする
        if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) return;

        if (_playerWindAffect == null) _playerWindAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect).GetComponent<WindAffectBody>();

        _playerWindAffect.AddWind(_myWindInfo);
    }

}
