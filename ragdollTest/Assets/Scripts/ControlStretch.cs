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
    [SerializeField] StretchBodyPart_RigidRot _stretchBody;

    void Update()
    {
        ApplyControl_Stretch();
    }

    void ApplyControl_Stretch()//����̓K�p
    {
        _stretchBody.Stretching = Input.GetKey(_keyCode_Stretch);
    }
}
