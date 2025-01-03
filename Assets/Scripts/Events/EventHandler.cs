public delegate void MovementDelegate(
    float xInput, float yInput, 
    bool isWalking, bool isRunning, 
    // bool isIdle, bool isCarrying, 
    ToolEffect toolEffect, 
    bool isUsingToolRight, bool isUsingToolLeft, bool isUsingToolUp, bool isUsingToolDown, 
    bool isLiftingToolRight, bool isLiftingToolLeft, bool isLiftingToolUp, bool isLiftingToolDown,
    bool isPickingRight, bool isPickingLeft, bool isPickingUp, bool isPickingDown,
    bool isSwingToolRight, bool isSwingToolLeft, bool isSwingToolUp, bool isSwingToolDown,
    bool idleRight, bool idleLeft, bool idleUp, bool idleDown
    );

public static class EventHandler{
    // Movement Event
    public static event MovementDelegate MovementEvent;

    // Movement Event Call for Publishers
    public static void CallMovementEvent(
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
            if(MovementEvent != null){
                MovementEvent(
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

}
