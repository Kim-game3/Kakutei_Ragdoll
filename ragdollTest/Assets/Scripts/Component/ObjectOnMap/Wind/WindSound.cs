using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の効果音の設定
//enabledをfalseにすると、その風の効果音は流れなくなる


public class WindSound : MonoBehaviour
{
    [Range(0, 1)]
    [Tooltip("音量、0～1の間で選択")]
    [SerializeField]
    float _volume = 1;

    [SerializeField]
    float _priority;

    public float Volume { get { return _volume; } }

    public float Priority { get { return _priority; } }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.WindSE_Listener)) return;

        WindSE_Listener listener = other.GetComponent<WindSE_Listener>();

        if (listener == null) return;

        listener.Add(this);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.WindSE_Listener)) return;

        WindSE_Listener listener = other.GetComponent<WindSE_Listener>();

        if (listener == null) return;

        listener.Remove(this);
    }
}
