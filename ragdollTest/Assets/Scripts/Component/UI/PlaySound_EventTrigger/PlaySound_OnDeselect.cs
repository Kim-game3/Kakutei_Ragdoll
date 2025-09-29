using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬��:���R
//�{�^����I�������ɉ���炷


public class PlaySound_OnDeselect : MonoBehaviour, IDeselectHandler
{
    [SerializeField]
    AudioSource _audioSource;

    [CustomLabel("�炵��������")] [SerializeField]
    AudioClip _clip;

    public void OnDeselect(BaseEventData eventData)
    {
        _audioSource.PlayOneShot(_clip);
    }
}
