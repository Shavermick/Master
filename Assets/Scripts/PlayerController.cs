using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	
	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float jumpHeight = 1;
	[Range(0,1)]
	public float airControlProcent;
	public float gravity = -12;
	public float turnSmoothTime = .2f;
	float turnSmoothVelocity;
	public float SpeedSmoothTime = .1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;
	public GameObject LinkForAnimation;
	Animator _animator;
	Transform cameraT;

	CharacterController _controller;

	void Start () {
		_animator = LinkForAnimation.GetComponent<Animator>();
		cameraT = Camera.main.transform;
		_controller = GetComponent<CharacterController>();
	}
	
	void Update () {
		
		Vector2 input = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey(KeyCode.LeftShift);
		Move(inputDir,running);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}

		float animationSpeedProcent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
		_animator.SetFloat("speedPercent", animationSpeedProcent, SpeedSmoothTime, Time.deltaTime);

	}

	void Move(Vector2 inputDir, bool running)
	{
		if (inputDir != Vector2.zero)
		{
			float targerRotation = Mathf.Atan2(inputDir.x,inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targerRotation, ref turnSmoothVelocity, GetModifedSmoothTime(turnSmoothTime));
		}

		float TargetSpeed = ((running)? runSpeed : walkSpeed) * inputDir.magnitude;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, TargetSpeed, ref speedSmoothVelocity, GetModifedSmoothTime(SpeedSmoothTime));

		velocityY +=Time.deltaTime * gravity;

		Vector3 velocity  = transform.forward * currentSpeed + Vector3.up * velocityY;

		_controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(_controller.velocity.x, _controller.velocity.z).magnitude;
	

		if (_controller.isGrounded)
		{
			velocityY = 0;
		}
	}

	void Jump()
	{
		if (_controller.isGrounded)
		{
			float jumpVelocity = Mathf.Sqrt(-2*gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	float GetModifedSmoothTime(float smoothTime)
	{
		if (_controller.isGrounded)
		{
			return smoothTime;
		}
		if (airControlProcent == 0)
		{
			return float.MaxValue;
		}
		return smoothTime / airControlProcent;
	}
}