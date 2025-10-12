using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�L�^�X�V��\��

public class ShowBreakRecord : MonoBehaviour
{
    [SerializeField] ShowUITypeBase _showBreakRecord;
    [SerializeField] HideUITypeBase _hideBreakRecord;
    [SerializeField] JudgeResultIsHighScore _judgeResultIsHighScore;

    // Start is called before the first frame update
    void Start()
    {
        if(_judgeResultIsHighScore.BrokeRecord)
        {
            _showBreakRecord.Show();
        }
        else
        {
            _hideBreakRecord.Hide();
        }
    }
}
