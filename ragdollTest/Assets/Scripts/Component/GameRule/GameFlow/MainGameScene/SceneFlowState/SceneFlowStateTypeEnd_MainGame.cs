using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//�쐬��:���R
//�V�[���̗���(���C���Q�[���V�[��)�̃Q�[���I���X�e�[�g

public class SceneFlowStateTypeEnd_MainGame : SceneFlowStateTypeBase
{
    // --- ���̃V�[���J�� --- //
    [SerializeField] SceneReference _resultScene;
    [SerializeField] JudgeGameSet _judgeGameSet;

    [CustomLabel("�V�[���J�ڂ���܂łɂ����鎞��")] [SerializeField] float _sceneChangeDuration;

    // --- �Q�[���I�����ɕ\������UI ---//
    [CustomLabel("�N���A���ɕ\������UI")] [SerializeField]
    GameObject _clearScreen;

    [SerializeField]
    ResultManager _result;//���ʂ��������ރN���X

    public override void OnEnter()
    {
        _clearScreen.SetActive(true);
        _result.ConfirmResult();//���ʊm��
        StartCoroutine(StateFinishFlow());
        _finished = false;
    }
    public override void OnUpdate() { }
    public override void OnExit()
    {
        SceneManager.LoadScene(_resultScene.ScenePath);
    }



    IEnumerator StateFinishFlow()//�Ƃ肠�������ŏ���������(��ɍ폜�\��)
    {
        yield return new WaitForSeconds(_sceneChangeDuration);

        _finished = true;
    }
}

