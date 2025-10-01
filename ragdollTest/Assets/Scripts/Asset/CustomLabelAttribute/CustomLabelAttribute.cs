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
        if (SceneChangeWatcher.isChangingScene||property == null || property.serializedObject == null || property.serializedObject.targetObject == null)
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

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (SceneChangeWatcher.isChangingScene||property == null || property.serializedObject == null || property.serializedObject.targetObject == null)
        {
            return EditorGUIUtility.singleLineHeight;
        }

        return EditorGUI.GetPropertyHeight(property, true);
    }
}
#endif