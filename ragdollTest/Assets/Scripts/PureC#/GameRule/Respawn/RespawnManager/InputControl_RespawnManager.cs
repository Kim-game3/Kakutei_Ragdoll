using Cinemachine;
using System.Collections;
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

        [Tooltip("明転直後に何秒待ってから操作を可能にするか")] [SerializeField]
        float _waitDurationToSetControllable = 2f;

        bool _isFinished = true;//処理が終わったか

        public bool IsFinished { get { return _isFinished; } }

        public void ProcessOnFallToWater()//水に落ちた瞬間の処理
        {
            SetControllable(false);//操作を不可能に
        }

        public IEnumerator CoroutineOnFinishFadeIn()//明転した直後に呼ぶ処理
        {
            _isFinished = false;

            yield return new WaitForSeconds(_waitDurationToSetControllable);

            SetControllable(true);//操作を可能に

            _isFinished = true;
        }

        void SetControllable(bool isControllable)//操作可能状態の切り替え
        {
            string newActionMapName = isControllable ? ActionMapNameDictionary.Controllable : ActionMapNameDictionary.Restart; 

            _playerInput.SwitchCurrentActionMap(newActionMapName);//操作マップ切り替え
            _inputProvider.enabled = isControllable;//カメラの操作切り替え
        }
    }
}
