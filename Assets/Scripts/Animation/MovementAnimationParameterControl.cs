using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAnimationParameterControl : MonoBehaviour
{
    Animator animator;

    void Awake(){
        animator = GetComponent<Animator>();
    }

    void OnEnable(){
        EventHandler.MovementEvent += SetAnimationParameters;
    }

    void OnDisable() {
        EventHandler.MovementEvent -= SetAnimationParameters;    
    }

    void SetAnimationParameters(
        float xInput, float yInput,
        bool isWalking, bool isRunning, 
        // bool isIdle, bool isCarrying,
        ToolEffect toolEffect,
        bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown,
        bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
        bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
        bool isSwingToolRight, bool isSwingToolLeft, bool isSwingToolUp, bool isSwingToolDown,
        bool idleRight, bool idleLeft, bool idleUp, bool idleDown
        )
    {
        // animator.SetFloat(Settings.xInput, xInput);
        // animator.SetFloat(Settings.yInput, yInput);
        // animator.SetBool(Settings.isWalking, isWalking);
        // animator.SetBool(Settings.isRunning, isRunning);

        // animator.SetInteger(Settings.toolEffect, (int)toolEffect);

        // if(isUsingToolRight) animator.SetTrigger(Settings.isUsingToolRight);
        // if(isUsingToolLeft) animator.SetTrigger(Settings.isUsingToolLeft);
        // if(isUsingToolUp) animator.SetTrigger(Settings.isUsingToolUp);
        // if(isUsingToolDown) animator.SetTrigger(Settings.isUsingToolDown);

        // if(isLiftingToolRight) animator.SetTrigger(Settings.isLiftingToolRight);
        // if(isLiftingToolLeft) animator.SetTrigger(Settings.isLiftingToolLeft);
        // if(isLiftingToolUp) animator.SetTrigger(Settings.isLiftingToolUp);
        // if(isLiftingToolDown) animator.SetTrigger(Settings.isLiftingToolDown);

        // if(isPickingRight) animator.SetTrigger(Settings.isPickingRight);
        // if(isPickingLeft) animator.SetTrigger(Settings.isPickingLeft);
        // if(isPickingUp) animator.SetTrigger(Settings.isPickingUp);
        // if(isPickingDown) animator.SetTrigger(Settings.isPickingDown);

        // if(isSwingToolRight) animator.SetTrigger(Settings.isSwingToolRight);
        // if(isSwingToolLeft) animator.SetTrigger(Settings.isSwingToolLeft);
        // if(isSwingToolUp) animator.SetTrigger(Settings.isSwingToolUp);
        // if(isSwingToolDown) animator.SetTrigger(Settings.isSwingToolDown);

        // if(idleRight) animator.SetTrigger(Settings.idleRight);
        // if(idleLeft) animator.SetTrigger(Settings.idleLeft);
        // if(idleUp) animator.SetTrigger(Settings.idleUp);
        // if(idleDown) animator.SetTrigger(Settings.idleDown);


        animator.SetFloat("xInput", xInput);
        animator.SetFloat("yInput", yInput);
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isRunning", isRunning);

        animator.SetInteger("toolEffect", (int)toolEffect);

        if(isUsingToolRight) animator.SetTrigger("isUsingToolRight");
        if(isUsingToolLeft) animator.SetTrigger("isUsingToolLeft");
        if(isUsingToolUp) animator.SetTrigger("isUsingToolUp");
        if(isUsingToolDown) animator.SetTrigger("isUsingToolDown");

        if(isLiftingToolRight) animator.SetTrigger("isLiftingToolRight");
        if(isLiftingToolLeft) animator.SetTrigger("isLiftingToolLeft");
        if(isLiftingToolUp) animator.SetTrigger("isLiftingToolUp");
        if(isLiftingToolDown) animator.SetTrigger("isLiftingToolDown");

        if(isPickingRight) animator.SetTrigger("isPickingRight");
        if(isPickingLeft) animator.SetTrigger("isPickingLeft");
        if(isPickingUp) animator.SetTrigger("isPickingUp");
        if(isPickingDown) animator.SetTrigger("isPickingDown");

        if(isSwingToolRight) animator.SetTrigger("isSwingToolRight");
        if(isSwingToolLeft) animator.SetTrigger("isSwingToolLeft");
        if(isSwingToolUp) animator.SetTrigger("isSwingToolUp");
        if(isSwingToolDown) animator.SetTrigger("isSwingToolDown");

        if(idleRight) animator.SetTrigger("idleRight");
        if(idleLeft) animator.SetTrigger("idleLeft");
        if(idleUp) animator.SetTrigger("idleUp");
        if(idleDown) animator.SetTrigger("idleDown");
    }
    void AnimationEventPalyFootstepSound(){
        
    }
}
