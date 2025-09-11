using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ラグドールの動きの安定化のコンポーネント

public class StabilizeRagdoll : MonoBehaviour
{
    [CustomLabel("身体のパーツのRigidbody")] [SerializeField]
    Rigidbody[] _bodyPartRbs;

    [CustomLabel("身体のパーツの回転のしすぎを抑える機能")] [SerializeField]
    StopBodyRotate _stopBodyRotate;

    [CustomLabel("制約を破った際の引き戻す処理を強化する機能")] [SerializeField]
    SolverIterarions _solverIterarions;

    private void Awake()
    {
        _stopBodyRotate.Init(_bodyPartRbs);
    }

    private void Start()
    {
        _stopBodyRotate.StopRotate(_bodyPartRbs);
        _solverIterarions.Change(_bodyPartRbs);
    }
    private void OnValidate()
    {
        if (!Application.isPlaying) return;//再生中のみ変更処理を行う

            _stopBodyRotate.StopRotate(_bodyPartRbs);
        _solverIterarions.Change(_bodyPartRbs);
    }
}
