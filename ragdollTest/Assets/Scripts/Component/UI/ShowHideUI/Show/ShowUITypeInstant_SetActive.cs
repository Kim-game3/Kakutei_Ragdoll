//�쐬��:���R
//UI�̕\��(�����Ƀp�b�ƕ\������^�C�v)

using UnityEngine;

public class ShowUITypeInstant_SetActive : ShowUITypeBase
{
    [CustomLabel("�\��������UI�Q")] [SerializeField]
    GameObject _showUIObject;

    public override void Show()
    {
        _showUIObject.SetActive(true);
    }
}
