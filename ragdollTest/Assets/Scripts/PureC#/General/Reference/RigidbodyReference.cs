using UnityEngine;

//作成者:杉山
//Transformの参照(参照が無くなっても入れ直すのを楽にするためのもの)

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
