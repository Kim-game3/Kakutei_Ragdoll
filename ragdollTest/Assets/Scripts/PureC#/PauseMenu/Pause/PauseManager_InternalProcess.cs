using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//ポーズの内部処理層

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_InternalProcess
    {
        [SerializeField]
        PlayerInput _playerInput;

        const float _defaultTimeScale = 1;//等速
        const float _pauseTimeScale = 0;//ポーズ時の時間の速度

        public void Start()
        {

            //ゲーム開始時に時間が止まることがないようにする
            Time.timeScale = _defaultTimeScale;
        }

        public void OnSwitchPause(bool isPausing)
        {
            Time.timeScale = isPausing ? _pauseTimeScale : _defaultTimeScale;

            //操作を変更
            string newActionMap = isPausing ? ActionMapNameDictionary.UnControllable : ActionMapNameDictionary.Controllable;
            _playerInput.SwitchCurrentActionMap(newActionMap);
        }
    }
}
