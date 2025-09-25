using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���I�[�o�[�ƃQ�[���N���A�𔻒f����
//�Q�[���I�[�o�[�ƃQ�[���N���A�������ɑ��݂��Ȃ��悤�ɂ���

//*���ӓ_
//������g���ہA�N���A����p�̃g���K�[�����邱��

public class JudgeGameSet : MonoBehaviour
{
    // --- �Q�[���I�[�o�[����p�ɕK�v --- //
    [CustomLabel("�������ԗp�̃^�C�}�[")] [SerializeField] 
    Timer _gameTimer;

    // --- �N���A����p�ɕK�v --- //
    const string _tagName_Player = "Player";

    //�N���A�E�Q�[���I�[�o�[���̎擾
    EGameState _gameState=EGameState.Playing;

    public EGameState GameState {  get { return _gameState; } }



    /// <summary>
    /// �Q�[���I�[�o�[����
    /// �������Ԑ؂�
    /// </summary>

    /// <summary>
    /// �Q�[���N���A����
    /// �N���A�̃g���K�[�ɐG�ꂽ�Ƃ�
    /// </summary>


    private void Awake()
    {
        //�Q�[���I�[�o�[����
        _gameTimer.TimeUpEvent += SwitchGameOver;
    }

    void SwitchGameOver()
    {
        SwitchState(EGameState.GameOver);
    }

    private void OnTriggerEnter(Collider other)//������ƕς��邩��
    {
        //�N���A����
        if (!other.CompareTag(_tagName_Player)) return;

        SwitchState(EGameState.Clear);
    }

    void SwitchState(EGameState newState)
    {
        //���ɃQ�[�����I�����Ă���ΕύX���Ȃ�
        if (_gameState != EGameState.Playing) return;

        _gameState = newState;
    }

}
