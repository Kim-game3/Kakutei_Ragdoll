using UnityEngine;

//�쐬��:���R
//Transform�̎Q��(�Q�Ƃ������Ȃ��Ă����꒼���̂��y�ɂ��邽�߂̂���)

public class RigidbodyReference : MonoBehaviour
{
    [SerializeField]
    Rigidbody _rb;

    public Rigidbody Rigidbody
    {
        get { return _rb; }
        set { _rb = value; }
    }
}
