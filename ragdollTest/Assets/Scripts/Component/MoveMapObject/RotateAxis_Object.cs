using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃R���|�[�l���g�������I�u�W�F�N�g��Z��(���)�����ɉ�]������

public class RotateAxis_Object : MonoBehaviour
{
    [CustomLabel("����(�b)")] [SerializeField]
    float _cycle;

    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float rate = Time.deltaTime / _cycle;

        float angle=MathfExtension.CircleAngle*rate;

        transform.Rotate(transform.forward, angle);
    }
}
