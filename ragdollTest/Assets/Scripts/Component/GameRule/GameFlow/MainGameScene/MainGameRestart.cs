using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*�쐬�ҁ@�ؑ�*/
public class MainGameRestart : MonoBehaviour
{
    [SerializeField] GameObject Player;
    private Vector3 initialposition;


    private void Start()
    {
        initialposition = Player.transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        Player.transform.position = initialposition;
    }
}
