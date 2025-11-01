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

    [Tooltip("カメラとの距離を測る機能\n距離は風の描画距離になるので、windHitZoneのトリガーよりも広めに取っておくとよい")] [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("エフェクト関係")] [SerializeField]
    WindEffect _windEffect;

    [Tooltip("風の当たり判定")] [SerializeField]
    WindHitZone _windZone;

    [Tooltip("プレイヤーに風の影響を与える機能")] [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo=new WindInfo();

    private void Awake()
    {
        GetWindAffectBody();

        _windCycle.OnTrue += OnBlowWind;
        _windCycle.OnFalse += OnStopWind;

        _judgeIsNearFromMainCamera.Awake();

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;

        _windEffect.Awake();
    }

    private void Start()
    {
        _judgeIsNearFromMainCamera.Update();

        if (_judgeIsNearFromMainCamera.IsClose) OnClose();
        else OnFar();
    }

    private void OnValidate()
    {
        GetWindAffectBody();
        _windEffect.OnValidate(_windZone.transform.localScale);
    }

    void GetWindAffectBody()//プレイヤーのWindAffectBodyを取得
    {
        if (_playerWindAffect != null) return;

        GameObject windAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect);

        if (windAffect == null) return;

        WindAffectBody get = windAffect.GetComponent<WindAffectBody>();

        if (get == null) return;

        _playerWindAffect = get;
    }

    void SetWindInfo()
    {
        if (_myWindInfo == null)
        {
            Debug.Log("風の情報がインスタンス化されていません！");
            return;
        }

        _myWindInfo.Direction = _windZone.transform.forward;
        _myWindInfo.Power = _windPower;
    }

    void OnClose()//近くなった時
    {
        _windEffect.Switchvisible(true);

        if (_windCycle.IsActive) _windEffect.Play();
        else _windEffect.Stop();
    }

    void OnFar()//遠くなった時
    {
        _windEffect.Switchvisible(false);
    }

    private void OnBlowWind()//風が吹き始めた時
    {
        _windEffect.Play();
    }

    private void OnStopWind()//風が止んだ時
    {
        _windEffect.Stop();
    }

    private void Update()
    {
        _judgeIsNearFromMainCamera.Update();

        _windCycle.Update();

        if (!_windCycle.IsActive) return;//風が吹いてなければここで打ち切り

        _windZone.IsHit(out bool isHitPlayer);

        if (isHitPlayer)//プレイヤーに当たっていたら、プレイヤーを風で吹き飛ばす
        {
            SetWindInfo();
            _playerWindAffect.AddWind(_myWindInfo);
        }
    }
}
