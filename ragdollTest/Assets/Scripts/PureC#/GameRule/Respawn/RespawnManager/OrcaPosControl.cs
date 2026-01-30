using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//シャチの場所を変更する

public partial class RespawnProcess
{
    [System.Serializable]
    class OrcaPosControl
    {
        [Tooltip("シャチの位置情報")] [SerializeField] 
        Transform _orcaTrs;

        //シャチの位置と向きを変更
        public void ChangePos(Transform spawnPos)
        {
            _orcaTrs.position = spawnPos.position;
            _orcaTrs.rotation = spawnPos.rotation;
        }
    }
}
