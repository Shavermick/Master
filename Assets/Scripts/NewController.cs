using UnityEngine;
using UnityEngine.Events;

public class NewController : MonoBehaviour {

	public float walkSpeed;

	public float walkSword;

	public float runSpeed;

	public float jumpHeight;

	public float gravity;
	public float SpeedSmoothTime;
	public float airControlProcent;
	public float turnSmoothTime;

	[SerializeField] private float turnSmoothVelocity;
	[SerializeField] private float speedSmoothVelocity;
	[SerializeField] private float currentSpeed;
	[SerializeField] private float velocityY;


	[SerializeField] private CharacterController controller;

	[SerializeField] private Animator animator;

	[SerializeField] private Transform cameraT;

	[Header("Sword")]
	public GameObject Sword;
	[SerializeField] private bool isActiveSword;


	bool attackMode;
	int activeSword;

	//UnityEvent myevent = new UnityEvent();

	void Start () {

		controller = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();

		cameraT = Camera.main.transform;

		isActiveSword = false;
		Sword.SetActive(isActiveSword);

		//myevent.AddListener(ShowSword);
	}
	
	void Update () {

		Vector2 inputKey = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		Vector2 inputDir = inputKey.normalized;
		
		bool running = Input.GetKey(KeyCode.LeftShift);

		if (attackMode = Input.GetKeyDown(KeyCode.Tab))
		{
			if (activeSword != 1)
			{
				activeSword = 1;
			}
			else
			{
				activeSword = 0;
			}
		}

		if (activeSword == 1)
		{
			animator.SetInteger("ActiveSword", activeSword);
			Move(inputDir);
			animator.SetFloat("Sword", currentSpeed / walkSword * .5f, SpeedSmoothTime, Time.deltaTime);
		}
		else
		{
			animator.SetInteger("ActiveSword", activeSword);
			Move(inputDir, running);
			float animationSpeedProcent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
			animator.SetFloat("No_Sword", animationSpeedProcent, SpeedSmoothTime, Time.deltaTime);
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Jump();
		}
	}

	void Move(Vector2 inputKey, bool run)
	{
		if (inputKey != Vector2.zero)
		{
			float targerRotation = Mathf.Atan2(inputKey.x, inputKey.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targerRotation, ref turnSmoothVelocity, GetModifedSmoothTime(turnSmoothTime));
		}

		float TargetSpeed = ((run) ? runSpeed : walkSpeed) * inputKey.magnitude;
		currentSpeed = Mathf.SmoothDamp(currentSpeed, TargetSpeed, ref speedSmoothVelocity, GetModifedSmoothTime(SpeedSmoothTime));

		velocityY += Time.deltaTime * gravity;

		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;


		if (controller.isGrounded)
		{
			velocityY = 0;
		}
	}

	void Move(Vector2 inputKey)
	{
		if (inputKey != Vector2.zero)
		{
			float targerRotation = Mathf.Atan2(inputKey.x, inputKey.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
			transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targerRotation, ref turnSmoothVelocity, GetModifedSmoothTime(turnSmoothTime));
		}

		currentSpeed = Mathf.SmoothDamp(currentSpeed, walkSword * inputKey.magnitude, ref speedSmoothVelocity, GetModifedSmoothTime(SpeedSmoothTime));

		velocityY += Time.deltaTime * gravity;

		Vector3 velocity = transform.forward * currentSpeed + Vector3.up * velocityY;

		controller.Move(velocity * Time.deltaTime);
		currentSpeed = new Vector2(controller.velocity.x, controller.velocity.z).magnitude;


		if (controller.isGrounded)
		{
			velocityY = 0;
		}

		if (Input.GetMouseButtonDown(0))
		{
			//attack
			animator.Play("Скелет|Attack");
		}
	}

	float GetModifedSmoothTime(float smoothTime)
	{
		if (controller.isGrounded)
		{
			return smoothTime;
		}
		if (airControlProcent == 0)
		{
			return float.MaxValue;
		}
		return smoothTime / airControlProcent;
	}

	void Jump()
	{
		if (controller.isGrounded)
		{
			float jumpVelocity = Mathf.Sqrt(-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	public void ShowSword()
	{
		isActiveSword = !isActiveSword;
		Sword.SetActive(isActiveSword);
	}
}