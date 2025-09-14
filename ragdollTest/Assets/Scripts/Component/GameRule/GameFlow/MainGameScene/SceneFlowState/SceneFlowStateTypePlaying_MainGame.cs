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

    // --- �������ԃ^�C�}�[ --- //
    [CustomLabel("�������ԗp�̃^�C�}�[")] [SerializeField]
    Timer _gameTimer;

    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(PlayerInput_ActionMapName.Controllable);//�v���C���[�𑀍�\�ɂ���
        //�^�C�}�[�J�n
    }
    public override void OnUpdate()
    {
        if(_judgeGameSet.GameState!=EGameState.Playing)//�X�e�[�g�̏I��
        {
            _finished = true;
        }
    }

    public override void OnExit()
    {
        _playerInput.SwitchCurrentActionMap(PlayerInput_ActionMapName.UnControllable);//�v���C���[�𑀍�s�\�ɂ���
        //�^�C�}�[�X�g�b�v
    }
}
