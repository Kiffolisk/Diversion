using System;
using UnityEngine;

[Serializable]
public class TextureAnimate : MonoBehaviour
{
	public int uvAnimationTileX;

	public int uvAnimationTileY;

	public float framesPerSecond;

	public float cullingDistance;

	public bool lookAtCamera;

	public Vector3 lookAtOffset;

	private float myDist;

	private int myCounter;

	private Vector2 textureSize;

	private int textureIndex;

	private float uIndex;

	private float vIndex;

	private Vector2 offset;

	public TextureAnimate()
	{
		uvAnimationTileX = 4;
		uvAnimationTileY = 4;
		framesPerSecond = 24f;
		cullingDistance = 500f;
	}

	public virtual void Awake()
	{
		textureSize = new Vector2(1f / (float)uvAnimationTileX, 1f / (float)uvAnimationTileY);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", textureSize);
		if (!Camera.main)
		{
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void LateUpdate()
	{
		myCounter++;
		if (myCounter > 30)
		{
			myDist = Vector3.Distance(Camera.main.transform.position, transform.position);
			myCounter = 0;
		}
		if (!(myDist >= cullingDistance))
		{
			textureIndex = (int)(Time.time * framesPerSecond);
			textureIndex %= uvAnimationTileX * uvAnimationTileY;
			uIndex = textureIndex % uvAnimationTileX;
			vIndex = textureIndex / uvAnimationTileX;
			offset = new Vector2(uIndex * textureSize.x, 1f - textureSize.y - vIndex * textureSize.y);
			GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
			if (lookAtCamera)
			{
				transform.LookAt(Camera.main.transform);
			}
			transform.Rotate(lookAtOffset);
		}
	}

	public virtual void Main()
	{
	}
}
