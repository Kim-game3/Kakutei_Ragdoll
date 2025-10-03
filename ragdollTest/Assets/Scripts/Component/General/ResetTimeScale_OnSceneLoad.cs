using UnityEngine;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーン移行した際に自動的に時間速度をリセットする。

public class ResetTimeScale_OnSceneLoad : MonoBehaviour
{
    const float _defaultTimeScale = 1;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetTimeScale;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetTimeScale;
    }

    void ResetTimeScale(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = _defaultTimeScale;
    }
}
