using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーンの流れ(メインゲームシーン)のゲーム終了ステート

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- 次のシーン遷移 --- //
    [SerializeField] SceneReference _gameClearScene;
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("シーン遷移するまでにかける時間")] [SerializeField] float _sceneChangeDuration;

    // --- ゲーム終了時に表示するUI ---//
    [CustomLabel("クリア時に表示するUI")] [SerializeField]
    GameObject _clearScreen;

    public override void OnEnter()
    {
        ResultShow();
        StartCoroutine(StateFinishFlow());
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        ChangeNextScene();
    }



    IEnumerator StateFinishFlow()//とりあえず仮で書いたもの(後に削除予定)
    {
        yield return new WaitForSeconds(_sceneChangeDuration);

        _finished = true;
    }

    void ResultShow()//結果表示
    {
        //クリアかゲームオーバーによって表示するUIを変更
        _clearScreen.SetActive(true);
    }

    void ChangeNextScene()//シーン遷移
    {
        //クリアかゲームオーバーによって遷移するシーンを変更
        SceneManager.LoadScene(_gameClearScene.ScenePath);
    }
}

