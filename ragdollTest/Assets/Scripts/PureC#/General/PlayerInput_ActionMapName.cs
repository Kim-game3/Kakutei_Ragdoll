using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//PlayerInput�̃A�N�V�����}�b�v�����ǂ�����ł��擾�o����悤�ɂ�������

public class PlayerInput_ActionMapName
{
    /// <summary>
    ///�Q�[���V�[���̃v���C���[���삪�\�ȏ�Ԃ�ActionMap��
    /// </summary>
    const string _controllableActionMapName = "Game";  

    public static string Controllable {  get { return _controllableActionMapName; } }


    /// <summary>
    ///�Q�[���V�[���̃v���C���[���삪�s�\�ȏ�Ԃ�ActionMap��
    /// </summary>
    const string _uncontrollableActionMapName = "UnControllable";

    public static string UnControllable { get { return _uncontrollableActionMapName; } }
}
