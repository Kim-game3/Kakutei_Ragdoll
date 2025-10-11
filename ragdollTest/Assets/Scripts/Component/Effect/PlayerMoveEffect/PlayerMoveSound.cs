using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//作成者:杉山
//プレイヤーが動いた時に音が鳴るようにする

public class PlayerMoveEffect : MonoBehaviour
{
    [Tooltip("動く時の効果音")] [SerializeField]
    AudioClip _moveSE;

    [Tooltip("効果音を鳴らした時のクールタイム\n連打しても音が鳴りすぎないようにすることが出来る")] [SerializeField]
    float _coolTime;

    [SerializeField]
    AudioSource _audioSource;

    [SerializeField]
    Move_ForceBody _move_ForceBody;

    bool _ableToPlay = true;

    private void Awake()
    {
        _move_ForceBody.OnMove += PlaySound;
    }

    void PlaySound()
    {
        if (!_ableToPlay) return;

        _audioSource.PlayOneShot(_moveSE);
        StartCoroutine(PlaySoundCoolTime());
    }

    IEnumerator PlaySoundCoolTime()
    {
        _ableToPlay = false;
        yield return new WaitForSecondsRealtime(_coolTime);
        _ableToPlay = true;
    }
}
