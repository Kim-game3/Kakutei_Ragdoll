using UnityEngine;

//�쐬��:���R
//UI�̕\��(�����Ƀp�b�ƕ\������^�C�v)

public class ShowUITypeInstant : ShowUITypeBase
{
    [CustomLabel("�\��������UI�Q")] [SerializeField]
    CanvasGroup _showUIGroup;

    const float _showAlpha = 1;

    public override void Show()
    {
        _showUIGroup.alpha = _showAlpha;
    }
}
