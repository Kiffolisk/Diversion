using System;
using UnityEngine;

[Serializable]
public class DestroyAbort : MonoBehaviour
{
	private int checkEverySecs;

	private GameControl gameControl;

	public DestroyAbort()
	{
		checkEverySecs = 1;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		InvokeRepeating("CheckAbortPlatform", checkEverySecs, checkEverySecs);
		if (transform.name.IndexOf("platformGoal") != -1)
		{
			gameControl.goalPosition = transform.position;
		}
	}

	public virtual void CheckAbortPlatform()
	{
		if (gameControl.missionAborted)
		{
			RemoveAbortObject();
		}
	}

	public virtual void RemoveAbortObject()
	{
		CancelInvoke();
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
