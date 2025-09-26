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

        [CustomLabel("ゲーム中のUI")] [SerializeField]
        GameObject _inGameUI;

        [CustomLabel("ポーズメニュー")] [SerializeField]
        GameObject _pauseMenu;

        

        Button _resumeButton;

        public void Awake(Button resumeButton)//resumeButton=ゲーム再開ボタン
        {
            _resumeButton = resumeButton;
        }

        public void Strat()
        {
            //ゲーム開始時にポーズメニューが表示されてたり、ゲーム中のUIが出てこないということがないようにする
            if(!_inGameUI.activeSelf) _inGameUI.SetActive(true);
            if(_pauseMenu.activeSelf) _pauseMenu.SetActive(false);
        }

        public void OnSwitchPause(bool isPausing)
        {
            _inGameUI.SetActive(!isPausing);
            _pauseMenu.SetActive(isPausing);

            //ポーズになったらResumeボタンを選択状態にする
            if(isPausing) _eventSystem.SetSelectedGameObject(_resumeButton.gameObject);
        }
    }
}
