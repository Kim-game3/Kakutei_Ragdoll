using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�L�΂�����̓K�p
public class ControlStretch : MonoBehaviour
{
    [Header("�L�΂�����̃{�^��")]
    [SerializeField] KeyCode _keyCode_Stretch;
    [Header("�ǂ��L�΂���")]
    [SerializeField] StretchBodyPart_ForwardWaist_AddForce _stretchBody;

    void Update()
    {
        ApplyControl_Stretch();
    }

    void ApplyControl_Stretch()//����̓K�p
    {
        if(Input.GetKeyDown(_keyCode_Stretch))
        {
            _stretchBody.Move();
        }
    }
}
