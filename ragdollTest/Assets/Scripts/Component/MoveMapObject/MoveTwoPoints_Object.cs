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

    float _current=0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _current += Time.deltaTime;
        _current %= _cycle;
        
        //Vector3 newPosition=Vector3.Lerp(_start.position,_end.position,t);
    }
}
