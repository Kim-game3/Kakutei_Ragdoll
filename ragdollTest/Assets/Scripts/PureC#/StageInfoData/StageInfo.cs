using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ステージ情報

[System.Serializable]
public class StageInfo
{
    [CustomLabel("ステージ名")] [SerializeField]
    string _stageName;

    [Tooltip("シーン")] [SerializeField]
    SceneReference _scene;

    public string StageName { get { return _stageName; } }
    public string ScenePath { get { return _scene != null ? _scene.ScenePath : null; } }
}
