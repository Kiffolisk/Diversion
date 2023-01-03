using System;
using UnityEngine;

[Serializable]
public class SpawnPlayer : MonoBehaviour
{
	private RaycastHit hit;

	private Vector3 collidePos;

	private int layerMask;

	private Vector3 spawnPos;

	private GameControl gameControl;

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if (!gameControl)
		{
			Application.LoadLevel(0);
		}
	}

	public virtual void Start()
	{
		if ((bool)gameControl)
		{
			layerMask = 4;
			layerMask = ~layerMask;
			spawnPos = transform.position;
			GameObject gameObject = null;
			if (Physics.Raycast(spawnPos, -Vector3.up, out hit, 200f, layerMask))
			{
				spawnPos = new Vector3(spawnPos.x, hit.point.y + 2.3f, spawnPos.z);
			}
			gameObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Player" + gameControl.gender), spawnPos, transform.rotation);
			GameObject gameObject2 = GameObject.FindWithTag("CameraTarget");
			if ((bool)gameObject2)
			{
				gameControl.cameraTarget = gameObject2.transform;
			}
		}
	}

	public virtual void Update()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
