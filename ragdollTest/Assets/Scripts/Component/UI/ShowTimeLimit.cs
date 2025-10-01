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
        _timerText.text = _stopWatch.ElapsedTime.ToString("0");
    }
}
