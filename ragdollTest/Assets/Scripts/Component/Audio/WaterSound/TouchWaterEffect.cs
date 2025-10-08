using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//身体が水に触れた時にエフェクトを出す機能

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

    [SerializeField]
    ParticleSystem _waterSplashParticle;

    bool[] _isTouchingWaterBeforeFrame;

    private void Awake()
    {
        //初期化
        _isTouchingWaterBeforeFrame = new bool[_detectTouchWaters.Length];

        for(int i=0; i<_isTouchingWaterBeforeFrame.Length ;i++)
        {
            _isTouchingWaterBeforeFrame[i] = false;
        }
    }

    void Update()
    {
        Transform foo=null;

        //前フレームで全ての部位で触れてないかつ今フレームでどこか一つでも触れている場合
        //リスタート中は流さない
        if(isAllNoTouchingWaterBeforeFrame() && isAnyTouchingWaterNowFrame(ref foo)&&!_restartManager.IsRestarting)
        {
            _audioSource.PlayOneShot(_clip);

            if(foo!=null)
            {
                var ins= Instantiate(_waterSplashParticle, foo.position,Quaternion.identity);
                ins.Play();
                Destroy(ins.gameObject, 3);
            }
        }

        //前フレームの状態を記録
        for (int i = 0; i < _isTouchingWaterBeforeFrame.Length; i++)
        {
            _isTouchingWaterBeforeFrame[i] = _detectTouchWaters[i].IsTouching;
        }
    }

    //前フレームで全部位が水に触れていないか
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

    //今フレームで一つでも水に触れているか
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
