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

    public void SwitchState(int animationId, bool loop, float timeScale, int track, float delay, bool overrideAnimation)
    {
        if (animationId < 0 || animationId > animationStates.Count)
        {
            Debug.LogError("Animation can not be played! Animation Id is out of bounce! AnimationId=" +
                animationId + ", Animation Count:" + animationStates.Count);
        }
        else
        {
            if (overrideAnimation || currentState != animationId)
            {
                skeletonAnimation.state.AddAnimation(track, animationStates[animationId], loop, delay).TimeScale = timeScale;
            }
        }
    }
}