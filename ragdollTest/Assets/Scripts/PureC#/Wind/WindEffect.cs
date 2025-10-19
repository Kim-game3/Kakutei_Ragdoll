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

    public void Switchvisible(bool isActive)//可視状態を切り替え
    {
        if (_effect.gameObject.activeSelf == isActive) return;

        _effect.gameObject.SetActive(isActive);
    }

    public void Stop()//エフェクトを止める
    {
        _effect.Stop();
    }


    public void Play()//エフェクトを再生する
    {
        _effect.Play();
    }
}
