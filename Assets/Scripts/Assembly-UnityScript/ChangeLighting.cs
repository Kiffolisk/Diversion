using System;
using UnityEngine;

[Serializable]
public class ChangeLighting : MonoBehaviour
{
	public Color lightColor;

	public float fadeTime;

	public bool changeBackOnExit;

	private bool activated;

	public ChangeLighting()
	{
		changeBackOnExit = true;
	}

	public virtual void Awake()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
