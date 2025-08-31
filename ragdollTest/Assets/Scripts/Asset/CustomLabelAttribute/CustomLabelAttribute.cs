/*
 * �C���X�y�N�^�ɕ\�������ϐ������D���ȕ����ɒu��������J�X�^���G�f�B�^
 * CustomLabelAttribute.cs : Ver. 1.0.3
 * Written by Takashi Sowa with ChatGPT
 * ���g�����F�ȉ��̂悤�ɋL�q����΃C���X�y�N�^�ɕ\�������uvariable�v���u�ϐ����v�ɒu�������
 * [CustomLabel("�ϐ���")]
 * public int variable = 0;//[SerializeField]�ł����p��
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

#endif

public class CustomLabelAttribute : PropertyAttribute
{
    public readonly GUIContent Label;//GUIContent�^�ɕύX
    public CustomLabelAttribute(string label)
    {
        Label = new GUIContent(label);//string����GUIContent�ɕϊ�
    }
}


#if UNITY_EDITOR
//�J�X�^���A�g���r���[�g�Ɋ֘A�Â���ꂽ�v���p�e�B�h�����[�̐錾
[CustomPropertyDrawer(typeof(CustomLabelAttribute))]
public class CustomLabelAttributeDrawer : PropertyDrawer
{
    //�G�f�B�^��ŃJ�X�^���v���p�e�B��`��
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (property == null) return;

        //�J�X�^���A�g���r���[�g��CustomLabelAttribute�Ƃ��Ď擾
        CustomLabelAttribute newLabel = attribute as CustomLabelAttribute;
        //�J�X�^���A�g���r���[�g�̃��x�����v���p�e�B�̃��x���ɐݒ�
        if (newLabel != null) label = newLabel.Label;
        //�G�f�B�^��Ƀv���p�e�B��`��
        EditorGUI.PropertyField(position, property, label, true);
    }

    //�G�f�B�^��Ńv���p�e�B�̍������擾
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        if (property == null) return 0;
        //�v���p�e�B�̍������擾
        return EditorGUI.GetPropertyHeight(property, true);
    }
}

#endif