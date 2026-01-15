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

    [Tooltip("エフェクト関係")] [SerializeField]
    WindEffect _windEffect;

    [Tooltip("効果音関係\n何も入れなければ音が鳴らなくなる")] [SerializeField] 
    WindSound _windSound;

    [Tooltip("風の当たり判定")] [SerializeField]
    WindHitZone _windZone;

    [Tooltip("プレイヤーに風の影響を与える機能")] [SerializeField]
    WindAffectBody _playerWindAffect;

    WindInfo _myWindInfo=new WindInfo();

    private void Awake()
    {
        GetWindAffectBody();

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

    private void OnEnable()
    {
        _windEffect.Play();
        if (_windSound != null) _windSound.enabled = true;
    }

    private void OnDisable()
    {
        _windEffect.Stop();
        if (_windSound != null) _windSound.enabled = false;
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
        if (enabled)
        {
            _windEffect.Play();
            if (_windSound != null) _windSound.enabled = true;
        }
        else
        {
            _windEffect.Stop();
            if (_windSound != null) _windSound.enabled = false;
        }
    }

    void OnFar()//遠くなった時
    {
        _windEffect.ToInvisible();
        if (_windSound != null) _windSound.enabled = false;
    }

    private void Update()
    {
        _judgeIsNearFromMainCamera.Update();

        _windZone.IsHit(out bool isHitPlayer);

        if (isHitPlayer)//プレイヤーに当たっていたら、プレイヤーを風で吹き飛ばす
        {
            SetWindInfo();
            _playerWindAffect.AddWind(_myWindInfo);
        }
    }
}
