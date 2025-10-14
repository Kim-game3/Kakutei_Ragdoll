using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�f�[�^�폜����R�}���h

public class ClearPlayerDataCommand : MonoBehaviour
{
    // ���o���������ԁi�C�ӂɕύX�j
    private readonly List<KeyCode> targetSequence = new()
    {
        KeyCode.T,
        KeyCode.R,
        KeyCode.A,
        KeyCode.C,
        KeyCode.K,
        KeyCode.E,
        KeyCode.R,
    };

    // ���݂̓��͗���
    private List<KeyCode> inputHistory = new();

    // ���͂̊Ԋu���󂫂������烊�Z�b�g���鎞��
    [SerializeField] private float inputTimeout = 1.0f;
    private float lastInputTime = 0f;

    void Update()
    {
        // �L�[���͂��Ď�
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKeyDown(key))
            {
                RegisterKey(key);
            }
        }

        // ��莞�ԓ��͂��Ȃ������烊�Z�b�g
        if (inputHistory.Count > 0 && Time.time - lastInputTime > inputTimeout)
        {
            inputHistory.Clear();
        }
    }

    private void RegisterKey(KeyCode key)
    {
        inputHistory.Add(key);
        lastInputTime = Time.time;

        // ����������������Â��̂��폜
        if (inputHistory.Count > targetSequence.Count)
        {
            inputHistory.RemoveAt(0);
        }

        // ���݂̗����ƃ^�[�Q�b�g���r
        bool matched = true;
        for (int i = 0; i < inputHistory.Count; i++)
        {
            if (inputHistory[i] != targetSequence[i])
            {
                matched = false;
                break;
            }
        }

        // ���S��v������Ăяo��
        if (matched && inputHistory.Count == targetSequence.Count)
        {
            OnSequenceMatched();
            inputHistory.Clear();
        }
    }

    private void OnSequenceMatched()
    {
        // �������̏����������ɏ���
        PlayerPrefs.DeleteAll();
    }
}
