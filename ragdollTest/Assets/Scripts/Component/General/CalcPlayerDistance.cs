using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�Ƃ̋����𑪂�

public class CalcPlayerDistance : MonoBehaviour
{
    [SerializeField]
    TransformReference _playerPos;

    public float CalcSqrt(Vector3 position)//������2��̏�Ԃ̂܂ܕԂ�(�����͂�����̕�����r�I�y��)
    {
        return (_playerPos.Transform.position - position).sqrMagnitude;
    }

    public float Calc(Vector3 position)//������Ԃ�(�����͂�����̕�����r�I�d��)
    {
        return Vector3.Distance(_playerPos.Transform.position,position);
    }

}
