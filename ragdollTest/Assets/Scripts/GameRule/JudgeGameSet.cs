using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//�쐬��:���R
//�Q�[���I������

public class JudgeGameSet : MonoBehaviour
{
    [Tooltip("�Q�[���N���A����")] [SerializeField] JudgeGameClear _judgeGameClear;
    [Tooltip("�Q�[���I�[�o�[����")] [SerializeField] JudgeGameOver _judgeGameOver;

    //public

    public event Action GameClearEvent;//�Q�[���N���A���ɌĂ΂��C�x���g
    public event Action GameOverEvent;//�Q�[���I�[�o�[���ɌĂ΂��C�x���g

    //private 

    private void Awake()
    {
        //�C�x���g��ݒ�
        _judgeGameClear.TriggerEvent += GameClear;
        _judgeGameOver.TriggerEvent += GameOver;
    }

    void GameClear()
    {
        //���ɃQ�[���I�[�o�[��Ԃł���΁A�������Ȃ�
        if (_judgeGameOver.JudgedGameOver) return;

        GameClearEvent?.Invoke();
    }

    void GameOver()
    {
        //���ɃQ�[���N���A��Ԃł���Ή������Ȃ�
        if (_judgeGameClear.JudgedGameClear) return;

        GameOverEvent?.Invoke();
    }
}
