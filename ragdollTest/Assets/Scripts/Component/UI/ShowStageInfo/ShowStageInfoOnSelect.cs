using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

//作成者:杉山
//ボタンを選択した際にステージごとの情報を表示する
//ボタンにアタッチする

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
