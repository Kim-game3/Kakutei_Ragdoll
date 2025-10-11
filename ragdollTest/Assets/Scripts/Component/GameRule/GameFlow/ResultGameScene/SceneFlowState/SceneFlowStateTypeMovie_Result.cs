using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//作成者:杉山
//シーンの流れ(リザルトシーン)のムービーステート
//スキップも出来るようにする

public class SceneFlowStateTypeMovie_Result : SceneFlowStateTypeBase
{

    [Tooltip("最初に選択状態になるボタン")] [SerializeField]
    Button _defaultButton;

    [SerializeField]
    EventSystem _eventSystem;

    [SerializeField]
    PlayableDirector _resultMovieTimeline;

    public override void OnEnter()
    {
        _resultMovieTimeline.Play();
        _eventSystem.SetSelectedGameObject(_defaultButton.gameObject);
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
}
