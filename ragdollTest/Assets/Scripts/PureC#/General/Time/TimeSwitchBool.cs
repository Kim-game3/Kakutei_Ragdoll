using UnityEngine;
using System;

//�쐬��:���R
//���Ԃ��Ƃ�true�Afalse��؂�ւ���

[System.Serializable]
public class TimeSwitchBool
{
    [System.Serializable]
    struct BoolAndTime
    {
        public bool isActive;
        public float time;
    }

    [Tooltip("��ɃA�N�e�B�u�܂��͔�A�N�e�B�u�ɂ������ۂ͗v�f��������ɂ��邱��")] [SerializeField]
    BoolAndTime[] _activateTimeline;

    float _currentTime=0f;
    int _currentIndex=0;

    public event Action<bool> OnSwitchIsActive;//IsActive���ς�����u��
    public event Action OnTrue;//true�ɕς�����u��
    public event Action OnFalse;//false�ɕς�����u��

    BoolAndTime Current { get { return _activateTimeline[_currentIndex]; } }

    const int _noCycleLength = 0;//�������Ȃ�(�������ݒ肳��Ă��Ȃ�)�ꍇ��_activateTimeline�̒���
    const int _singleCycleLength = 1;//��ɓ�����Ԃ�_activateTimeline�̒���

    public bool IsActive//���݂��A�N�e�B�u(true)�̏�Ԃ�
    {
        get
        {
            if (_activateTimeline.Length <= _noCycleLength)
            {
                Debug.Log("�������������ݒ肳��Ă��܂���I");
                return false;
            }

            return _activateTimeline[_currentIndex].isActive;
        }
    }

    public TimeSwitchBool()
    {
        _currentTime = 0f;
        _currentIndex = 0;
    }

    public void Update()
    {
        if (_activateTimeline.Length <= _singleCycleLength) return;

        _currentTime += Time.deltaTime;

        bool isActiveBefore = Current.isActive;
        bool isOver = _currentTime > Current.time;

        while(isOver)
        {
            _currentTime -= Current.time;

            _currentIndex++;
            _currentIndex %= _activateTimeline.Length;

            isOver = _currentTime > Current.time;
        }

        bool isActiveNew = Current.isActive;

        //�R�[���o�b�N�̌Ăяo��
        if (isActiveNew == isActiveBefore) return;

        OnSwitchIsActive?.Invoke(isActiveNew);

        if (isActiveNew) OnTrue?.Invoke();
        else OnFalse?.Invoke();
    }
}
