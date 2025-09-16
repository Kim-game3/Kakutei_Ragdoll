using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̊J�n�X�e�[�g

public class SceneFlowStateTypeStart_MainGame : SceneFlowStateTypeBase
{
    [CustomLabel("�ŏ��̕��ɍĐ�����^�C�����C��")] [SerializeField]
    PlayableDirector _playableDirector;

    [SerializeField]
    PlayerInput _playerInput;

    [CustomLabel("�J�n���o���I���܂ő҂���")] [SerializeField]
    float _waitDuration;

    public override void OnEnter() 
    {
        _finished = false;
        _playableDirector.Play();//�^�C�����C�����Đ�
        _playerInput.SwitchCurrentActionMap(PlayerInput_ActionMapName.UnControllable);//����s�\�ɂ���
        StartCoroutine(Wait_FinishStartEvent());
    }
    public override void OnUpdate() { }
    public override void OnExit() 
    {

    }

    IEnumerator Wait_FinishStartEvent()//�J�n���o���I���܂ő҂�
    {
        yield return new WaitForSeconds(_waitDuration);

        _finished = true;
    }
}
