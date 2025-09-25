using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̎�ނ��Ƃɉ��ʂ͈̔͂⏉���l�Ƃ��������ʐݒ��ݒ�\

[CreateAssetMenu(fileName = "SoundConfig", menuName = "ScriptableObjects/SoundConfig")]
public class SoundConfigs : ScriptableObject
{
    [CustomLabel("�}�X�^�[���ʂ̐ݒ�")] [SerializeField]
    A_SoundVolumeConfig _masterVolumeConfig;

    [CustomLabel("SE���ʂ̐ݒ�")] [SerializeField]
    A_SoundVolumeConfig _seVolumeConfig;

    [CustomLabel("BGM���ʂ̐ݒ�")] [SerializeField]
    A_SoundVolumeConfig _bgmVolumeConfig;

    const float _errorValue = 0;//�G���[���ɂƂ肠�����Ԃ��l

    Dictionary<ESoundType, A_SoundVolumeConfig> _soundVolumeConfigsDic;



    //�ŏ�����
    public float MinVolume(ESoundType soundType)
    {
        if (!IsValidSoundType(soundType, out var config)) return _errorValue;

        return config.MinVolume;
    }

    //�ő剹��
    public float MaxVolume(ESoundType soundType)
    {
        if (!IsValidSoundType(soundType, out var config)) return _errorValue;

        return config.MaxVolume;
    }

    //��������
    public float DefaultVolume(ESoundType soundType)
    {
        if (!IsValidSoundType(soundType, out var config)) return _errorValue;

        return config.DefaultVolume;
    }

    //private
    bool IsValidSoundType(ESoundType soundType, out A_SoundVolumeConfig config)//���݂��鉹�̎�ނ�����(�Ȃ�������x��)
    {
        if (!_soundVolumeConfigsDic.TryGetValue(soundType, out config))
        {
            Debug.Log("�����Ɏ��s");
            return false;
        }

        return true;
    }

    private void Awake()
    {
        _soundVolumeConfigsDic 
            = new Dictionary<ESoundType, A_SoundVolumeConfig>() {
                {ESoundType.Master, _masterVolumeConfig },
                {ESoundType.SE, _seVolumeConfig },
                {ESoundType.BGM, _bgmVolumeConfig },
            };
    }

    private void OnValidate()
    {
        _masterVolumeConfig.OnValidate();
        _seVolumeConfig.OnValidate();
        _bgmVolumeConfig.OnValidate();
    }
}
