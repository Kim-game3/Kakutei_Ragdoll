using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーンの流れ(メインゲームシーン)のゲーム終了ステート

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- 次のシーン遷移 --- //
    [Tooltip("リザルトシーン")] [SerializeField]
    SceneReference _resultScene;

    [Tooltip("ゲームクリア演出")] [SerializeField]
    PlayableDirector _gameClearTimeline;

    [SerializeField]
    JudgeGameSet _judgeGameSet;

    [SerializeField] 
    RestartProcess _restartManager;

    [SerializeField]
    ResultManager _result;//結果を書き込むクラス

    public override void OnEnter()
    {
        _gameClearTimeline.Play();//演出開始
        _result.ConfirmResult();//結果確定
        _restartManager.enabled = false;//リスタートが起こらないようにする
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        SceneManager.LoadScene(_resultScene.ScenePath);
    }

    private void Awake()
    {
        //演出が終わったらシーン遷移するようにする
        _gameClearTimeline.stopped += SetStateFinished;
    }

    void SetStateFinished(PlayableDirector director)
    {
        _finished = true;
    }
}

