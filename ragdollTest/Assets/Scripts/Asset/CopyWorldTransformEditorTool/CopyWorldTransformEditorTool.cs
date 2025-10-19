using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CopyWorldTransformEditorTool : MonoBehaviour
{
    [Header("コピー元オブジェクト群")]
    public Transform[] sources;

    [Header("コピー先オブジェクト群")]
    public Transform[] targets;

#if UNITY_EDITOR
    [ContextMenu("コピー実行")]
    public void CopyAllTransforms()
    {
        if (sources == null || targets == null)
        {
            Debug.LogWarning("sources または targets が設定されていません。");
            return;
        }

        int count = Mathf.Min(sources.Length, targets.Length);
        for (int i = 0; i < count; i++)
        {
            var src = sources[i];
            var dst = targets[i];

            if (src == null || dst == null)
                continue;

            Undo.RecordObject(dst, "Copy World Transform");

            dst.position = src.position;
            dst.rotation = src.rotation;
            dst.localScale = src.lossyScale;

            EditorUtility.SetDirty(dst);
        }

        Debug.Log($"Copied {count} transforms successfully!");
    }
#endif
}