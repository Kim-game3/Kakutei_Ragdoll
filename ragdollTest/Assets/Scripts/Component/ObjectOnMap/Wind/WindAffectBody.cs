using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//風の影響を受ける
//風の当たり判定に使うコライダーオブジェクトにこのコンポーネントをアタッチする

public class WindAffectBody : MonoBehaviour
{
    class WindInfoAndTime
    {
        public WindInfo windInfo;
        public float time;

        public WindInfoAndTime(WindInfo windInfo,float time)
        {
            this.windInfo = windInfo;
            this.time = time;
        }
    }

    [SerializeField]
    float _affectingDuration;

    [Tooltip("動かす体の部位")] [SerializeField]//ConstantForceを使用して、風に飛ばされるのを演出する
    ConstantForce _playerBody;

    List<WindInfoAndTime> _affectingWinds=new List<WindInfoAndTime>();//影響を受けてる風リスト

    public void  AddWind(WindInfo windInfo)
    {
        foreach(var wind in _affectingWinds)
        {
            if(wind.windInfo==windInfo)//既に影響を受けている風が見つかった
            {
                wind.time = _affectingDuration;//更新
                return;
            }
        }

        //見つからなかったら新たに追加
        WindInfoAndTime newWind= new WindInfoAndTime(windInfo,_affectingDuration);
        _affectingWinds.Add(newWind);
    }

    private void OnDisable()
    {
        _affectingWinds.Clear();
        _playerBody.force = Vector3.zero;
    }

    private void Update()
    {
        //風リストを更新
        foreach (var wind in _affectingWinds)
        {
            wind.time-=Time.deltaTime;
        }

        _affectingWinds.RemoveAll(wind => wind.time<=0);


        //力を加える
        Vector3 force=Vector3.zero;

        foreach (var wind in _affectingWinds)
        {
            Vector3 addForce = wind.windInfo.ForceVec;
            force += addForce;
        }

        _playerBody.force = force;
    }
}
