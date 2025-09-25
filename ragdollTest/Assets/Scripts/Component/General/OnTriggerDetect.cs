using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�R�[���o�b�N�`����OnTrigger�ɃC�x���g��o�^�ł���

public class OnTriggerDetect : MonoBehaviour
{
    public event Action<Collider> OnStay;
    public event Action<Collider> OnEnter;
    public event Action<Collider> OnExit;

    private void OnTriggerStay(Collider other)
    {
        OnStay?.Invoke(other);
    }

    private void OnTriggerExit(Collider other)
    {
        OnExit?.Invoke(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        OnEnter?.Invoke(other);
    }
}
