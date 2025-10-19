using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃R���|�[�l���g�������I�u�W�F�N�g��Z��(���)�����ɋt���v���ɉ�]������

public class RotateAxis_Object : MonoBehaviour
{
    [CustomLabel("����(�b)")] [SerializeField]
    float _cycle;

    [CustomLabel("�������Ώ�")] [SerializeField]
    Transform _target;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rate = Time.deltaTime / _cycle;

        float angle=MathfExtension.CircleAngle*rate;

        Quaternion angleRot = Quaternion.AngleAxis(angle,transform.forward);

        _target.rotation=angleRot*_target.rotation;
    }
}
