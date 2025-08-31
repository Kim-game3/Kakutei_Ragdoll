using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

//�쐬��:���R
//�x�N�g���𑫏�̊p�x�ɍ��킹��

[System.Serializable]
public class FollowVectorToScaffold
{
    [SerializeField] GetScaffoldInfo _getScaffoldInfo;//����̏�������Ă���R���|�[�l���g

    public Vector3 Follow(Vector3 inputVec)
    {
        //����̏��̎擾�Ɏ��s�����ꍇ�̓x�N�g�������̂܂ܕԂ�
        if(!_getScaffoldInfo.Get(out RaycastHit scaffoldInfo)) return inputVec;

        float magnitude_InputVec = inputVec.magnitude;//���̃x�N�g���̑傫��

        Vector3 scaffoldNormal = scaffoldInfo.normal;//����̖@���x�N�g��

        Vector3 ret = Vector3.ProjectOnPlane(inputVec, scaffoldNormal);//����̖ʂɓ��e

        ret = ret.normalized * magnitude_InputVec;//���̑傫���ɖ߂�

        return ret;
    }
}
