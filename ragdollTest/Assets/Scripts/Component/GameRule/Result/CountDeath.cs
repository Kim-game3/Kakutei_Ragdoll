using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�f�X��(���ɗ�������)�𐔂���

public class CountDeath : MonoBehaviour
{
    [SerializeField]
    RestartManager _restartManager;

    int _count=0;

    public int Count {  get { return _count; } }

    private void Awake()
    {
        _restartManager.OnRestrat += AddCount;
    }

    void AddCount()
    {
        _count++;
    }
}
