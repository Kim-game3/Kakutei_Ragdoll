using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風を出す機能
//負荷軽減のため、プレイヤーがある程度近づいてきた時に風が吹くようにする

public class Wind : MonoBehaviour
{
    [Tooltip("風を出す周期")] [SerializeField]
    TimeSwitchBool _windCycle;

    [Tooltip("プレイヤーが近づいてきたのを感知する機能\n十分に大きくすることをお勧めする")] [SerializeField]
    OnTriggerDetect _playerDetect;

    bool _isNearPlayer = false;

    private void Awake()
    {
        _windCycle.OnTrue += Tr;
        _windCycle.OnFalse += Fr;

        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Tr()
    {
        if (!_isNearPlayer) return;

        Debug.Log("風が吹く");
    }

    private void Fr()
    {
        if (!_isNearPlayer) return;

        Debug.Log("風が止む");
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = true;

        if (_windCycle.IsActive) Tr();
        else Fr();
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isNearPlayer = false;
    }

    private void Update()
    {
        if (!_isNearPlayer) return;

        _windCycle.Update();
    }


}
