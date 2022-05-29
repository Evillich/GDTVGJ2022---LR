using UnityEditor;
using UnityEngine;

namespace LerpAnimator
{
    [CustomEditor(typeof(LerpAnimator))]
    public class LerpAnimatorEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            LerpAnimator animator = (LerpAnimator)target;
            if (GUILayout.Button("Add AnimatedObject on gameobject"))
            {
                animator.AddAnimatedObject();
            }
        }
    }
}
