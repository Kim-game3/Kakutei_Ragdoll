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

    [Tooltip("�����I�ɃT�C�Y�𒲐����邩")] [SerializeField]
    bool _autoSize;

    const float _effectScaleZ = 0.2f;

    bool _isActive=true;

    public void Awake()
    {
        //�ŏ��ɕ��̃G�t�F�N�g����A�N�e�B�u�ɂȂ��Ă���\�����Ȃ��悤�ɂ���
        _isActive=_effect.gameObject.activeSelf;
    }

    public void OnValidate(Vector3 windZoneScale)
    {
        //�G�t�F�N�g�̃T�C�Y����������
        if (!_autoSize) return;

        if(_effect==null) return;

        ParticleSystem[] effects = _effect.GetComponentsInChildren<ParticleSystem>();

        //lifeTime�̒���
        for(int i=0; i<effects.Length ;i++)
        {
            var mainModule=effects[i].main;
            mainModule.startLifetime=windZoneScale.z/ mainModule.startSpeed.constant;
        }

        //�T�C�Y�̒���
        for(int i=0; i<effects.Length ;i++)
        {
            var effectShape = effects[i].shape;

            effectShape.scale = new Vector3(windZoneScale.x, windZoneScale.y, _effectScaleZ);
        }
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
