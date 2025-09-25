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

    [SerializeField] [Tooltip("��������")]
    float _defaultVolume;

    private void Start()
    {
        //AudioMixer�̉��ʂ̏�����
        for(int i=0; i<(int)ESoundType.Length ;i++)
        {
            ESoundType type = (ESoundType)i;

            string soundName=AudioMixerName.SoundName(type);

            bool haveSet = PlayerDataManager.HaveSetSoundVolume(type);//���ʂ�ύX�������Ƃ����邩

            float volume = haveSet ? PlayerDataManager.GetSoundVolume(type) : _defaultVolume;

            _audioMixer.SetFloat(soundName,volume);
        }
    }
}
