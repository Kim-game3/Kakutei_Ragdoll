using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSolverIterations : MonoBehaviour
{
    [SerializeField] int iterations;

    [CustomLabel("身体のパーツのRigidbody")] [SerializeField]
    Rigidbody[] _bodyPartRbs;

    void Start()
    {
        for(int i=0; i<_bodyPartRbs.Length ;i++)
        {
            _bodyPartRbs[i].solverIterations = iterations;
            _bodyPartRbs[i].solverVelocityIterations = iterations;
        }
    }

}
