using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームの状態クラス(ベース)

public abstract class MainGameStateTypeBase : MonoBehaviour
{
    /// <summary>
    /// OnUpdateかOnEnter中で_finishedをtrueにすれば、次のステートに移る
    /// </summary>
    protected bool _finished;

    public bool Finished { get { return _finished; } }//ステートが終わったか


    public abstract void OnEnter();//ステートの開始処理
    public abstract void OnUpdate();//ステートの毎フレーム処理
    public abstract void OnExit();//ステートの終了処理
}
