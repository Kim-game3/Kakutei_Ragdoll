using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃G�t�F�N�g

[System.Serializable]
public class WindEffect
{
    [SerializeField]
    ParticleSystem _effect;

    bool _isActive=true;

    public void Awake()
    {
        //�ŏ��ɕ��̃G�t�F�N�g����A�N�e�B�u�ɂȂ��Ă���\�����Ȃ��悤�ɂ���
        _isActive=_effect.gameObject.activeSelf;
    }

    public void Switchvisible(bool isActive)//����Ԃ�؂�ւ�
    {
        if (!_isActive) return;

        if (_effect.gameObject.activeSelf == isActive) return;

        _effect.gameObject.SetActive(isActive);
    }

    public void Stop()//�G�t�F�N�g���~�߂�
    {
        if (!_isActive) return;

        _effect.Stop();
    }


    public void Play()//�G�t�F�N�g���Đ�����
    {
        if (!_isActive) return;

        _effect.Play();
    }
}
