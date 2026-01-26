using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//データ削除するコマンド

public class ClearPlayerDataCommand : MonoBehaviour
{
    // 検出したい順番（任意に変更）
    private readonly List<KeyCode> targetSequence = new()
    {
        KeyCode.T,
        KeyCode.R,
        KeyCode.A,
        KeyCode.C,
        KeyCode.K,
        KeyCode.E,
        KeyCode.R,
    };

    // 現在の入力履歴
    private List<KeyCode> inputHistory = new();

    // 入力の間隔が空きすぎたらリセットする時間
    [SerializeField] private float inputTimeout = 1.0f;
    private float lastInputTime = 0f;

    void Update()
    {
        // キー入力を監視
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                RegisterKey(key);
            }
        }

        // 一定時間入力がなかったらリセット
        if (inputHistory.Count > 0 && Time.time - lastInputTime > inputTimeout)
        {
            inputHistory.Clear();
        }
    }

    private void RegisterKey(KeyCode key)
    {
        inputHistory.Add(key);
        lastInputTime = Time.time;

        // 履歴が長すぎたら古いのを削除
        if (inputHistory.Count > targetSequence.Count)
        {
            inputHistory.RemoveAt(0);
        }

        // 現在の履歴とターゲットを比較
        bool matched = true;
        for (int i = 0; i < inputHistory.Count; i++)
        {
            if (inputHistory[i] != targetSequence[i])
            {
                matched = false;
                break;
            }
        }

        // 完全一致したら呼び出し
        if (matched && inputHistory.Count == targetSequence.Count)
        {
            OnSequenceMatched();
            inputHistory.Clear();
        }
    }

    private void OnSequenceMatched()
    {
        // 成功時の処理をここに書く
        PlayerPrefs.DeleteAll();
        PlayerDataManager.DeleteStageData();
    }
}
