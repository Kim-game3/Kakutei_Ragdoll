using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//�쐬��:���R
//�{�^����I�������ۂɃX�e�[�W���Ƃ̏���\������
//�{�^���ɃA�^�b�`����

public class ShowStageInfoOnSelect : MonoBehaviour, ISelectHandler
{
    [SerializeField]
    ShowStageInfoManager _showStageInfo;

    [SerializeField]
    int _showStageID;

    public void OnSelect(BaseEventData eventData)
    {
        _showStageInfo.UpdateStageInfo(_showStageID);
    }
}
