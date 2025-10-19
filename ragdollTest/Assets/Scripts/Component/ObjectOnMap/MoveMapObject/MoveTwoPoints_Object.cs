using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃R���|�[�l���g�������I�u�W�F�N�g�Ɏw�肵����_�Ԃ��s����������

public class MoveTwoPoints_Object : MonoBehaviour
{
    [CustomLabel("����(�b)")] [SerializeField]
    float _cycle;

    [CustomLabel("�n�_")] [SerializeField]
    Transform _start;

    [CustomLabel("�I�_")] [SerializeField]
    Transform _end;

    [CustomLabel("�������Ώ�")] [SerializeField]
    Transform _target;

    float _current=0;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        _current += Time.deltaTime;
        _current %= _cycle;

        float t = MathfExtension.TriangleWave01(_current, 0, _cycle);
        
        Vector3 newPosition=Vector3.Lerp(_start.position,_end.position,t);
        _target.position = newPosition;
    }
}
