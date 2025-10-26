using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�J�����Ƃ̋����ɉ����ăR���|�[�l���g��enable��؂�ւ���@�\

public class ActivateComponent_CameraDistance : MonoBehaviour
{
    [Tooltip("�J�����Ƃ̋����𑪂�@�\")] [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("�J�����Ƃ̋����ɉ����ăA�N�e�B�u��Ԃ�؂�ւ���R���|�[�l���g\n�J�����ɋ߂Â����玩���I��enable��true�ɂȂ�")] [SerializeField]
    Behaviour[] _behaviours;

    private void Awake()
    {
        _judgeIsNearFromMainCamera.Awake();

        _judgeIsNearFromMainCamera.OnClose += OnClose;
        _judgeIsNearFromMainCamera.OnFar += OnFar;
    }

    void OnClose()//�J�����Ƌ߂��Ȃ�����
    {
        SetEnabled(true);
    }

    void OnFar()//�J�����Ɖ����Ȃ�����
    {
        SetEnabled(false);
    }

    void SetEnabled(bool enabled)
    {
        for (int i = 0; i < _behaviours.Length; i++)
        {
            if (_behaviours[i] == null) continue;

            _behaviours[i].enabled = enabled;
        }
    }

    void Start()
    {
        _judgeIsNearFromMainCamera.Update();

        bool enabled = _judgeIsNearFromMainCamera.IsClose;

        SetEnabled(enabled);
    }

    void Update()
    {
        _judgeIsNearFromMainCamera.Update();
    }
}
