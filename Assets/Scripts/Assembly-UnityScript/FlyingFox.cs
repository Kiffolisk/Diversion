using System;
using UnityEngine;

[Serializable]
public class FlyingFox : MonoBehaviour
{
	public float distanceToTravel;

	public Transform visibleTransform;

	public bool returnToStart;

	private float maxSpeed;

	private bool isActive;

	private float mySpeed;

	private GameControl gameControl;

	private Vector3 visibleOffset;

	private bool reachedEnd;

	private Vector3 startPos;

	public FlyingFox()
	{
		distanceToTravel = 50f;
		returnToStart = true;
		maxSpeed = 70f;
	}

	public virtual void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawLine(transform.position, transform.position + transform.right * distanceToTravel);
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		startPos = transform.position;
		if ((bool)visibleTransform)
		{
			visibleOffset = transform.position - visibleTransform.position;
		}
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent && !(triggerObject.transform.parent.tag != "Player") && (bool)gameControl && !isActive)
		{
			isActive = true;
			if ((bool)GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().Play();
			}
		}
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if ((bool)triggerObject.transform.parent && !(triggerObject.transform.parent.tag != "Player") && (bool)gameControl && isActive && (bool)GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().Stop();
		}
	}

	public virtual void Update()
	{
		if (!isActive)
		{
			return;
		}
		if (!(Vector3.Distance(transform.position, startPos) < distanceToTravel))
		{
			transform.position = startPos;
			reachedEnd = true;
			if ((bool)GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().Stop();
			}
		}
		else
		{
			mySpeed += Time.deltaTime * 50f;
		}
		mySpeed = Mathf.Clamp(mySpeed, 0f, maxSpeed);
		transform.Translate(Vector3.right * mySpeed * Time.deltaTime);
		if ((bool)visibleTransform && !reachedEnd)
		{
			visibleTransform.position = transform.position + visibleOffset;
		}
	}

	public virtual void Main()
	{
	}
}
