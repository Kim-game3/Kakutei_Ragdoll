using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�X�g�b�v�E�H�b�`�@�\

public class StopWatch : MonoBehaviour
{
    [Tooltip("�J�n���Ɍv�����J�n���邩")] [SerializeField] 
    bool _startOnAwake;

    float _elapsedTime;//�o�ߎ���
    StopWatchState _state = StopWatchState.Off;//�^�C�}�[�̏��

    const float _resetTime = 0;//���Z�b�g�����Ƃ��Ɍo�ߎ��Ԃ�0�ɂȂ�悤�ɂ���

    //public

    public event Action OnReset;//�X�g�b�v�E�H�b�`�̃��Z�b�g��
    public event Action OnStart;//�X�g�b�v�E�H�b�`���J�n���ꂽ��
    public event Action OnPause;//�X�g�b�v�E�H�b�`�̈ꎞ��~��
    public event Action OnResume;//�X�g�b�v�E�H�b�`���ĊJ������

    public float ElapsedTime { get { return _elapsedTime; } }

    public StopWatchState State { get { return _state; } }

    public void ResetStopWatch()//�^�C�}�[�̏�Ԃ����Z�b�g
    {
        _state = StopWatchState.Off;
        _elapsedTime = _resetTime;
        OnReset?.Invoke();
    }

    public void SwitchStartStop()//�J�n�A��~�A�ĊJ���삪�o����
    {
        switch (_state)
        {
            case StopWatchState.Off://�I�t���I��
                _state = StopWatchState.On;
                OnStart?.Invoke();
                break;

            case StopWatchState.On://�I�����ꎞ��~
                _state = StopWatchState.Stop;
                OnPause?.Invoke();
                break;

            case StopWatchState.Stop://�ꎞ��~���I��
                _state = StopWatchState.On;
                OnResume?.Invoke();
                break;

            default:
                Debug.Log("�X�g�b�v�E�H�b�`�̏�Ԃ̐؂�ւ��Ɏ��s���܂����I");
                break;
        }
    }

    //private
    private void Awake()
    {
        //�X�g�b�v�E�H�b�`�̏�Ԃ����Z�b�g
        _state = StopWatchState.Off;
        _elapsedTime = _resetTime;
    }

    private void Start()
    {
        if (_startOnAwake) SwitchStartStop();
    }

    private void Update()
    {
        UpdateRemainingTime();
    }

    void UpdateRemainingTime()
    {
        if (_state != StopWatchState.On) return;

        _elapsedTime += Time.deltaTime;
    }
}
