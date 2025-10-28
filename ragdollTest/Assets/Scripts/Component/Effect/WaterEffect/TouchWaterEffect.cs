using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�g�̂����ɐG�ꂽ���ɃG�t�F�N�g���o���@�\

public class TouchWaterEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSource;

    [Tooltip("���ɐG�ꂽ���̌��ʉ�")] [SerializeField]
    AudioClip _clip;

    [Tooltip("���ɐG�ꂽ���Ƃ����m����@�\")] [SerializeField]
    DetectTouchWater[] _detectTouchWaters;

    [SerializeField]
    RestartProcess _restartProcess;

    [Tooltip("�����Ԃ��̃G�t�F�N�g")] [SerializeField]
    ParticleSystem _waterSplashParticle;

    [Tooltip("�����Ԃ��̎���\n���̎��Ԃ��߂���Ǝ����I�ɔj��")] [SerializeField]
    float _lifeTime=3;

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
        Transform foo=null;

        //�O�t���[���őS�Ă̕��ʂŐG��ĂȂ������t���[���łǂ�����ł��G��Ă���ꍇ
        //���X�^�[�g���͗����Ȃ�(��ŏC���\��)
        if(isAllNoTouchingWaterBeforeFrame() && isAnyTouchingWaterNowFrame(ref foo)&&!_restartProcess.IsRestarting)
        {
            _audioSource.PlayOneShot(_clip);

            if(foo!=null)
            {
                var ins= Instantiate(_waterSplashParticle, foo.position,Quaternion.identity);
                ins.Play();
                Destroy(ins.gameObject, _lifeTime);
            }
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

    //���t���[���ň�ł����ɐG��Ă��邩(��ŏC���\��)
    bool isAnyTouchingWaterNowFrame(ref Transform _bodyTrs)
    {
        bool ret = false;

        for (int i = 0; i < _detectTouchWaters.Length; i++)
        {
            if (_detectTouchWaters[i].IsTouching == true)
            {
                ret = true;
                _bodyTrs= _detectTouchWaters[i].transform;
                break;
            }
        }

        return ret;
    }
}
