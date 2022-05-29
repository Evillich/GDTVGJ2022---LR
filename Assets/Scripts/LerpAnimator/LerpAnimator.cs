using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace LerpAnimator
{
    public class LerpAnimator : MonoBehaviour
    {
        [Header("Setup")] [SerializeField] private GameObject objectForAnimation;
        [SerializeField] private AnimatedObject currentAnimatedObject;
        [SerializeField] private List<AnimationMag> animationMags;

        private Dictionary<AnimationMag, float> progress;

        private void Awake()
        {
            progress = new Dictionary<AnimationMag, float>();
        }

        public void AddAnimatedObject()
        {
            currentAnimatedObject = objectForAnimation.AddComponent<AnimatedObject>();
            currentAnimatedObject.animationMag.animatedObject = objectForAnimation.transform;
            animationMags.Add(currentAnimatedObject.animationMag);
        }
        
        public void RunAnimationById(int id)
        {
            if (animationMags.Count == 0)
            {
                Debug.LogError("Mag list is empty");
                return;
            }

            if (id < 0 || id > animationMags.Count - 1)
            {
                Debug.LogError("Mag with this id does not exist");
                return;
            }
            
            if(animationMags.Count <2 ) return;
            var currentMag = animationMags[id];
            progress.Add(currentMag, 0f);
        }

        private void SetProcessAnimation(float value)
        {
            
        }

        private void Update()
        {
            ProcessAnimation();
        }

        private void ProcessAnimation()
        {
            if(progress.Count==0) return;
            foreach (var p in progress)
            {
                var animatedObject = p.Key.animatedObject;
                var actionMag = p.Key;
                
                //animatedObject.position = Vector3.Lerp(animatedObject.position, m_WagonPosition[numberSegment].position, localProgress);
                //animatedObject.rotation = Quaternion.Slerp(m_WagonPosition[numberSegment - 1].rotation, m_WagonPosition[numberSegment].rotation, localProgress);
            }
            
        }

        private int GetNodeId()
        {
            return 0;
        }
        
        private float GetLocalProgress(float globalProgress, AnimationMag actionMag, int nodeId)
        {
            return 0f;
        }
    }
}