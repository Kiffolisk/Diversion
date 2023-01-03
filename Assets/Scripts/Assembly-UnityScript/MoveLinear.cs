using System;
using UnityEngine;

[Serializable]
public class MoveLinear : MonoBehaviour
{
	public Vector3 translate;

	public Vector3 rotate;

	public virtual void Update()
	{
		transform.Translate(translate * Time.deltaTime);
	}

	public virtual void Main()
	{
	}
}
