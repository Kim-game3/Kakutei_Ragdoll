using UnityEngine;

//�쐬��:���R
//Transform�̎Q��(�Q�Ƃ������Ȃ��Ă����꒼���̂��y�ɂ��邽�߂̂���)

public class TransformReference : MonoBehaviour
{
    [SerializeField]
    Transform _trs;

    public Transform Transform
    {
        get { return _trs; }
        set { _trs = value; }
    }
}
