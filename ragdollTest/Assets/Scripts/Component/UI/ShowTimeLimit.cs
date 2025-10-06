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
        MathfExtension.ConvertTime(_stopWatch.ElapsedTime, out float hour, out float min, out float second);

        _timerText.text = $"{hour:00}:{min:00}:{second:00}";
    }
}
