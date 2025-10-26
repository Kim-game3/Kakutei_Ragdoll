using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�J�����Ƃ̋����ɉ�����Renderer��enable��؂�ւ���@�\

public class ActivateRenderer_CameraDistance_ : MonoBehaviour
{
    [Tooltip("�J�����Ƃ̋����𑪂�@�\")] [SerializeField]
    JudgeIsNearFromMainCamera _judgeIsNearFromMainCamera;

    [Tooltip("�J�����Ƃ̋����ɉ����ăA�N�e�B�u��Ԃ�؂�ւ���Renderer\n�J�����ɋ߂Â����玩���I��enable��true�ɂȂ�")] [SerializeField]
    Renderer[] _renderers;

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
        for (int i = 0; i < _renderers.Length; i++)
        {
            if (_renderers[i] == null) continue;

            _renderers[i].enabled = enabled;
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
