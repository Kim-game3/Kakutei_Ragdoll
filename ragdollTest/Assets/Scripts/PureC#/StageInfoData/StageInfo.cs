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

    [CustomLabel("ステージのイメージ画像")] [Tooltip("ステージ選択の時に表示する画像")] [SerializeField]
    Sprite _stageImage;

    public string StageName { get { return _stageName; } }
    public Sprite StageSprite { get{ return _stageImage; } }
}
