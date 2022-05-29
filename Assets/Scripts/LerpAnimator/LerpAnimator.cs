using System;
using System.Collections.Generic;
using UnityEngine;

namespace LerpAnimator
{
    public class LerpAnimator : MonoBehaviour
    {
        [Header("Setup")] [SerializeField] private GameObject objectForAnimation;
        [SerializeField] private List<AnimationMag> animationMags;
        [SerializeField] private AnimationMag loadedMag;
        public Action OnAnimationFinish;
        [SerializeField][Range(0,1f)]
        private float progress;
        private float progressScale;

        [SerializeField] bool inProgress;

        private void Awake()
        {
            PreCache();
        }

        private void PreCache()
        {
            foreach (var mag in animationMags)
            {
                mag.CashDurationScale();
            }
        }

        public void AddAnimatedObject()
        {
            var currentAnimatedObject = objectForAnimation.AddComponent<AnimatedObject>();
            currentAnimatedObject.animationMag = new AnimationMag();
            currentAnimatedObject.animationMag.nodes = new List<AnimationNode>();
            currentAnimatedObject.animationMag.animatedObject = objectForAnimation.transform;
            animationMags.Add(currentAnimatedObject.animationMag);
        }
        
        public void RunAnimationById(int id)
        {            
            if (inProgress)
            {
                Debug.Log("Another animation in progress");
                return;
            }
            //
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

            progress = 0f;
            inProgress = true;
            loadedMag = animationMags[id];
            progressScale = loadedMag.durationScale;
        }

        private void Update()
        {
            ProcessAnimation();            
        }

        private void ProcessAnimation()
        {
            if (!inProgress)
                return;
            progress += Time.deltaTime * progressScale;
            if (progress >= 1f)
            {
                progress = 1f;
                inProgress = false;
            }

            var animatedObject = loadedMag.animatedObject;
            MagProgress magProgress = GetLocalProgress(loadedMag, progress);
            Debug.Log($"loadedMag = {loadedMag}; progress = {progress}; nodeIndex = {magProgress.nodeIndex}; nodeProgress = {magProgress.nodeProgress}; loadedMag.nodes.Count = {loadedMag.nodes.Count} ");



            animatedObject.localPosition = Vector3.Lerp(loadedMag.nodes[magProgress.nodeIndex].position, loadedMag.nodes[magProgress.nodeIndex + 1].position, magProgress.nodeProgress);
            animatedObject.localRotation = Quaternion.Slerp(loadedMag.nodes[magProgress.nodeIndex].rotation, loadedMag.nodes[magProgress.nodeIndex + 1].rotation, magProgress.nodeProgress);

            if (inProgress)
                return;
            loadedMag = null;
            OnAnimationFinish?.Invoke();
        }

        
        struct MagProgress
        {
            public int nodeIndex;
            public float nodeProgress;

            public MagProgress(int index, float progress)
            {
                nodeIndex = index;
                nodeProgress = progress;                
            }
        }
        
        private MagProgress GetLocalProgress(AnimationMag actionMag, float globalProgress)
        {
            int index = 0;
            float progress = 0f;


            float nextProgress = 0f;
            float lastProgress = 0f;
            float nodeScaledSize = 0f;
            foreach (var node in actionMag.nodes)
            {
                nodeScaledSize = node.size * actionMag.nodesDurationScale;
                nextProgress += nodeScaledSize;
                if (nextProgress >= globalProgress)
                    break;

                lastProgress = nextProgress;
                index += 1;
            }

            progress = (globalProgress - lastProgress) / nodeScaledSize;

            return new MagProgress(index, progress);
        }
    }
}