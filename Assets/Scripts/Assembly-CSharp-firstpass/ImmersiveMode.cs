using UnityEngine;

public static class ImmersiveMode
{
	public static AndroidJavaClass AJC { get; private set; }

	static ImmersiveMode()
	{
		try
		{
			AJC = new AndroidJavaClass("com.ruudlenders.immersivemode.ImmersiveMode");
		}
		catch
		{
			AJC = null;
		}
	}

	public static bool Add(AndroidJavaObject activity)
	{
		return AJC != null && AJC.CallStatic<bool>("add", new object[1] { activity });
	}

	public static bool Contains(AndroidJavaObject activity)
	{
		return AJC != null && AJC.CallStatic<bool>("contains", new object[1] { activity });
	}

	public static bool Remove(AndroidJavaObject activity)
	{
		return AJC != null && AJC.CallStatic<bool>("remove", new object[1] { activity });
	}

	public static bool AddCurrentActivity()
	{
		return AJC != null && AJC.CallStatic<bool>("addCurrentActivity", new object[0]);
	}

	public static bool Clear()
	{
		return AJC != null && AJC.CallStatic<bool>("clear", new object[0]);
	}

	public static bool ContainsCurrentActivity()
	{
		return AJC != null && AJC.CallStatic<bool>("containsCurrentActivity", new object[0]);
	}

	public static bool DeviceHasKey(int keyCode)
	{
		return AJC != null && AJC.CallStatic<bool>("deviceHasKey", new object[1] { keyCode });
	}

	public static bool RemoveCurrentActivity()
	{
		return AJC != null && AJC.CallStatic<bool>("removeCurrentActivity", new object[0]);
	}
}
