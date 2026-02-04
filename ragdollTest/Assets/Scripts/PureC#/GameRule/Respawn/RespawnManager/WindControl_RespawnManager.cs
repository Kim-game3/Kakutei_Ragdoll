using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ì¬Ò:™R
//ƒŠƒXƒ|[ƒ“‚Ì•—‚Ìˆ—

public partial class RespawnProcess
{
    [System.Serializable]
    class WindControl
    {
        [Tooltip("–¾“]’¼Œã‚É‰½•b‘Ò‚Á‚Ä‚©‚çƒvƒŒƒCƒ„[‚ª•—‚Ì‰e‹¿‚ğó‚¯‚é‚æ‚¤‚É‚·‚é‚©")] [SerializeField]
        float _waitDurationToSwitch = 0.7f;

        [SerializeField]
        WindAffectBody _windAffectBody;

        bool _isFinished = true;//ˆ—‚ªI‚í‚Á‚½‚©

        public bool IsFinished { get { return _isFinished; } }

        public void ProcessOnFallToWater()//…‚É—‚¿‚½uŠÔ‚Ìˆ—
        {
            _windAffectBody.enabled = false;//•—‚Ì‰e‹¿‚ğó‚¯‚È‚­‚·‚é
        }

        public IEnumerator CoroutineOnFinishFadeIn()//–¾“]‚µ‚½’¼Œã‚ÉŒÄ‚Ôˆ—
        {
            _isFinished = false;

            yield return new WaitForSeconds(_waitDurationToSwitch);

            _windAffectBody.enabled = true;//•—‚Ì‰e‹¿‚ğó‚¯‚é‚æ‚¤‚É‚·‚é

            _isFinished = true;
        }
    }
}
