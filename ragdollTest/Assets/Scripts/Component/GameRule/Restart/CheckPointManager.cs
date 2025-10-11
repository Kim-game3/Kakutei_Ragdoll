using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�`�F�b�N�|�C���g�̃}�l�[�W���[
//�`�F�b�N�|�C���g�̐����c��

public class CheckPointManager : MonoBehaviour
{
    [Tooltip("�`�F�b�N�|�C���g�X�V�̃g���K�[\n�v�f�ԍ����`�F�b�N�|�C���g�̐���")] [SerializeField]
    OnTriggerDetect[] _checkPointZones;

    CheckPointUpdateTrigger[] _checkPointUpdateTriggers;

    int _currentCheckPointIndex = 0;//���݂̃`�F�b�N�|�C���g�ԍ�

    public int CurrentCheckPointIndex { get { return _currentCheckPointIndex; } }

    public int CheckPointLength { get { return _checkPointZones.Length; } }

    public void UpdateCheckPoint(int newCheckPointIndex)//�`�F�b�N�|�C���g�̍X�V
    {
        if (newCheckPointIndex <= _currentCheckPointIndex) return;

        _currentCheckPointIndex=newCheckPointIndex;
    }

    private void Awake()
    {
        _checkPointUpdateTriggers = new CheckPointUpdateTrigger[_checkPointZones.Length];

        for (int i = 0; i<_checkPointUpdateTriggers.Length ; i++)
        {
            _checkPointUpdateTriggers[i]=new CheckPointUpdateTrigger(i, _checkPointZones[i]);
            _checkPointUpdateTriggers[i].OnEnter += UpdateCheckPoint;
        }
    }
}
