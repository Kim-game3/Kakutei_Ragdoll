using TMPro;
using UnityEngine;

//�쐬��:���R
//�X�g�b�v�E�H�b�`�̕\��

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
