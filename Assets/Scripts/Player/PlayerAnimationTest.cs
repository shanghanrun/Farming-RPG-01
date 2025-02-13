using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTest : MonoBehaviour
{
    public float xInput;
    public float yInput;
    public bool isWalking;
    public bool isRunning;
    // public bool isIdle;
    // public bool isCarrying;
    public ToolEffect toolEffect;
    public bool isUsingToolRight;
    public bool isUsingToolLeft;
    public bool isUsingToolUp;
    public bool isUsingToolDown;
    public bool isLiftingToolRight;
    public bool isLiftingToolLeft;
    public bool isLiftingToolUp;
    public bool isLiftingToolDown;
    public bool isPickingRight;
    public bool isPickingLeft;
    public bool isPickingUp;
    public bool isPickingDown;
    public bool isSwingToolRight;
    public bool isSwingToolLeft;
    public bool isSwingToolUp;
    public bool isSwingToolDown;

    //Shared Animation Parameters
    public bool idleRight;
    public bool idleLeft;
    public bool idleUp;
    public bool idleDown;

    void Update(){
        EventHandler.CallMovementEvent(
            xInput, yInput,
            isWalking, isRunning, 
            // isIdle, isCarrying,
            toolEffect,
            isUsingToolRight, isUsingToolLeft, isUsingToolUp, isUsingToolDown,
            isLiftingToolRight, isLiftingToolLeft, isLiftingToolUp, isLiftingToolDown,
            isPickingRight, isPickingLeft, isPickingUp, isPickingDown,
            isSwingToolRight, isSwingToolLeft, isSwingToolUp, isSwingToolDown,
            idleRight, idleLeft, idleUp, idleDown
        );
    }
}
