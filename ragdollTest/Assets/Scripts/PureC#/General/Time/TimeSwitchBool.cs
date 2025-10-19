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

    [Tooltip("常にアクティブまたは非アクティブにしたい際は要素を一つだけにすること")] [SerializeField]
    BoolAndTime[] _activateTimeline;

    float _currentTime=0f;
    int _currentIndex=0;

    public event Action<bool> OnSwitchIsActive;//IsActiveが変わった瞬間
    public event Action OnTrue;//trueに変わった瞬間
    public event Action OnFalse;//falseに変わった瞬間

    BoolAndTime Current { get { return _activateTimeline[_currentIndex]; } }

    const int _noCycleLength = 0;//周期がない(正しく設定されていない)場合の_activateTimelineの長さ
    const int _singleCycleLength = 1;//常に同じ状態の_activateTimelineの長さ

    public bool IsActive//現在がアクティブ(true)の状態か
    {
        get
        {
            if (_activateTimeline.Length <= _noCycleLength)
            {
                Debug.Log("周期が正しく設定されていません！");
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

        //コールバックの呼び出し
        if (isActiveNew == isActiveBefore) return;

        OnSwitchIsActive?.Invoke(isActiveNew);

        if (isActiveNew) OnTrue?.Invoke();
        else OnFalse?.Invoke();
    }
}
