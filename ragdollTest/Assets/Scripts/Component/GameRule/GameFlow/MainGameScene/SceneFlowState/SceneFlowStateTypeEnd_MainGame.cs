using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーンの流れ(メインゲームシーン)のゲーム終了ステート

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- 次のシーン遷移 --- //
    [SerializeField] SceneReference _resultScene;
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("シーン遷移するまでにかける時間")] [SerializeField] float _sceneChangeDuration;

    // --- ゲーム終了時に表示するUI ---//
    [CustomLabel("クリア時に表示するUI")] [SerializeField]
    GameObject _clearScreen;

    [SerializeField]
    ResultManager _result;//結果を書き込むクラス

    public override void OnEnter()
    {
        _clearScreen.SetActive(true);
        _result.ConfirmResult();//結果確定
        StartCoroutine(StateFinishFlow());
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        SceneManager.LoadScene(_resultScene.ScenePath);
    }



    IEnumerator StateFinishFlow()//とりあえず仮で書いたもの(後に削除予定)
    {
        yield return new WaitForSeconds(_sceneChangeDuration);

        _finished = true;
    }
}

