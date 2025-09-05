using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���C���Q�[���V�[���̗���

public class MainGameSceneFlow : MonoBehaviour
{
    [CustomLabel("�V�[���J�ڒ���ɃQ�[�����J�n���邩")] [SerializeField]
    bool _playOnAwake;

    [Tooltip("�J�n�����̃X�e�[�g")] [SerializeField] SceneFlowStateTypeStart_MainGame _start;
    [Tooltip("�Q�[�����̃X�e�[�g")] [SerializeField] SceneFlowStateTypePlaying_MainGame _playing;
    [Tooltip("�I�������̃X�e�[�g")] [SerializeField] SceneFlowStateTypeEnd_MainGame _end;

    SceneFlowStateTypeBase _currentState;//���݂̃X�e�[�g
    Dictionary<SceneFlowStateTypeBase, EMainGameSceneState> _stateDic;

    bool _isRunning=false;


    public void StartGame()//�Q�[���J�n
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

        //�ŏ��̃X�e�[�g��ݒ�
        ChangeState(_start);

        bool shouldContinue;//�����邩

        do
        {
            yield return null;

            _currentState.OnUpdate();

            shouldContinue = SelectNextState();//�X�e�[�g�̕ύX����

        } while (shouldContinue);

        _isRunning = false;
    }


    bool SelectNextState()//�X�e�[�g�I�����A���̃X�e�[�g��I��(�I����ۂ�false��Ԃ�)
    {
        if (!_currentState.Finished) return true;

        if(!_stateDic.TryGetValue(_currentState,out EMainGameSceneState state))
        {
            Debug.Log("�X�e�[�g�̎擾�Ɏ��s���܂���");
            return false;
        }

        //���̃X�e�[�g��I��
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


    void ChangeState(SceneFlowStateTypeBase nextState)//�X�e�[�g�̕ύX����
    {
        if (_currentState != null) _currentState.OnExit();//�X�e�[�g�̏I������

        _currentState = nextState;//�X�e�[�g��ύX

        if (_currentState != null) _currentState.OnEnter();//�X�e�[�g�̊J�n����
    }
}
