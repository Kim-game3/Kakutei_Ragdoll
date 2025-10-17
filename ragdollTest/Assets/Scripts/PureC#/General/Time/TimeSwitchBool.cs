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

    [SerializeField]
    BoolAndTime[] _activateTimeline;

    float _currentTime;
    int _currentIndex;

    public bool IsActive { get { return _activateTimeline[_currentIndex].isActive; } }//���݂��A�N�e�B�u(true)�̏�Ԃ�

    public event Action<bool> OnSwitchIsActive;//IsActive���ς�����u��
    public event Action OnTrue;//true�ɕς�����u��
    public event Action OnFalse;//false�ɕς�����u��

    BoolAndTime Current { get { return _activateTimeline[_currentIndex]; } }

    public TimeSwitchBool()
    {
        _currentTime = 0f;
        _currentIndex = 0;
    }

    public void Update()
    {
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
