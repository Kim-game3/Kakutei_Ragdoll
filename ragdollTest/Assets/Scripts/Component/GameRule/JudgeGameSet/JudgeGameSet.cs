using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���I���𔻒f

//*���ӓ_
//������g���ہA�N���A����p�̃g���K�[�����邱��

public class JudgeGameSet : MonoBehaviour
{
    bool _isGameSet=false;//�Q�[���I��������

    public bool IsGameSet {  get { return _isGameSet; } }


    private void OnTriggerEnter(Collider other)//������ƕς��邩��
    {
        //�N���A����
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isGameSet = true;
    }

}
