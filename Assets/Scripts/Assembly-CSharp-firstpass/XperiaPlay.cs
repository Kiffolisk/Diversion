using UnityEngine;

public class XperiaPlay : MonoBehaviour
{
	public bool test;

	public static bool isOpen;

	public static bool isDevice;

	private AndroidJavaObject currentConfig;

	public void Start()
	{
		if (SystemInfo.deviceModel.Contains("R800") || SystemInfo.deviceModel.Contains("Z1i"))
		{
			isDevice = true;
		}
		using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
		{
			AndroidJavaObject @static = androidJavaClass.GetStatic<AndroidJavaObject>("currentActivity");
			AndroidJavaObject androidJavaObject = @static.Call<AndroidJavaObject>("getResources", new object[0]).Call<AndroidJavaObject>("getConfiguration", new object[0]);
		}
	}

	public void Update()
	{
		if (isDevice)
		{
			if (currentConfig.Get<int>("navigationHidden") == 1)
			{
				isOpen = true;
			}
			else
			{
				isOpen = false;
			}
		}
	}
}
