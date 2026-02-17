using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.SceneManagement;

//何の操作も無かった時にオープニングシーンにシーンを遷移させる機能

public class OpeningSceneLoaderOnInputIdle : MonoBehaviour
{
    [SerializeField]
    InputSystemUIInputModule uiInputModule;

    [SerializeField]
    InputActionAsset _inputActions;

    [SerializeField]
    Animator _fadeAnimator;

    [SerializeField]
    string _triggerName;

    [SerializeField]
    SceneReference _openingScene;

    [SerializeField]
    InputIdleChecker _inputIdleChecker;

    [SerializeField]
    float _delayDurationStartLoad = 0.7f;

    private void OnEnable()
    {
        _inputIdleChecker.OnIdle += LoadOpening;
    }

    private void OnDisable()
    {
        _inputIdleChecker.OnIdle -= LoadOpening;
    }

    void LoadOpening()
    {
        //操作を無効化
        DisableAllInput();

        //フェードアウトさせ始める
        _fadeAnimator.SetTrigger(_triggerName);

        //少し待ってからシーン移行
        StartCoroutine(LoadOpeningSceneCoroutine());
    }

    IEnumerator LoadOpeningSceneCoroutine()
    {
        yield return new WaitForSeconds(_delayDurationStartLoad);

        // 非同期でシーンを読み込み開始
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_openingScene.ScenePath);

        // 読み込み完了まで待機
        while (!asyncLoad.isDone)
        {
            yield return null; // 1フレーム待つ
        }
    }

    void DisableAllInput()
    {
        //InputActionを無効化
        foreach (var map in _inputActions.actionMaps)
        {
            map.Disable();
        }

        // UI側入力を無効化
        uiInputModule.enabled = false;
    }
}
