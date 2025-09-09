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
    const string _controllable_Game_ActionMapName = "Game";//�Q�[���̑���\
    const string _uncontrollable_ActionMapName = "Uncontrollable";//����s�\

    // --- �Q�[���I������ --- //
    [SerializeField] JudgeGameSet _judgeGameSet;


    public override void OnEnter()
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(_controllable_Game_ActionMapName);//�v���C���[�𑀍�\�ɂ���
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
        _playerInput.SwitchCurrentActionMap(_uncontrollable_ActionMapName);//�v���C���[�𑀍�s�\�ɂ���
    }
}
