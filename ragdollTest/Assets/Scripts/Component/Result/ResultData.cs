using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���U���g�f�[�^(�V�[�����ׂ��œn���p)
//���ӓ_:�J�ڃV�[����ň�x���g��Ȃ��ƁA�f�[�^�����Z�b�g����܂�

[CreateAssetMenu(fileName = "ResultData", menuName = "ScriptableObjects/ResultData")]
public class ResultData : ScriptableObject
{
    float _clearTime;//�N���A�^�C��
    int _deathCount;//�f�X��(���ɗ�������)

    public float ClearTime
    {
        get { return _clearTime; }
        set { _clearTime = value; }
    }

    public int DeathCount
    {
        get { return _deathCount; }
        set { _deathCount = value; }
    }
}
