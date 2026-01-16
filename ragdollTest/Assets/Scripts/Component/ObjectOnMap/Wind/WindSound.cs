using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//•—‚ÌŒø‰Ê‰¹
//enabled‚ğfalse‚É‚·‚é‚ÆA‚»‚Ì•—‚ÌŒø‰Ê‰¹‚Í—¬‚ê‚È‚­‚È‚é

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

    private void Awake()
    {
        _setPos.Awake(_myTrs, _windZoneTrs);
    }

    private void OnValidate()
    {
        _autoAudioResizer.OnValidate(_windZoneTrs, _windAudio);
    }

    private void OnEnable()
    {
        if (_windAudio != null) _windAudio.Play();
    }

    private void OnDisable()
    {
        if (_windAudio != null) _windAudio.Stop();
    }

    private void Update()
    {
        _setPos.Update();
    }
}
