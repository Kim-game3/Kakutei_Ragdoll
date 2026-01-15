using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風のエフェクト

[System.Serializable]
public class WindEffect
{
    [SerializeField]
    ParticleSystem _effect;

    [Tooltip("自動的にサイズを調整するか")] [SerializeField]
    bool _autoSize;

    const float _effectScaleZ = 0.2f;

    bool _isActive=true;

    public void Awake()
    {
        //最初に風のエフェクトが非アクティブになってたら表示しないようにする
        _isActive=_effect.gameObject.activeSelf;
    }

    public void OnValidate(Vector3 windZoneScale)
    {
        //エフェクトのサイズを自動調整
        if (!_autoSize) return;

        if(_effect==null) return;

        ParticleSystem[] effects = _effect.GetComponentsInChildren<ParticleSystem>();

        //lifeTimeの調整
        for(int i=0; i<effects.Length ;i++)
        {
            var mainModule=effects[i].main;
            mainModule.startLifetime=windZoneScale.z/ mainModule.startSpeed.constant;
        }

        //サイズの調整
        for(int i=0; i<effects.Length ;i++)
        {
            var effectShape = effects[i].shape;

            effectShape.scale = new Vector3(windZoneScale.x, windZoneScale.y, _effectScaleZ);
        }
    }

    public void ToInvisible()//エフェクトを見えなくする
    {
        if (!_isActive) return;

        _effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void Stop()//エフェクトを止める
    {
        if (!_isActive) return;

        _effect.Stop();
    }


    public void Play()//エフェクトを再生する
    {
        if (!_isActive) return;

        _effect.Play();
    }
}
