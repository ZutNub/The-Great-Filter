using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController
{
    private readonly SkeletonAnimation skeletonAnimation;

    private readonly List<AnimationReferenceAsset> animationStates;

    private int currentState;

    public AnimationController(SkeletonAnimation skeletonAnimation, List<AnimationReferenceAsset> animationStates)
    {
        this.skeletonAnimation = skeletonAnimation;
        this.animationStates = animationStates;
    }

    public void SwitchState(int animationId, bool loop, float timeScale, int track)
    {
        if (animationId < 0 || animationId > animationStates.Count)
        {
            Debug.LogError("Animation can not be played! Animation Id is out of bounce! AnimationId=" + 
                animationId + ", Animation Count:" + animationStates.Count);
        }
        else
        {
            if (animationId != currentState)
            {
                skeletonAnimation.state.SetAnimation(track, animationStates[animationId], loop).TimeScale = timeScale;
                currentState = animationId;
            }
        }
    }
}