using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̊J�n�X�e�[�g

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [SerializeField]
    GameStartMovieSequence _gameStartMovieSequence;

    [SerializeField]
    PlayerInput _playerInput;

    public override void OnEnter() 
    {
        _finished = false;
        _playerInput.SwitchCurrentActionMap(ActionMapNameDictionary.Movie);//����s�\�ɂ���
        _gameStartMovieSequence.Play();//�J�n���o���Đ�
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {

    }

    private void Awake()
    {
        _gameStartMovieSequence.OnMovieFinished += SetStateFinished;
    }

    void SetStateFinished()
    {
        _finished = true;
    }
}
