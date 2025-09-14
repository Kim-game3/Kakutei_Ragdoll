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

    //private

    void Start()
    {
        StartCoroutine(GameFlow());
    }

    IEnumerator GameFlow()
    {
        //�J�n�X�e�[�g
        ChangeState(_start);
        yield return CurrentStateUpdate();

        //�v���C���X�e�[�g
        ChangeState(_playing);
        yield return CurrentStateUpdate();

        //�I���X�e�[�g
        ChangeState(_end);
        yield return CurrentStateUpdate();

        ChangeState(null);//�I���ɂ�������Ȃ��ƍŌ�̃X�e�[�g��OnExit���Ă΂�Ȃ�
    }

    IEnumerator CurrentStateUpdate()//���݂̃X�e�[�g�̍X�V����
    {
        while(!_currentState.Finished)
        {
            yield return null;
            if (_currentState!=null) _currentState.OnUpdate();
        }
    }


    void ChangeState(SceneFlowStateTypeBase nextState)//�X�e�[�g�̕ύX����
    {
        if (_currentState != null) _currentState.OnExit();//�X�e�[�g�̏I������

        _currentState = nextState;//�X�e�[�g��ύX

        if (_currentState != null) _currentState.OnEnter();//�X�e�[�g�̊J�n����
    }
}
