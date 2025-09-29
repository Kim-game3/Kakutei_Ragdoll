using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬��:���R
//�{�^�����莞�ɉ���炷

public class PlaySound_OnClick : MonoBehaviour, IPointerClickHandler, ISubmitHandler
{
    [SerializeField]
    AudioSource _audioSource;

    [CustomLabel("�炵��������")] [SerializeField] 
    AudioClip _clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        _audioSource.PlayOneShot(_clip);
    }

    public void OnSubmit(BaseEventData eventData)
    {
        _audioSource.PlayOneShot(_clip);
    }
}
    