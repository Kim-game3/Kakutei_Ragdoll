using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//特定シーンから遷移してきた時に最初にアニメーションを再生

public class PlayAnimationOnTheSceneLoaded : MonoBehaviour
{
    [SerializeField]
    Animator _animator;

    [SerializeField]
    string _triggerName;

    [SerializeField]
    SceneReference _beforeScene;

    void Start()
    {
        string scenePath=BeforeSceneMemo.BeforeScenePath;

        if (string.IsNullOrEmpty(scenePath)) return;

        if (scenePath != _beforeScene.ScenePath) return;

        _animator.SetTrigger(_triggerName);

        BeforeSceneMemo.BeforeScenePath = "";//タイトルシーンから遷移した後にまた再生されるのを 防ぐための応急措置
    }
}
