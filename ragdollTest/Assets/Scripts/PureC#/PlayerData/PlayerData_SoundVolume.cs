using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�f�[�^�̉��ʕ���

public partial class PlayerDataManager
{
    //---���ʊ֌W---//
    readonly static Dictionary<ESoundType, string> _soundTypeNameDic
        = new Dictionary<ESoundType, string>(){
            { ESoundType.Master,"MasterVolume"},//�}�X�^�[���ʂ̃f�[�^��
            { ESoundType.SE,"SEVolume"},//SE���ʂ̃f�[�^��
            {ESoundType.BGM,"BGMVolume"},//BGM���ʂ̃f�[�^��
    };

    const float _errorVolume = 0f;//�G���[���ɂƂ肠�����Ԃ����ʂ̒l

    public static SoundVolumeData GetSoundVolume(ESoundType soundType)//���ʃf�[�^�̎擾(��x���������������Ƃ��Ȃ��ꍇ��null��Ԃ�)
    {
        if (!IsValidSoundType(soundType, out var volumeName)) return null;

        SoundVolumeData ret=null;

        if(PlayerPrefs.HasKey(volumeName))
        {
            float volume = PlayerPrefs.GetFloat(volumeName); ;
            ret = new SoundVolumeData(volume);
        }

        return ret;
    }

    public static void SetSoundVolume(ESoundType soundType,float volume)//���ʃf�[�^�̏�������
    {
        if (!IsValidSoundType(soundType, out var volumeName)) return;   

        PlayerPrefs.SetFloat(volumeName, volume);
    }

    static bool IsValidSoundType(ESoundType soundType, out string volumeName)//���݂��鉹�̎�ނ�����(�Ȃ�������x��)
    {
        if (!_soundTypeNameDic.TryGetValue(soundType,out volumeName))
        {
            Debug.Log("�����Ɏ��s");
            return false;
        }

        return true;
    }

    
}
