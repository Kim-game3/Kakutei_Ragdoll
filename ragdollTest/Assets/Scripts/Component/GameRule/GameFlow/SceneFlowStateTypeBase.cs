using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�V�[���̗���̏�ԃN���X(�x�[�X)

public abstract class SceneFlowStateTypeBase : MonoBehaviour
{
    /// <summary>
    /// OnUpdate��OnEnter����_finished��true�ɂ���΁A���̃X�e�[�g�Ɉڂ�
    /// </summary>
    protected bool _finished;

    public bool Finished { get { return _finished; } }//�X�e�[�g���I�������


    public abstract void OnEnter();//�X�e�[�g�̊J�n����
    public abstract void OnUpdate();//�X�e�[�g�̖��t���[������
    public abstract void OnExit();//�X�e�[�g�̏I������
}
