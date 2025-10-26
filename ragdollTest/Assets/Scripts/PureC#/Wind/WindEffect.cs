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

    bool _isActive=true;

    public void Awake()
    {
        //最初に風のエフェクトが非アクティブになってたら表示しないようにする
        _isActive=_effect.gameObject.activeSelf;
    }

    public void Switchvisible(bool isActive)//可視状態を切り替え
    {
        if (!_isActive) return;

        if (_effect.gameObject.activeSelf == isActive) return;

        _effect.gameObject.SetActive(isActive);
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
