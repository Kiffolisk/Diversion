using System;
using UnityEngine;

[Serializable]
public class TextureAnimateDie : MonoBehaviour
{
	public int uvAnimationTileX;

	public int uvAnimationTileY;

	public float framesPerSecond;

	private Vector2 textureSize;

	private int textureIndex;

	private float uIndex;

	private float vIndex;

	private Vector2 offset;

	private float startTime;

	private Vector3 origEulerAngles;

	public TextureAnimateDie()
	{
		uvAnimationTileX = 4;
		uvAnimationTileY = 4;
		framesPerSecond = 24f;
	}

	public virtual void Awake()
	{
		textureSize = new Vector2(1f / (float)uvAnimationTileX, 1f / (float)uvAnimationTileY);
		GetComponent<Renderer>().material.SetTextureScale("_MainTex", textureSize);
		startTime = Time.time;
		LateUpdate();
	}

	public virtual void LateUpdate()
	{
		textureIndex = (int)((Time.time - startTime) * framesPerSecond);
		if (textureIndex >= uvAnimationTileX * uvAnimationTileY)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		textureIndex %= uvAnimationTileX * uvAnimationTileY;
		uIndex = textureIndex % uvAnimationTileX;
		vIndex = textureIndex / uvAnimationTileX;
		offset = new Vector2(uIndex * textureSize.x, 1f - textureSize.y - vIndex * textureSize.y);
		GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
		origEulerAngles = transform.eulerAngles;
		transform.LookAt(Camera.main.transform);
		transform.eulerAngles = new Vector3(90f, transform.eulerAngles.y, origEulerAngles.z);
	}

	public virtual void Main()
	{
	}
}
