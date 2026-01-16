using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風のエフェクト

[System.Serializable]
public class WindEffect
{
    [Tooltip("特に何も入れなければエフェクトを表示しない")] [SerializeField]
    ParticleSystem _effect;

    [Tooltip("自動的にサイズを調整するか")] [SerializeField]
    bool _autoSize;

    const float _effectScaleZ = 0.2f;

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
        if (_effect == null) return;

        _effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }

    public void EffectSwitchActive(bool active)
    {
        if (_effect == null) return;

        if(active) _effect.Play();
        else _effect.Stop();
    }
}
