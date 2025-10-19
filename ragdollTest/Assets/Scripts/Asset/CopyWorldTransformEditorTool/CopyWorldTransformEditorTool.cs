using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class CopyWorldTransformEditorTool : MonoBehaviour
{
    [Header("�R�s�[���I�u�W�F�N�g�Q")]
    public Transform[] sources;

    [Header("�R�s�[��I�u�W�F�N�g�Q")]
    public Transform[] targets;

#if UNITY_EDITOR
    [ContextMenu("�R�s�[���s")]
    public void CopyAllTransforms()
    {
        if (sources == null || targets == null)
        {
            Debug.LogWarning("sources �܂��� targets ���ݒ肳��Ă��܂���B");
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