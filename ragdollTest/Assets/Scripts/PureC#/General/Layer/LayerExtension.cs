using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//レイヤー関係の汎用メソッド

public class LayerExtension
{
    public static bool IsInLayerMask(LayerMask targetLayer,GameObject targetObj)//指定したレイヤーマスクの中に、指定オブジェクトのレイヤーが入っているか
    {
        return (targetLayer.value & (1 << targetObj.layer)) != 0;
    }
}
