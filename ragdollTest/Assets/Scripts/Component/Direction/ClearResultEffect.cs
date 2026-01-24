using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//クリア(リザルト)演出

public class ClearResultEffect : MonoBehaviour
{
    [SerializeField]
    AudioSource _clearJingleAudioSource;

    [SerializeField]
    StageInfoData _stageInfoData;

    [SerializeField]
    TextMeshProUGUI _clearText;

    // Start is called before the first frame update
    void Start()
    {
        var playingStateInstance = PlayingStageInfoManager.Instance;

        if (playingStateInstance == null) return;

        var data = playingStateInstance.Data;

        if (data == null) return;

        //ジングルの設定
        AudioClip clip = _stageInfoData.GetStageInfo(data.StageID).ClearJingle;

        _clearJingleAudioSource.clip = clip;
        _clearJingleAudioSource.Play();


        //クリアのメッセージを変える
        _clearText.text = _stageInfoData.GetStageInfo(data.StageID).ClearMessage;
    }
}
