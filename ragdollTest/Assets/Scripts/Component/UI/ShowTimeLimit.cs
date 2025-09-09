using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//タイマーの表示

public class ShowTimeLimit : MonoBehaviour
{
    [SerializeField] Timer _timer;
    [SerializeField] TextMeshProUGUI _timerText;

    private void Start()
    {
        _timerText.text = _timer.Duration.ToString("0");
        enabled = false;
    }

    void Update()
    {
        _timerText.text=_timer.RemainingTime.ToString("0");
    }

    private void Awake()
    {
        _timer.TimerStartEvent += ShowRemainingTime;//タイマーが開始した瞬間に残り時間を表示するようにする
    }

    void ShowRemainingTime()
    {
        enabled = true;
    }
}
