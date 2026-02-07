using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//作成者:杉山
//チェックポイント更新の通知

public class UpdateCheckPointNotification : MonoBehaviour
{
    [SerializeField]
    CheckPointManager _checkPointManager;

    [SerializeField]
    AudioSource _audioSource;

    [Tooltip("通知音")] [SerializeField]
    AudioClip _notificationSE;

    [SerializeField]
    TextMeshProUGUI _notificationText;

    [Tooltip("表示時間")] [SerializeField]
    float _showDuration = 2f;

    [Tooltip("フェードアウトにかける時間")] [SerializeField]
    float _fadeOutDuration=0.5f;

    Coroutine _noticeCoroutine;

    private void OnEnable()
    {
        _checkPointManager.OnUpdateCheckPoint += Notice;
    }

    private void OnDisable()
    {
        _checkPointManager.OnUpdateCheckPoint -= Notice;
    }

    void Notice()//通知
    {
        //通知音を鳴らす
        _audioSource.PlayOneShot(_notificationSE);

        // 既に表示中なら止めてやり直す
        if (_noticeCoroutine != null)
        {
            StopCoroutine(_noticeCoroutine);
        }

        _noticeCoroutine = StartCoroutine(NoticeRoutine());
    }

    IEnumerator NoticeRoutine()
    {
        // 不透明で表示
        Color color = _notificationText.color;
        color.a = 1f;
        _notificationText.color = color;
        _notificationText.gameObject.SetActive(true);

        // 指定時間そのまま表示
        yield return new WaitForSeconds(_showDuration);

        // フェードアウト
        float elapsed = 0f;
        while (elapsed < _fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / _fadeOutDuration;

            color.a = Mathf.Lerp(1f, 0f, t);
            _notificationText.color = color;

            yield return null;
        }

        // 完全に透明にして非表示
        color.a = 0f;
        _notificationText.color = color;
        _notificationText.gameObject.SetActive(false);
    }
}
