using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//作成者:杉山
//音量を初期化する(最初のシーンに置けばゲームを始めた瞬間に音量が設定される)

public class SetSoundVolume : MonoBehaviour
{
    [SerializeField] AudioMixer _audioMixer;

    [SerializeField] [Tooltip("初期音量")]
    float _defaultVolume;

    private void Start()
    {
        //AudioMixerの音量の初期化
        for(int i=0; i<(int)ESoundType.Length ;i++)
        {
            ESoundType type = (ESoundType)i;

            string soundName=AudioMixerName.SoundName(type);

            bool haveSet = PlayerDataManager.HaveSetSoundVolume(type);//音量を変更したことがあるか

            float volume = haveSet ? PlayerDataManager.GetSoundVolume(type) : _defaultVolume;

            _audioMixer.SetFloat(soundName,volume);
        }
    }
}
