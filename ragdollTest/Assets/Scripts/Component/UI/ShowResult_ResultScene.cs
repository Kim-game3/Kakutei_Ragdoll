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

        _clearTimeText.text=thisScore.ClearTime.ToString("0");
        _deathCountText.text=thisScore.DeathCount.ToString("0");
    }
}
