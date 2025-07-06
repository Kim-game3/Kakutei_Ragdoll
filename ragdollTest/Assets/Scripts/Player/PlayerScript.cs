using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("Še•”ˆÊ‚ÌRigidbody‚ðƒAƒ^ƒbƒ`‚·‚é")]
    // ŽlŽˆ‚ÌRigidbodyiInspector‚ÅÝ’èj
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public Rigidbody leftLeg;
    public Rigidbody rightLeg;
    public Rigidbody head;

    [Header("L‚Î‚·‚Æ‚«‚Ì”’l")]

    [Tooltip("L‚Î‚·‚Æ‚«‚Ì‘¬“x")]
    // ‰ñ“]•â³‘¬“x
    public float rotationCorrectionSpeed = 8f;
    [Tooltip("L‚Î‚·‚Æ‚«‚Ì‰ñ“]‚Ì•â³")]
    // ‘O‚ÉL‚Î‚·ó‘Ô‚Ì‰ñ“]‚µ‚«‚¢’l
    public float rotationThreshold = 1f;

    // ŽlŽˆ‚²‚Æ‚Ì§Œäƒtƒ‰ƒO
    private bool extendLeftArm = false;
    private bool extendRightArm = false;
    private bool extendLeftLeg = false;
    private bool extendRightLeg = false;

    void Update()
    {
        // ƒL[“ü—Í‚ÅŽlŽˆ‚Ìó‘Ô‚ðØ‚è‘Ö‚¦
        extendLeftArm = Input.GetKey(KeyCode.A);  // Q‚Å¶˜r‚ð‘O‚É
        extendRightArm = Input.GetKey(KeyCode.D); // E‚Å‰E˜r‚ð‘O‚É
        extendLeftLeg = Input.GetKey(KeyCode.Z);  // A‚Å¶‹r‚ð‘O‚É
        extendRightLeg = Input.GetKey(KeyCode.X); // D‚Å‰E‹r‚ð‘O‚É
    }

    void FixedUpdate()
    {
        ControlLimbs();
    }

    private void ControlLimbs()
    {
        // ¶˜r
        if (leftArm != null)
        {
            if (extendLeftArm)
            {
                ApplyForwardRotation(leftArm);
            }
        }

        // ‰E˜r
        if (rightArm != null)
        {
            if (extendRightArm)
            {
                ApplyForwardRotation(rightArm);
            }
        }

        // ¶‹r
        if (leftLeg != null)
        {
            if (extendLeftLeg)
            {
                ApplyForwardRotation(leftLeg);
            }
        }

        // ‰E‹r
        if (rightLeg != null)
        {
            if (extendRightLeg)
            {
                ApplyForwardRotation(rightLeg);
            }
        }
    }

    // ‘O‚É‚Ü‚Á‚·‚®L‚Î‚·‚½‚ß‚Ì‰ñ“]‚ð“K—p
    private void ApplyForwardRotation(Rigidbody rb)
    {
        if (head == null)
        {
            Debug.LogWarning("Head Rigidbody is not assigned!");
            return;
        }

        // “ª‚Ì‘O•ûi–Ú‚Ì‘Oj‚ðŠî€‚É
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
