using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AnimationMag : ScriptableObject
{
    public Transform animatedObject;
    public List<AnimationNode> nodes;
    public float duration;
    public float durationScale;

    public float nodesDurationScale;

    private float nodeSize = 1f;

    public void RecordNewNode()
    {
        nodes?.Add(new AnimationNode(animatedObject, nodeSize));
    }
    public void RecordNewNode(Transform animatedObj, float size)
    {
        nodes?.Add(new AnimationNode(animatedObj, size));
    }

    public void CashDurationScale()
    {
        if (nodes == null)
            return;

        foreach (var node in nodes)
        {
            nodesDurationScale += node.size;
        }

        nodesDurationScale = duration / nodesDurationScale;
        durationScale = 1f / duration;
    }
}
