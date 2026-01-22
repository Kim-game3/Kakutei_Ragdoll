using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

//作成者:杉山
//オプションのUI処理

public partial class OptionManager
{
    [System.Serializable]
    class OptionManager_UI
    {
        [SerializeField]
        EventSystem _eventSystem;

        [Tooltip("オプションメニューを開く機能")] [SerializeField]
        ShowUITypeBase _openOption;

        [Tooltip("オプションメニューを閉じる機能")] [SerializeField]
        HideUITypeBase _closeOption;

        [Tooltip("オプションを閉じる時に表示したいUI")] [SerializeField]
        ShowUITypeBase _showUIOnOpenOption;

        [Tooltip("オプションを開く時に非表示にしたいUI")] [SerializeField]
        HideUITypeBase _hideUIOnOpenOption;

        Button _openButton;//オプションメニューを開くボタン
        Button _closeButton;//オプションメニューを閉じるボタン

        public void Awake(Button openButton,Button closeButton)
        {
            _openButton = openButton;
            _closeButton = closeButton;
        }

        public void Start()
        {
            _closeOption.Hide();//ゲーム開始時にはオプションメニューは閉じておく
        }

        public void OnOpen()
        {
            if (_hideUIOnOpenOption != null) _hideUIOnOpenOption.Hide();
            _openOption.Show();
            _eventSystem.SetSelectedGameObject(_closeButton.gameObject);//選択ボタンを閉じるボタンに設定
        }

        public void OnClose()
        {
            if (_showUIOnOpenOption != null) _showUIOnOpenOption.Show();
            _closeOption.Hide();
            _eventSystem?.SetSelectedGameObject(_openButton.gameObject);//選択ボタンを開くボタンに設定
        }

        public void OnDisable()
        {
            if(_closeOption != null) _closeOption.Hide();
        }
    }
    
}
