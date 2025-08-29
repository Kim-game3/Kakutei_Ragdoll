using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//タイマーの表示

public class ShowTimeLimit : MonoBehaviour
{
    [SerializeField] Timer _timer;
    [SerializeField] TextMeshProUGUI _timerText;

    // Update is called once per frame
    void Update()
    {
        _timerText.text=_timer.RemainingTime.ToString("0");
    }
}
