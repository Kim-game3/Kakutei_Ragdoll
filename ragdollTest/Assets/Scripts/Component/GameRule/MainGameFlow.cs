using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�Q�[���̗���

public class MainGameFlow : MonoBehaviour
{
    [Tooltip("�V�[���J�ڒ���ɃQ�[�����J�n���邩")] [SerializeField]
    bool _playOnAwake;


    public void StartGame()//�Q�[���J�n
    {
        StartCoroutine(GameFlow());
    }


    //private
    void Start()
    {
        if(_playOnAwake) StartGame();
    }

    IEnumerator GameFlow()
    {
        Debug.Log("�Q�[���J�n�t�F�[�Y");
        Debug.Log("�Q�[���t�F�[�Y");
        Debug.Log("�Q�[���I���t�F�[�Y");


        yield return null;
    }
}
