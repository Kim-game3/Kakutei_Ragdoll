using UnityEngine;
using System;

//作成者:杉山
//時間ごとにtrue、falseを切り替える

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

    public bool IsActive { get { return _activateTimeline[_currentIndex].isActive; } }//現在がアクティブ(true)の状態か

    public event Action<bool> OnSwitchIsActive;//IsActiveが変わった瞬間
    public event Action OnTrue;//trueに変わった瞬間
    public event Action OnFalse;//falseに変わった瞬間

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

        //コールバックの呼び出し
        if (isActiveNew == isActiveBefore) return;

        OnSwitchIsActive?.Invoke(isActiveNew);

        if (isActiveNew) OnTrue?.Invoke();
        else OnFalse?.Invoke();
    }
}
