using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の効果音
//enabledをfalseにすると、その風の効果音は流れなくなる

public class WindSound : MonoBehaviour
{
    [SerializeField]
    AudioSource _windAudio;

    [SerializeField]
    Transform _myTrs;

    [SerializeField]
    Transform _windZoneTrs;

    [SerializeField]
    AutoAudioDistanceResizer_WindSound _autoAudioResizer;

    [SerializeField]
    SetPosition_WindSound _setPos;

    [Tooltip("風が消える時の音のフェードアウトにかける時間")] [SerializeField]
    float _fadeOutDuration = 1f;

    float _maxVolume;

    Coroutine _soundFadeOut;

    private void Awake()
    {
        _setPos.Awake(_myTrs, _windZoneTrs);
        if (_windAudio != null) _maxVolume = _windAudio.volume;
    }

    private void OnValidate()
    {
        _autoAudioResizer.OnValidate(_windZoneTrs, _windAudio);
    }

    public void Play()
    {
        if(_soundFadeOut != null)
        {
            StopCoroutine(_soundFadeOut);
        }

        if (_windAudio != null)
        {
            _windAudio.volume = _maxVolume;
            _windAudio.Play();
        }
    }

    public void Stop()
    {
        if (!isActiveAndEnabled) return;
        if (_windAudio != null)
        {
            _soundFadeOut = StartCoroutine(SoundFadeout());
        }
    }

    IEnumerator SoundFadeout()
    {
        float current = 0;

        while(current<_fadeOutDuration)
        {
            current += Time.deltaTime;
            float rate = current / _fadeOutDuration;

            //音量を変更
            _windAudio.volume = Mathf.Lerp(_maxVolume, 0f, rate);

            yield return null;
        }

        _soundFadeOut = null;
    }

    private void Update()
    {
        _setPos.Update();
    }
}
