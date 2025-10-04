using UnityEngine;

//�쐬��:���R
//UI�̔�\��(�����Ƀp�b�Ɣ�\���ɂ���^�C�v)

public class HideUITypeInstant : HideUITypeBase
{
    [CustomLabel("��\���ɂ�����UI�Q")] [SerializeField]
    CanvasGroup _hideUIGroup;

    const float _hideAlpha = 0;

    public override void Hide()
    {
        _hideUIGroup.alpha = _hideAlpha;
        _hideUIGroup.blocksRaycasts = false;
    }
}
