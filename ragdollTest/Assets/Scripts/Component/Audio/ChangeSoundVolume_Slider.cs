using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//�쐬��:���R
//�X���C�_�[�ŉ��ʂ�ύX����

public class ChangeSoundVolume_Slider : MonoBehaviour
{
    [CustomLabel("���̎��")] [SerializeField] 
    ESoundType _soundType;

    [CustomLabel("�g�p����X���C�_�[")] [SerializeField] 
    Slider _slider;

    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] SoundConfigs _soundConfigs;

    public void Change(float value)
    {
        string soundName = AudioMixerName.SoundName(_soundType);

        _audioMixer.SetFloat(soundName, value);

        PlayerDataManager.SetSoundVolume(_soundType, value);//�Z�[�u�f�[�^�̕��ɂ��L�^
    }

    //private
    private void Awake()
    {
        _slider.onValueChanged.AddListener(Change);
    }

    private void Start()
    {
        //�X���C�_�[�̍ő�l�ƍŏ��l��ݒ�
        _slider.maxValue = _soundConfigs.MaxVolume(_soundType);
        _slider.minValue= _soundConfigs.MinVolume(_soundType);

        //�X���C�_�[�̌��݂̒l��ݒ�
        string soundName = AudioMixerName.SoundName(_soundType);
        _audioMixer.GetFloat(soundName,out var value);
        _slider.value = value;
    }
}
