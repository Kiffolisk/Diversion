using System;
using UnityEngine;

[Serializable]
public class MovePingPong : MonoBehaviour
{
	public float movementRange;

	public float movementSpeed;

	public Vector3 movementVector;

	public float movementOffset;

	public bool activateWhenJumpedOn;

	public bool stopWhenHit;

	private bool isActive;

	private float mySpeed;

	private GameControl gameControl;

	private float startTime;

	private Vector3 startPos;

	private Rigidbody myRigidbody;

	public MovePingPong()
	{
		movementRange = 20f;
		movementSpeed = 1f;
		movementVector = new Vector3(0f, 1f, 0f);
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if (!activateWhenJumpedOn)
		{
			isActive = true;
			startTime = Time.time;
			startPos = transform.position;
		}
		movementOffset = (float)Math.PI * 2f * movementOffset;
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Player" && !isActive && activateWhenJumpedOn)
		{
			isActive = true;
			startTime = Time.time;
			startPos = transform.position;
		}
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent && !(triggerObject.transform.parent.tag != "Player") && stopWhenHit)
		{
			isActive = false;
		}
	}

	public virtual void Update()
	{
		if (isActive)
		{
			transform.position = startPos + movementVector * movementRange * Mathf.Sin(movementOffset + (Time.time - startTime) * movementSpeed);
		}
	}

	public virtual void Main()
	{
	}
}
