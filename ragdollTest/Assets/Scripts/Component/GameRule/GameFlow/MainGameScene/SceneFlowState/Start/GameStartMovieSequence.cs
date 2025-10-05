using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

//�쐬��:���R
//�Q�[���J�n���̃��[�r�[

public class GameStartMovieSequence : MonoBehaviour
{
    [SerializeField]
    HideUITypeBase _hideInGameUI;

    [SerializeField]
    ShowUITypeBase _showInGameUI;

    [SerializeField]
    CinemachineVirtualCamera _playCamera;

    [CustomLabel("�Q�[���J�n���ɗ����^�C�����C��")] [SerializeField]
    PlayableDirector _startMovieTimeline;

    public event Action OnMovieFinished;
    bool _isFinishedMovie = false;

    public void Play()//���o�J�n
    {
        StartCoroutine(MovieSequence());
    }

    public void OnFinishFadeOut()//�t�F�[�h�A�E�g���I������u�ԂɌĂ�
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

        //���[�r�[�I��
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
