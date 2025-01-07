
using UnityEngine;

public static class Settings{

    // Fading Item
    public const float fadeInSeconds = .25f;
    public const float fadeOutSeconds = .35f;
    public const float targetAlpha = .45f;

    //Player Movement
    public const float runningSpeed = 5.33f;
    public const float walkingSpeed = 2.66f;
    
    //Player Animation Parameters
    public static int xInput;
    public static int yInput;
    public static int isWalking; 
    public static int isRunning; 
    // public static int isIdle; 
    // public static int isCarrying;
    public static int toolEffect; 
    public static int isUsingToolRight; 
    public static int isUsingToolLeft; 
    public static int isUsingToolUp; 
    public static int isUsingToolDown;
    public static int isLiftingToolRight; 
    public static int isLiftingToolLeft; 
    public static int isLiftingToolUp; 
    public static int isLiftingToolDown;
    public static int isPickingRight; 
    public static int isPickingLeft;     
    public static int isPickingUp; 
    public static int isPickingDown;
    public static int isSwingToolRight; 
    public static int isSwingToolLeft; 
    public static int isSwingToolUp; 
    public static int isSwingToolDown;

    //Shared Animation Parameters
    public static int idleRight; 
    public static int idleLeft; 
    public static int idleUp; 
    public static int idleDown;

    // static constructor
    static Settings(){
        //Player Animation Parameters
        xInput = Animator.StringToHash("xInput");
        yInput= Animator.StringToHash("yInput");
        isWalking= Animator.StringToHash("isWalking");
        isRunning= Animator.StringToHash("isRunning");
        // isIdle= Animator.StringToHash("isIdle");
        // isCarrying= Animator.StringToHash("isCarrying");
        toolEffect= Animator.StringToHash("toolEffect");
        isUsingToolRight= Animator.StringToHash("isUsingToolRight");
        isUsingToolLeft= Animator.StringToHash("isUsingToolLeft");
        isUsingToolUp= Animator.StringToHash("isUsingToolUp");
        isUsingToolDown= Animator.StringToHash("isUsingToolDown");
        isLiftingToolRight= Animator.StringToHash("isLiftingToolRight");
        isLiftingToolLeft= Animator.StringToHash("isLiftingToolLeft");
        isLiftingToolUp= Animator.StringToHash("isLiftingToolUp");
        isLiftingToolDown= Animator.StringToHash("isLiftingToolDown");
        isPickingRight= Animator.StringToHash("isPickingRight");
        isPickingLeft= Animator.StringToHash("isPickingLeft");
        isPickingUp= Animator.StringToHash("isPickingUp");
        isPickingDown= Animator.StringToHash("isPickingDown");
        isSwingToolRight= Animator.StringToHash("isSwingToolRight");
        isSwingToolLeft= Animator.StringToHash("isSwingToolLeft");
        isSwingToolUp= Animator.StringToHash("isSwingToolUp");
        isSwingToolDown= Animator.StringToHash("isSwingToolDown");

    //Shared Animation Parameters
        idleRight= Animator.StringToHash("idleRight");
        idleLeft= Animator.StringToHash("idleLeft");
        idleUp= Animator.StringToHash("idleUp");
        idleDown= Animator.StringToHash("idleDown");
    }
}
