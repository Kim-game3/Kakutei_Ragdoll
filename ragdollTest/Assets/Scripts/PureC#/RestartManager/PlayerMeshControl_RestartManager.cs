using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//リスタート時のプレイヤーのメッシュ表示の処理

public partial class RestartManager
{
    [System.Serializable]
    class PlayerMeshControl
    {
        [Tooltip("プレイヤーのメッシュ")] [SerializeField]
        SkinnedMeshRenderer[] _playerMeshs;

        //プレイヤーの表示状態を変更
        public void ChangeMeshEnabled(bool enabled)
        {
            for(int i=0; i<_playerMeshs.Length ;i++)
            {
                _playerMeshs[i].enabled = enabled;
            }
        }
    }
}
