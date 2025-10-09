using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BoneComponentCopier))]
public class BoneComponentCopierEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        BoneComponentCopier copier = (BoneComponentCopier)target;

        if (GUILayout.Button("�R���|�[�l���g���R�s�["))
        {
            if (copier.sourceRoot == null || copier.targetRoot == null)
            {
                Debug.LogError("sourceRoot �� targetRoot �̗�����ݒ肵�Ă��������B");
                return;
            }

            CopyComponents(copier.sourceRoot, copier.targetRoot, copier.includeInactive);
            Debug.Log("�R���|�[�l���g�̃R�s�[���������܂����B");
        }
    }

    private void CopyComponents(Transform source, Transform target, bool includeInactive)
    {
        // ���O�őΉ�����{�[����T��
        foreach (Transform sourceChild in source.GetComponentsInChildren<Transform>(includeInactive))
        {
            Transform targetChild = FindChildByName(target, sourceChild.name);
            if (targetChild == null) continue;

            // Transform�ȊO�̑S�R���|�[�l���g���R�s�[
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