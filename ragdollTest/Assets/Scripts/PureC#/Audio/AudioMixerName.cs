using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//AudioMixer�̉��ʂ̎�ނ��Ƃ̖��O

public class AudioMixerName : MonoBehaviour
{
    readonly static Dictionary<ESoundType,string> _audioMixerSoundNameDic
        = new Dictionary<ESoundType, string>()
        {
            {ESoundType.Master,"Master" },//�}�X�^�[
            { ESoundType.SE,"SE"},//SE
            { ESoundType.BGM,"BGM"}//BGM
        };

    public static string SoundName(ESoundType type)
    {
        if(!_audioMixerSoundNameDic.TryGetValue(type,out var name))
        {
            Debug.Log("�擾�Ɏ��s���܂���");
            return null;
        }

        return name;
    }
}
