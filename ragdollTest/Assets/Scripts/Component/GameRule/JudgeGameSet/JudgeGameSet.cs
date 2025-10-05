using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���I���𔻒f

public class JudgeGameSet : MonoBehaviour
{
    [SerializeField]
    OnTriggerDetect _gameClearZone;

    bool _isGameSet=false;//�Q�[���I��������

    public bool IsGameSet {  get { return _isGameSet; } }

    private void Awake()
    {
        _gameClearZone.OnEnter += SetGameClear;
    }

    void SetGameClear(Collider other)
    {
        //�N���A����
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isGameSet = true;
    }
}
