using System.Threading;
using UnityEngine;

public class FPSCap : MonoBehaviour
{
	private float oldTime;

	private float theDeltaTime;

	private float curTime;

	private float timeTaken;

	public int frameRate = 30;

	/*private void Awake()
	{
		if (!Application.isEditor)
		{
			Object.Destroy(this);
		}
		Object.DontDestroyOnLoad(this);
	}

	private void Start()
	{
		theDeltaTime = 1f / (float)frameRate;
		oldTime = Time.realtimeSinceStartup;
	}

	private void LateUpdate()
	{
		curTime = Time.realtimeSinceStartup;
		timeTaken = curTime - oldTime;
		if (timeTaken < theDeltaTime)
		{
			Thread.Sleep((int)(1000f * (theDeltaTime - timeTaken)));
		}
		oldTime = Time.realtimeSinceStartup;
	}*/
}
