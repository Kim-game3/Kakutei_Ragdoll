using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWind : MonoBehaviour
{
    [SerializeField] float power;

    [SerializeField]
    WindAffectBody _body;

    WindInfo windInfo;

    // Start is called before the first frame update
    void Start()
    {
        windInfo = new WindInfo(Vector3.up,power);
    }

    // Update is called once per frame
    void Update()
    {
        _body.AddWind(windInfo);
    }
}
