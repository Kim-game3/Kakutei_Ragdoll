using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//作成者:杉山
//体験版終了シーンのゲームルール
//最初の数秒フェードアウトを入れ、フェードアウトが終わった後に体験版終了のUIを表示する

public class TrialFinishSceneGameRule : MonoBehaviour
{
    [Tooltip("シーンが始まってからUIが表示されるまでの時間")] [SerializeField]
    float _waitDuration_s;

    [SerializeField]
    Animator _fadeAnimator;

    [SerializeField]
    Button _finishButton;


    void Start()
    {
       StartCoroutine(ShowUICoroutine());
    }

    IEnumerator ShowUICoroutine()
    {
        //フェードイン開始
        _fadeAnimator.SetTrigger(FadeInOutTriggerName.fadeIn);

        //数秒間待つ
        yield return new WaitForSeconds(_waitDuration_s);

        //フェードイン用のスクリーンを無効化(ボタンが押せるようにする)
        _fadeAnimator.gameObject.SetActive(false);
        //終了ボタンを選択状態にする
        EventSystem.current.SetSelectedGameObject(_finishButton.gameObject);
    }


}
