using System;
using UnityEngine;

[Serializable]
public class GarbotControl : MonoBehaviour
{
	private float offsetDistance;

	private GameControl gameControl;

	private Transform followTransform;

	private Vector3 lastPos;

	private Vector3 forwardVector;

	private int updateCounter;

	public GarbotControl()
	{
		offsetDistance = 0.1f;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		lastPos = transform.position;
		if (!gameControl.garbot)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void Update()
	{
		UpdateFollowObject();
		if (!followTransform)
		{
			return;
		}
		lastPos = transform.position;
		if (!(Vector3.Distance(transform.position, followTransform.position + followTransform.right * 0f - new Vector3(0f, 4f, 0f)) <= offsetDistance))
		{
			transform.position = Vector3.Lerp(transform.position, followTransform.position + followTransform.right * 0f - new Vector3(0f, 4f, 0f), Time.deltaTime);
			forwardVector = transform.position - lastPos;
			if (!(forwardVector.magnitude <= 0.1f))
			{
				transform.forward = forwardVector;
				int num = 0;
				Vector3 eulerAngles = transform.eulerAngles;
				float num2 = (eulerAngles.x = num);
				Vector3 vector2 = (transform.eulerAngles = eulerAngles);
			}
		}
	}

	public virtual void UpdateFollowObject()
	{
		updateCounter++;
		if (updateCounter >= 10)
		{
			updateCounter = 0;
			followTransform = gameControl.playerControl.transform;
		}
	}

	public virtual void Main()
	{
	}
}
