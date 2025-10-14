using UnityEngine;
using UnityEngine.InputSystem;

//作成者:杉山
//リスタート時のプレイヤーの入力操作の切り替え処理

public partial class RestartProcess
{
    [System.Serializable]
    class InputControl
    {
        [SerializeField]
        PlayerInput _playerInput;

        public void SetControllable(bool isControllable)//操作可能状態の切り替え
        {
            string newActionMapName = isControllable ? ActionMapNameDictionary.Controllable : ActionMapNameDictionary.Restart; 

            _playerInput.SwitchCurrentActionMap(newActionMapName);
        }
    }
}
