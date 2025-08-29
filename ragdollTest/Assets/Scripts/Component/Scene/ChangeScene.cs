using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�V�[����ύX(�ȈՓI�Ȃ��)

public class ChangeScene : MonoBehaviour
{
    [SerializeField] SceneReference _targetScene;

    public void Change()//�V�[���𑦃`�F���W
    {
        if (!string.IsNullOrEmpty(_targetScene.ScenePath))
        {
            SceneManager.LoadScene(_targetScene.ScenePath);
        }
        else
        {
            Debug.LogError("�V�[�����w�肳��Ă��܂���I");
        }
    }

    public void ChangeAsync()//�V�[����񓯊��Ń`�F���W
    {
        if (!string.IsNullOrEmpty(_targetScene.ScenePath))
        {
            StartCoroutine(LoadSceneCoroutine());
        }
        else
        {
            Debug.LogError("�V�[�����w�肳��Ă��܂���I");
        }
    }

    private IEnumerator LoadSceneCoroutine()
    {
        // �񓯊��ŃV�[����ǂݍ��݊J�n
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_targetScene.ScenePath);

        // �ǂݍ��݊����܂őҋ@
        while (!asyncLoad.isDone)
        {
            Debug.Log("�i�s�x: " + (asyncLoad.progress * 100) + "%");
            yield return null; // 1�t���[���҂�
        }
    }
}
