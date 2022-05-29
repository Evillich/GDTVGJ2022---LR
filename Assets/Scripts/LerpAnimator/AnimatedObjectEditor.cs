using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AnimatedObject))]
public class AnimatedObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AnimatedObject animated = (AnimatedObject)target;

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Relaod Current Node", GUILayout.Width(150)))
        {
            animated.ReloadCurrentNode();
        }

        if (GUILayout.Button("Previous Node", GUILayout.Width(150)))
        {
            animated.PreviousNode();
        }

        if (GUILayout.Button("Next Node", GUILayout.Width(150)))
        {
            animated.NextNode();
        }

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();

        if (GUILayout.Button("Record new Node", GUILayout.Width(150)))
        {
            animated.AddAnimationNode();
        }

        if (GUILayout.Button("Change Current Node", GUILayout.Width(150)))
        {
            animated.ChangeCurrentNode();
        }

        if (GUILayout.Button("Remove Current Node", GUILayout.Width(150)))
        {
            animated.RemoveCurrentNode();
        }

        EditorGUILayout.EndHorizontal();
    }
}