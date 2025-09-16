using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//メインゲームシーンの流れ

public class MainGameSceneFlow : MonoBehaviour
{
    [CustomLabel("シーン遷移直後にゲームを開始するか")] [SerializeField]
    bool _playOnAwake;

    [Tooltip("開始処理のステート")] [SerializeField] SceneFlowStateTypeStart_MainGame _start;
    [Tooltip("ゲーム中のステート")] [SerializeField] SceneFlowStateTypePlaying_MainGame _playing;
    [Tooltip("終了処理のステート")] [SerializeField] SceneFlowStateTypeEnd_MainGame _end;

    SceneFlowStateTypeBase _currentState;//現在のステート

    //private

    void Start()
    {
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        //開始ステート
        ChangeState(_start);
        yield return CurrentStateUpdate();

        //プレイ中ステート
        ChangeState(_playing);
        yield return CurrentStateUpdate();

        //終了ステート
        ChangeState(_end);
        yield return CurrentStateUpdate();

        ChangeState(null);//終了にこれをしないと最後のステートのOnExitが呼ばれない
    }

    IEnumerator CurrentStateUpdate()//現在のステートの更新処理
    {
        while(!_currentState.Finished)
        {
            yield return null;
            if (_currentState!=null) _currentState.OnUpdate();
        }
    }


    void ChangeState(SceneFlowStateTypeBase nextState)//ステートの変更処理
    {
        if (_currentState != null) _currentState.OnExit();//ステートの終了処理

        _currentState = nextState;//ステートを変更

        if (_currentState != null) _currentState.OnEnter();//ステートの開始処理
    }
}
