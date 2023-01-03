using System;
using UnityEngine;

namespace Heyzap
{
	public class HZVideoAd : MonoBehaviour
	{
		public delegate void AdDisplayListener(string state, string tag);

		private static AdDisplayListener adDisplayListener;

		private static HZVideoAd _instance;

		public static void Show()
		{
			ShowWithOptions(null);
		}

		public static void ShowWithOptions(HZShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZShowOptions();
			}
			HZVideoAdAndroid.ShowWithOptions(showOptions);
		}

		public static void Fetch()
		{
			Fetch(null);
		}

		public static void Fetch(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			HZVideoAdAndroid.Fetch(tag);
		}

		public static bool IsAvailable()
		{
			return IsAvailable(null);
		}

		public static bool IsAvailable(string tag)
		{
			tag = HeyzapAds.TagForString(tag);
			return HZVideoAdAndroid.IsAvailable(tag);
		}

		public static void SetDisplayListener(AdDisplayListener listener)
		{
			adDisplayListener = listener;
		}

		public static void InitReceiver()
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("HZVideoAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_instance = gameObject.AddComponent<HZVideoAd>();
			}
		}

		public void SetCallback(string message)
		{
			string[] array = message.Split(',');
			SetCallbackStateAndTag(array[0], array[1]);
		}

		protected static void SetCallbackStateAndTag(string state, string tag)
		{
			if (adDisplayListener != null)
			{
				adDisplayListener(state, tag);
			}
		}

		[Obsolete("Use the Fetch() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch()
		{
			Fetch();
		}

		[Obsolete("Use the Fetch(string) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void fetch(string tag)
		{
			Fetch(tag);
		}

		[Obsolete("Use the Show() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void show()
		{
			Show();
		}

		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string tag)
		{
			HZIncentivizedShowOptions hZIncentivizedShowOptions = new HZIncentivizedShowOptions();
			hZIncentivizedShowOptions.Tag = tag;
			ShowWithOptions(hZIncentivizedShowOptions);
		}

		[Obsolete("Use the IsAvailable() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable()
		{
			return IsAvailable();
		}

		[Obsolete("Use the IsAvailable(tag) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool isAvailable(string tag)
		{
			return IsAvailable(tag);
		}

		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(AdDisplayListener listener)
		{
			SetDisplayListener(listener);
		}
	}
}
