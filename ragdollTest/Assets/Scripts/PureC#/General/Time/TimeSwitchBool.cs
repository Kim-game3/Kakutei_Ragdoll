using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    float _current;
    int _currentIndex;

    public bool IsActive { get { return _activateTimeline[_currentIndex].isActive; } }//現在がアクティブ(true)の状態か

    public TimeSwitchBool()
    {
        _current = 0f;
        _currentIndex = 0;
    }

    public void Update()
    {
        _current += Time.deltaTime;

        bool isOver = _current > _activateTimeline[_currentIndex].time;

        while(isOver)
        {
            _current -= _activateTimeline[_currentIndex].time;

            _currentIndex++;
            _currentIndex %= _activateTimeline.Length;

            isOver = _current > _activateTimeline[_currentIndex].time;
        }
    }
}
