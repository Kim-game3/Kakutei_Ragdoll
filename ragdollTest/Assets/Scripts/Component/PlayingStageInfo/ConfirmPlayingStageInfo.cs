using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイ中のステージ情報を取得する機能の実体がなければ作る

public class ConfirmPlayingStageInfo : MonoBehaviour
{
    [SerializeField]
    int _stageID;

    
    void Awake()
    {
        if (PlayingStageInfoManager.Instance == null)
        {
            PlayingStageInfoManager.Instantiate();
            PlayingStageInfoManager.Instance.SetData(_stageID);
        }
        else if (PlayingStageInfoManager.Instance.Data == null)
        {
            PlayingStageInfoManager.Instance.SetData(_stageID);
        }
    }
}
