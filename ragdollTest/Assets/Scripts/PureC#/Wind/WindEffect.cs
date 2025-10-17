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

    public void Switchvisible(bool isActive)//����Ԃ�؂�ւ�
    {
        if (_effect.gameObject.activeSelf == isActive) return;

        _effect.gameObject.SetActive(isActive);
    }

    public void Stop()//�G�t�F�N�g���~�߂�
    {
        _effect.Stop();
    }


    public void Play()//�G�t�F�N�g���Đ�����
    {
        _effect.Play();
    }
}
