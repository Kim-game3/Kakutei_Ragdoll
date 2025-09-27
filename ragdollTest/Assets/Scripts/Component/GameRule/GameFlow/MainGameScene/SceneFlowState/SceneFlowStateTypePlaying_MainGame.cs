using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̃Q�[�����X�e�[�g

public class SceneFlowStateTypePlaying_MainGame : SceneFlowStateTypeBase
{
    // --- ����\�؂�ւ� --- // 
    [SerializeField] PlayerInput _playerInput;

    // --- �Q�[���I������ --- //
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("�X�g�b�v�E�H�b�`")] [SerializeField]
    StopWatch _stopWatch;

    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.Controllable);//�v���C���[�𑀍�\�ɂ���
        _stopWatch.SwitchStartStop();//�X�g�b�v�E�H�b�`�J�n
    }
    public override void OnUpdate()
    {
        if(_judgeGameSet.IsGameSet)//�X�e�[�g�̏I��
        {
            _finished = true;
        }
    }

    public override void OnExit()
    {
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.UnControllable);//�v���C���[�𑀍�s�\�ɂ���
        _stopWatch.SwitchStartStop();//�X�g�b�v�E�H�b�`��~
    }
}
