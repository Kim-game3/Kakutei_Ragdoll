using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//�쐬��:���R
//�V�[����ύX����{�^��

public class ChangeSceneButton : MonoBehaviour
{
    [Tooltip("���̃V�[��")] [SerializeField] 
    SceneReference _nextScene;

    [Tooltip("�{�^��")] [SerializeField]
    Button _targetButton;

    [SerializeField]
    CanvasGroup _canvasGroup;

    float _loadProgress = 0;
    const float _completeLoadProgress = 100;

    public float LoadProgress { get { return _loadProgress; } }//���[�h�̐i�s�x

    public float CompleteLoadProgress { get { return _completeLoadProgress; } }//���[�h�����������̐i�s�x

    public event Action OnStartLoad;

    private void Awake()
    {
        _targetButton.onClick.AddListener(ChangeScene);
    }

    public void ChangeScene()
    {
        if (!string.IsNullOrEmpty(_nextScene.ScenePath))
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
        _canvasGroup.interactable = false;
        OnStartLoad?.Invoke();

        // �񓯊��ŃV�[����ǂݍ��݊J�n
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene.ScenePath);

        // �ǂݍ��݊����܂őҋ@
        while (!asyncLoad.isDone)
        {
            _loadProgress = asyncLoad.progress * _completeLoadProgress;
            yield return null; // 1�t���[���҂�
        }
    }
}
