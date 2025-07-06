using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foo : MonoBehaviour
{
    [SerializeField] Rigidbody[] _rb;
    [SerializeField] float _rate;


    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<_rb.Length ;i++)
        {
            _rb[i].inertiaTensor *= _rate;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
