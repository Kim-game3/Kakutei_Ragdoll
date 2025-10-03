#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

//¡ƒV[ƒ“‚ð‘JˆÚ‚µ‚Ä‚¢‚é‚©‚ðŒ©‚é

[InitializeOnLoad]
public static class SceneChangeWatcher
{
    public static bool isChangingScene = false;

    static SceneChangeWatcher()
    {
        SceneManager.activeSceneChanged += (oldScene, newScene) =>
        {
            isChangingScene = true;
            EditorApplication.delayCall += () => { isChangingScene = false; };
        };
    }
}
#endif