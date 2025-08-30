using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//作成者:杉山
//接地判定
//円形とその中心からレイを飛ばして地面がないかを探る方式

public class JudgeIsGround : MonoBehaviour
{
    [CustomLabel("中心点")] [SerializeField] 
    Transform _center;
    [CustomLabel("円の半径")] [SerializeField]
    float _radius;
    [CustomLabel("下に飛ばす距離")] [SerializeField]
    float _distance;
    [Tooltip("中心から飛ばすレイに加えて、円周上からも追加でレイを飛ばす")] [CustomLabel("円周上のレイの本数")] [Min(0)] [SerializeField] 
    int _rayCount;
    [CustomLabel("足場のレイヤー")] [SerializeField]
    LayerMask _scaffoldLayer;

    bool _isGround;

    public bool IsGround { get { return _isGround; } }//接地しているか
    //中心点
    public float Radius { get { return _radius; } }//円の半径
    public float Distance { get { return _distance; } }//下に飛ばす距離
    //足場のレイヤー

    //private

    void UpdateIsGround()//接地判定更新
    {
        //円の中心、円周上から飛ばしたレイの中からどれか一つでも当たれば接地したことにする
        _isGround = false;

        //円の中心から飛ばす
        if (IsFoundScafford(_center.position)) return;

        //円周上から飛ばす
        for(int i=0; i<_rayCount ;i++)
        {
            float angle = (360f / _rayCount) * i;
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
            Vector3 origin = _center.position + offset;

            if (IsFoundScafford(origin)) return;
        }
    }

    bool IsFoundScafford(Vector3 origin)//足場を見つけたか(足場を見つけたら接地していることにしてtrueを返す)
    {
        Debug.DrawRay(origin, Vector3.down*_distance, Color.green);
        if (!Physics.Raycast(origin, Vector3.down, _distance, _scaffoldLayer)) return false;

        //足場が見つかった
        _isGround = true;
        return true;
    }

    private void Update()
    {
        UpdateIsGround();
    }
}
