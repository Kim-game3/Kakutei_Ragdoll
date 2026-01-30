using System;
using UnityEngine;

//作成者:杉山
//リスタートのマネージャー(リスタートをするか否か、どのチェックポイントにリスタートさせるかを判断)

public class RespawnManager : MonoBehaviour
{
    [Tooltip("現在のチェックポイントの番号を教える機能")] [SerializeField]
    CheckPointManager _checkPointManager;

    [Tooltip("リスタートの処理を行う機能")] [SerializeField]
    RespawnProcess _respawnProcess;

    [Tooltip("リスタートゾーンのトリガー")] [SerializeField] 
    OnTriggerDetect[] _respawnZoneTriggers;

    //水に落ちた瞬間に呼ぶ
    public event Action OnRestrat;


    private void Awake()
    {
        for(int i=0; i<_respawnZoneTriggers.Length ;i++)
        {
            _respawnZoneTriggers[i].OnEnter += OnHit_RestartTrigger;
        }
    }

    private void Start() { }//enabledのチェック欄を出すためにわざと空のStartを入れてます

    private void OnHit_RestartTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_respawnProcess.IsRestarting) return;

        if (!enabled) return;

        OnRestrat?.Invoke();
        _respawnProcess.RestartTrigger(_checkPointManager.CurrentCheckPointIndex);
    }
}
