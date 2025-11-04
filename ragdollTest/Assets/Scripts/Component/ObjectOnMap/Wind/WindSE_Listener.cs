using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の効果音を聞くためのコンポーネント

public class WindSE_Listener : MonoBehaviour
{
    [Tooltip("風の効果音を流すためのAudioSource")]
    [SerializeField]
    AudioSource _windSEAudioSource;

    [SerializeField]
    PauseManager _pauseManager;

    List<WindSound> _windSoundList = new List<WindSound>();

    public void Add(WindSound windSound)
    {
        if (windSound == null) return;

        _windSoundList.Add(windSound);

        OnChangeSoundList();
    }

    public void Remove(WindSound windSound)
    {
        if (windSound == null) return;

        _windSoundList.Remove(windSound);

        OnChangeSoundList();
    }




    private void Awake()
    {
        _pauseManager.OnPause += OnPause;
        _pauseManager.OnResume += OnResume;
    }

    private void OnPause()
    {
        enabled = false;

        StopSound();
    }

    void OnResume()
    {
        enabled = true;
    }

    void PlaySound()
    {
        if (_windSEAudioSource.isPlaying) return;

        _windSEAudioSource.Play();
    }

    void StopSound()
    {
        if (!_windSEAudioSource.isPlaying) return;

        _windSEAudioSource.Stop();
    }

    void Update()
    {
        UpdateVolume();
    }

    void UpdateVolume()
    {
        if (_windSoundList.Count == 0)
        {
            StopSound();
            return;
        }

        foreach (var windSound in _windSoundList)
        {
            if (windSound.enabled)
            {
                _windSEAudioSource.volume = windSound.Volume;
                PlaySound();
                return;
            }
        }

        StopSound();
    }

    void OnChangeSoundList()
    {
        //優先度の高い順に並べる(一番最初の要素が優先度の高いものになるように)

        _windSoundList.Sort((a, b) => b.Priority.CompareTo(a.Priority));
    }
}
