using System;
using UnityEngine;

//�쐬��:���R
//���X�^�[�g�̃}�l�[�W���[(���X�^�[�g�����邩�ۂ��A�ǂ̃`�F�b�N�|�C���g�Ƀ��X�^�[�g�����邩�𔻒f)

public class RestartManager : MonoBehaviour
{
    [Tooltip("���݂̃`�F�b�N�|�C���g�̔ԍ���������@�\")] [SerializeField]
    CheckPointManager _checkPointManager;

    [Tooltip("���X�^�[�g�̏������s���@�\")] [SerializeField]
    RestartProcess _restartProcess;

    [Tooltip("���X�^�[�g�]�[���̃g���K�[")] [SerializeField] 
    OnTriggerDetect _restartZoneTrigger;

    public event Action OnRestrat;//���ɗ������u�ԂɌĂ�

    private void Awake()
    {
        _restartZoneTrigger.OnEnter += OnHit_RestartTrigger;
    }

    private void Start() { }//enabled�̃`�F�b�N�����o�����߂ɂ킴�Ƌ��Start�����Ă܂�

    private void OnHit_RestartTrigger(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        if (_restartProcess.IsRestarting) return;

        if (!enabled) return;

        OnRestrat?.Invoke();
        _restartProcess.RestartTrigger(_checkPointManager.CurrentCheckPointIndex);
    }
}
