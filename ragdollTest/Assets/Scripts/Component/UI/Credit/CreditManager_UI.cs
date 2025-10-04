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

        [CustomLabel("クレジットメニューを開く機能")] [SerializeField]
        ShowUITypeBase _openOption;

        [CustomLabel("クレジットメニューを閉じる機能")] [SerializeField]
        HideUITypeBase _closeOption;

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
            _openOption.Show();
            _eventSystem.SetSelectedGameObject(_closeButton.gameObject);//選択ボタンを閉じるボタンに設定
        }

        public void OnClose()
        {
            _closeOption.Hide();
            _eventSystem?.SetSelectedGameObject(_openButton.gameObject);//選択ボタンを開くボタンに設定
        }
    }
}
