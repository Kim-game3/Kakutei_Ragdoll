using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�^�C�}�[

public class Timer : MonoBehaviour
{
    [Tooltip("�v�鎞��")] [SerializeField] float _duration;
    [Tooltip("�J�n���Ƀ^�C�}�[���J�n���邩")] [SerializeField] bool _startOnAwake;
    float _remainingTime;//�c�莞��
    TimerState _state = TimerState.Off; //�^�C�}�[�̏��

    //public

    public event Action TimeUpEvent;//�^�C�}�[��0�ɂȂ������ɌĂ΂��C�x���g
    public event Action TimerStartEvent;//�^�C�}�[���J�n���ꂽ���ɌĂ΂��C�x���g
    public event Action PauseEvent;//�^�C�}�[���ꎞ��~�ɂȂ������ɌĂ΂��C�x���g
    public event Action ResumeEvent;//�^�C�}�[���ĊJ�������ɌĂ΂��C�x���g

    //�^�C�}�[���ŏ�����J�n����
    public void TimerStart()
    {
        //���ɃI���ɂȂ��Ă���x���������ĉ������Ȃ�
        if(_state==TimerState.On)
        {
            Debug.Log("���Ƀ^�C�}�[���J�n���Ă��܂��I");
            return;
        }

        _state= TimerState.On;
        TimerStartEvent?.Invoke();
        _remainingTime = _duration;
    }

    public float RemainingTime { get { return _remainingTime; } }//�^�C�}�[�̎c�莞�Ԃ�Ԃ�

    public TimerState State { get { return _state; } }//�^�C�}�[�̏��

    public float Duration//�^�C�}�[�̑��鎞��
    {
        get { return _duration; }
        set { _remainingTime = value; }
    }

    
    public bool SwitchPauseResume() //�^�C�}�[�̈ꎞ��~�E�ĊJ�̐؂�ւ�
    {
        //�������������Ă��Ȃ�������x������false��Ԃ�
        if(_state==TimerState.Off)
        {
            Debug.Log("�^�C�}�[�������Ă܂���I");
            return false;
        }

        //�^�C�}�[�������Ă����Ԃł�������ꎞ��~�ɂ���
        else if(_state==TimerState.On)
        {
            _state = TimerState.Pause;
            PauseEvent?.Invoke();
            return true;
        }

        //�^�C�}�[���ꎞ��~��Ԃł�������ĊJ����
        else
        {
            _state= TimerState.On;
            ResumeEvent?.Invoke();
            return true;
        }
    }

    //private

    private void Start()
    {
        if (_startOnAwake) TimerStart();
    }

    private void Update()
    {
        UpdateRemainingTime();
    }

    void UpdateRemainingTime()
    {
        if (_state != TimerState.On) return;

        _remainingTime -= Time.deltaTime;

        bool timeUp=_remainingTime < 0;//���Ԑ؂�ɂȂ���

        if(timeUp)
        {
            //���Ԑ؂�ɂȂ������̏���
            _state = TimerState.Off;
            TimeUpEvent?.Invoke();
        }
    }
}
