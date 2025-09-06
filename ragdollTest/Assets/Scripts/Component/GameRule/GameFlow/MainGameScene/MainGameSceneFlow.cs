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
    Dictionary<SceneFlowStateTypeBase, EMainGameSceneState> _stateDic;

    bool _isRunning=false;


    public void StartGame()//ゲーム開始
    {
        StartCoroutine(GameFlow());
    }


    //private
    private void Awake()
    {
        _stateDic = new Dictionary<SceneFlowStateTypeBase, EMainGameSceneState>()
        {
            {_start,EMainGameSceneState.Start },
            {_playing,EMainGameSceneState.Playing},
            {_end,EMainGameSceneState.End }
        };
    }

    void Start()
    {
        if(_playOnAwake) StartGame();
    }

    IEnumerator GameFlow()
    {
        if(_isRunning) yield break;
        _isRunning = true;

        //最初のステートを設定
        ChangeState(_start);

        bool shouldContinue;//続けるか

        do
        {
            yield return null;

            _currentState.OnUpdate();

            shouldContinue = SelectNextState();//ステートの変更処理

        } while (shouldContinue);

        _isRunning = false;
    }


    bool SelectNextState()//ステート終了時、次のステートを選ぶ(終える際はfalseを返す)
    {
        if (!_currentState.Finished) return true;

        if(!_stateDic.TryGetValue(_currentState,out EMainGameSceneState state))
        {
            Debug.Log("ステートの取得に失敗しました");
            return false;
        }

        //次のステートを選ぶ
        switch(state)
        {
            case EMainGameSceneState.Start:
                ChangeState(_playing);
                break;

            case EMainGameSceneState.Playing:
                ChangeState(_end);
                break;

            case EMainGameSceneState.End:
                ChangeState(null);
                return false;
        }

        return true;
    }


    void ChangeState(SceneFlowStateTypeBase nextState)//ステートの変更処理
    {
        if (_currentState != null) _currentState.OnExit();//ステートの終了処理

        _currentState = nextState;//ステートを変更

        if (_currentState != null) _currentState.OnEnter();//ステートの開始処理
    }
}
