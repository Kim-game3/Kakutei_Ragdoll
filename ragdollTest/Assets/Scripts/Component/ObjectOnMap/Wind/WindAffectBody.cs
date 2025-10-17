using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���̉e�����󂯂�
//���̓����蔻��Ɏg���R���C�_�[�I�u�W�F�N�g�ɂ��̃R���|�[�l���g���A�^�b�`����

public class WindAffectBody : MonoBehaviour
{
    class WindInfoAndTime
    {
        public WindInfo windInfo;
        public float time;

        public WindInfoAndTime(WindInfo windInfo,float time)
        {
            this.windInfo = windInfo;
            this.time = time;
        }
    }

    [SerializeField] float
    _affectingDuration;

    [Tooltip("�������̂̕���")] [SerializeField]
    ConstantForce _playerBody;

    List<WindInfoAndTime> _affectingWinds=new List<WindInfoAndTime>();//�e�����󂯂Ă镗���X�g

    public void  AddWind(WindInfo windInfo)
    {
        foreach(var wind in _affectingWinds)
        {
            if(wind.windInfo==windInfo)//���ɉe�����󂯂Ă��镗����������
            {
                wind.time = _affectingDuration;//�X�V
                return;
            }
        }

        //������Ȃ�������V���ɒǉ�
        WindInfoAndTime newWind= new WindInfoAndTime(windInfo,_affectingDuration);
        _affectingWinds.Add(newWind);
    }

    private void Update()
    {
        //�����X�g���X�V
        foreach (var wind in _affectingWinds)
        {
            wind.time-=Time.deltaTime;
        }

        _affectingWinds.RemoveAll(wind => wind.time<=0);


        //�͂�������
        Vector3 force=Vector3.zero;

        foreach (var wind in _affectingWinds)
        {
            Vector3 addForce = wind.windInfo.ForceVec;
            force += addForce;
        }

        _playerBody.force = force;
    }
}
