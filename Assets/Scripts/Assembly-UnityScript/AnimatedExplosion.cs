using System;
using UnityEngine;

[Serializable]
public class AnimatedExplosion : MonoBehaviour
{
	public bool followPlayer;

	public Transform explosionPlane;

	public bool neverDie;

	public float forceDieAfterSecs;

	public int uvAnimationTileX;

	public int uvAnimationTileY;

	public float framesPerSecond;

	private string state;

	private Vector2 textureSize;

	private int textureIndex;

	private float uIndex;

	private float vIndex;

	private Vector2 offset;

	private float startTime;

	private Vector3 origEulerAngles;

	private Transform playerTransform;

	private GameControl gameControl;

	public AnimatedExplosion()
	{
		uvAnimationTileX = 4;
		uvAnimationTileY = 4;
		framesPerSecond = 24f;
		state = "on";
	}

	public virtual void Start()
	{
		if (followPlayer)
		{
			gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
			if ((bool)gameControl)
			{
				playerTransform = gameControl.playerControl.transform;
			}
		}
		textureSize = new Vector2(1f / (float)uvAnimationTileX, 1f / (float)uvAnimationTileY);
		explosionPlane.GetComponent<Renderer>().material.SetTextureScale("_MainTex", textureSize);
		startTime = Time.time;
		origEulerAngles = transform.eulerAngles;
		LateUpdate();
	}

	public virtual void LateUpdate()
	{
		if (state != "on")
		{
			return;
		}
		textureIndex = (int)((Time.time - startTime) * framesPerSecond);
		if (textureIndex >= uvAnimationTileX * uvAnimationTileY && forceDieAfterSecs == 0f)
		{
			if ((bool)explosionPlane)
			{
				explosionPlane.GetComponent<Renderer>().enabled = false;
			}
			if (!GetComponent<AudioSource>().isPlaying)
			{
				Kill();
			}
		}
		else
		{
			textureIndex %= uvAnimationTileX * uvAnimationTileY;
			uIndex = textureIndex % uvAnimationTileX;
			vIndex = textureIndex / uvAnimationTileX;
			offset = new Vector2(uIndex * textureSize.x, 1f - textureSize.y - vIndex * textureSize.y);
			explosionPlane.GetComponent<Renderer>().material.SetTextureOffset("_MainTex", offset);
		}
		if ((bool)playerTransform)
		{
			transform.position = playerTransform.position;
		}
		transform.LookAt(Camera.main.transform);
		if (forceDieAfterSecs != 0f && !(Time.time - startTime <= forceDieAfterSecs))
		{
			Kill();
		}
	}

	public virtual void Kill()
	{
		if (!(state == "off"))
		{
			state = "off";
			UnityEngine.Object.Destroy(gameObject);
		}
	}

	public virtual void Main()
	{
	}
}
