using Spine.Unity;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTest : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;

    [SerializeField]
    private AnimationReferenceAsset idle;

    [SerializeField]
    private AnimationReferenceAsset death;

    private AnimationController animationController;

    public int health = 100;

    // Start is called before the first frame update
    private void Start()
    {
        List<AnimationReferenceAsset> animationStates = new List<AnimationReferenceAsset> { idle, death };

        animationController = new AnimationController(skeletonAnimation, animationStates);
    }

    // Update is called once per frame
    private void Update()
    {
        if (health > 0)
        {
            animationController.SwitchState(0, true, 1);
        }
        else
        {
            animationController.SwitchState(1, false, 1);
        }
    }
}