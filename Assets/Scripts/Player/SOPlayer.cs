using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer : ScriptableObject
{
	public Animator player;
	public SOString soStringName;

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
	public float playerSwipeDuration = .1f;
	
}
