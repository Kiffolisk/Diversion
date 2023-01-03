using System;
using UnityEngine;

[Serializable]
public class FollowObject : MonoBehaviour
{
	public Vector3 offset;

	private GameControl gameControl;

	private Transform followTransform;

	private Vector3 lastPos;

	private Vector3 forwardVector;

	private int updateCounter;

	public FollowObject()
	{
		offset = new Vector3(2f, 5f, 2f);
		updateCounter = 200;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
	}

	public virtual void Update()
	{
		UpdateFollowObject();
		if ((bool)followTransform)
		{
			lastPos = transform.position;
			transform.position = Vector3.Lerp(transform.position, followTransform.position + offset, Time.deltaTime);
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
		if (updateCounter >= 200)
		{
			updateCounter = 0;
			followTransform = gameControl.cameraTarget;
		}
	}

	public virtual void Main()
	{
	}
}
