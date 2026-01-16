using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーに風の影響を与える機能を取得し、確実に渡せるようにする

public partial class Wind
{
    [System.Serializable]
    class GetWindAffectBody
    {
        [Tooltip("プレイヤーに風の影響を与える機能")] [SerializeField]
        WindAffectBody _playerWindAffect;

        public WindAffectBody PlayerWindAffect { get { return _playerWindAffect; } }

        public void Get()
        {
            if (_playerWindAffect != null) return;

            GameObject windAffect = GameObject.FindWithTag(ObjectTagNameDictionary.WindAffect);

            if (windAffect == null) return;

            WindAffectBody get = windAffect.GetComponent<WindAffectBody>();

            if (get == null) return;

            _playerWindAffect = get;
        }
    }
}
