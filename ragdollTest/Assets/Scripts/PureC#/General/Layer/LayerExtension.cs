using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���C���[�֌W�̔ėp���\�b�h

public class LayerExtension
{
    public static bool IsInLayerMask(LayerMask targetLayer,GameObject targetObj)//�w�肵�����C���[�}�X�N�̒��ɁA�w��I�u�W�F�N�g�̃��C���[�������Ă��邩
    {
        return (targetLayer.value & (1 << targetObj.layer)) != 0;
    }
}
