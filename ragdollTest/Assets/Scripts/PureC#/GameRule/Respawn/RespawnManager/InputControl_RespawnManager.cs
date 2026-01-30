using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//リスタート時のプレイヤーの入力操作の切り替え処理

public partial class RespawnProcess
{
    [System.Serializable]
    class InputControl
    {
        [SerializeField]
        PlayerInput _playerInput;

        [SerializeField]
        CinemachineInputProvider _inputProvider;

        public void SetControllable(bool isControllable)//操作可能状態の切り替え
        {
            string newActionMapName = isControllable ? ActionMapNameDictionary.Controllable : ActionMapNameDictionary.Restart; 

            _playerInput.SwitchCurrentActionMap(newActionMapName);//操作マップ切り替え
            _inputProvider.enabled = isControllable;//カメラの操作切り替え
        }
    }
}
