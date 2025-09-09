using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//シーンの流れの状態クラス(ベース)

public abstract class SceneFlowStateTypeBase : MonoBehaviour
{
    /// <summary>
    /// OnUpdateかOnEnter中で_finishedをtrueにすれば、次のステートに移る
    /// </summary>
    protected bool _finished;

    public bool Finished { get { return _finished; } }//ステートが終わったか

    /// <summary>
    ///ステートの開始処理
    ///そのステートになった時、一回だけ呼ばれる
    /// </summary>
    public abstract void OnEnter();

    /// <summary>
    ///ステートの毎フレーム処理
    ///そのステート中、毎フレーム呼ばれる
    /// </summary>
    public abstract void OnUpdate();

    /// <summary>
    ///ステートの終了処理
    ///そのステートから抜け出す時、一回だけ呼ばれる
    /// </summary>
    public abstract void OnExit();
}
