using Cinemachine;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

//�쐬��:���R
//�Q�[���J�n���̃��[�r�[

public class GameStartMovieSequence : MonoBehaviour
{
    [Tooltip("�X�L�b�v�����ۂɉ��b���_�܂Ŕ�΂���")] [SerializeField]
    float _skipDuration;

    [Header("�Q�[������UI")]

    [SerializeField]
    HideUITypeBase _hideInGameUI;

    [SerializeField]
    ShowUITypeBase _showInGameUI;

    [Header("���[�r�[����UI")]

    [SerializeField]
    HideUITypeBase _hideMovieUI;

    [SerializeField]
    ShowUITypeBase _showMovieUI;


    [Space]
    [SerializeField]
    CinemachineVirtualCamera _playCamera;

    [CustomLabel("�Q�[���J�n���ɗ����^�C�����C��")] [SerializeField]
    PlayableDirector _startMovieTimeline;

    public event Action OnMovieFinished;
    bool _isFinishedMovie = false;

    public void Skip(InputAction.CallbackContext context)//���o�̃X�L�b�v
    {
        if (!context.performed) return;

        if (_isFinishedMovie) return;//���Ƀ��[�r�[���I����Ă��疳��

        //�o�ߎ��Ԃ��X�L�b�v�Ŕ�΂��Ƃ�����߂��Ă��疳��
        float elapsed = (float)_startMovieTimeline.time;
        if (elapsed >= _skipDuration) return;

        _startMovieTimeline.time = _skipDuration;
        _startMovieTimeline.Evaluate();
    }

    public void Play()//���o�J�n
    {
        StartCoroutine(MovieSequence());
    }

    public void OnFinishFadeOut()//�t�F�[�h�A�E�g���I������u�ԂɌĂ�
    {
        _hideMovieUI.Hide();
        _showInGameUI.Show();
        _playCamera.enabled = true;
    }

    IEnumerator MovieSequence()
    {
        _showMovieUI.Show();
        _hideInGameUI.Hide();
        _startMovieTimeline.Play();

        yield return new WaitUntil(()=>_isFinishedMovie);//�^�C�����C���̃��[�r�[���I���܂ő҂�

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
