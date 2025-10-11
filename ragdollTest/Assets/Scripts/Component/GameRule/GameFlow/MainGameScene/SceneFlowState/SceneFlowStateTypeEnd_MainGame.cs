using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̃Q�[���I���X�e�[�g

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- ���̃V�[���J�� --- //
    [Tooltip("���U���g�V�[��")] [SerializeField]
    SceneReference _resultScene;

    [Tooltip("�Q�[���N���A���o")] [SerializeField]
    PlayableDirector _gameClearTimeline;

    [SerializeField]
    JudgeGameSet _judgeGameSet;

    [SerializeField] 
    RestartProcess _restartManager;

    [SerializeField]
    ResultManager _result;//���ʂ��������ރN���X

    public override void OnEnter()
    {
        _gameClearTimeline.Play();//���o�J�n
        _result.ConfirmResult();//���ʊm��
        _restartManager.enabled = false;//���X�^�[�g���N����Ȃ��悤�ɂ���
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        SceneManager.LoadScene(_resultScene.ScenePath);
    }

    private void Awake()
    {
        //���o���I�������V�[���J�ڂ���悤�ɂ���
        _gameClearTimeline.stopped += SetStateFinished;
    }

    void SetStateFinished(PlayableDirector director)
    {
        _finished = true;
    }
}

