using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//アザラシの叫ぶ動作
//頭は向いてる方向に動くようにする

public class Scream : MonoBehaviour
{
    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    AudioClip _screamClip;

    [SerializeField]
    RigidbodyReference _head;

    [SerializeField]
    float _power;

    [SerializeField]
    float _coolTime = 2f;

    bool _isCoolTime = false;

    public event Action OnScream;

    public void ScreamTrigger(InputAction.CallbackContext context)
    {
        if(!context.performed) return;

        if (_isCoolTime) return;//クールタイム中は叫べない

        //音を鳴らす
        if(_audioSource!=null && _screamClip!=null)
        {
            _audioSource.PlayOneShot(_screamClip);
        }

        //力をかける
        var headRb = _head.Rigidbody;
        Vector3 force = headRb.transform.forward * _power;
        headRb.AddForce(force, ForceMode.VelocityChange);

        //コールバック呼び出し
        OnScream?.Invoke();

        //クールタイム開始
        StartCoroutine(CoolTimeCoroutine());
    }

    IEnumerator CoolTimeCoroutine()
    {
        _isCoolTime = true;
        yield return new WaitForSeconds(_coolTime);
        _isCoolTime = false;
    }
}
