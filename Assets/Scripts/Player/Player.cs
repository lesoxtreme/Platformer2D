using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : MonoBehaviour
{
	public Rigidbody2D myRigidbody;
	public HealthBase healthBase;

	[Header("Setup")]
	public SOPlayer soPlayerSetup;
	
	//public Animator animator;

	private float _currentSpeed;

	private Animator _currentPlayer;


	private void Awake()
	{
		if(healthBase != null)
		{
			healthBase.OnKill += OnPlayerKill;
		}

		_currentPlayer = Instantiate(soPlayerSetup.player, transform);
	}

	private void OnPlayerKill()
	{
		healthBase.OnKill -= OnPlayerKill;
		_currentPlayer.SetTrigger(soPlayerSetup.triggerDeath);

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
		_currentSpeed = soPlayerSetup.speedRun;
		_currentPlayer.speed = 3;
	}
	else 
	{
		_currentSpeed = soPlayerSetup.speed;
		_currentPlayer.speed = 1;
	}

	

	if(Input.GetKey(KeyCode.LeftArrow))
	{
		//myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
		myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);
		if(myRigidbody.transform.localScale.x != -1)
		{
			myRigidbody.transform.DOScaleX(-1, soPlayerSetup.playerSwipeDuration);
		}
		_currentPlayer.SetBool(soPlayerSetup.boolRun, true);
	}
	else if(Input.GetKey(KeyCode.RightArrow))
	{
		//myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
		myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);
		if(myRigidbody.transform.localScale.x != 1)
		{
			myRigidbody.transform.DOScaleX(1, soPlayerSetup.playerSwipeDuration);
		}
		myRigidbody.transform.localScale = new Vector3(1 ,1 ,1);
		_currentPlayer.SetBool(soPlayerSetup.boolRun, true);
	}
	else
	{
		_currentPlayer.SetBool(soPlayerSetup.boolRun, false);
	}

	if(myRigidbody.velocity.x > 0)
	{
		myRigidbody.velocity += soPlayerSetup.friction;
	}
	else if (myRigidbody.velocity.x < 0)
	{
		myRigidbody.velocity -= soPlayerSetup.friction;
	}
   }

   private void HandleJump()
   {
	if(Input.GetKeyDown(KeyCode.Space))
	{
		myRigidbody.velocity = Vector2.up * soPlayerSetup.forceJump;
		myRigidbody.transform.localScale = Vector2.one;

		DOTween.Kill(myRigidbody.transform);
		HandleScaleJump();
	}
   }

   private void HandleScaleJump()
   {
		  myRigidbody.transform.DOScaleY(soPlayerSetup.jumpScaleY, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
		  myRigidbody.transform.DOScaleX(soPlayerSetup.jumpScaleX, soPlayerSetup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayerSetup.ease);
   }

   public void DestroyMe()
   {
		  Destroy(gameObject);
   }
}
