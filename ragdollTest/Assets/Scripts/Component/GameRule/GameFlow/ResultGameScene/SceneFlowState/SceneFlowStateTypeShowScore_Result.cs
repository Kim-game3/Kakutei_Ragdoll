using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//作成者:杉山
//シーンの流れ(リザルトシーン)のスコア表示ステート

public class SceneFlowStateTypeShowScore_Result : SceneFlowStateTypeBase
{
    [Tooltip("結果表示演出のタイムライン")] [SerializeField]
    PlayableDirector _showScoreTimeLine;

    [Tooltip("演出が終わった後に最初に選択状態になるボタン")] [SerializeField]
    Button _defaultButton;

    [SerializeField]
    EventSystem _eventSystem;

    public override void OnEnter()
    {
        _showScoreTimeLine.Play();
    }
    public override void OnUpdate() 
    {
    
    }
    public override void OnExit()
    {
        _eventSystem.SetSelectedGameObject(_defaultButton.gameObject);
    }

    private void Awake()
    {
        _showScoreTimeLine.stopped += SetFinishedTrue;
    }

    void SetFinishedTrue(PlayableDirector director)
    {
        _finished = true;
    }
}
