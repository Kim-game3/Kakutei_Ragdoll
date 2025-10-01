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
    [CustomLabel("遅延時間")] [SerializeField]
    float _delayDuration;

    [Tooltip("次のシーン")] [SerializeField] 
    SceneReference _nextScene;

    [Tooltip("ボタン")] [SerializeField]
    Button _targetButton;

    [SerializeField]
    CanvasGroup _canvas;

    float _loadProgress = 0;

    public float LoadProgress { get { return _loadProgress; } }//ロードの進行度(0～1)

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
        yield return new WaitForSeconds(_delayDuration);//少し遅延させる

        _canvas.interactable = false;
        OnStartLoad?.Invoke();

        // 非同期でシーンを読み込み開始
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene.ScenePath);

        // 読み込み完了まで待機
        while (!asyncLoad.isDone)
        {
            _loadProgress = asyncLoad.progress;
            yield return null; // 1フレーム待つ
        }
    }
}
