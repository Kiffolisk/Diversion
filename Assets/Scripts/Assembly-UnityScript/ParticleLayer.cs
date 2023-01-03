using System;
using UnityEngine;

[Serializable]
public class ParticleLayer : MonoBehaviour
{
	public float layerhieght;

	private Vector3 position;

	public virtual void Update()
	{
		GameObject gameObject = Camera.main.gameObject;
		Vector3 vector = gameObject.transform.position - transform.position;
		if ((bool)transform.parent && (vector.magnitude > layerhieght || !(layerhieght >= 0f)))
		{
			transform.position = transform.parent.TransformPoint(position) + vector.normalized * layerhieght;
		}
	}

	public virtual void Main()
	{
		position = transform.localPosition;
	}
}
