using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�I�u�W�F�N�g�̃^�O�����ǂ�����ł��擾�ł���悤�ɂ�������

public class ObjectTagNameDictionary
{
    /// <summary>
    /// �v���C���[�̃^�O��
    /// </summary>
    const string _playerTagName = "Player";

    public static string Player { get { return _playerTagName; } }


    /// <summary>
    /// ���̃^�O��
    /// </summary>
    const string _waterTagName = "Water";
    
    public static string Water { get { return _waterTagName; } }
}
