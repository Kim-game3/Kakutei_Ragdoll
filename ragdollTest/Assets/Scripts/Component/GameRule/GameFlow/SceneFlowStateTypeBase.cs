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

    /// <summary>
    ///�X�e�[�g�̊J�n����
    ///���̃X�e�[�g�ɂȂ������A��񂾂��Ă΂��
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    ///�X�e�[�g�̖��t���[������
    ///���̃X�e�[�g���A���t���[���Ă΂��
    /// </summary>
    public abstract void OnUpdate();

    /// <summary>
    ///�X�e�[�g�̏I������
    ///���̃X�e�[�g���甲���o�����A��񂾂��Ă΂��
    /// </summary>
    public abstract void OnExit();
}
