using TMPro;
using UnityEngine;

//�쐬��:���R
//���U���g�V�[���̃X�R�A��\��

public class ShowResult_ResultScene : MonoBehaviour
{
    [CustomLabel("�N���A�^�C����\�����镶��")] [SerializeField]
    TextMeshProUGUI _clearTimeText;

    [CustomLabel("�������񐔂�\��")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    [SerializeField]
    JudgeResultIsHighScore _judgeResultIsHighScore;

    void Start()
    {
        if (_judgeResultIsHighScore.BrokeRecord)
        {
            Debug.Log("�L�^�X�V�I");
        }

        ScoreData thisScore = ResultManager.Score;

        if (thisScore == null) return;

        MathfExtension.ConvertTime(thisScore.ClearTime, out float hour, out float min, out float second);

        _clearTimeText.text = $"{hour:00}:{min:00}:{second:00}";
        _deathCountText.text = thisScore.DeathCount.ToString("0") + "��";
    }
}
