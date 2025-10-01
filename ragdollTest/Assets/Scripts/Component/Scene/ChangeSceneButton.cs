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
    [CustomLabel("�x������")] [SerializeField]
    float _delayDuration;

    [Tooltip("���̃V�[��")] [SerializeField] 
    SceneReference _nextScene;

    [Tooltip("�{�^��")] [SerializeField]
    Button _targetButton;

    [SerializeField]
    CanvasGroup _canvas;

    float _loadProgress = 0;

    public float LoadProgress { get { return _loadProgress; } }//���[�h�̐i�s�x(0�`1)

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
        yield return new WaitForSeconds(_delayDuration);//�����x��������

        _canvas.interactable = false;
        OnStartLoad?.Invoke();

        // �񓯊��ŃV�[����ǂݍ��݊J�n
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(_nextScene.ScenePath);

        // �ǂݍ��݊����܂őҋ@
        while (!asyncLoad.isDone)
        {
            _loadProgress = asyncLoad.progress;
            yield return null; // 1�t���[���҂�
        }
    }
}
