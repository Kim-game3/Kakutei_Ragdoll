using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーンの流れ(リザルトシーン)のムービーステート
//スキップも出来るようにする

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
