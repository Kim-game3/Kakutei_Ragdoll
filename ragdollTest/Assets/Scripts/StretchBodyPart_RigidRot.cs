using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//身体のパーツについたRigidBodyを使って一定の角度まで伸ばす
public class StretchBodyPart_RigidRot : MonoBehaviour
{
    [Header("頭の位置")]
    [SerializeField] Transform _headTransform;
    [Header("動かしたい部位のRigidBody")]
    [SerializeField] Rigidbody _bodyPartRb_Stretch;

    [Header("伸ばすときの数値")]
    [Tooltip("伸ばすときの速度")]
    [SerializeField] float _rotationCorrectionSpeed = 8f;// 回転補正速度
    [Tooltip("伸ばすときの回転の補正")]
    [SerializeField] float _rotationThreshold = 1f;// 前に伸ばす状態の回転しきい値

    bool _stretching = false;//伸ばしているかのフラグ

    public bool Stretching//trueになってる間は伸ばすようにする
    {
        get { return _stretching; }
        set { _stretching = value; }
    }

    private void FixedUpdate()
    {
        CheckStretchFlag();
    }

    void CheckStretchFlag()//伸ばすかのフラグを確認して、フラグがtrueになってたら伸ばす
    {
        if (!_stretching) return;
        
        ApplyForwardRotation();
    }

    void ApplyForwardRotation()// 前(頭の向きを基準に)にまっすぐ伸ばすための回転を適用
    {
        if(_headTransform == null)//頭の位置が設定されていない
        {
            Debug.Log("頭の位置が設定されていません");
            return;
        }
        
        Quaternion targetRotation = TargetRotation();//目標値(角度)

        float rotationDistance = Quaternion.Angle(_bodyPartRb_Stretch.rotation, targetRotation);//目標値(角度)との差を算出

        if (!ShouldMoveRot(rotationDistance, _rotationThreshold)) return;//しきい値と目標値との差を比較して、動かす必要がなかったらここで処理を終える
        
        MoveBodyPartRot(targetRotation);//身体のパーツを動かす
    }

    Quaternion TargetRotation()//身体のパーツを動かすときの目標角度
    {
        Vector3 forward = _headTransform.forward;// 頭の前方（目の前）を基準に
        return Quaternion.LookRotation(forward, Vector3.up);
    }

    bool ShouldMoveRot(float distance,float threshold)//目標値との差としきい値を比較して、その差がしきい値より大きければ動かす(trueを返す)
    {
        return distance > threshold;
    }

    void MoveBodyPartRot(Quaternion targetRot)//身体のパーツの角度を動かす(targetRotは目標角度)
    {
        Quaternion newRotation = Quaternion.Slerp(_bodyPartRb_Stretch.rotation, targetRot, Time.fixedDeltaTime * _rotationCorrectionSpeed);
        _bodyPartRb_Stretch.MoveRotation(newRotation);
    }
}
