/*
 * �C���X�y�N�^�ɕ\�������ϐ������D���ȕ����ɒu��������J�X�^���G�f�B�^
 * CustomLabelAttribute.cs : Ver. 1.0.3
 * Written by Takashi Sowa with ChatGPT
 * ���g�����F�ȉ��̂悤�ɋL�q����΃C���X�y�N�^�ɕ\�������uvariable�v���u�ϐ����v�ɒu�������
 * [CustomLabel("�ϐ���")]
 * public int variable = 0;//[SerializeField]�ł����p��
*/

using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class CustomLabelAttribute : PropertyAttribute
{
    public readonly GUIContent Label;
    public CustomLabelAttribute(string label)
    {
        Label = new GUIContent(label);
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(CustomLabelAttribute))]
public class CustomLabelAttributeDrawer : PropertyDrawer
{

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        try
        {
            if (!IsValid(property))
            {
                // �����ȏꍇ�͋󃉃x���� 1 �s�`�悵�Ă���
                EditorGUI.LabelField(position, label);
                return;
            }

            CustomLabelAttribute newLabel = attribute as CustomLabelAttribute;
            if (newLabel != null) label = newLabel.Label;

            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndProperty();
        }
        catch
        {
            Debug.Log("�j��");
        }
        
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        try
        {
            if (!IsValid(property))
            {
                return EditorGUIUtility.singleLineHeight;
            }

            return EditorGUI.GetPropertyHeight(property, true);
        }
        catch
        {
            Debug.Log("�j��");
            return EditorGUIUtility.singleLineHeight;
        }
    }

    bool IsValid(SerializedProperty property)
    {
        // targetObject��UnityEngine.Object�Ȃ�AUnity���L��null������g��
        var targetObj = property?.serializedObject?.targetObject;
        return !SceneChangeWatcher.isChangingScene
            && property != null
            && property.serializedObject != null
            && targetObj != null
            && !(targetObj is UnityEngine.Object unityObj && !unityObj);
    }
}
#endif