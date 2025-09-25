using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//�쐬��:���R
//�|�[�Y���̑���

public class PauseManager : MonoBehaviour
{
    //��������
    //UI

    [CustomLabel("�|�[�Y���j���[")] [SerializeField]
    GameObject _pauseMenu;

    const float _defaultTimeScale = 1;//����
    const float _pauseTimeScale = 0;//�|�[�Y���̎��Ԃ̑��x

    bool _isPausing=false;

    //�|�[�Y��Ԃ̐؂�ւ�
    public void SwitchPause(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        SwitchPauseProcess();
    }

    public void SwitchPause()
    {
        SwitchPauseProcess();
    }


    //




    //private

    void SwitchPauseProcess()//�|�[�Y��Ԑ؂�ւ�
    {
        _isPausing = !_isPausing;


        //���������̓N���X��
        _pauseMenu.SetActive(_isPausing);

        Time.timeScale = _isPausing ? _pauseTimeScale : _defaultTimeScale;
    }

}
