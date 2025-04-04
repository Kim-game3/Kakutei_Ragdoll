using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    [Header("各部位のRigidbodyをアタッチする")]
    // 四肢のRigidbody（Inspectorで設定）
    public Rigidbody leftArm;
    public Rigidbody rightArm;
    public Rigidbody leftLeg;
    public Rigidbody rightLeg;
    public Rigidbody head;

    [Header("伸ばすときの数値")]

    [Tooltip("伸ばすときの速度")]
    // 回転補正速度
    public float rotationCorrectionSpeed = 8f;
    [Tooltip("伸ばすときの回転の補正")]
    // 前に伸ばす状態の回転しきい値
    public float rotationThreshold = 1f;

    // 四肢ごとの制御フラグ
    private bool extendLeftArm = false;
    private bool extendRightArm = false;
    private bool extendLeftLeg = false;
    private bool extendRightLeg = false;

    void Update()
    {
        // キー入力で四肢の状態を切り替え
        extendLeftArm = Input.GetKey(KeyCode.A);  // Qで左腕を前に
        extendRightArm = Input.GetKey(KeyCode.D); // Eで右腕を前に
        extendLeftLeg = Input.GetKey(KeyCode.Z);  // Aで左脚を前に
        extendRightLeg = Input.GetKey(KeyCode.X); // Dで右脚を前に
    }

    void FixedUpdate()
    {
        ControlLimbs();
    }

    private void ControlLimbs()
    {
        // 左腕
        if (leftArm != null)
        {
            if (extendLeftArm)
            {
                ApplyForwardRotation(leftArm);
            }
        }

        // 右腕
        if (rightArm != null)
        {
            if (extendRightArm)
            {
                ApplyForwardRotation(rightArm);
            }
        }

        // 左脚
        if (leftLeg != null)
        {
            if (extendLeftLeg)
            {
                ApplyForwardRotation(leftLeg);
            }
        }

        // 右脚
        if (rightLeg != null)
        {
            if (extendRightLeg)
            {
                ApplyForwardRotation(rightLeg);
            }
        }
    }

    // 前にまっすぐ伸ばすための回転を適用
    private void ApplyForwardRotation(Rigidbody rb)
    {
        if (head == null)
        {
            Debug.LogWarning("Head Rigidbody is not assigned!");
            return;
        }

        // 頭の前方（目の前）を基準に
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
