using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̃Q�[���I���X�e�[�g

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- ���̃V�[���J�� --- //
    [SerializeField] SceneReference _gameOverScene;
    [SerializeField] SceneReference _gameClearScene;
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("�V�[���J�ڂ���܂łɂ����鎞��")] [SerializeField] float _sceneChangeDuration;

    // --- �Q�[���I�����ɕ\������UI ---//
    [CustomLabel("�N���A���ɕ\������UI")] [SerializeField]
    GameObject _clearScreen;

    [CustomLabel("�Q�[���I�[�o�[���ɕ\������UI")] [SerializeField] 
    GameObject _gameOverScreen;

    public override void OnEnter()
    {
        ResultShow();
        StartCoroutine(StateFinishFlow());
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        ChangeNextScene();
    }



    IEnumerator StateFinishFlow()//�Ƃ肠�������ŏ���������(��ɍ폜�\��)
    {
        yield return new WaitForSeconds(_sceneChangeDuration);

        _finished = true;
    }

    void ResultShow()//���ʕ\��
    {
        //�N���A���Q�[���I�[�o�[�ɂ���ĕ\������UI��ύX
        bool isClear = (_judgeGameSet.GameState == EGameState.Clear);
        GameObject displayUI = isClear ? _clearScreen : _gameOverScreen;
        displayUI.SetActive(true);
    }

    void ChangeNextScene()//�V�[���J��
    {
        //�N���A���Q�[���I�[�o�[�ɂ���đJ�ڂ���V�[����ύX
        bool isClear = (_judgeGameSet.GameState == EGameState.Clear);
        string nextScenePath = isClear ? _gameClearScene.ScenePath : _gameOverScene.ScenePath;
        
        //if(isClear)
        //{
        //    SceneManager.LoadScene("ClearScene");
        //}
        //else
        //{
        //    SceneManager.LoadScene("GameOverScene");
        //}

        SceneManager.LoadScene(nextScenePath);
    }
}

