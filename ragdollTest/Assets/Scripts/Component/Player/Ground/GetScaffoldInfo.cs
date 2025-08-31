using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UI;

//作成者:杉山
//足場の情報を取ってくる

public class GetScaffoldInfo : MonoBehaviour
{
    [CustomLabel("下に飛ばす距離")] [SerializeField]
    float _distance;
    [CustomLabel("半径")] [SerializeField]
    float _radius;
    [SerializeField] 
    JudgeIsGround _judgeIsGround;//接地状況の取得用

    RaycastHit _scaffoldInfo;
    bool _successToGet = false;//取得に成功したか
    

    public bool Get(out RaycastHit scaffoldInfo)//足場の情報を取ってくる(取得の失敗をfalseとする)
    {
        scaffoldInfo = _scaffoldInfo;

        return (_successToGet && _judgeIsGround.IsGround);
    }

    //private
    void UpdateScaffoldInfo()//足場の情報の更新
    {
        Vector3 origin = _judgeIsGround.Center.position;
        float radius = _judgeIsGround.Radius;
        LayerMask layer = _judgeIsGround.ScaffoldLayer;

        Debug.DrawRay(origin, Vector3.down * _distance, Color.red);
        _successToGet = Physics.SphereCast(origin, _radius, Vector3.down, out _scaffoldInfo, _distance, layer);
    }

    private void Update()
    {
        UpdateScaffoldInfo();
    }
}
