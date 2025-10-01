/*
 * インスペクタに表示される変数名を好きな文字に置き換えるカスタムエディタ
 * CustomLabelAttribute.cs : Ver. 1.0.3
 * Written by Takashi Sowa with ChatGPT
 * ▼使い方：以下のように記述すればインスペクタに表示される「variable」が「変数名」に置き換わる
 * [CustomLabel("変数名")]
 * public int variable = 0;//[SerializeField]でも利用可
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
            // 無効な場合は空ラベルで 1 行描画しておく
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