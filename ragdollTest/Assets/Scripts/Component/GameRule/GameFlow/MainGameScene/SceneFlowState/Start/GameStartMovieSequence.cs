using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

//作成者:杉山
//ゲーム開始時のムービー

public class GameStartMovieSequence : MonoBehaviour
{
    [SerializeField]
    HideUITypeBase _hideInGameUI;

    [SerializeField]
    ShowUITypeBase _showInGameUI;

    [SerializeField]
    CinemachineVirtualCamera _playCamera;

    [CustomLabel("ゲーム開始時に流すタイムライン")] [SerializeField]
    PlayableDirector _startMovieTimeline;

    public event Action OnMovieFinished;
    bool _isFinishedMovie = false;

    public void Play()//演出開始
    {
        StartCoroutine(MovieSequence());
    }

    public void OnFinishFadeOut()//フェードアウトが終わった瞬間に呼ぶ
    {
        _showInGameUI.Show();
        _playCamera.enabled = true;
    }

    IEnumerator MovieSequence()
    {
        _playCamera.enabled = false;
        _hideInGameUI.Hide();
        _startMovieTimeline.Play();

        yield return new WaitUntil(()=>_isFinishedMovie);

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
