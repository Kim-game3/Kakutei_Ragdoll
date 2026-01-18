using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//作成者:杉山
//ゲームのステージのシーンに遷移(開始)する

public class StartGameStageButton : MonoBehaviour
{
    [CustomLabel("遅延時間")] [SerializeField]
    float _delayDuration;

    [SerializeField]
    StageInfoData _stageInfoData;

    [Tooltip("ステージID")] [SerializeField]
    EStageID _stageID;

    [Tooltip("ボタン")] [SerializeField]
    Button _targetButton;

    [Tooltip("ボタンのテキスト")] [SerializeField]
    TextMeshProUGUI _buttonText;

    float _loadProgress = 0;

    StageInfo _stageInfo;

    public float LoadProgress { get { return _loadProgress; } }//ロードの進行度(0～1)

    public event Action OnStartLoad;

    private void Awake()
    {
        _targetButton.onClick.AddListener(ChangeScene);

        //ステージのデータを取得
        if (_stageInfoData == null)
        {
            Debug.Log("ステージのデータベースが設定されていません！");
            return;
        }

        _stageInfo = _stageInfoData.GetStageInfo(_stageID);

        if (_stageInfo == null)
        {
            Debug.Log("存在しないステージIDです！");
            return;
        }
    }

    private void Start()
    {
        PlayingStageInfoManager.Destroy();//プレイ中のステージの情報を管理するオブジェクトの削除処理

        //ボタンの名前を設定

        _buttonText.text = _stageInfo.StageName;
    }

    public void ChangeScene()
    {
        if (!_targetButton.interactable) return;

        string scenePath = _stageInfo.ScenePath;

        //シーン遷移処理開始

        //ステージの情報を管理するマネージャーの作成
        PlayingStageInfoManager.Instantiate();
        PlayingStageInfoManager.Instance.SetData(_stageID);

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
