using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�쐬��:���R
//���͈̔�(�����蔻��@�\)
//���׌y���̂��߁A�v���C���[���g���K�[���ɓ����Ă������������̓����蔻�������悤�ɂ���
//���S��������̕����Ɍ������Ďl�p�`�^�̕�������

public class WindHitZone : MonoBehaviour
{
    [Tooltip("���̉e�����󂯂郌�C���[")] [SerializeField]
    LayerMask _affectableWindLayer;

    [Tooltip("�v���C���[�̃��C���[")] [SerializeField]
    LayerMask _playerLayer;

    [Tooltip("�v���C���[���߂Â��Ă����̂����m����@�\\n���͈͓̔��ɂ��Ȃ��ƁA�����蔻������Ȃ��̂ŏ\���ɑ傫�����邱�Ƃ������߂���")] [SerializeField]
    OnTriggerDetect _playerDetect;

    const float _boxcastSizeZ = 0.01f;
    bool _isPlayer_InWindableZone = false;//�v���C���[�����̓����蔻�������͈�(���͈̔͊O�ɂ����瓖���蔻������Ȃ�)

    public bool IsHit(out Vector3 hitPos, out bool isHitPlayer)//�����ɓ���������(�Փ˒n�_(hitPos)�ƃv���C���[�ɏՓ˂�����(isHitPlayer)��������)
    {
        hitPos = Vector3.zero;
        isHitPlayer = false;

        if (!_isPlayer_InWindableZone) return false;

        Vector3 boxcastSize = transform.localScale / 2;
        boxcastSize.z = _boxcastSizeZ;

        //��������̃��C���΂�
        if (!Physics.BoxCast(transform.position, boxcastSize, transform.forward, out RaycastHit hit, transform.rotation, transform.localScale.z, _affectableWindLayer)) return false;

        hitPos = hit.point;

        //�����ɓ�������
        if (!LayerExtension.IsInLayerMask(_playerLayer, hit.collider.gameObject)) return true;

        //���������̂��v���C���[�ł���΃v���C���[�����̕��̉e�����󂯂�悤�ɂ���
        isHitPlayer = true;
        return true;
    }

    private void Awake()
    {
        _playerDetect.OnEnter += OnEnterPlayer;
        _playerDetect.OnExit += OnExitPlayer;
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
