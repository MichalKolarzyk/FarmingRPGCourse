using UnityEngine;

public class MovementAnimationParaterControll : MonoBehaviour
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    void OnDisable()
    {
        EventHandler.MovementEvent -= SetAnimationParameters;
    }

    private void SetAnimationParameters(MovementEventArgs args)
    {
        if(args == null) return;
        animator.SetFloat(Settings.PlayerAnimationParameters.inputX, args.inputX);
        animator.SetFloat(Settings.PlayerAnimationParameters.inputY, args.inputY);
        animator.SetBool(Settings.PlayerAnimationParameters.isWalking, args.isWalking);
        animator.SetBool(Settings.PlayerAnimationParameters.isRunning, args.isRunning);
        animator.SetInteger(Settings.PlayerAnimationParameters.toolEffect, (int)args.toolEffect);

        if (args.isUsingToolRight) animator.SetTrigger(Settings.PlayerAnimationParameters.isUsingToolRight);
        if (args.isUsingToolLeft) animator.SetTrigger(Settings.PlayerAnimationParameters.isUsingToolLeft);
        if (args.isUsingToolUp) animator.SetTrigger(Settings.PlayerAnimationParameters.isUsingToolUp);
        if (args.isUsingToolDown) animator.SetTrigger(Settings.PlayerAnimationParameters.isUsingToolDown);
        if (args.isLiftingToolRight) animator.SetTrigger(Settings.PlayerAnimationParameters.isLiftingToolRight);
        if (args.isLiftingToolLeft) animator.SetTrigger(Settings.PlayerAnimationParameters.isLiftingToolLeft);
        if (args.isLiftingToolUp) animator.SetTrigger(Settings.PlayerAnimationParameters.isLiftingToolUp);
        if (args.isLiftingToolDown) animator.SetTrigger(Settings.PlayerAnimationParameters.isLiftingToolDown);
        if (args.isPickingRight) animator.SetTrigger(Settings.PlayerAnimationParameters.isPickingRight);
        if (args.isPickingLeft) animator.SetTrigger(Settings.PlayerAnimationParameters.isPickingLeft);
        if (args.isPickingUp) animator.SetTrigger(Settings.PlayerAnimationParameters.isPickingUp);
        if (args.isPickingDown) animator.SetTrigger(Settings.PlayerAnimationParameters.isPickingDown);
        if (args.isSwingingToolRight) animator.SetTrigger(Settings.PlayerAnimationParameters.isSwingingToolRight);
        if (args.isSwingingToolLeft) animator.SetTrigger(Settings.PlayerAnimationParameters.isSwingingToolLeft);
        if (args.isSwingingToolUp) animator.SetTrigger(Settings.PlayerAnimationParameters.isSwingingToolUp);
        if (args.isSwingingToolDown) animator.SetTrigger(Settings.PlayerAnimationParameters.isSwingingToolDown);

        if (args.idleUp) animator.SetTrigger(Settings.SharedAnimationParameters.idleUp);
        if (args.idleDown) animator.SetTrigger(Settings.SharedAnimationParameters.idleDown);
        if (args.idleLeft) animator.SetTrigger(Settings.SharedAnimationParameters.idleLeft);
        if (args.idleRight) animator.SetTrigger(Settings.SharedAnimationParameters.idleRight);
    }

    private void AnimationEventPlayFootstepSound()
    {

    }

}
