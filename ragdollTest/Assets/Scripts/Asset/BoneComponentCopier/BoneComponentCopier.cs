using UnityEngine;

public class BoneComponentCopier : MonoBehaviour
{
    [Header("コピー元のボーンルート")]
    public Transform sourceRoot;

    [Header("コピー先のボーンルート")]
    public Transform targetRoot;

    [Header("Transformはコピーしません")]
    public bool includeInactive = true; // 非アクティブも対象にするか
}