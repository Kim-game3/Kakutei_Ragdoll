using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

//作成者:杉山
//クレジットのUI処理

public partial class CreditManager
{
    [System.Serializable]
    class CreditManager_UI
    {
        [SerializeField]
        EventSystem _eventSystem;

        [Tooltip("クレジットメニューを開く機能")] [SerializeField]
        ShowUITypeBase _openOption;

        [Tooltip("クレジットメニューを閉じる機能")] [SerializeField]
        HideUITypeBase _closeOption;

        [Tooltip("クレジットを閉じる時に表示したいUI")] [SerializeField]
        ShowUITypeBase _showUIOnOpenCredit;

        [Tooltip("クレジットを開く時に非表示にしたいUI")] [SerializeField]
        HideUITypeBase _hideUIOnOpenCredit;

        Button _openButton;//クレジットメニューを開くボタン
        Button _closeButton;//クレジットメニューを閉じるボタン

        public void Awake(Button openButton, Button closeButton)
        {
            _openButton = openButton;
            _closeButton = closeButton;
        }

        public void Start()
        {
            _closeOption.Hide();
        }

        public void OnOpen()
        {
            if(_hideUIOnOpenCredit != null) _hideUIOnOpenCredit.Hide();
            _openOption.Show();
            _eventSystem.SetSelectedGameObject(_closeButton.gameObject);//選択ボタンを閉じるボタンに設定
        }

        public void OnClose()
        {
            if(_showUIOnOpenCredit != null) _showUIOnOpenCredit.Show();
            _closeOption.Hide();
            _eventSystem?.SetSelectedGameObject(_openButton.gameObject);//選択ボタンを開くボタンに設定
        }
    }
}
