using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:���R
//���U���g�V�[���̗���

public class ResultSceneFlow : MonoBehaviour
{
    [CustomLabel("�V�[���J�ڒ���ɃQ�[�����J�n���邩")] [SerializeField]
    bool _playOnAwake;

    [Tooltip("���[�r�[�V�[���̃X�e�[�g")][SerializeField] SceneFlowStateTypeMovie_Result _movie;
    [Tooltip("���ʕ\���̃X�e�[�g")] [SerializeField] SceneFlowStateTypeShowScore_Result _showScore;

    SceneFlowStateTypeBase _currentState;//���݂̃X�e�[�g

    //private

    void Start()
    {
        if (_playOnAwake) StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        //���[�r�[�X�e�[�g
        ChangeState(_movie);
        yield return CurrentStateUpdate();

        //���ʕ\���X�e�[�g
        ChangeState(_showScore);
        yield return CurrentStateUpdate();

        _currentState.OnExit();
    }

    IEnumerator CurrentStateUpdate()//���݂̃X�e�[�g�̍X�V����
    {
        while (!_currentState.Finished)
        {
            yield return null;
            if (_currentState != null) _currentState.OnUpdate();
        }
    }


    void ChangeState(SceneFlowStateTypeBase nextState)//�X�e�[�g�̕ύX����
    {
        if (_currentState != null) _currentState.OnExit();//�X�e�[�g�̏I������

        _currentState = nextState;//�X�e�[�g��ύX

        if (_currentState != null) _currentState.OnEnter();//�X�e�[�g�̊J�n����
    }
}
