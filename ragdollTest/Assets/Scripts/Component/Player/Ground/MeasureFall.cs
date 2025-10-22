using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�n�ʂɏՓ˂����ۂ̗������x�𑪂�

public class MeasureFall : MonoBehaviour
{
    [Tooltip("�ݒu����")] [SerializeField]
    JudgeIsGround _judgeIsGround;

    [SerializeField]
    TransformReference _playerPos;

    [Tooltip("���b�O�̍����Ɣ�r���邩")] [SerializeField]
    float _sampleInterval;

    float _currentElapsedTime = 0;

    Vector3 _currentSamplePos;
    Vector3 _previousSamplePos;

    public event Action<float> OnLanding;//�ڒn�����u�Ԃ�1s�b�Ԃ̕ψʂ�������(�����Ēn�ʂɏՓ˂����̂ł���Ε��̒l���Ԃ����)

    private void Awake()
    {
        _previousSamplePos = _playerPos.Transform.position;
        _currentSamplePos = _previousSamplePos;

        _judgeIsGround.OnEnter += HandleGroundEnter;
    }

    private void HandleGroundEnter()
    {
        if(_sampleInterval<=0f)
        {
            Debug.Log("SampleInterval��0���傫�����Ă��������I");
            return;
        }

        //�ʒu�̍��i�O�̈ʒu - ���݈ʒu�j
        float posDifference = _currentSamplePos.y - _previousSamplePos.y;

        float ret = posDifference / _sampleInterval;
        OnLanding?.Invoke(ret);
        //Debug.Log(ret);
    }

    private void Update()
    {
        UpdatePosInfo();
    }

    void UpdatePosInfo()
    {
        _currentElapsedTime += Time.deltaTime;

        if (_currentElapsedTime <= _sampleInterval) return;//�w�莞�ԕ��o�߂����猻�݂̍����Ƃ��̑O�̍����̋L�^���X�V

        _currentElapsedTime = 0f;
        _previousSamplePos = _currentSamplePos;
        _currentSamplePos = _playerPos.Transform.position;
    }
}
