using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//�^�C�}�[�̕\��

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
        _timer.TimerStartEvent += ShowRemainingTime;//�^�C�}�[���J�n�����u�ԂɎc�莞�Ԃ�\������悤�ɂ���
    }

    void ShowRemainingTime()
    {
        enabled = true;
    }
}
