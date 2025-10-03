using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���ڍs�����ۂɎ����I�Ɏ��ԑ��x�����Z�b�g����B

public class ResetTimeScale_OnSceneLoad : MonoBehaviour
{
    const float _defaultTimeScale = 1;

    private void OnEnable()
    {
        SceneManager.sceneLoaded += ResetTimeScale;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= ResetTimeScale;
    }

    void ResetTimeScale(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = _defaultTimeScale;
    }
}
