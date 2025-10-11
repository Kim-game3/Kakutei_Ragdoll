using System;
using UnityEngine;

//作成者:杉山
//リスタートのマネージャー(リスタートをするか否か、どのチェックポイントにリスタートさせるかを判断)

public class RestartManager : MonoBehaviour
{
    [Tooltip("現在のチェックポイントの番号を教える機能")] [SerializeField]
    CheckPointManager _checkPointManager;

    [Tooltip("リスタートの処理を行う機能")] [SerializeField]
    RestartProcess _restartProcess;

    [Tooltip("リスタートゾーンのトリガー")] [SerializeField] 
    OnTriggerDetect _restartZoneTrigger;

    public event Action OnRestrat;//水に落ちた瞬間に呼ぶ

    private void Awake()
    {
        _restartZoneTrigger.OnEnter += OnHit_RestartTrigger;
    }

    private void Start() { }//enabledのチェック欄を出すためにわざと空のStartを入れてます

    private void OnHit_RestartTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_restartProcess.IsRestarting) return;

        if (!enabled) return;

        OnRestrat?.Invoke();
        _restartProcess.RestartTrigger(_checkPointManager.CurrentCheckPointIndex);
    }
}
