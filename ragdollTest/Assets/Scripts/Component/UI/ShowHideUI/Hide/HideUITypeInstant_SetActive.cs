using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//UI�̔�\��(�����Ƀp�b�Ɣ�\���ɂ���^�C�v)

public class HideUITypeInstant_SetActive : HideUITypeBase
{
    [CustomLabel("��\���ɂ�����UI�Q")] [SerializeField]
    GameObject _hideUIObject;

    public override void Hide()
    {
        _hideUIObject.SetActive(false);
    }
}
