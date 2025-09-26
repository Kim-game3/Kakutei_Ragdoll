using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ポーズの内部処理層

public partial class PauseManager
{
    [System.Serializable]
    class PauseManager_InternalProcess
    {
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
        }
    }
}
