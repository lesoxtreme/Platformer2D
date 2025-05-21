using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	public Rigidbody2D myRigidbody;
	public HealthBase healthBase;

	[Header("Speed Setup")]
	public Vector2 friction = new Vector2(.1f, 0);
	public float speed;
	public float speedRun;
	public float forceJump = 2;

	[Header("Animation Setup")]
	public float jumpScaleY = 1.5f;
	public float jumpScaleX = 0.7f;
	public float animationDuration = 0.3f;
	public Ease ease = Ease.OutBack;

	[Header("Animation player Setup")]
	public string boolRun = "Run";
	public string triggerDeath = "Death";
	public Animator animator;
	public float playerSwipeDuration = .1f;

	private float _currentSpeed;


	private void Awake()
	{
		if(healthBase != null)
		{
			healthBase.OnKill += OnPlayerKill;
		}
	}

	private void OnPlayerKill()
	{
		healthBase.OnKill -= OnPlayerKill;
		animator.SetTrigger(triggerDeath);

	}

   private void Update()
   {
	HandleJump();
	HandleMovement();
	

   }

   private void HandleMovement()
   {

	if(Input.GetKey(KeyCode.LeftControl))
	{
		_currentSpeed = speedRun;
		animator.speed = 3;
	}
	else 
	{
		_currentSpeed = speed;
		animator.speed = 1;
	}

	

	if(Input.GetKey(KeyCode.LeftArrow))
	{
		//myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
		myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
		if(myRigidbody.transform.localScale.x != -1)
		{
			myRigidbody.transform.DOScaleX(-1, playerSwipeDuration);
		}
		animator.SetBool(boolRun, true);
	}
	else if(Input.GetKey(KeyCode.RightArrow))
	{
		//myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
		myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
		if(myRigidbody.transform.localScale.x != 1)
		{
			myRigidbody.transform.DOScaleX(1, playerSwipeDuration);
		}
		myRigidbody.transform.localScale = new Vector3(1 ,1 ,1);
		animator.SetBool(boolRun, true);
	}
	else
	{
		animator.SetBool(boolRun, false);
	}

	if(myRigidbody.velocity.x > 0)
	{
		myRigidbody.velocity += friction;
	}
	else if (myRigidbody.velocity.x < 0)
	{
		myRigidbody.velocity -= friction;
	}
   }

   private void HandleJump()
   {
	if(Input.GetKeyDown(KeyCode.Space))
	{
		myRigidbody.velocity = Vector2.up * forceJump;
		myRigidbody.transform.localScale = Vector2.one;

		DOTween.Kill(myRigidbody.transform);
		HandleScaleJump();
	}
   }

   private void HandleScaleJump()
   {
		  myRigidbody.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
		  myRigidbody.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
   }

   public void DestroyMe()
   {
		  Destroy(gameObject);
   }
}
