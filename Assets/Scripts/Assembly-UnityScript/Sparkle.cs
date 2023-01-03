using System;
using UnityEngine;

[Serializable]
public class Sparkle : MonoBehaviour
{
	public bool pulse;

	public bool spin;

	public bool faceCamera;

	public bool shrink;

	public float dieAfterSeconds;

	private Vector3 origEulerAngles;

	private float origScale;

	private float newScale;

	private float timeOffset;

	public Sparkle()
	{
		pulse = true;
		spin = true;
		faceCamera = true;
	}

	public virtual void Awake()
	{
		origEulerAngles = transform.eulerAngles;
		origScale = transform.localScale.x;
		newScale = origScale;
		timeOffset = UnityEngine.Random.Range(0f, 10f);
		if (dieAfterSeconds != 0f)
		{
			UnityEngine.Object.Destroy(gameObject, dieAfterSeconds);
		}
	}

	public virtual void LateUpdate()
	{
		if (shrink)
		{
			origScale = Mathf.Lerp(origScale, 0f, dieAfterSeconds * Time.deltaTime);
		}
		if (pulse)
		{
			newScale = origScale * (1f + 0.2f * Mathf.Sin((Time.time + timeOffset) * 10f));
			transform.localScale = new Vector3(1f, 1f, 1f) * newScale;
		}
		if (spin)
		{
			float z = transform.eulerAngles.z + Time.deltaTime * 80f;
			Vector3 eulerAngles = transform.eulerAngles;
			float num = (eulerAngles.z = z);
			Vector3 vector2 = (transform.eulerAngles = eulerAngles);
		}
		if (faceCamera)
		{
			origEulerAngles = transform.eulerAngles;
			transform.LookAt(Camera.main.transform);
			transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, origEulerAngles.z);
		}
	}

	public virtual void Main()
	{
	}
}
