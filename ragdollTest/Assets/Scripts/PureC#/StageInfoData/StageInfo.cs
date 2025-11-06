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

    [Tooltip("アイコン")] [SerializeField]
    Sprite _imageIcon;

    [Tooltip("キャラの名前")] [SerializeField]
    string _charaName;

    [Tooltip("説明文")] [Multiline(5)] [SerializeField]
    string _comment;

    [Tooltip("シーン")] [SerializeField]
    SceneReference _scene;

    public string StageName { get { return _stageName; } }//ステージ名
    public Sprite ImageIcon { get { return _imageIcon; } }//アイコン
    public string CharaName { get { return _charaName; } }//キャラの名前
    public string Comment { get { return _comment; } }//説明文
    public string ScenePath { get { return _scene != null ? _scene.ScenePath : null; } }//シーンのパス
}
