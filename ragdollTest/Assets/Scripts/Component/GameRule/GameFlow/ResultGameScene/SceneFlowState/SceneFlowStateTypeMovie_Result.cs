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

    [SerializeField]
    PlayableDirector _resultMovieTimeline;

    public override void OnEnter()
    {
        _resultMovieTimeline.Play();
        HideUIs();
        _finished = false;
    }

    public override void OnUpdate() 
    {
    
    }

    public override void OnExit()
    {
        
    }

    private void Awake()
    {
        _resultMovieTimeline.stopped += SetFinishedTrue;
    }

    void SetFinishedTrue(PlayableDirector director)
    {
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
