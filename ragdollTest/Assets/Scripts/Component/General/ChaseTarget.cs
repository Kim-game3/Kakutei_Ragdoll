using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�^�[�Q�b�g�̈ʒu�Ɠ���������

public class ChaseTarget : MonoBehaviour
{
    [CustomLabel("�ǂ�������Ώ�")] [SerializeField] 
    TransformReference _target;

    // Update is called once per frame
    void Update()
    {
        transform.position = _target.Transform.position;
    }
}
