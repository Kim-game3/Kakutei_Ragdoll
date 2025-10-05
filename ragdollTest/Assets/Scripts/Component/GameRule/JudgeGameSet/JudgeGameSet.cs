using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲーム終了を判断

public class JudgeGameSet : MonoBehaviour
{
    [SerializeField]
    OnTriggerDetect _gameClearZone;

    bool _isGameSet=false;//ゲーム終了したか

    public bool IsGameSet {  get { return _isGameSet; } }

    private void Awake()
    {
        _gameClearZone.OnEnter += SetGameClear;
    }

    void SetGameClear(Collider other)
    {
        //クリア条件
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isGameSet = true;
    }
}
