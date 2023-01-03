using System;
using UnityEngine;

[Serializable]
public class Destroy : MonoBehaviour
{
	public float destroyAfterSecs;

	public Destroy()
	{
		destroyAfterSecs = 1f;
	}

	public virtual void Start()
	{
		UnityEngine.Object.Destroy(gameObject, destroyAfterSecs);
	}

	public virtual void Main()
	{
	}
}
