using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//作成者:杉山
//ゲームをやめるボタン

public class QuitGameButton : MonoBehaviour
{
    [CustomLabel("遅延時間")] [SerializeField]
    float _delayDuration;

    [Tooltip("ボタン")] [SerializeField]
    Button _targetButton;

    private void Awake()
    {
        _targetButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    private IEnumerator QuitGameCoroutine()
    {
        EventSystem.current.enabled = false;//UI操作を出来なくする
        yield return new WaitForSecondsRealtime(_delayDuration);//少し遅延させる

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
    }
}
