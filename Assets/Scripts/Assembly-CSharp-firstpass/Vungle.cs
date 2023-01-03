using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class Vungle
{
	[method: MethodImpl(32)]
	public static event Action onAdStartedEvent;

	[method: MethodImpl(32)]
	public static event Action onAdEndedEvent;

	[method: MethodImpl(32)]
	public static event Action onCachedAdAvailableEvent;

	[method: MethodImpl(32)]
	public static event Action<double, double> onAdViewedEvent;

	[method: MethodImpl(32)]
	public static event Action<string> onLogEvent;

	static Vungle()
	{
		VungleAndroidManager.onAdStartEvent += adStarted;
		VungleAndroidManager.onAdEndEvent += adFinished;
		VungleAndroidManager.onVideoViewEvent += videoViewed;
		VungleAndroidManager.onCachedAdAvailableEvent += onCachedAdAvailable;
	}

	private static void adStarted()
	{
		if (Vungle.onAdStartedEvent != null)
		{
			Vungle.onAdStartedEvent();
		}
	}

	private static void adFinished()
	{
		if (Vungle.onAdEndedEvent != null)
		{
			Vungle.onAdEndedEvent();
		}
	}

	private static void videoViewed(double timeWatched, double totalDuration)
	{
		if (Vungle.onAdViewedEvent != null)
		{
			Vungle.onAdViewedEvent(timeWatched, totalDuration);
		}
	}

	private static void vungleMoviePlayedEvent(Dictionary<string, object> data)
	{
		adFinished();
		bool flag = bool.Parse(data["completedView"].ToString());
		double num = double.Parse(data["playTime"].ToString());
		double arg = ((!flag) ? (num * 2.0) : num);
		if (Vungle.onAdViewedEvent != null)
		{
			Vungle.onAdViewedEvent(num, arg);
		}
	}

	private static void onCachedAdAvailable()
	{
		if (Vungle.onCachedAdAvailableEvent != null)
		{
			Vungle.onCachedAdAvailableEvent();
		}
	}

	private static void onLog(string log)
	{
		if (Vungle.onLogEvent != null)
		{
			Vungle.onLogEvent(log);
		}
	}

	public static void init(string androidAppId, string iosAppId)
	{
		VungleAndroid.init(androidAppId);
	}

	public static void setSoundEnabled(bool isEnabled)
	{
		VungleAndroid.setSoundEnabled(isEnabled);
	}

	public static bool isAdvertAvailable()
	{
		return VungleAndroid.isVideoAvailable();
	}

	public static void playAd(bool incentivized = false, string user = "", int orientation = 6)
	{
		VungleAndroid.playAd(incentivized, user);
	}

	public static void playAdWithOptions(Dictionary<string, object> options)
	{
		VungleAndroid.playAdEx(options);
	}

	public static void clearCache()
	{
	}

	public static void clearSleep()
	{
	}

	public static void setEndPoint(string endPoint)
	{
	}

	public static void setLogEnable(bool enable)
	{
	}

	public static string getEndPoint()
	{
		return string.Empty;
	}
}
