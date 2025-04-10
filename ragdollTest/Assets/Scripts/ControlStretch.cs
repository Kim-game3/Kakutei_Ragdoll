using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//伸ばす操作の適用
public class ControlStretch : MonoBehaviour
{
    [Header("伸ばす操作のボタン")]
    [SerializeField] KeyCode _keyCode_Stretch;
    [Header("どれを伸ばすか")]
    [SerializeField] StretchBodyPart_ForwardWaist_AddForce _stretchBody;

    void Update()
    {
        ApplyControl_Stretch();
    }

    void ApplyControl_Stretch()//操作の適用
    {
        if(Input.GetKeyDown(_keyCode_Stretch))
        {
            _stretchBody.Move();
        }
    }
}
