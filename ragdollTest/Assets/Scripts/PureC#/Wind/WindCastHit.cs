using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̓����蔻��̃��C���΂������̕���

[System.Serializable]
public class WindCastHit
{
    [Tooltip("���̉e�����󂯂郌�C���[")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("�v���C���[�̃��C���[")] [SerializeField]
    LayerMask _playerLayer;

    [Min(1)] [SerializeField]
    int castNumX = 1;

    [Min(1)] [SerializeField]
    int castNumY = 1;

    Transform _transform;

    //�����C�̉��s���̑傫��
    const float _boxcastSizeZ = 0.01f;

    //XY���ʂ̍L��
    const float _width = 1;
    const float _height = 1;

    const float _halfWidth = _width / 2;
    const float _halfHeight = _height / 2;

    public void Awake(Transform transform)//������
    {
        _transform=transform;
    }

    public void IsHit(out bool isHitPlayer, out RaycastHit[] hits)//�v���C���[�ɏՓ˂�����(isHitPlayer)�A���������R���C�_�[(hits)
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

                //��������̃��C���΂�
                if (!Physics.BoxCast(_transform.TransformPoint(castPos), boxcastSize, _transform.forward, out RaycastHit hit, _transform.rotation, _transform.localScale.z, _affectableWindLayer)) continue;

                hitList.Add(hit);

                if (isHitPlayer) continue;

                //���������̂��v���C���[�ł��邩�𒲂ׂ�
                if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) continue;

                isHitPlayer = true;
            }
        }

        hits = hitList.ToArray();
    }

    Vector3 BoxCastSize()//��΂������C�̑傫��
    {
        Vector3 boxcastSize = _transform.localScale / 2;//BoxCast�ɓn���ۂ͑傫���̔����̒l�����Ȃ���΂Ȃ�Ȃ�
        boxcastSize.x /= castNumX;
        boxcastSize.y /= castNumY;
        boxcastSize.z = _boxcastSizeZ;

        return boxcastSize;
    }

    Vector3 Origin()//��΂����̊�_
    {
        return new Vector3(_halfWidth, _halfHeight, 0);
    }

    Vector3 CastPos(Vector3 origin, int x, int y)//���C���΂��ʒu(���[�J��)
    {
        Vector3 castPos = origin;
        castPos.x -= _halfWidth / castNumX * (1 + 2 * x);
        castPos.y -= _halfHeight / castNumY * (1 + 2 * y);

        return castPos;
    }
}
