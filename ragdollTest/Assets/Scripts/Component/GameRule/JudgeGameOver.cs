using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���I�[�o�[�̔��f

public class JudgeGameOver : MonoBehaviour 
{
    [SerializeField] Timer _timer;
    bool _judgedGameOver=false;

    //public
    public bool JudgedGameOver { get { return _judgedGameOver; } }

    public event Action TriggerEvent;//�Q�[���I�[�o�[�Ɣ��肳�ꂽ�u�ԂɌĂ΂��

    void Awake()
    {
        _timer.TimeUpEvent += Judge;//�^�C���A�b�v���ɃQ�[���I�[�o�[�Ɣ��f
    }

    //private
    void Judge()//�Q�[���I�[�o�[�Ɣ��f
    {
        if (_judgedGameOver) return;

        _judgedGameOver = true;
        TriggerEvent?.Invoke();
    }

}
