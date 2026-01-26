using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームシーンでリトライかタイトルに戻る時にセーブする

public class SaveOnRetryOrGotoTitle : MonoBehaviour
{
    [SerializeField]
    ChangeSceneButton _gotoTitleButton;

    [SerializeField]
    RetryGameStageButton _retryButton;

    [SerializeField]
    SaveUtilityOnQuitNowPlaying _saveUtility;

    private void OnEnable()
    {
        _gotoTitleButton.OnStartLoad += Save;
        _retryButton.OnStartLoad += Save;
    }

    private void OnDisable()
    {
        _gotoTitleButton.OnStartLoad -= Save;
        _retryButton.OnStartLoad -= Save;
    }

    void Save()
    {
        _saveUtility.Save();
    }
}
