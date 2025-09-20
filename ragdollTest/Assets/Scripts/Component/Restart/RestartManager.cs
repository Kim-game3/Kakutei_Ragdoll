using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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


        yield return null;
    }
}
