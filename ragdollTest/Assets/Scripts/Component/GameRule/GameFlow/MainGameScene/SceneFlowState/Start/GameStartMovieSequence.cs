using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

//作成者:杉山
//ゲーム開始時のムービー

public class GameStartMovieSequence : MonoBehaviour
{
    [Tooltip("スキップした際に何秒時点まで飛ばすか")] [SerializeField]
    float _skipDuration;

    [Header("ゲーム中のUI")]

    [SerializeField]
    HideUITypeBase _hideInGameUI;

    [SerializeField]
    ShowUITypeBase _showInGameUI;

    [Header("ムービー中のUI")]

    [SerializeField]
    HideUITypeBase _hideMovieUI;

    [SerializeField]
    ShowUITypeBase _showMovieUI;


    [Space]
    [Tooltip("プレイ用のカメラをまとめたもの")] [SerializeField]
    GameObject _playCameraObjects;

    [CustomLabel("ゲーム開始時に流すタイムライン")] [SerializeField]
    PlayableDirector _startMovieTimeline;

    public event Action OnMovieFinished;
    bool _isFinishedMovie = false;

    public void Skip(InputAction.CallbackContext context)//演出のスキップ
    {
        if (!context.performed) return;

        if (_isFinishedMovie) return;//既にムービーが終わってたら無視

        //経過時間がスキップで飛ばすところを過ぎてたら無視
        float elapsed = (float)_startMovieTimeline.time;
        if (elapsed >= _skipDuration) return;

        _startMovieTimeline.time = _skipDuration;
        _startMovieTimeline.Evaluate();
    }

    public void Play()//演出開始
    {
        StartCoroutine(MovieSequence());
    }

    public void OnFinishFadeOut()//フェードアウトが終わった瞬間に呼ぶ
    {
        _hideMovieUI.Hide();
        _showInGameUI.Show();
        _playCameraObjects.SetActive(true);
    }

    IEnumerator MovieSequence()
    {
        _showMovieUI.Show();
        _hideInGameUI.Hide();
        _startMovieTimeline.Play();

        yield return new WaitUntil(()=>_isFinishedMovie);//タイムラインのムービーが終わるまで待つ

        //ムービー終了
        OnMovieFinished?.Invoke();
    }

    private void Awake()
    {
        _startMovieTimeline.stopped += SetIsFinishedMovieTrue;
    }

    void SetIsFinishedMovieTrue(PlayableDirector director)
    {
        _isFinishedMovie = true;
    }
}
