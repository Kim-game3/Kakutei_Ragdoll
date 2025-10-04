using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;

//�쐬��:���R
//�X�e�[�W���Ƃ̏���\������

public class ShowStageInfoManager : MonoBehaviour
{
    [Tooltip("�X�e�[�W�̏��")] [SerializeField]
    StageInfoData _stageInfoData;

    [CustomLabel("�X�e�[�W��")] [SerializeField]
    TextMeshProUGUI _stageName;

    [CustomLabel("�X�e�[�W�̃C���[�W�摜")] [SerializeField]
    Image _stageImage;

    [CustomLabel("�N���A�^�C��")] [SerializeField]
    TextMeshProUGUI _clearTimeText;

    [CustomLabel("��������")] [SerializeField]
    TextMeshProUGUI _deathCountText;

    const string _noScore = "-";

    public void UpdateStageInfo(int stageID)//�\������X�e�[�W�̏��̍X�V
    {
        //�w��X�e�[�W�̃n�C�X�R�A���擾
        ScoreData highScoreData = PlayerDataManager.GetHighScore(stageID);

        //�w��X�e�[�W�̏����擾
        StageInfo stageInfo=_stageInfoData.GetStageInfo(stageID);

        if (stageInfo == null)
        {
            Debug.Log("�X�e�[�W�̏��̎擾�Ɏ��s");
            return;
        }

        //������������
        _stageName.text = stageInfo.StageName;
        _stageImage.sprite =stageInfo.StageSprite;

        //���N���A�̏ꍇ�̓X�R�A��\�L���Ȃ�
        if(highScoreData==null)
        {
            _clearTimeText.text = _noScore;
            _deathCountText.text = _noScore;
        }
        else
        {
            _clearTimeText.text = highScoreData.ClearTime.ToString("0");
            _deathCountText.text = highScoreData.DeathCount.ToString("0");
        }
    }
}
