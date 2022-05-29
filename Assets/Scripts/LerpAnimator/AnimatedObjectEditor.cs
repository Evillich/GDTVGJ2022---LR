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
        if (GUILayout.Button("Record new Node"))
        {
            animated.AddAnimationNode();
        }

        if (GUILayout.Button("Next Node"))
        {
            animated.NextNode();
        }

        if (GUILayout.Button("Previous Node"))
        {
            animated.PreviousNode();
        }

        if (GUILayout.Button("Change Current Node"))
        {
            animated.ChangeCurrentNode();
        }

        if (GUILayout.Button("Remove Current Node"))
        {
            animated.RemoveCurrentNode();
        }

        if (GUILayout.Button("Relaod Current Node"))
        {
            animated.ReloadCurrentNode();
        }
    }
}