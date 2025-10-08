using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���ɐZ���������Ƃ����m����

public class DetectTouchWater : MonoBehaviour
{
    bool _isTouching=false;

    public bool IsTouching { get { return _isTouching; } }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Water)) return;
        _isTouching = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Water)) return;
        _isTouching = false;
    }
}
