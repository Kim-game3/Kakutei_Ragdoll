using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//ゲームの流れ

public class MainGameFlow : MonoBehaviour
{
    [Tooltip("シーン遷移直後にゲームを開始するか")] [SerializeField]
    bool _playOnAwake;


    public void StartGame()//ゲーム開始
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
        Debug.Log("ゲーム開始フェーズ");
        Debug.Log("ゲームフェーズ");
        Debug.Log("ゲーム終了フェーズ");


        yield return null;
    }
}
