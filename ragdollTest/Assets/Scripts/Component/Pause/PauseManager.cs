using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//ポーズ時の操作

public class PauseManager : MonoBehaviour
{
    //
    //UI
    //音量設定

    [CustomLabel("ポーズメニュー")] [SerializeField]
    GameObject _pauseMenu;

    const float _defaultTimeScale = 1;//等速
    const float _pauseTimeScale = 0;//ポーズ時の時間の速度

    bool _isPausing=false;

    //ポーズ状態の切り替え
    public void SwitchPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SwitchPauseProcess();
    }

    public void SwitchPause()
    {
        SwitchPauseProcess();
    }


    //




    //private

    void SwitchPauseProcess()//ポーズ状態切り替え
    {
        _isPausing = !_isPausing;

        _pauseMenu.SetActive(_isPausing);

        Time.timeScale = _isPausing ? _pauseTimeScale : _defaultTimeScale;
    }

}
