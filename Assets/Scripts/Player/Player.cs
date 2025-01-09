using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehaviour<Player>
{
	// camera 를 통해 viewport 즉, 월드 좌표얻는다.
	Camera mainCamera;

	//Movement Parameters
	public float xInput;
	public float yInput;
	public bool isWalking;
	public bool isRunning;
	public bool isIdle;
	public bool isCarrying = false;

	public ToolEffect toolEffect = ToolEffect.none;

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

	public bool idleRight = false; 
	public bool idleLeft = false; 
	public bool idleUp = false;
	public bool idleDown = false;

	Rigidbody2D rb;

	#pragma warning disable 414
	Direction playerDirection;
	#pragma warning restore 414

	float movementSpeed;

	bool _playerInputIsDisabled = false;

	public bool PlayerInputIsDisabled {
		get=> _playerInputIsDisabled;
		set=> _playerInputIsDisabled = value;
	}

	protected override void Awake(){
		base.Awake();

		rb = GetComponent<Rigidbody2D>();
		mainCamera = Camera.main;
	}

	void Update(){
		#region Player Input

		ResetAnimationTriggers();
		PlayerMovementInput();
		PlayerWalkInput();

		//Send event to any listener for player movement input
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

		#endregion
	}
	

	void FixedUpdate(){
		PlayerMovement();
	}
	void PlayerMovement(){
		Vector2 move = new Vector2(xInput *movementSpeed *Time.deltaTime, yInput *movementSpeed *Time.deltaTime);
		rb.MovePosition(rb.position + move);
	}

	

	void ResetAnimationTriggers(){
		isPickingRight = false;
		isPickingLeft = false;
		isPickingUp = false;
		isPickingDown = false;

		isUsingToolRight = false;
		isUsingToolLeft = false;
		isUsingToolUp = false;
		isUsingToolDown = false;
		
		isLiftingToolRight = false;
		isLiftingToolLeft = false;
		isLiftingToolUp = false;
		isLiftingToolDown = false;
		isSwingToolRight = false;
		isSwingToolLeft = false;
		isSwingToolUp = false;
		isSwingToolDown = false;
		toolEffect = ToolEffect.none;
	}

	void PlayerMovementInput()
	{
		xInput = Input.GetAxisRaw("Horizontal");
		yInput = Input.GetAxisRaw("Vertical");

		if(xInput !=0 && yInput !=0){
			xInput = xInput * 0.71f;
			yInput = yInput * 0.71f;
		}

		if(xInput !=0 || yInput !=0){
			isRunning = true;
			isWalking = false;
			isIdle = false;
			movementSpeed = Settings.runningSpeed;

			//Capture player direction for save game
			if(xInput <0) playerDirection = Direction.left;
			else if(xInput >0) playerDirection = Direction.right;
			else if(yInput <0) playerDirection = Direction.down;
			else if(yInput >0) playerDirection = Direction.up;
		}
		else if(xInput ==0 && yInput ==0){
			isRunning = false;
			isWalking = false;
			isIdle = true;
		}
	}

	void PlayerWalkInput(){
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)){
			isRunning = false;
			isWalking = true;
			isIdle = false;
			movementSpeed = Settings.walkingSpeed;
		}
		else{
			isRunning = true;
			isWalking = false;
			isIdle = false;
			movementSpeed = Settings.runningSpeed;
		}
	}

	public Vector3 GetPlayerViewportPosition(){
		return mainCamera.WorldToViewportPoint(transform.position);
	}
}
