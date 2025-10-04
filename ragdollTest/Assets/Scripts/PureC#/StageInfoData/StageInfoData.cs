using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�X�e�[�W���Ƃ̏����擾����f�[�^�x�[�X�N���X

[CreateAssetMenu(fileName = "StageInfoData", menuName = "ScriptableObjects/StageInfoData")]
public class StageInfoData : ScriptableObject
{
    [Tooltip("�X�e�[�W���Ƃ̏��\n�z��̗v�f�ԍ����X�e�[�W��ID�ɂȂ�܂�")] [SerializeField]
    StageInfo[] _stageInfos;

    public int StageLength { get { return _stageInfos.Length; } }//�o�^����Ă���X�e�[�W�̐�

    public StageInfo GetStageInfo(int stageID)
    {
        if (!MathfExtension.IsInRange(stageID,0,_stageInfos.Length-1))
        {
            Debug.Log("�͈͊O�̒l�ł��I");
            return null;
        }

        return _stageInfos[stageID];
    }
}
