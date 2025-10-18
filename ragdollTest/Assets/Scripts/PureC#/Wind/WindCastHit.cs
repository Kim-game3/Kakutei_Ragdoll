using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の当たり判定のレイを飛ばす処理の部分

[System.Serializable]
public class WindCastHit
{
    [Tooltip("風の影響を受けるレイヤー")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("プレイヤーのレイヤー")] [SerializeField]
    LayerMask _playerLayer;

    [Min(1)] [SerializeField]
    int castNumX = 1;

    [Min(1)] [SerializeField]
    int castNumY = 1;

    Transform _transform;

    //箱レイの奥行きの大きさ
    const float _boxcastSizeZ = 0.01f;

    //XY平面の広さ
    const float _width = 1;
    const float _height = 1;

    const float _halfWidth = _width / 2;
    const float _halfHeight = _height / 2;

    public void Awake(Transform transform)//初期化
    {
        _transform=transform;
    }

    public void IsHit(out bool isHitPlayer, out RaycastHit[] hits)//プレイヤーに衝突したか(isHitPlayer)、当たったコライダー(hits)
    {
        isHitPlayer = false;
        List<RaycastHit> hitList = new List<RaycastHit>();

        Vector3 boxcastSize = BoxCastSize();
        Vector3 origin = Origin();

        for (int y = 0; y < castNumY; y++)
        {
            for (int x = 0; x < castNumX; x++)
            {
                Vector3 castPos = CastPos(origin, x, y);

                Vector3 foo = _transform.TransformPoint(castPos);
                Debug.DrawLine(foo, foo + _transform.forward * _transform.localScale.z, Color.red, 2);

                //平たい板状のレイを飛ばす
                if (!Physics.BoxCast(_transform.TransformPoint(castPos), boxcastSize, _transform.forward, out RaycastHit hit, _transform.rotation, _transform.localScale.z, _affectableWindLayer)) continue;

                hitList.Add(hit);

                if (isHitPlayer) continue;

                //当たったのがプレイヤーであるかを調べる
                if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) continue;

                isHitPlayer = true;
            }
        }

        hits = hitList.ToArray();
    }

    Vector3 BoxCastSize()//飛ばす箱レイの大きさ
    {
        Vector3 boxcastSize = _transform.localScale / 2;//BoxCastに渡す際は大きさの半分の値を入れなければならない
        boxcastSize.x /= castNumX;
        boxcastSize.y /= castNumY;
        boxcastSize.z = _boxcastSizeZ;

        return boxcastSize;
    }

    Vector3 Origin()//飛ばす時の基準点
    {
        return new Vector3(_halfWidth, _halfHeight, 0);
    }

    Vector3 CastPos(Vector3 origin, int x, int y)//レイを飛ばす位置(ローカル)
    {
        Vector3 castPos = origin;
        castPos.x -= _halfWidth / castNumX * (1 + 2 * x);
        castPos.y -= _halfHeight / castNumY * (1 + 2 * y);

        return castPos;
    }
}
