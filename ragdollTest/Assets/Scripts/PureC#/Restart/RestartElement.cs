using Cinemachine;
using UnityEngine;

//作成者:杉山
//チェックポイントごとのリスタートに必要な要素

[System.Serializable]
public struct RestartElement
{
    //--- カメラ関係 ---//
    [CustomLabel("リスタート地点のカメラ")]
    public CinemachineVirtualCamera restartPointCamera;

    [Header("プレイヤーが操作するカメラのデフォルトの向き")]
    public float defaultVerticalValue_PlayCamera;
    public float defaultHorizontalValue_PlayCamera;
    [Space]

    //--- リスタート関係 ---//
    [CustomLabel("リスタート地点&方向")] [Tooltip("プレイヤーがこの地点に出現＆この方向に向かって投げ飛ばされる")]
    public Transform restartPoint;

    [CustomLabel("かける力の大きさ")]
    public float power;
}

