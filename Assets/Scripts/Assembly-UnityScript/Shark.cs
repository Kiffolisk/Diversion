using System;
using UnityEngine;

[Serializable]
public class Shark : MonoBehaviour
{
	public float movementRange;

	public float movementSpeed;

	public Vector3 movementVector;

	public float jumpInterval;

	public float jumpHeight;

	private float jumpVelocity;

	private float jumpTime;

	private float directionTime;

	private string myAction;

	private float myDirection;

	private Vector3 myVelocity;

	private GameControl gameControl;

	private Vector3 startPos;

	private TriggerObject triggerControl;

	private float maxHeight;

	public Shark()
	{
		movementRange = 90f;
		movementSpeed = 20f;
		movementVector = new Vector3(0f, 1f, 0f);
		jumpHeight = 2f;
		myAction = "swim";
		myDirection = 1f;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		startPos = transform.position;
		movementVector = movementVector.normalized;
		transform.forward = movementVector;
		jumpTime = Time.time + jumpInterval;
		triggerControl = (TriggerObject)gameObject.GetComponent(typeof(TriggerObject));
	}

	public virtual void Update()
	{
		if (!(Vector3.Distance(startPos, transform.position) < movementRange) && !(Time.time - directionTime <= 1f))
		{
			myDirection *= -1f;
			directionTime = Time.time;
		}
		if (jumpInterval != 0f)
		{
			if (myAction == "jump")
			{
				jumpVelocity -= 3f * Time.deltaTime * 30f;
				if (!(transform.position.y > startPos.y))
				{
					jumpVelocity = 0f;
					float y = startPos.y;
					Vector3 position = transform.position;
					float num = (position.y = y);
					Vector3 vector2 = (transform.position = position);
					myAction = "swim";
					jumpTime = Time.time + jumpInterval;
					if ((bool)triggerControl)
					{
						triggerControl.underwater = true;
					}
					UnityEngine.Object.Instantiate(Resources.Load("waterSplash"), transform.position + new Vector3(0f, 2f, 0f), Quaternion.identity);
					GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/splash"));
				}
			}
			else
			{
				jumpVelocity = 0f;
				if (!(Time.time <= jumpTime))
				{
					jumpVelocity = jumpHeight * 30f;
					myAction = "jump";
					if ((bool)triggerControl)
					{
						triggerControl.underwater = false;
					}
				}
			}
		}
		myVelocity = movementVector * movementSpeed * myDirection * Time.deltaTime + new Vector3(0f, jumpVelocity * Time.deltaTime, 0f);
		if (myVelocity != Vector3.zero)
		{
			transform.Translate(myVelocity, Space.World);
			transform.forward = myVelocity;
		}
	}

	public virtual void Main()
	{
	}
}
