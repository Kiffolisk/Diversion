using System;
using UnityEngine;

[Serializable]
public class TiltSkyControl : MonoBehaviour
{
	private Vector3 targetRotation;

	public virtual void Awake()
	{
		if (!SystemInfo.supportsAccelerometer)
		{
			UnityEngine.Object.Destroy(this);
		}
	}

	public virtual void Update()
	{
		targetRotation = Vector3.zero;
		targetRotation.x = (0.5f + Acceleration.acceleration.y) * 10f;
		targetRotation.y = Acceleration .acceleration.x * 10f;
		float x = Mathf.LerpAngle(transform.localEulerAngles.x, targetRotation.x, Time.deltaTime);
		Vector3 localEulerAngles = transform.localEulerAngles;
		float num = (localEulerAngles.x = x);
		Vector3 vector2 = (transform.localEulerAngles = localEulerAngles);
		float y = Mathf.LerpAngle(transform.localEulerAngles.y, targetRotation.y, Time.deltaTime);
		Vector3 localEulerAngles2 = transform.localEulerAngles;
		float num2 = (localEulerAngles2.y = y);
		Vector3 vector4 = (transform.localEulerAngles = localEulerAngles2);
	}

	public virtual void Main()
	{
	}
}
