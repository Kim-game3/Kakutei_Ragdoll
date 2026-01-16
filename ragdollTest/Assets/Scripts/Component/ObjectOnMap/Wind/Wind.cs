using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風を出す機能
//WindZoneがついたオブジェクトの中心から青い矢印の方向に向かって四角形型の風が吹く

public partial class Wind : MonoBehaviour
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

    [SerializeField]
    GetWindAffectBody _getWindAffectBody;

    [SerializeField]
    float _delayDuration=0.8f;

    Coroutine _blowWindCoroutine;
    bool _isBlowing = false;

    readonly WindInfo _myWindInfo=new WindInfo();

    private void Awake()
    {
        _getWindAffectBody.Get();

        _judgeIsNearFromMainCamera.Awake();
    }

    private void OnValidate()
    {
        _getWindAffectBody.Get();
        _windEffect.OnValidate(_windZone.transform.localScale);
    }

    private void OnEnable()//風の吹き始め
    {
        _judgeIsNearFromMainCamera.Update();

        if(_judgeIsNearFromMainCamera.IsClose)//カメラが近くにいたら風が吹き始める
        {
            _blowWindCoroutine = StartCoroutine(StartBlowWind());
        }

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;
    }

    private void OnDisable()//風の吹き終わり
    {
        if (_blowWindCoroutine != null) StopCoroutine(_blowWindCoroutine);
        _isBlowing = false;

        _judgeIsNearFromMainCamera.OnClose -= OnClose;
        _judgeIsNearFromMainCamera.OnFar -= OnFar;

        SetWindEffect(false);
        SetWindSound(false);
    }

    void OnClose()//カメラとの距離が近くなった時
    {
        //もう既にエフェクト待ちが終わっていたらすぐに表示
        bool canStartImmediately = _isBlowing || _blowWindCoroutine == null;

        if (!canStartImmediately) return;

        _isBlowing = true;
        SetWindEffect(true);
        SetWindSound(true);
    }

    void OnFar()//カメラとの距離が遠くなった時
    {
        _windEffect.ToInvisible();
        SetWindSound(false);
    }

    IEnumerator StartBlowWind()
    {
        SetWindEffect(true);

        yield return new WaitForSeconds(_delayDuration);

        SetWindSound(true);
        _isBlowing = true;

        _blowWindCoroutine = null;
    }

    void SetWindEffect(bool play)
    {
        if (_windEffect != null) _windEffect.EffectSwitchActive(play);
    }

    void SetWindSound(bool enable)
    {
        if (_windSound != null) _windSound.enabled = enable;
    }

    void JudgeWindHit()//風の当たり判定処理
    {
        if (!_isBlowing) return;

        _windZone.IsHit(out bool isHitPlayer);

        if (!isHitPlayer) return;//プレイヤーに当たっていなかったら何もしない

        _myWindInfo.Set(_windZone.transform.forward, _windPower);
        _getWindAffectBody.PlayerWindAffect.AddWind(_myWindInfo);
    }

    private void Update()
    {
        _judgeIsNearFromMainCamera.Update();

        //風の当たり判定関係
        JudgeWindHit();
    }
}
