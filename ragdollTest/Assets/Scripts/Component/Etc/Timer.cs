using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�^�C�}�[�@�\

public class Timer : MonoBehaviour
{
    [Tooltip("�v�鎞��")] [SerializeField] float _duration;
    [Tooltip("�J�n���Ƀ^�C�}�[���J�n���邩")] [SerializeField] bool _startOnAwake;
    float _remainingTime;//�c�莞��
    TimerState _state = TimerState.Off;//�^�C�}�[�̏��

    //public

    public event Action ResetEvent;//�^�C�}�[�̃��Z�b�g��
    public event Action TimeUpEvent;//�c�莞�Ԃ�0�ɂȂ�����
    public event Action StartEvent;//�^�C�}�[���J�n���ꂽ��
    public event Action PauseEvent;//�^�C�}�[�̈ꎞ��~��
    public event Action ResumeEvent;//�^�C�}�[���ĊJ������

    public float RemainingTime { get { return _remainingTime; } }//�^�C�}�[�̎c�莞�Ԃ�Ԃ�

    public TimerState State { get { return _state; } }//�^�C�}�[�̏��

    public float Duration//�^�C�}�[�̑��鎞��
    {
        get { return _duration; }
        set { _remainingTime = value; }
    }

    public void ResetTimer()//�^�C�}�[�̏�Ԃ����Z�b�g
    {
        _state=TimerState.Off;
        _remainingTime=_duration;
        ResetEvent?.Invoke();
    }

    public void SwitchStartStop()//�^�C�}�[�J�n�A�^�C�}�[�̒�~�A�^�C�}�[�̍ĊJ���삪�o����
    {
        switch(_state)
        {
            case TimerState.Off://�I�t���I��
                _state=TimerState.On;
                _remainingTime = _duration;
                StartEvent?.Invoke();
                break;

            case TimerState.On://�I�����ꎞ��~
                _state=TimerState.Stop;
                PauseEvent?.Invoke();
                break;

            case TimerState.Stop://�ꎞ��~���I��
                _state = TimerState.On;
                ResumeEvent?.Invoke();
                break;

            default:
                Debug.Log("�^�C�}�[�̏�Ԃ̐؂�ւ��Ɏ��s���܂����I");
                break;
        }
    }

    

    //private

    private void Start()
    {
        ResetTimer();//�^�C�}�[�̏�Ԃ����Z�b�g
        
        if (_startOnAwake) SwitchStartStop();//�I���̏�ԂɂȂ�
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

        if (!timeUp) return;

        //���Ԑ؂�ɂȂ������̏���
        _state = TimerState.TimeUp;
        TimeUpEvent?.Invoke();
    }
}
