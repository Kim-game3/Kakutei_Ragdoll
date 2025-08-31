using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//シーンを変更(簡易的なやつ)

public class ChangeScene : MonoBehaviour
{
    [SerializeField] SceneReference _targetScene;

    public void Change()//シーンを即チェンジ
    {
        if (!string.IsNullOrEmpty(_targetScene.ScenePath))
        {
            SceneManager.LoadScene(_targetScene.ScenePath);
        }
        else
        {
            Debug.LogError("シーンが指定されていません！");
        }
    }

    public void ChangeAsync()//シーンを非同期でチェンジ
    {
        if (!string.IsNullOrEmpty(_targetScene.ScenePath))
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
        // 非同期でシーンを読み込み開始
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_targetScene.ScenePath);

        // 読み込み完了まで待機
        while (!asyncLoad.isDone)
        {
            Debug.Log("進行度: " + (asyncLoad.progress * 100) + "%");
            yield return null; // 1フレーム待つ
        }
    }
}
