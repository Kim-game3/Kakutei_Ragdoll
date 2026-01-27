using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//ƒfƒX”(…‚É—‚¿‚½‰ñ”)‚ğ”‚¦‚é

public class CountDeath : MonoBehaviour
{
    [SerializeField]
    RestartManager _restartManager;

    int _count=0;

    public int Count {  get { return _count; } }

    private void OnEnable()
    {
        _restartManager.OnRestrat += AddCount;
    }

    private void OnDisable()
    {
        _restartManager.OnRestrat -= AddCount;
    }

    void AddCount()
    {
        _count++;
    }
}
