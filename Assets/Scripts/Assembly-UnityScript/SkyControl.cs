using System;
using UnityEngine;

[Serializable]
public class SkyControl : MonoBehaviour
{
	public Vector3 offset;

	public float spinSpeed;

	public SkyControl()
	{
		spinSpeed = -2f;
	}

	public virtual void Start()
	{
		if (!Camera.main)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void Update()
	{
		transform.position = Camera.main.transform.position + offset;
		transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
	}

	public virtual void Main()
	{
	}
}
