using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VungleAndroidManager : MonoBehaviour
{
	[method: MethodImpl(32)]
	public static event Action onAdStartEvent;

	[method: MethodImpl(32)]
	public static event Action onAdEndEvent;

	[method: MethodImpl(32)]
	public static event Action onCachedAdAvailableEvent;

	[method: MethodImpl(32)]
	public static event Action<double, double> onVideoViewEvent;

	static VungleAndroidManager()
	{
		try
		{
			GameObject gameObject = new GameObject("VungleAndroidManager");
			gameObject.AddComponent<VungleAndroidManager>();
			UnityEngine.Object.DontDestroyOnLoad(gameObject);
		}
		catch (UnityException)
		{
			Debug.LogWarning("It looks like you have the VungleAndroidManager on a GameObject in your scene. Please remove the script from your scene.");
		}
	}

	public static void noop()
	{
	}

	private void onAdStart(string empty)
	{
		if (VungleAndroidManager.onAdStartEvent != null)
		{
			VungleAndroidManager.onAdStartEvent();
		}
	}

	private void onAdEnd(string empty)
	{
		if (VungleAndroidManager.onAdEndEvent != null)
		{
			VungleAndroidManager.onAdEndEvent();
		}
	}

	private void onCachedAdAvailable(string empty)
	{
		if (VungleAndroidManager.onCachedAdAvailableEvent != null)
		{
			VungleAndroidManager.onCachedAdAvailableEvent();
		}
	}

	private void onVideoView(string str)
	{
		if (VungleAndroidManager.onVideoViewEvent != null)
		{
			string[] array = str.Split('-');
			if (array.Length == 2)
			{
				VungleAndroidManager.onVideoViewEvent(double.Parse(array[0]) / 1000.0, double.Parse(array[1]) / 1000.0);
			}
		}
	}
}
