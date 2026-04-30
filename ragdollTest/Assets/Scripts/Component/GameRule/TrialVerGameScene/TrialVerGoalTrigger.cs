using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class TrialVerGoalTrigger : MonoBehaviour
{
    [Tooltip("ゲームクリア演出")] [SerializeField]
    PlayableDirector _gameClearTimeline;

    [SerializeField]
    SceneReference _trialFinishScene;

    [SerializeField]
    RespawnProcess _restartManager;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _gameClearTimeline.Play();//演出開始
        _restartManager.enabled = false;//リスタートが起こらないようにする
    }

    void OnEnable()
    {
        //演出が終わったらシーン遷移するようにする
        _gameClearTimeline.stopped += LoadTrialFinishScene;
    }

    void OnDisable()
    {
        _gameClearTimeline.stopped -= LoadTrialFinishScene;
    }

    void LoadTrialFinishScene(PlayableDirector director)
    {
        if(_trialFinishScene == null) return;

        string scenePath = _trialFinishScene.ScenePath;

        if (scenePath == null) return;

        SceneManager.LoadScene(scenePath);
    }
}
