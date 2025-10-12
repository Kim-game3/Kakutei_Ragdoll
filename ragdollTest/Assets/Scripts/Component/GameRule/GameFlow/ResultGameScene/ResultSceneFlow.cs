using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//作成者:杉山
//リザルトシーンの流れ

public class ResultSceneFlow : MonoBehaviour
{
    [CustomLabel("シーン遷移直後にゲームを開始するか")] [SerializeField]
    bool _playOnAwake;

    [Tooltip("ムービーシーンのステート")][SerializeField] SceneFlowStateTypeMovie_Result _movie;
    //[Tooltip("結果表示のステート")] [SerializeField] SceneFlowStateTypeShowScore_Result _showScore;

    SceneFlowStateTypeBase _currentState;//現在のステート

    //private

    void Start()
    {
        if (_playOnAwake) StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        //ムービーステート
        ChangeState(_movie);
        yield return CurrentStateUpdate();

        //結果表示ステート
        //ChangeState(_showScore);
        //yield return CurrentStateUpdate();

        _currentState.OnExit();
    }

    IEnumerator CurrentStateUpdate()//現在のステートの更新処理
    {
        while (!_currentState.Finished)
        {
            yield return null;
            if (_currentState != null) _currentState.OnUpdate();
        }
    }


    void ChangeState(SceneFlowStateTypeBase nextState)//ステートの変更処理
    {
        if (_currentState != null) _currentState.OnExit();//ステートの終了処理

        _currentState = nextState;//ステートを変更

        if (_currentState != null) _currentState.OnEnter();//ステートの開始処理
    }
}
