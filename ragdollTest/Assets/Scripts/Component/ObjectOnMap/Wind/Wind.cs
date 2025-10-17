using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風を出す機能
//WindZoneがついたオブジェクトの中心から青い矢印の方向に向かって四角形型の風が吹く

public class Wind : MonoBehaviour
{
    [Tooltip("風の強さ")] [SerializeField]
    float _windPower;

    [Tooltip("風が見える距離限界\n(WindHitZoneのトリガーより)かなり広めにとることをおすすめする")] [SerializeField]
    float _visibleDistanceLimit;

    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("自分の位置")] [SerializeField]
    Transform _myTrs;

    [SerializeField]
    WindHitZone _windZone;

    [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo;
    float _sqrtDistanceFromCamera;

    public bool IsInRangeVisibleWind { get { return (_sqrtDistanceFromCamera <= _visibleDistanceLimit * _visibleDistanceLimit); } }

    private void Awake()
    {
        if (_playerWindAffect == null) _playerWindAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect).GetComponent<WindAffectBody>();

        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _myWindInfo = new WindInfo(_windZone.transform.forward,_windPower);
    }

    private void OnValidate()
    {
        if (_myWindInfo == null) return;

        _myWindInfo.Direction = _windZone.transform.forward;
        _myWindInfo.Power = _windPower;
    }

    private void OnBlowWind()//風が吹き始めた時
    {
        if (!IsInRangeVisibleWind) return;

        Debug.Log("風が吹く");
    }

    private void OnStopWind()//風が止んだ時
    {
        if (!IsInRangeVisibleWind) return;

        Debug.Log("風が止む");
    }

    

    private void Update()
    {
        _sqrtDistanceFromCamera = (Camera.main.transform.position-_myTrs.position).sqrMagnitude;

        //プレイヤーが近くに来た時だけ風全体の処理をする
        if (!IsInRangeVisibleWind) return;

        _windCycle.Update();

        if (!_windCycle.IsActive) return;//風が吹いてなければここで打ち切り

        _windZone.IsHit(out Vector3 hitPos, out bool isHitPlayer);

        if(isHitPlayer)//プレイヤーに当たっていたら、プレイヤーを風で吹き飛ばす
        {
            AffectWindToPlayer();
        }
    }

    void AffectWindToPlayer()
    {
        _playerWindAffect.AddWind(_myWindInfo);
    }

}
