using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

//作成者:杉山
//シーンの流れ(リザルトシーン)のムービーステート
//スキップも出来るようにする

public class SceneFlowStateTypeMovie_Result : SceneFlowStateTypeBase
{
    [SerializeField]
    HideUITypeBase[] _hideUIs;

    [SerializeField] float _delayTime;

    public override void OnEnter()
    {
        HideUIs();
        _finished = false;
        StartCoroutine(Wait());//とりあえずは数秒遅延させてから終わらせる
    }

    public override void OnUpdate() 
    {
    
    }

    public override void OnExit()
    {
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(_delayTime);

        _finished = true;
    }

    void HideUIs()
    {
        for(int i=0; i<_hideUIs.Length ;i++)
        {
            _hideUIs[i].Hide();
        }
    }
}
