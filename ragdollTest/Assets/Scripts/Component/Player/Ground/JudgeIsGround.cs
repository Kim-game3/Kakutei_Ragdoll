using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

//�쐬��:���R
//�ڒn����
//�~�`�Ƃ��̒��S���烌�C���΂��Ēn�ʂ��Ȃ�����T�����

public class JudgeIsGround : MonoBehaviour
{
    [CustomLabel("���S�_")] [SerializeField] 
    Transform _center;
    [CustomLabel("�~�̔��a")] [SerializeField]
    float _radius;
    [CustomLabel("���ɔ�΂�����")] [SerializeField]
    float _distance;
    [Tooltip("���S�����΂����C�ɉ����āA�~���ォ����ǉ��Ń��C���΂�")] [CustomLabel("�~����̃��C�̖{��")] [Min(0)] [SerializeField] 
    int _rayCount;
    [CustomLabel("����̃��C���[")] [SerializeField]
    LayerMask _scaffoldLayer;

    bool _isGround;

    public bool IsGround { get { return _isGround; } }//�ڒn���Ă��邩
    public Transform Center { get { return _center; } }//���S�_
    public float Radius { get { return _radius; } }//�~�̔��a
    public float Distance { get { return _distance; } }//���ɔ�΂�����
    public LayerMask ScaffoldLayer { get { return _scaffoldLayer; } }//����̃��C���[

    //private

    void UpdateIsGround()//�ڒn����X�V
    {
        //�~�̒��S�A�~���ォ���΂������C�̒�����ǂꂩ��ł�������ΐڒn�������Ƃɂ���
        _isGround = false;

        //�~�̒��S�����΂�
        if (IsFoundScafford(_center.position)) return;

        //�~���ォ���΂�
        for(int i=0; i<_rayCount ;i++)
        {
            float angle = (360f / _rayCount) * i;
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), 0, Mathf.Sin(angle * Mathf.Deg2Rad)) * _radius;
            Vector3 origin = _center.position + offset;

            if (IsFoundScafford(origin)) return;
        }
    }

    bool IsFoundScafford(Vector3 origin)//�������������(�������������ڒn���Ă��邱�Ƃɂ���true��Ԃ�)
    {
        Debug.DrawRay(origin, Vector3.down*_distance, Color.green);
        if (!Physics.Raycast(origin, Vector3.down, _distance, _scaffoldLayer)) return false;

        //���ꂪ��������
        _isGround = true;
        return true;
    }

    private void Update()
    {
        UpdateIsGround();
    }
}
