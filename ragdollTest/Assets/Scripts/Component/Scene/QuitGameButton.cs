using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//�쐬��:���R
//�Q�[������߂�{�^��

public class QuitGameButton : MonoBehaviour
{
    [CustomLabel("�x������")] [SerializeField]
    float _delayDuration;

    [Tooltip("�{�^��")] [SerializeField]
    Button _targetButton;

    [SerializeField]
    CanvasGroup _canvas;

    private void Awake()
    {
        _targetButton.onClick.AddListener(QuitGame);
    }

    public void QuitGame()
    {
        StartCoroutine(QuitGameCoroutine());
    }

    private IEnumerator QuitGameCoroutine()
    {
        _canvas.interactable = false;
        yield return new WaitForSecondsRealtime(_delayDuration);//�����x��������

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}
