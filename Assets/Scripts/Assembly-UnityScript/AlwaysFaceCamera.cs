using System;
using UnityEngine;

[Serializable]
public class AlwaysFaceCamera : MonoBehaviour
{
	public float cullingDistance;

	private float myDist;

	private int myCounter;

	private Vector3 origEulerAngles;

	public AlwaysFaceCamera()
	{
		cullingDistance = 500f;
	}

	public virtual void Update()
	{
		myCounter++;
		if (myCounter > 30)
		{
			myDist = Vector3.Distance(Camera.main.transform.position, transform.position);
			myCounter = 0;
		}
		if (!(myDist >= cullingDistance))
		{
			origEulerAngles = transform.eulerAngles;
			transform.LookAt(Camera.main.transform);
			transform.eulerAngles = new Vector3(origEulerAngles.x, transform.eulerAngles.y, origEulerAngles.z);
		}
	}

	public virtual void Main()
	{
	}
}
