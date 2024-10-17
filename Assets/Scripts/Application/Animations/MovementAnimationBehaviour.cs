using System;
using UnityEngine;

public class MovementAnimationController : MonoBehaviour
{
    private Animator animator;
    private Context<Movement> movementContext;
    public AnimationOverrideInfo animationOverrideCarry;
    void Awake()
    {
        animator = GetComponent<Animator>();
        movementContext = GetComponentInParent<Context<Movement>>();
    }

    void OnEnable()
    {
        movementContext.Subscribe<Movement.OnUpdate>(SetAnimationParameters);
        movementContext.Subscribe<Movement.OnIsCarryingItemChangeEvent>(OverrideIsCarringAnimation);
    }


    void OnDisable()
    {
        movementContext.Unsubscribe<Movement.OnUpdate>(SetAnimationParameters);
        movementContext.Unsubscribe<Movement.OnIsCarryingItemChangeEvent>(OverrideIsCarringAnimation);
    }

    private void SetAnimationParameters(Movement.OnUpdate domainEvent)
    {
        var movement = domainEvent.movement;
        if (movement.isCarrying) ApplyOverrides(animationOverrideCarry); else RemoveOverrides();

        animator.SetFloat(AnimatorParamsIds.inputX, movement.inputX);
        animator.SetFloat(AnimatorParamsIds.inputY, movement.inputY);
        animator.SetBool(AnimatorParamsIds.isWalking, movement.isWalking);
        animator.SetBool(AnimatorParamsIds.isRunning, movement.isRunning);
        animator.SetInteger(AnimatorParamsIds.toolEffect, (int)movement.toolEffect);

        if (movement.isUsingToolRight) animator.SetTrigger(AnimatorParamsIds.isUsingToolRight);
        if (movement.isUsingToolLeft) animator.SetTrigger(AnimatorParamsIds.isUsingToolLeft);
        if (movement.isUsingToolUp) animator.SetTrigger(AnimatorParamsIds.isUsingToolUp);
        if (movement.isUsingToolDown) animator.SetTrigger(AnimatorParamsIds.isUsingToolDown);
        if (movement.isLiftingToolRight) animator.SetTrigger(AnimatorParamsIds.isLiftingToolRight);
        if (movement.isLiftingToolLeft) animator.SetTrigger(AnimatorParamsIds.isLiftingToolLeft);
        if (movement.isLiftingToolUp) animator.SetTrigger(AnimatorParamsIds.isLiftingToolUp);
        if (movement.isLiftingToolDown) animator.SetTrigger(AnimatorParamsIds.isLiftingToolDown);
        if (movement.isPickingRight) animator.SetTrigger(AnimatorParamsIds.isPickingRight);
        if (movement.isPickingLeft) animator.SetTrigger(AnimatorParamsIds.isPickingLeft);
        if (movement.isPickingUp) animator.SetTrigger(AnimatorParamsIds.isPickingUp);
        if (movement.isPickingDown) animator.SetTrigger(AnimatorParamsIds.isPickingDown);
        if (movement.isSwingingToolRight) animator.SetTrigger(AnimatorParamsIds.isSwingingToolRight);
        if (movement.isSwingingToolLeft) animator.SetTrigger(AnimatorParamsIds.isSwingingToolLeft);
        if (movement.isSwingingToolUp) animator.SetTrigger(AnimatorParamsIds.isSwingingToolUp);
        if (movement.isSwingingToolDown) animator.SetTrigger(AnimatorParamsIds.isSwingingToolDown);
        if (movement.idleUp) animator.SetTrigger(AnimatorParamsIds.idleUp);
        if (movement.idleDown) animator.SetTrigger(AnimatorParamsIds.idleDown);
        if (movement.idleLeft) animator.SetTrigger(AnimatorParamsIds.idleLeft);
        if (movement.idleRight) animator.SetTrigger(AnimatorParamsIds.idleRight);
    }

    private void OverrideIsCarringAnimation(Movement.OnIsCarryingItemChangeEvent domainEvent)
    {
        if (domainEvent.isCarrying)
            ApplyOverrides(animationOverrideCarry);
        else
            RemoveOverrides();
    }

    private void ApplyOverrides(AnimationOverrideInfo animationOverrideInfo = null)
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
