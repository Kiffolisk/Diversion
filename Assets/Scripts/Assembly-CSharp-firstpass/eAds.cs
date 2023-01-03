using System.Runtime.CompilerServices;
using Heyzap;
using UnityEngine;

public class eAds : MonoBehaviour
{
	public delegate void AdEventHandler();

	private static bool debug;

	private static float interTimer;

	private static float secondsBetweenInters = 180f;

	private static float videoTimer;

	private static float secondsBetweenVideos = 120f;

	private static bool bannerWanted;

	public static bool videoReady;

	public static eAds Instance;

	[CompilerGenerated]
	private static HZIncentivizedAd.AdDisplayListener _003C_003Ef__am_0024cacheA;

	[CompilerGenerated]
	private static HZBannerAd.AdDisplayListener _003C_003Ef__am_0024cacheB;

	[method: MethodImpl(32)]
	public static event AdEventHandler onVideoSuccess;

	[method: MethodImpl(32)]
	public static event AdEventHandler onVideoFailed;

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
	}

	public static void Initialize()
	{
		if (Instance == null)
		{
			GameObject gameObject = new GameObject("eAds");
			Instance = gameObject.AddComponent(typeof(eAds)) as eAds;
			HeyzapAds.Start("73ea8cadec6197df8b6ad78468642483", HeyzapAds.FLAG_NO_OPTIONS);
			if (_003C_003Ef__am_0024cacheA == null)
			{
				_003C_003Ef__am_0024cacheA = _003CInitialize_003Em__B;
			}
			HZIncentivizedAd.SetDisplayListener(_003C_003Ef__am_0024cacheA);
			if (_003C_003Ef__am_0024cacheB == null)
			{
				_003C_003Ef__am_0024cacheB = _003CInitialize_003Em__C;
			}
			HZBannerAd.SetDisplayListener(_003C_003Ef__am_0024cacheB);
			InitTimer();
		}
	}

	private static void InitTimer()
	{
		videoTimer = Time.realtimeSinceStartup - secondsBetweenVideos;
		interTimer = Time.realtimeSinceStartup - secondsBetweenInters;
		if (debug)
		{
			Debug.Log("EADS: InitTimer: " + videoTimer + ", " + Time.realtimeSinceStartup);
		}
	}

	public static void ShowTest()
	{
		if (debug)
		{
			HeyzapAds.ShowMediationTestSuite();
		}
	}

	public static void VideoShow(bool incentivized)
	{
		HZIncentivizedAd.Show();
		videoTimer = Time.realtimeSinceStartup;
		if (debug)
		{
			Debug.Log("EADS: VideoShow - ");
		}
	}

	public static void InterShow()
	{
		if (!(Time.realtimeSinceStartup - interTimer < secondsBetweenInters) || debug)
		{
			interTimer = Time.realtimeSinceStartup;
			HZInterstitialAd.Show();
			if (debug)
			{
				Debug.Log("EADS: InterShow - ");
			}
		}
	}

	public static void BannerShow(bool show)
	{
		bannerWanted = show;
		if (show)
		{
			HZBannerShowOptions hZBannerShowOptions = new HZBannerShowOptions();
			hZBannerShowOptions.Position = "bottom";
			HZBannerAd.ShowWithOptions(hZBannerShowOptions);
		}
		else
		{
			HZBannerAd.Destroy();
		}
		if (debug)
		{
			Debug.Log("EADS: Banner: " + show);
		}
	}

	public static void VideoSuccess()
	{
		if (eAds.onVideoSuccess != null)
		{
			eAds.onVideoSuccess();
		}
		if (debug)
		{
			Debug.Log("EADS: VideoSuccess");
		}
	}

	public static void VideoFailed()
	{
		if (eAds.onVideoFailed != null)
		{
			eAds.onVideoFailed();
		}
		if (debug)
		{
			Debug.Log("EADS: VideoFailed");
		}
	}

	public static bool VideoIsReady()
	{
		bool flag = false;
		flag = HZIncentivizedAd.IsAvailable();
		if (!flag)
		{
			HZIncentivizedAd.Fetch();
		}
		if (Application.isEditor)
		{
			flag = true;
		}
		if (Time.realtimeSinceStartup - videoTimer < secondsBetweenVideos && !debug)
		{
			if (debug)
			{
				Debug.Log("EADS: videoTimer not ready " + (Time.realtimeSinceStartup - videoTimer));
			}
			flag = false;
		}
		if (debug)
		{
			Debug.Log("EADS: VideoIsReady - " + flag);
		}
		return flag;
	}

	private static void Update()
	{
		if (Input.GetKeyUp(KeyCode.Escape) && !HeyzapAds.OnBackPressed())
		{
		}
	}

	public static void MoreGames()
	{
		ShowTest();
		if (!debug)
		{
			Application.OpenURL("http://ezone.com/moreapps");
		}
	}

	[CompilerGenerated]
	private static void _003CInitialize_003Em__B(string adState, string adTag)
	{
		if (adState.Equals("incentivized_result_complete"))
		{
			VideoSuccess();
		}
		if (adState.Equals("incentivized_result_incomplete"))
		{
			VideoFailed();
		}
	}

	[CompilerGenerated]
	private static void _003CInitialize_003Em__C(string adState, string adTag)
	{
		if (adState == "loaded" && !bannerWanted)
		{
			BannerShow(false);
		}
	}
}
