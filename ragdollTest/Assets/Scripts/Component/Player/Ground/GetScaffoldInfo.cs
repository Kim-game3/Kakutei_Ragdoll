using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;
using UnityEngine.UI;

//�쐬��:���R
//����̏�������Ă���

public class GetScaffoldInfo : MonoBehaviour
{
    [CustomLabel("���ɔ�΂�����")] [SerializeField]
    float _distance;
    [CustomLabel("���a")] [SerializeField]
    float _radius;
    [SerializeField] JudgeIsGround _judgeIsGround;

    RaycastHit _scaffoldInfo;
    bool _successToGet = false;//�擾�ɐ���������
    

    public bool Get(out RaycastHit scaffoldInfo)//����̏�������Ă���(�擾�̎��s��false�Ƃ���)
    {
        scaffoldInfo = _scaffoldInfo;

        return (_successToGet && _judgeIsGround.IsGround);
    }

    //private
    void UpdateScaffoldInfo()//����̏��̍X�V
    {
        Vector3 origin = _judgeIsGround.Center.position;
        float radius = _judgeIsGround.Radius;
        LayerMask layer = _judgeIsGround.ScaffoldLayer;

        Debug.DrawRay(origin, Vector3.down * _distance, Color.red);
        _successToGet = Physics.SphereCast(origin, _radius, Vector3.down, out _scaffoldInfo, _distance, layer);
    }

    private void Update()
    {
        UpdateScaffoldInfo();
    }
}
