using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AnimationNode
{
    public Vector3 position;
    public Quaternion rotation;
    public float size;

    public AnimationNode(Transform transform, float fragmentSize)
    {
        position = transform.position;
        rotation = transform.rotation;
        size = fragmentSize; 
    }
}
