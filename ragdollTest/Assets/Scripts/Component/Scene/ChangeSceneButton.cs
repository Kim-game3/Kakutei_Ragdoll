using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//作成者:杉山
//シーンを変更するボタン

public class ChangeSceneButton : MonoBehaviour
{
    [Tooltip("次のシーン")] [SerializeField] 
    SceneReference _nextScene;

    [Tooltip("ボタン")] [SerializeField]
    Button _targetButton;

    [SerializeField]
    CanvasGroup _canvasGroup;

    float _loadProgress = 0;
    const float _completeLoadProgress = 100;

    public float LoadProgress { get { return _loadProgress; } }//ロードの進行度

    public float CompleteLoadProgress { get { return _completeLoadProgress; } }//ロード完了した時の進行度

    public event Action OnStartLoad;

    private void Awake()
    {
        _targetButton.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(_nextScene.ScenePath))
        {
            StartCoroutine(LoadSceneCoroutine());
        }
        else
        {
            Debug.LogError("シーンが指定されていません！");
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        _canvasGroup.interactable = false;
        OnStartLoad?.Invoke();

        // 非同期でシーンを読み込み開始
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene.ScenePath);

        // 読み込み完了まで待機
        while (!asyncLoad.isDone)
        {
            _loadProgress = asyncLoad.progress * _completeLoadProgress;
            yield return null; // 1フレーム待つ
        }
    }
}
