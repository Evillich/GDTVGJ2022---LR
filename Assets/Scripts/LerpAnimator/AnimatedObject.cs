using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedObject : MonoBehaviour
{
    // This class is purely QoL feature and not required for animation, only for comfortable animation setting
    public float nodeSize = 1f;
    public AnimationMag animationMag;

    [ContextMenu("DEBUG create animationMag")]
    public void CreateAnimationMag()
    {
        animationMag = new AnimationMag();
        animationMag.animatedObject = transform;
        animationMag.nodes = new List<AnimationNode>();
    }

    //[ContextMenu("DEBUG set animationMag object to self")]
    //public void SetupAnimationMag()
    //{
    //    animationMag.animatedObject = transform;
    //}

    [ContextMenu("Record new Node")]
    public void AddAnimationNode()
    {
        animationMag.RecordNewNode(transform, nodeSize);
        index = animationMag.nodes.Count - 1;
    }

    [SerializeField] int index;

    [ContextMenu("Next Node")]
    public void NextNode()
    {
        if (index >= animationMag.nodes.Count - 1)
            return;

        index += 1;
        LoadNode();
    }

    [ContextMenu("Previous Node")]
    public void PreviousNode()
    {
        if (index <= 0)
            return;

        index -= 1;
        LoadNode();
    }

    private void LoadNode()
    {
        AnimationNode node = animationMag.nodes[index];
        transform.position = node.position;
        transform.rotation = node.rotation;
        nodeSize = node.size;
    }

    [ContextMenu("Change Current Node")]
    public void ChangeCurrentNode()
    {
        if (index < 0)
            return;
        if (index > animationMag.nodes.Count - 1)
            return;

        AnimationNode node = animationMag.nodes[index];

        node.position = transform.position;
        node.rotation = transform.rotation;
        node.size = nodeSize;

        animationMag.nodes[index] = node;
    }

    [ContextMenu("Remove Current Node")]
    public void RemoveCurrentNode()
    {
        if (index < 0)
            return;
        if (index > animationMag.nodes.Count - 1)
            return;
        if (animationMag.nodes.Count == 0)
            return;

        animationMag.nodes.RemoveAt(index);
        if (index > animationMag.nodes.Count - 1)
            index -= 1;

        LoadNode();
    }

    [ContextMenu("Relaod Current Node")]
    public void ReloadCurrentNode()
    {        
        LoadNode();
    }
}
