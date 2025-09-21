using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class RestartManager : MonoBehaviour
{
    // --- リスタートの設定関係 --- //
    [CustomLabel("リスタート地点&方向")] [Tooltip("明転終了後、プレイヤーがこの地点に出現＆この方向に向かって投げ飛ばされる")] [SerializeField]
    Transform _restartPoint;

    [CustomLabel("リスタート時のカメラ関係")] [SerializeField]
    CameraControl _cameraControl;

    [CustomLabel("リスタート時の入力関係")] [SerializeField]
    InputControl _inputControl;

    bool _isRestarting = false;//リスタート中か

    public bool IsRestarting { get { return _isRestarting; } }

    private void Awake()
    {
        _cameraControl.Init();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_isRestarting) return;

        StartCoroutine(OnRestart());
    }

    IEnumerator OnRestart()
    {
        //☆落ちた瞬間
        //リスポーン中をオンにする
        //カメラの追跡をやめる(FollowとLookAtをnullにする)
        //操作を出来なくする
        //☆シャチがザパっと出てくる
        //☆暗転
        //☆明転
        //プレイヤーを海の中のリスポーン地点に戻す
        //特定の方向に力をかける
        //リスポーン地点用のカメラをオンにする
        //カメラの追跡(FollowとLookAtにプレイヤーを入れる)
        //☆シャチが一瞬顔を出して海に戻る
        //☆(数s後)
        //カメラの追跡をオンにする
        //☆(数秒後)
        //操作可能に
        //リスポーン中をオフに

        //落ちた瞬間
        _isRestarting=true;
        _inputControl.SetControllable(false);//操作不可能にする
        _cameraControl.ChangeFollow_PlayCamera(false);//カメラのプレイヤーの追跡をやめる

        //明転まで待つ

        //明転が終わった直後
        _cameraControl.SwitchRestartPointCamera(true);//リスタート地点のカメラにする

        //明転が終わってから数秒後
        _cameraControl.ChangeFollow_PlayCamera(true);//カメラのプレイヤーの追跡を再開
        _cameraControl.SwitchRestartPointCamera(false);//プレイカメラに戻す

        //さらに数秒後
        _inputControl.SetControllable(true);//操作可能にする
        _isRestarting = false;


        yield return null;
    }
}
