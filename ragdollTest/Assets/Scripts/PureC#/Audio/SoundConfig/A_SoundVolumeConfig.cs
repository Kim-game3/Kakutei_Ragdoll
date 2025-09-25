using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���ʐݒ�(���ʂ͈̔́A�����l��ݒ�\)

[System.Serializable]
public class A_SoundVolumeConfig
{
    [CustomLabel("�ŏ�����")] [SerializeField]
    float _minVolume;

    [CustomLabel("���ʂ͈̔�")] [SerializeField]
    float _volumeRange;

    [CustomLabel("��������")] [SerializeField]
    float _defaultVolume;

    public void OnValidate()
    {
        //�������ʂ�͈͓��Ɏ��߂�悤�ɂ���
        _defaultVolume = Mathf.Clamp(_defaultVolume, _minVolume, MaxVolume);
    }

    //�Q�b�^�[

    public float MinVolume { get { return _minVolume; } }
    public float MaxVolume { get { return _minVolume+_volumeRange; } }
    public float DefaultVolume { get { return _defaultVolume; } }
}
