using System;
using UnityEngine;

[Serializable]
public class ExplosionExpand : MonoBehaviour
{
	public Transform expandPlane;

	private float lastForSeconds;

	private float growthFactor;

	private bool fadeOut;

	public ExplosionExpand()
	{
		lastForSeconds = 0.1f;
		growthFactor = 20f;
		fadeOut = true;
	}

	public virtual void Awake()
	{
		UnityEngine.Object.Destroy(gameObject, lastForSeconds);
	}

	public virtual void Update()
	{
		if ((bool)expandPlane)
		{
			expandPlane.localScale *= 1f + growthFactor * Time.deltaTime;
		}
	}

	public virtual void Main()
	{
	}
}
