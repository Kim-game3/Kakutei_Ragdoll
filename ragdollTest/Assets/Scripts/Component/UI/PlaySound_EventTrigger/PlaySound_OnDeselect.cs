using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//作成者:杉山
//ボタン非選択化時に音を鳴らす
//ボタン本体につける

public class PlaySound_OnDeselect : MonoBehaviour, IDeselectHandler
{
    [SerializeField]
    AudioSource _audioSource;

    [CustomLabel("鳴らしたい音源")] [SerializeField]
    AudioClip _clip;

    public void OnDeselect(BaseEventData eventData)
    {
        if(_audioSource!=null&&_clip!=null)
        _audioSource.PlayOneShot(_clip);
    }
}
