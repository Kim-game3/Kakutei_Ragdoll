using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̃Q�[���I���X�e�[�g

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- ���̃V�[���J�� --- //
    [SerializeField] SceneReference _gameClearScene;
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("�V�[���J�ڂ���܂łɂ����鎞��")] [SerializeField] float _sceneChangeDuration;

    // --- �Q�[���I�����ɕ\������UI ---//
    [CustomLabel("�N���A���ɕ\������UI")] [SerializeField]
    GameObject _clearScreen;

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
        _clearScreen.SetActive(true);
    }

    void ChangeNextScene()//�V�[���J��
    {
        //�N���A���Q�[���I�[�o�[�ɂ���đJ�ڂ���V�[����ύX
        SceneManager.LoadScene(_gameClearScene.ScenePath);
    }
}

