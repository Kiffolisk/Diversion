using System;
using UnityEngine;

[Serializable]
public class TextureScroll : MonoBehaviour
{
	public float scrollSpeed;

	public float cullingDistance;

	private float offset;

	private float myDist;

	private int myCounter;

	public TextureScroll()
	{
		scrollSpeed = 0.5f;
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
			offset = Time.time * scrollSpeed;
			GetComponent<Renderer>().material.SetTextureOffset("_MainTex", new Vector2(offset, 0f));
		}
	}

	public virtual void Main()
	{
	}
}
