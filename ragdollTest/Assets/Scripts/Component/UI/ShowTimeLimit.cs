using TMPro;
using UnityEngine;

//作成者:杉山
//ストップウォッチの表示

public class ShowStopWatch : MonoBehaviour
{
    [SerializeField] StopWatch _stopWatch;
    [SerializeField] TextMeshProUGUI _timerText;

    void Update()
    {
        _timerText.text = _stopWatch.ElapsedTime.ToString("0");
    }
}
