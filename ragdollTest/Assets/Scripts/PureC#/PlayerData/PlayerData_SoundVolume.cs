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

    public static bool HaveSetSoundVolume(ESoundType soundType)//��x�ł�������������������
    {
        if (!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("���ʃf�[�^�̎擾�Ɏ��s");
            return false;
        }

        return PlayerPrefs.HasKey(volumeName);
    }

    public static float GetSoundVolume(ESoundType soundType)//���ʃf�[�^�̎擾
    {
        if(!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("���ʃf�[�^�̎擾�Ɏ��s");
            return _errorVolume;
        }

        float ret = PlayerPrefs.GetFloat(volumeName);

        return ret;
    }

    public static void SetSoundVolume(ESoundType soundType,float volume)//���ʃf�[�^�̏�������
    {
        if (!_soundTypeNameDic.TryGetValue(soundType, out var volumeName))
        {
            Debug.Log("���݂��Ȃ����ʃf�[�^�ł�");
            return;
        }

        PlayerPrefs.SetFloat(volumeName, volume);
    }

    
}
