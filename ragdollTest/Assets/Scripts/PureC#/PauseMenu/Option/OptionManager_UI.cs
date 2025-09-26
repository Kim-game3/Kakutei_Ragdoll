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

        [CustomLabel("オプションメニュー")] [SerializeField]
        GameObject _optionMenu;

        [Tooltip("オプションメニューを閉じた後に選択状態にするボタン")] [SerializeField]
        Button _selectButton_AfterClose;

        Button _closeButton;//オプションメニューを閉じるボタン

        public void Awake(Button closeButton)//closeButton=閉じるボタン
        {
            _closeButton = closeButton;
        }

        public void Start()
        {
            _optionMenu.SetActive(false);//ゲーム開始時にはオプションメニューは閉じておく
        }

        public void OnOpen()
        {
            _optionMenu.SetActive(true);
            _eventSystem.SetSelectedGameObject(_closeButton.gameObject);//選択ボタンを閉じるボタンに設定
        }

        public void OnClose()
        {
            _optionMenu.SetActive(false);
            _eventSystem?.SetSelectedGameObject(_selectButton_AfterClose.gameObject);
        }

        public void OnDisable()
        {
            if(_optionMenu!=null) _optionMenu.SetActive(false);
        }
    }
    
}
