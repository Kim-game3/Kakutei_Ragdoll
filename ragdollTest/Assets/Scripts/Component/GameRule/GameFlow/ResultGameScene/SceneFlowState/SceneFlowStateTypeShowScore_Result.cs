using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�쐬��:���R
//�V�[���̗���(���U���g�V�[��)�̃X�R�A�\���X�e�[�g

public class SceneFlowStateTypeShowScore_Result : SceneFlowStateTypeBase
{
    [Tooltip("���ʕ\�����o�̃^�C�����C��")] [SerializeField]
    PlayableDirector _showScoreTimeLine;

    [Tooltip("���o���I�������ɍŏ��ɑI����ԂɂȂ�{�^��")] [SerializeField]
    Button _defaultButton;

    [SerializeField]
    EventSystem _eventSystem;

    public override void OnEnter()
    {
        _showScoreTimeLine.Play();
    }
    public override void OnUpdate() 
    {
    
    }
    public override void OnExit()
    {
        _eventSystem.SetSelectedGameObject(_defaultButton.gameObject);
    }

    private void Awake()
    {
        _showScoreTimeLine.stopped += SetFinishedTrue;
    }

    void SetFinishedTrue(PlayableDirector director)
    {
        _finished = true;
    }
}
