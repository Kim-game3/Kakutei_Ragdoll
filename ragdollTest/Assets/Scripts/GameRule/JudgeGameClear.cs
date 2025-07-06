using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���N���A����

public class JudgeGameClear : MonoBehaviour
{
    bool _judgedGameClear = false;
    const string _tagName_JudgeGameClear = "Clear";

    //public
    public bool JudgedGameClear { get { return _judgedGameClear; } }

    public event Action TriggerEvent;//�Q�[���N���A�Ɣ��肳�ꂽ�u�ԂɌĂ΂��

    //private

    private void OnTriggerEnter(Collider other)
    {
        //�L�����ɂ��Ă���N���A����p�̃g���K�[�ɐڐG����΃N���A��������
        if (!other.CompareTag(_tagName_JudgeGameClear)) return;

        Judge();
    }

    void Judge()
    {
        if (_judgedGameClear) return;

        _judgedGameClear = true;
        TriggerEvent?.Invoke();
    }
}
