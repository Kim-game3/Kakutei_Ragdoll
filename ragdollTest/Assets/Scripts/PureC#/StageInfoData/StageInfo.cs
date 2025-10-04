using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���

[System.Serializable]
public class StageInfo
{
    [CustomLabel("�X�e�[�W��")] [SerializeField]
    string _stageName;

    [CustomLabel("�X�e�[�W�̃C���[�W�摜")] [Tooltip("�X�e�[�W�I���̎��ɕ\������摜")] [SerializeField]
    Sprite _stageImage;

    public string StageName { get { return _stageName; } }
    public Sprite StageSprite { get{ return _stageImage; } }
}
