using UnityEngine;

public class BoneComponentCopier : MonoBehaviour
{
    [Header("�R�s�[���̃{�[�����[�g")]
    public Transform sourceRoot;

    [Header("�R�s�[��̃{�[�����[�g")]
    public Transform targetRoot;

    [Header("Transform�̓R�s�[���܂���")]
    public bool includeInactive = true; // ��A�N�e�B�u���Ώۂɂ��邩
}