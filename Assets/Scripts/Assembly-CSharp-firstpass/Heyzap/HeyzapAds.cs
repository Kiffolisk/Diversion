using System;
using UnityEngine;

namespace Heyzap
{
	public class HeyzapAds : MonoBehaviour
	{
		public class NetworkCallback
		{
			public static string INITIALIZED = "initialized";

			public static string SHOW = "show";

			public static string AVAILABLE = "available";

			public static string HIDE = "hide";

			public static string FETCH_FAILED = "fetch_failed";

			public static string CLICK = "click";

			public static string DISMISS = "dismiss";

			public static string INCENTIVIZED_RESULT_COMPLETE = "incentivized_result_complete";

			public static string INCENTIVIZED_RESULT_INCOMPLETE = "incentivized_result_incomplete";

			public static string AUDIO_STARTING = "audio_starting";

			public static string AUDIO_FINISHED = "audio_finished";

			public static string BANNER_LOADED = "banner-loaded";

			public static string BANNER_CLICK = "banner-click";

			public static string BANNER_HIDE = "banner-hide";

			public static string BANNER_DISMISS = "banner-dismiss";

			public static string BANNER_FETCH_FAILED = "banner-fetch_failed";

			public static string LEAVE_APPLICATION = "leave_application";

			public static string FACEBOOK_LOGGING_IMPRESSION = "logging_impression";

			public static string CHARTBOOST_MOREAPPS_FETCH_FAILED = "moreapps-fetch_failed";

			public static string CHARTBOOST_MOREAPPS_HIDE = "moreapps-hide";

			public static string CHARTBOOST_MOREAPPS_DISMISS = "moreapps-dismiss";

			public static string CHARTBOOST_MOREAPPS_CLICK = "moreapps-click";

			public static string CHARTBOOST_MOREAPPS_SHOW = "moreapps-show";

			public static string CHARTBOOST_MOREAPPS_AVAILABLE = "moreapps-available";

			public static string CHARTBOOST_MOREAPPS_CLICK_FAILED = "moreapps-click_failed";
		}

		public class Network
		{
			public static string HEYZAP = "heyzap";

			public static string HEYZAP_CROSS_PROMO = "heyzap_cross_promo";

			public static string HEYZAP_EXCHANGE = "heyzap_exchange";

			public static string FACEBOOK = "facebook";

			public static string UNITYADS = "unityads";

			public static string APPLOVIN = "applovin";

			public static string VUNGLE = "vungle";

			public static string CHARTBOOST = "chartboost";

			public static string ADCOLONY = "adcolony";

			public static string ADMOB = "admob";

			public static string IAD = "iad";

			public static string LEADBOLT = "leadbolt";
		}

		public delegate void NetworkCallbackListener(string network, string callback);

		public const string DEFAULT_TAG = "default";

		private static NetworkCallbackListener networkCallbackListener;

		private static HeyzapAds _instance = null;

		public static int FLAG_NO_OPTIONS = 0;

		public static int FLAG_DISABLE_AUTOMATIC_FETCHING = 1;

		public static int FLAG_INSTALL_TRACKING_ONLY = 2;

		public static int FLAG_AMAZON = 4;

		public static int FLAG_DISABLE_MEDIATION = 8;

		public static int FLAG_DISABLE_AUTOMATIC_IAP_RECORDING = 16;

		[Obsolete("Use FLAG_AMAZON instead - we refactored the flags to be consistently named.")]
		public static int AMAZON = FLAG_AMAZON;

		[Obsolete("Use FLAG_DISABLE_MEDIATION instead - we refactored the flags to be consistently named.")]
		public static int DISABLE_MEDIATION = FLAG_DISABLE_MEDIATION;

		public static void Start(string publisher_id, int options)
		{
			HeyzapAdsAndroid.Start(publisher_id, options);
			InitReceiver();
			HZInterstitialAd.InitReceiver();
			HZVideoAd.InitReceiver();
			HZIncentivizedAd.InitReceiver();
			HZBannerAd.InitReceiver();
		}

		public static string GetRemoteData()
		{
			return HeyzapAdsAndroid.GetRemoteData();
		}

		public static void ShowMediationTestSuite()
		{
			HeyzapAdsAndroid.ShowMediationTestSuite();
		}

		public static bool OnBackPressed()
		{
			return HeyzapAdsAndroid.OnBackPressed();
		}

		public static bool IsNetworkInitialized(string network)
		{
			return HeyzapAdsAndroid.IsNetworkInitialized(network);
		}

		public static void SetNetworkCallbackListener(NetworkCallbackListener listener)
		{
			networkCallbackListener = listener;
		}

		public static void PauseExpensiveWork()
		{
		}

		public static void ResumeExpensiveWork()
		{
		}

		public static void ShowDebugLogs()
		{
			HeyzapAdsAndroid.ShowDebugLogs();
		}

		public static void HideDebugLogs()
		{
			HeyzapAdsAndroid.HideDebugLogs();
		}

		public static void ShowThirdPartyDebugLogs()
		{
		}

		public static void HideThirdPartyDebugLogs()
		{
		}

		public void SetNetworkCallbackMessage(string message)
		{
			string[] array = message.Split(',');
			SetNetworkCallback(array[0], array[1]);
		}

		protected static void SetNetworkCallback(string network, string callback)
		{
			if (networkCallbackListener != null)
			{
				networkCallbackListener(network, callback);
			}
		}

		public static void InitReceiver()
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("HeyzapAds");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_instance = gameObject.AddComponent<HeyzapAds>();
			}
		}

		public static string TagForString(string tag)
		{
			if (tag == null)
			{
				tag = "default";
			}
			return tag;
		}

		[Obsolete("Use the Start() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void start(string publisher_id, int options)
		{
			Start(publisher_id, options);
		}

		[Obsolete("Use the GetRemoteData() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static string getRemoteData()
		{
			return GetRemoteData();
		}

		[Obsolete("Use the ShowMediationTestSuite() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void showMediationTestSuite()
		{
			ShowMediationTestSuite();
		}

		[Obsolete("Use the IsNetworkInitialized(String) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isNetworkInitialized(string network)
		{
			return IsNetworkInitialized(network);
		}

		[Obsolete("Use the SetNetworkCallbackListener(NetworkCallbackListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setNetworkCallbackListener(NetworkCallbackListener listener)
		{
			SetNetworkCallbackListener(listener);
		}

		[Obsolete("Use the PauseExpensiveWork() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void pauseExpensiveWork()
		{
			PauseExpensiveWork();
		}

		[Obsolete("Use the ResumeExpensiveWork() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void resumeExpensiveWork()
		{
			ResumeExpensiveWork();
		}

		[Obsolete("Use the ShowDebugLogs() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void showDebugLogs()
		{
			ShowDebugLogs();
		}

		[Obsolete("Use the HideDebugLogs() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void hideDebugLogs()
		{
			HideDebugLogs();
		}

		[Obsolete("Use the OnBackPressed() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool onBackPressed()
		{
			return OnBackPressed();
		}
	}
}
