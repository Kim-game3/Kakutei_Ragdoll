using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̃R���|�[�l���g�������I�u�W�F�N�g�Ɏw�肵����_�Ԃ��s����������(��������ver)

public class InertialMoveTwoPoints_Objects : MonoBehaviour
{
    [CustomLabel("����(�b)")] [SerializeField]
    float _cycle;

    [CustomLabel("�n�_")] [SerializeField]
    Transform _start;

    [CustomLabel("�I�_")] [SerializeField]
    Transform _end;

    float _current = 0;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _current += Time.deltaTime;
        _current %= _cycle;

        float rate= _current / _cycle;
        float t = MathfExtension.Cos01(rate*2*Mathf.PI);

        Vector3 newPosition = Vector3.Lerp(_end.position, _start.position, t);
        transform.position = newPosition;
    }
}
