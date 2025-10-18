using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

//�쐬��:���R
//���͈̔�(�����蔻��@�\)
//���׌y���̂��߁A�v���C���[���g���K�[���ɓ����Ă������������̓����蔻�������悤�ɂ���
//���S��������̕����Ɍ������Ďl�p�`�^�̕�������

public class WindHitZone : MonoBehaviour
{
    [Tooltip("�v���C���[���߂Â��Ă����̂����m����@�\\n���͈͓̔��ɂ��Ȃ��ƁA�����蔻������Ȃ��̂ŏ\���ɑ傫�����邱�Ƃ������߂���")] [SerializeField]
    OnTriggerDetect _playerDetect;

    [SerializeField]
    WindCastHit _windCastHit;

    bool _isPlayer_InWindableZone = false;//�v���C���[�����̓����蔻�������͈�(���͈̔͊O�ɂ����瓖���蔻������Ȃ�)

    public void IsHit(out bool isHitPlayer, out RaycastHit[] hits)//�v���C���[�ɏՓ˂�����(isHitPlayer)�A���������R���C�_�[(hits)
    {
        isHitPlayer = false;
        hits = null;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out isHitPlayer, out hits);//���C���΂�
    }

    public void IsHit(out RaycastHit[] hits)//���������R���C�_�[(hits)
    {
        hits = null;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out bool isHitPlayer, out hits);//���C���΂�
    }

    public void IsHit(out bool isHitPlayer)//�v���C���[�ɏՓ˂�����(isHitPlayer)
    {
        isHitPlayer = false;

        if (!_isPlayer_InWindableZone) return;

        _windCastHit.IsHit(out isHitPlayer, out RaycastHit[] hits);//���C���΂�
    }



    //private
    private void Awake()
    {
        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;

        _windCastHit.Awake(transform);
    }

    void OnEnterPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isPlayer_InWindableZone = true;
    }

    void OnExitPlayer(Collider other)
    {
        if (!other.CompareTag(ObjectTagNameDictionary.Player)) return;

        _isPlayer_InWindableZone = false;
    }
}
