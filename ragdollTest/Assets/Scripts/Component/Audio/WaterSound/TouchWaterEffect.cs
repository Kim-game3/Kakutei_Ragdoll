using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̂����ɐG�ꂽ���ɃG�t�F�N�g���o���@�\

public class TouchWaterEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    AudioClip _clip;

    [SerializeField]
    DetectTouchWater[] _detectTouchWaters;

    [SerializeField]
    RestartManager _restartManager;

    bool[] _isTouchingWaterBeforeFrame;

    private void Awake()
    {
        //������
        _isTouchingWaterBeforeFrame = new bool[_detectTouchWaters.Length];

        for(int i=0; i<_isTouchingWaterBeforeFrame.Length ;i++)
        {
            _isTouchingWaterBeforeFrame[i] = false;
        }
    }

    void Update()
    {
        //�O�t���[���őS�Ă̕��ʂŐG��ĂȂ������t���[���łǂ�����ł��G��Ă���ꍇ
        //���X�^�[�g���͗����Ȃ�
        if(isAllNoTouchingWaterBeforeFrame() && isAnyTouchingWaterNowFrame()&&!_restartManager.IsRestarting)
        {
            _audioSource.PlayOneShot(_clip);
        }

        //�O�t���[���̏�Ԃ��L�^
        for (int i = 0; i < _isTouchingWaterBeforeFrame.Length; i++)
        {
            _isTouchingWaterBeforeFrame[i] = _detectTouchWaters[i].IsTouching;
        }
    }

    //�O�t���[���őS���ʂ����ɐG��Ă��Ȃ���
    bool isAllNoTouchingWaterBeforeFrame()
    {
        bool ret = true;

        for (int i = 0; i < _isTouchingWaterBeforeFrame.Length; i++)
        {
            if (_isTouchingWaterBeforeFrame[i] == true)
            {
                ret = false;
                break;
            }
        }

        return ret;
    }

    //���t���[���ň�ł����ɐG��Ă��邩
    bool isAnyTouchingWaterNowFrame()
    {
        bool ret = false;

        for (int i = 0; i < _detectTouchWaters.Length; i++)
        {
            if (_detectTouchWaters[i].IsTouching == true)
            {
                ret = true;
                break;
            }
        }

        return ret;
    }
}
