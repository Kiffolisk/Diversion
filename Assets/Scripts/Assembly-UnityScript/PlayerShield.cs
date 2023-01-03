using System;
using UnityEngine;

[Serializable]
public class PlayerShield : MonoBehaviour
{
	public virtual void Start()
	{
	}

	public virtual void Update()
	{
		transform.Rotate(0f, 360f * Time.deltaTime, 0f);
	}

	public virtual void Main()
	{
	}
}
