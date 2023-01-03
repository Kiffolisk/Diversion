using System;
using UnityEngine;

[Serializable]
public class DestroyTimer : MonoBehaviour
{
	private float howFar;

	private int checkEverySecs;

	private GameControl gameControl;

	private int missionCount;

	private float endX;

	public Vector3 endPoint;

	public DestroyTimer()
	{
		howFar = 300f;
		checkEverySecs = 5;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		missionCount = gameControl.missionCount;
		endX = this.transform.position.x - 200f;
		endPoint = this.transform.position - new Vector3(200f, 0f, 0f);
		Transform transform = this.transform.Find("EndPoint");
		if ((bool)transform)
		{
			endX = transform.position.x;
			endPoint = transform.position;
		}
		if ((bool)gameControl.playerControl)
		{
			InvokeRepeating("CheckForOldPlatform", checkEverySecs, checkEverySecs);
		}
	}

	public virtual void CheckForOldPlatform()
	{
		float num = endX - gameControl.playerControl.transform.position.x;
		if (num > howFar || missionCount != gameControl.missionCount)
		{
			RemoveObject();
		}
	}

	public virtual void RemoveObject()
	{
		CancelInvoke();
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
