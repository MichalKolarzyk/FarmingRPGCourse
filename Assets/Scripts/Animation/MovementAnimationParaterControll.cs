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
        if (args == null) return;
        animator.SetFloat(AnimatorParams.inputX, args.inputX);
        animator.SetFloat(AnimatorParams.inputY, args.inputY);
        animator.SetBool(AnimatorParams.isWalking, args.isWalking);
        animator.SetBool(AnimatorParams.isRunning, args.isRunning);
        animator.SetInteger(AnimatorParams.toolEffect, (int)args.toolEffect);

        if (args.isUsingToolRight) animator.SetTrigger(AnimatorParams.isUsingToolRight);
        if (args.isUsingToolLeft) animator.SetTrigger(AnimatorParams.isUsingToolLeft);
        if (args.isUsingToolUp) animator.SetTrigger(AnimatorParams.isUsingToolUp);
        if (args.isUsingToolDown) animator.SetTrigger(AnimatorParams.isUsingToolDown);
        if (args.isLiftingToolRight) animator.SetTrigger(AnimatorParams.isLiftingToolRight);
        if (args.isLiftingToolLeft) animator.SetTrigger(AnimatorParams.isLiftingToolLeft);
        if (args.isLiftingToolUp) animator.SetTrigger(AnimatorParams.isLiftingToolUp);
        if (args.isLiftingToolDown) animator.SetTrigger(AnimatorParams.isLiftingToolDown);
        if (args.isPickingRight) animator.SetTrigger(AnimatorParams.isPickingRight);
        if (args.isPickingLeft) animator.SetTrigger(AnimatorParams.isPickingLeft);
        if (args.isPickingUp) animator.SetTrigger(AnimatorParams.isPickingUp);
        if (args.isPickingDown) animator.SetTrigger(AnimatorParams.isPickingDown);
        if (args.isSwingingToolRight) animator.SetTrigger(AnimatorParams.isSwingingToolRight);
        if (args.isSwingingToolLeft) animator.SetTrigger(AnimatorParams.isSwingingToolLeft);
        if (args.isSwingingToolUp) animator.SetTrigger(AnimatorParams.isSwingingToolUp);
        if (args.isSwingingToolDown) animator.SetTrigger(AnimatorParams.isSwingingToolDown);
        if (args.idleUp) animator.SetTrigger(AnimatorParams.idleUp);
        if (args.idleDown) animator.SetTrigger(AnimatorParams.idleDown);
        if (args.idleLeft) animator.SetTrigger(AnimatorParams.idleLeft);
        if (args.idleRight) animator.SetTrigger(AnimatorParams.idleRight);
    }

    private void AnimationEventPlayFootstepSound()
    {

    }

    private static class AnimatorParams
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
