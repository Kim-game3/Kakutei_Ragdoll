using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���̗���(���U���g�V�[��)�̃��[�r�[�X�e�[�g
//�X�L�b�v���o����悤�ɂ���

public class SceneFlowStateTypeMovie_Result : SceneFlowStateTypeBase
{
    [SerializeField]
    HideUITypeBase[] _hideUIs;

    [SerializeField] float _delayTime;

    public override void OnEnter()
    {
        HideUIs();
        _finished = false;
        StartCoroutine(Wait());//�Ƃ肠�����͐��b�x�������Ă���I��点��
    }

    public override void OnUpdate() 
    {
    
    }

    public override void OnExit()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(_delayTime);

        _finished = true;
    }

    void HideUIs()
    {
        for(int i=0; i<_hideUIs.Length ;i++)
        {
            _hideUIs[i].Hide();
        }
    }
}
