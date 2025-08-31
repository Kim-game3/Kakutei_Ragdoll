using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

//作成者:杉山
//ベクトルを足場の角度に合わせる

[System.Serializable]
public class FollowVectorToScaffold
{
    [SerializeField] GetScaffoldInfo _getScaffoldInfo;//足場の情報を取ってくるコンポーネント

    public Vector3 Follow(Vector3 inputVec)
    {
        //足場の情報の取得に失敗した場合はベクトルをそのまま返す
        if(!_getScaffoldInfo.Get(out RaycastHit scaffoldInfo)) return inputVec;

        float magnitude_InputVec = inputVec.magnitude;//元のベクトルの大きさ

        Vector3 scaffoldNormal = scaffoldInfo.normal;//足場の法線ベクトル

        Vector3 ret = Vector3.ProjectOnPlane(inputVec, scaffoldNormal);//足場の面に投影

        ret = ret.normalized * magnitude_InputVec;//元の大きさに戻す

        return ret;
    }
}
