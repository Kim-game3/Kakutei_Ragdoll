using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("�e���ʂ�Rigidbody���A�^�b�`����")]
    // �l����Rigidbody�iInspector�Őݒ�j
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public Rigidbody leftLeg;
    public Rigidbody rightLeg;
    public Rigidbody head;

    [Header("�L�΂��Ƃ��̐��l")]

    [Tooltip("�L�΂��Ƃ��̑��x")]
    // ��]�␳���x
    public float rotationCorrectionSpeed = 8f;
    [Tooltip("�L�΂��Ƃ��̉�]�̕␳")]
    // �O�ɐL�΂���Ԃ̉�]�������l
    public float rotationThreshold = 1f;

    // �l�����Ƃ̐���t���O
    private bool extendLeftArm = false;
    private bool extendRightArm = false;
    private bool extendLeftLeg = false;
    private bool extendRightLeg = false;

    void Update()
    {
        // �L�[���͂Ŏl���̏�Ԃ�؂�ւ�
        extendLeftArm = Input.GetKey(KeyCode.A);  // Q�ō��r��O��
        extendRightArm = Input.GetKey(KeyCode.D); // E�ŉE�r��O��
        extendLeftLeg = Input.GetKey(KeyCode.Z);  // A�ō��r��O��
        extendRightLeg = Input.GetKey(KeyCode.X); // D�ŉE�r��O��
    }

    void FixedUpdate()
    {
        ControlLimbs();
    }

    private void ControlLimbs()
    {
        // ���r
        if (leftArm != null)
        {
            if (extendLeftArm)
            {
                ApplyForwardRotation(leftArm);
            }
        }

        // �E�r
        if (rightArm != null)
        {
            if (extendRightArm)
            {
                ApplyForwardRotation(rightArm);
            }
        }

        // ���r
        if (leftLeg != null)
        {
            if (extendLeftLeg)
            {
                ApplyForwardRotation(leftLeg);
            }
        }

        // �E�r
        if (rightLeg != null)
        {
            if (extendRightLeg)
            {
                ApplyForwardRotation(rightLeg);
            }
        }
    }

    // �O�ɂ܂������L�΂����߂̉�]��K�p
    private void ApplyForwardRotation(Rigidbody rb)
    {
        if (head == null)
        {
            Debug.LogWarning("Head Rigidbody is not assigned!");
            return;
        }

        // ���̑O���i�ڂ̑O�j�����
        Vector3 forward = head.transform.forward;
        Quaternion targetRotation = Quaternion.LookRotation(forward, Vector3.up);

        float rotationDistance = Quaternion.Angle(rb.rotation, targetRotation);
        if (rotationDistance > rotationThreshold)
        {
            Quaternion newRotation = Quaternion.Slerp(rb.rotation, targetRotation, Time.fixedDeltaTime * rotationCorrectionSpeed);
            rb.MoveRotation(newRotation);
        }
    }
}
