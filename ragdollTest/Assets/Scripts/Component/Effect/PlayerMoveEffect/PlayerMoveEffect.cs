using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//�v���C���[�����������ɉ�����悤�ɂ���

public class PlayerMoveEffect : MonoBehaviour
{
    [Tooltip("�������̌��ʉ�")] [SerializeField]
    AudioClip[] _moveSEs;

    [Tooltip("���ʉ���炵�����̃N�[���^�C��\n�A�ł��Ă������肷���Ȃ��悤�ɂ��邱�Ƃ��o����")] 
    
    [SerializeField] float _minCoolTime;
    [SerializeField] float _maxCoolTime;

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

        //�炷���������_���Ɍ���
        AudioClip clip = _moveSEs[MathfExtension.RandomRange(0, _moveSEs.Length)];

        _audioSource.PlayOneShot(clip);
        StartCoroutine(PlaySoundCoolTime());
    }

    IEnumerator PlaySoundCoolTime()
    {
        _ableToPlay = false;
        yield return new WaitForSecondsRealtime(MathfExtension.RandomRange(_minCoolTime,_maxCoolTime));
        _ableToPlay = true;
    }
}
