using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MovementAnimationController : MonoBehaviour
{
    private Animator animator;
    private MovementModel movementModel;
    public AnimationOverrideInfo animationOverrideCarry;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        movementModel = GetComponentInParent<ObjectMonoBehaviour<MovementModel>>().GetModel();
        movementModel.OnMoveUpdateEvent += SetAnimationParameters;
    }


    void OnDisable()
    {
        movementModel.OnMoveUpdateEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(object sender, EventArgs e)
    {
        if (sender is not MovementModel args) return;
        if (args.isCarrying) ApplyOverrides(animationOverrideCarry); else RemoveOverrides();

        animator.SetFloat(AnimatorParamsIds.inputX, args.inputX);
        animator.SetFloat(AnimatorParamsIds.inputY, args.inputY);
        animator.SetBool(AnimatorParamsIds.isWalking, args.isWalking);
        animator.SetBool(AnimatorParamsIds.isRunning, args.isRunning);
        animator.SetInteger(AnimatorParamsIds.toolEffect, (int)args.toolEffect);

        if (args.isUsingToolRight) animator.SetTrigger(AnimatorParamsIds.isUsingToolRight);
        if (args.isUsingToolLeft) animator.SetTrigger(AnimatorParamsIds.isUsingToolLeft);
        if (args.isUsingToolUp) animator.SetTrigger(AnimatorParamsIds.isUsingToolUp);
        if (args.isUsingToolDown) animator.SetTrigger(AnimatorParamsIds.isUsingToolDown);
        if (args.isLiftingToolRight) animator.SetTrigger(AnimatorParamsIds.isLiftingToolRight);
        if (args.isLiftingToolLeft) animator.SetTrigger(AnimatorParamsIds.isLiftingToolLeft);
        if (args.isLiftingToolUp) animator.SetTrigger(AnimatorParamsIds.isLiftingToolUp);
        if (args.isLiftingToolDown) animator.SetTrigger(AnimatorParamsIds.isLiftingToolDown);
        if (args.isPickingRight) animator.SetTrigger(AnimatorParamsIds.isPickingRight);
        if (args.isPickingLeft) animator.SetTrigger(AnimatorParamsIds.isPickingLeft);
        if (args.isPickingUp) animator.SetTrigger(AnimatorParamsIds.isPickingUp);
        if (args.isPickingDown) animator.SetTrigger(AnimatorParamsIds.isPickingDown);
        if (args.isSwingingToolRight) animator.SetTrigger(AnimatorParamsIds.isSwingingToolRight);
        if (args.isSwingingToolLeft) animator.SetTrigger(AnimatorParamsIds.isSwingingToolLeft);
        if (args.isSwingingToolUp) animator.SetTrigger(AnimatorParamsIds.isSwingingToolUp);
        if (args.isSwingingToolDown) animator.SetTrigger(AnimatorParamsIds.isSwingingToolDown);
        if (args.idleUp) animator.SetTrigger(AnimatorParamsIds.idleUp);
        if (args.idleDown) animator.SetTrigger(AnimatorParamsIds.idleDown);
        if (args.idleLeft) animator.SetTrigger(AnimatorParamsIds.idleLeft);
        if (args.idleRight) animator.SetTrigger(AnimatorParamsIds.idleRight);
    }

    private void ApplyOverrides(AnimationOverrideInfo animationOverrideInfo)
    {
        if (animationOverrideInfo == null) return;
        var overrideController = new AnimatorOverrideController(animator.runtimeAnimatorController);
        overrideController.ApplyOverrides(animationOverrideInfo.GetKeyValuePairs());
        animator.runtimeAnimatorController = overrideController;
    }

    private void RemoveOverrides()
    {
        animator.runtimeAnimatorController = new AnimatorOverrideController(animator.runtimeAnimatorController);
    }

    private void AnimationEventPlayFootstepSound()
    {

    }

    private static class AnimatorParamsIds
    {
        public static int inputX = Animator.StringToHash("xInput");
        public static int inputY = Animator.StringToHash("yInput");
        public static int isWalking = Animator.StringToHash("isWalking");
        public static int isRunning = Animator.StringToHash("isRunning");
        public static int toolEffect = Animator.StringToHash("toolEffect");
        public static int isUsingToolRight = Animator.StringToHash("isUsingToolRight");
        public static int isUsingToolLeft = Animator.StringToHash("isUsingToolLeft");
        public static int isUsingToolUp = Animator.StringToHash("isUsingToolUp");
        public static int isUsingToolDown = Animator.StringToHash("isUsingToolDown");
        public static int isLiftingToolRight = Animator.StringToHash("isLiftingToolRight");
        public static int isLiftingToolLeft = Animator.StringToHash("isLiftingToolLeft");
        public static int isLiftingToolUp = Animator.StringToHash("isLiftingToolUp");
        public static int isLiftingToolDown = Animator.StringToHash("isLiftingToolDown");
        public static int isPickingRight = Animator.StringToHash("isPickingRight");
        public static int isPickingLeft = Animator.StringToHash("isPickingLeft");
        public static int isPickingUp = Animator.StringToHash("isPickingUp");
        public static int isPickingDown = Animator.StringToHash("isPickingDown");
        public static int isSwingingToolRight = Animator.StringToHash("isSwingingToolRight");
        public static int isSwingingToolLeft = Animator.StringToHash("isSwingingToolLeft");
        public static int isSwingingToolUp = Animator.StringToHash("isSwingingToolUp");
        public static int isSwingingToolDown = Animator.StringToHash("isSwingingToolDown");
        public static int idleUp = Animator.StringToHash("idleUp");
        public static int idleDown = Animator.StringToHash("idleDown");
        public static int idleLeft = Animator.StringToHash("idleLeft");
        public static int idleRight = Animator.StringToHash("idleRight");
    }
}
