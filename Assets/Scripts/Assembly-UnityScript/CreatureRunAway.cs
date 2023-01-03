using System;
using UnityEngine;

[Serializable]
public class CreatureRunAway : MonoBehaviour
{
	public string idleAnimation;

	public string walkAnimation;

	public string runAwayAnimation;

	public AudioClip runAwaySound;

	public float idleSpeed;

	public Vector3 runAwayVelocity;

	private string state;

	private GameControl gameControl;

	private Animation myAnimation;

	private Vector3 startPos;

	private int idleCounter;

	private Vector3 idleVelocity;

	private Vector3 idleRotation;

	public CreatureRunAway()
	{
		idleAnimation = "idle";
		walkAnimation = "walk";
		runAwayAnimation = "run";
		runAwayVelocity = new Vector3(0f, 0f, 10f);
		state = "idle";
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		startPos = transform.position;
		myAnimation = (Animation)gameObject.GetComponentInChildren(typeof(Animation));
		if ((bool)myAnimation && !(idleSpeed <= 0f))
		{
			ChangeIdle();
		}
	}

	public virtual void Update()
	{
		if (state == "idle")
		{
			idleCounter--;
			if (idleCounter < 0)
			{
				ChangeIdle();
			}
			if (idleVelocity != Vector3.zero)
			{
				transform.Translate(idleVelocity * Time.deltaTime, Space.Self);
				transform.Rotate(idleRotation * Time.deltaTime);
				CheckGround();
			}
		}
		else
		{
			transform.Translate(runAwayVelocity * Time.deltaTime, Space.Self);
		}
	}

	public virtual void ChangeIdle()
	{
		if (UnityEngine.Random.Range(0, 2) == 1)
		{
			idleCounter = UnityEngine.Random.Range(30, 90);
			idleVelocity = new Vector3(0f, 0f, idleSpeed);
			idleRotation = new Vector3(0f, UnityEngine.Random.Range(-90, 90), 0f);
			if ((bool)myAnimation)
			{
				myAnimation.Play(walkAnimation);
			}
		}
		else
		{
			idleCounter = UnityEngine.Random.Range(15, 30);
			idleVelocity = new Vector3(0f, 0f, 0f);
			idleRotation = new Vector3(0f, 0f, 0f);
			if ((bool)myAnimation)
			{
				myAnimation.Play(idleAnimation);
			}
		}
	}

	public virtual void BackUp()
	{
		transform.Rotate(0f, 180f, 0f);
		idleCounter = 30;
		idleVelocity = new Vector3(0f, 0f, idleSpeed);
		idleRotation = new Vector3(0f, 0f, 0f);
		if ((bool)myAnimation)
		{
			myAnimation.Play(walkAnimation);
		}
	}

	public virtual void CheckGround()
	{
		if (!(state == "runaway") && !Physics.Raycast(transform.position + transform.forward * 3f, -Vector3.up, 20f))
		{
			BackUp();
		}
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (!(state == "on") && (bool)triggerObject.transform.parent && !(triggerObject.transform.parent.tag != "Player"))
		{
			transform.forward = triggerObject.transform.right;
			transform.Rotate(0f, UnityEngine.Random.Range(-90, 0), 0f);
			state = "runaway";
			if ((bool)myAnimation)
			{
				myAnimation.Play(runAwayAnimation);
			}
			if ((bool)runAwaySound)
			{
				gameControl.PlaySound(runAwaySound);
			}
		}
	}

	public virtual void Main()
	{
	}
}
