using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

//作成者:杉山
//起動直後のムービー

public class OpeningMovieManager : MonoBehaviour
{
    [Tooltip("オープニングのムービーのタイムライン")] [SerializeField]
    PlayableDirector _openingMovieTimeline;

    [Tooltip("タイトルシーン")] [SerializeField] 
    SceneReference _titleScene;

    [Tooltip("現在のシーン")] [SerializeField]
    SceneReference _currentScene;

    [Tooltip("スキップした際に何秒時点まで飛ばすか")] [SerializeField]
    float _skipDuration;

    bool _isFinishedMovie = false;

    public void Skip(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (_isFinishedMovie) return;//既にムービーが終わってたら無視

        //経過時間がスキップで飛ばすところを過ぎてたら無視
        float elapsed = (float)_openingMovieTimeline.time;
        if (elapsed >= _skipDuration) return;

        _openingMovieTimeline.time = _skipDuration;
        _openingMovieTimeline.Evaluate();
    }

    private void Awake()
    {
        _openingMovieTimeline.stopped += SetIsFinishedMovieTrue;
    }

    private void Start()
    {
        StartCoroutine(MovieSequence());
    }

    IEnumerator MovieSequence()
    {
        _openingMovieTimeline.Play();

        yield return new WaitUntil(() => _isFinishedMovie);//タイムラインのムービーが終わるまで待つ

        BeforeSceneMemo.BeforeScenePath = _currentScene.ScenePath;
        SceneManager.LoadScene(_titleScene.ScenePath);//シーンを切り替え
    }

    private void SetIsFinishedMovieTrue(PlayableDirector director)
    {
        _isFinishedMovie=true;
    }
}
