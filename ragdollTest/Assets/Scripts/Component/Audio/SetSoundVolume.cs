using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//�쐬��:���R
//���ʂ�����������(�ŏ��̃V�[���ɒu���΃Q�[�����n�߂��u�Ԃɉ��ʂ��ݒ肳���)

public class SetSoundVolume : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] SoundConfigs _soundConfigs;

    private void Start()
    {
        //AudioMixer�̉��ʂ̏�����
        for(int i=0; i<(int)ESoundType.Length ;i++)
        {
            ESoundType type = (ESoundType)i;

            string soundName=AudioMixerName.SoundName(type);

            SoundVolumeData volumeData = PlayerDataManager.GetSoundVolume(type);//���ʃf�[�^�̎擾

            float volume = (volumeData != null) ? volumeData.Value : _soundConfigs.DefaultVolume(type);

            _audioMixer.SetFloat(soundName,volume);
        }
    }
}
