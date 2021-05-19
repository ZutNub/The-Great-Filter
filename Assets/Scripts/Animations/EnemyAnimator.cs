using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;

    [SerializeField]
    private AnimationReferenceAsset idle;

    [SerializeField]
    private AnimationReferenceAsset death;

    private AnimationController animationController;

    // Start is called before the first frame update
    public void Init()
    {
        List<AnimationReferenceAsset> animationStates = new List<AnimationReferenceAsset> { idle, death };

        animationController = new AnimationController(skeletonAnimation, animationStates);
    }

    public void PlayIdleAnimation()
    {
        animationController.SwitchState(0, true, 1, 0, 0, false);
    }

    public void PlayDeathAnimation()
    {
        animationController.SwitchState(1, false, 1, 0, 0, false);
    }
}