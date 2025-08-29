using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�V�[����ύX(�ȈՓI�Ȃ��)

public class ChangeScene : MonoBehaviour
{
    [SerializeField] SceneReference targetScene;

    public void Change()//�V�[���𑦃`�F���W
    {
        if (!string.IsNullOrEmpty(targetScene.ScenePath))
        {
            SceneManager.LoadScene(targetScene.ScenePath);
        }
        else
        {
            Debug.LogError("�V�[�����w�肳��Ă��܂���I");
        }
    }

    public void ChangeAsync()//�V�[����񓯊��Ń`�F���W
    {
        if (!string.IsNullOrEmpty(targetScene.ScenePath))
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
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene.ScenePath);

        // �ǂݍ��݊����܂őҋ@
        while (!asyncLoad.isDone)
        {
            Debug.Log("�i�s�x: " + (asyncLoad.progress * 100) + "%");
            yield return null; // 1�t���[���҂�
        }
    }
}
