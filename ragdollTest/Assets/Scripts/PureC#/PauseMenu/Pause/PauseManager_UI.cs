using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//作成者:杉山
//ポーズのUI層(プレイヤーの目に見える部分)

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_UI
    {
        [SerializeField] 
        EventSystem _eventSystem;

        [Header("ゲーム中のUI関連")]

        [CustomLabel("ゲーム中のUIを開く機能")] [SerializeField]
        ShowUITypeBase _openInGameUI;

        [CustomLabel("ゲーム中のUIを閉じる機能")] [SerializeField]
        HideUITypeBase _closeInGameUI;

        [Header("ポーズメニュー関連")]

        [CustomLabel("ポーズメニューを開く機能")] [SerializeField]
        ShowUITypeBase _openPauseMenu;

        [CustomLabel("ポーズメニューを閉じる機能")] [SerializeField]
        HideUITypeBase _closePauseMenu;

        [Tooltip("一番上の階層のCanvasGroup")] [SerializeField]
        CanvasGroup _canvas;

        Button _resumeButton;

        public void Awake(Button resumeButton)//resumeButton=ゲーム再開ボタン
        {
            _resumeButton = resumeButton;
        }

        public void Start()
        {
            OnResume();
        }

        public void OnSwitchPause(bool isPausing)
        {
            if (isPausing) OnPause();

            else OnResume();
        }

        void OnPause()
        {
            _closeInGameUI.Hide();
            _openPauseMenu.Show();
            _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);//Resumeボタンを選択状態にする
        }

        void OnResume()
        {
            _closePauseMenu.Hide();
            _openInGameUI.Show();
            _eventSystem.SetSelectedGameObject(null);//どのボタンも選択状態にしない
        }
    }
}
