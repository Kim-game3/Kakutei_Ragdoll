using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//�쐬��:���R
//�v���C���[�̃J�����؂�ւ��]�[���̐N���E�E�o�����m����@�\

public class SwitchCameraZone : MonoBehaviour
{
    public event Action<int> OnEnterPlayer;//�v���C���[���J�����؂�ւ��]�[���ɐN���������Ƃ�ʒm
    public event Action<int> OnExitPlayer;//�v���C���[���J�����؂�ւ��]�[������E�o�������Ƃ�ʒm

    int _cameraIndex;

    public int CameraIndex
    {
        get { return _cameraIndex; }
        set { _cameraIndex = value; }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        OnEnterPlayer?.Invoke(_cameraIndex);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        OnExitPlayer?.Invoke(_cameraIndex);
    }
}
