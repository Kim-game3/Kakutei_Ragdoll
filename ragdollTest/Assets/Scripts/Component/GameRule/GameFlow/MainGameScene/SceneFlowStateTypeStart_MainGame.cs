using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̊J�n�X�e�[�g

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [CustomLabel("�������ԗp�̃^�C�}�[")] [SerializeField]
    Timer _gameTimer;

    public override void OnEnter() 
    {
        _finished = true;//�Ƃ肠�����J�n�̉��o�͖�����
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {
        _gameTimer.TimerStart();
    }
}
