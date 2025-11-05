using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

//作成者:杉山
//さっきプレイしたステージのシーンに遷移する

public class RetryGameStageButton : MonoBehaviour
{
    [CustomLabel("遅延時間")] [SerializeField]
    float _delayDuration;

    [SerializeField]
    StageInfoData _stageInfoData;

    [Tooltip("ボタン")] [SerializeField]
    Button _targetButton;

    float _loadProgress = 0;

    public float LoadProgress { get { return _loadProgress; } }//ロードの進行度(0～1)

    public event Action OnStartLoad;

    private void Awake()
    {
        _targetButton.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        if (!_targetButton.interactable) return;

        if (_stageInfoData == null)
        {
            Debug.Log("ステージのデータベースが設定されていません！");
            return;
        }

        if (PlayingStageInfoManager.Instance==null || PlayingStageInfoManager.Instance.Data==null)
        {
            Debug.Log("さっきプレイしていたステージのデータの取得に失敗");
            return;
        }

        StageInfo stageInfo = _stageInfoData.GetStageInfo(PlayingStageInfoManager.Instance.Data.StageID);

        if (stageInfo == null)
        {
            Debug.Log("存在しないステージIDです！");
            return;
        }

        string scenePath = stageInfo.ScenePath;

        if (string.IsNullOrEmpty(scenePath))
        {
            Debug.Log("シーンが正しく設定されていません！");
            return;
        }

        //シーン遷移処理開始

        StartCoroutine(LoadSceneCoroutine(scenePath));//シーンのロード
    }

    private IEnumerator LoadSceneCoroutine(string scenePath)
    {
        EventSystem.current.enabled = false;//UI操作を出来なくする
        yield return new WaitForSecondsRealtime(_delayDuration);//少し遅延させる

        OnStartLoad?.Invoke();

        // 非同期でシーンを読み込み開始
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scenePath);

        // 読み込み完了まで待機
        while (!asyncLoad.isDone)
        {
            _loadProgress = asyncLoad.progress;
            yield return null; // 1フレーム待つ
        }
    }
}
