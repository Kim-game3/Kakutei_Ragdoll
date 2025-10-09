using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoneComponentCopier))]
public class BoneComponentCopierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BoneComponentCopier copier = (BoneComponentCopier)target;

        if (GUILayout.Button("コンポーネントをコピー"))
        {
            if (copier.sourceRoot == null || copier.targetRoot == null)
            {
                Debug.LogError("sourceRoot と targetRoot の両方を設定してください。");
                return;
            }

            CopyComponents(copier.sourceRoot, copier.targetRoot, copier.includeInactive);
            Debug.Log("コンポーネントのコピーが完了しました。");
        }
    }

    private void CopyComponents(Transform source, Transform target, bool includeInactive)
    {
        // 名前で対応するボーンを探す
        foreach (Transform sourceChild in source.GetComponentsInChildren<Transform>(includeInactive))
        {
            Transform targetChild = FindChildByName(target, sourceChild.name);
            if (targetChild == null) continue;

            // Transform以外の全コンポーネントをコピー
            foreach (var comp in sourceChild.GetComponents<Component>())
            {
                if (comp is Transform) continue;

                UnityEditorInternal.ComponentUtility.CopyComponent(comp);
                UnityEditorInternal.ComponentUtility.PasteComponentAsNew(targetChild.gameObject);
            }
        }
    }

    private Transform FindChildByName(Transform root, string name)
    {
        foreach (Transform t in root.GetComponentsInChildren<Transform>(true))
        {
            if (t.name == name)
                return t;
        }
        return null;
    }
}