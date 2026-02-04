using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//作成者:杉山
//進行度の表示

public class ShowProgress : MonoBehaviour
{
    [SerializeField]
    RectTransform _start;

    [SerializeField]
    RectTransform _end;

    [SerializeField]
    RectTransform _current;

    [SerializeField]
    Image _inGauge;

    [SerializeField]
    ProgressManager _progressManager;

    private void Awake()
    {
        _progressManager.OnUpdateProgress += UpdateGauge;
    }

    private void Start()
    {
        _current.position = _start.position;
        _inGauge.fillAmount = 0f;
    }

    void UpdateGauge(float progress)
    {
        _inGauge.fillAmount = progress;

        Vector3 currentPos = Vector3.Lerp(_start.position, _end.position, progress);

        _current.position = currentPos;
    }
}
