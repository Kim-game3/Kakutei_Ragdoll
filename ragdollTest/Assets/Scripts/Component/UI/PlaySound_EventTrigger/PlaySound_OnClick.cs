using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//ì¬Ò:™R
//ƒ{ƒ^ƒ“Œˆ’è‚É‰¹‚ğ–Â‚ç‚·

public class PlaySound_OnClick : MonoBehaviour, IPointerClickHandler, ISubmitHandler
{
    [SerializeField]
    AudioSource _audioSource;

    [CustomLabel("–Â‚ç‚µ‚½‚¢‰¹Œ¹")] [SerializeField] 
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
    