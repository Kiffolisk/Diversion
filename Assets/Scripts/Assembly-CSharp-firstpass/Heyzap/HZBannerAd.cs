using System;
using UnityEngine;

namespace Heyzap
{
	public class HZBannerAd : MonoBehaviour
	{
		public delegate void AdDisplayListener(string state, string tag);

		[Obsolete("This constant has been relocated to HZBannerShowOptions")]
		public const string POSITION_TOP = "top";

		[Obsolete("This constant has been relocated to HZBannerShowOptions")]
		public const string POSITION_BOTTOM = "bottom";

		private static AdDisplayListener adDisplayListener;

		private static HZBannerAd _instance;

		public static void ShowWithOptions(HZBannerShowOptions showOptions)
		{
			if (showOptions == null)
			{
				showOptions = new HZBannerShowOptions();
			}
			HZBannerAdAndroid.ShowWithOptions(showOptions);
		}

		public static bool GetCurrentBannerDimensions(out Rect banner)
		{
			return HZBannerAdAndroid.GetCurrentBannerDimensions(out banner);
		}

		public static void Hide()
		{
			HZBannerAdAndroid.Hide();
		}

		public static void Destroy()
		{
			HZBannerAdAndroid.Destroy();
		}

		public static void SetDisplayListener(AdDisplayListener listener)
		{
			adDisplayListener = listener;
		}

		public static void InitReceiver()
		{
			if (_instance == null)
			{
				GameObject gameObject = new GameObject("HZBannerAd");
				UnityEngine.Object.DontDestroyOnLoad(gameObject);
				_instance = gameObject.AddComponent<HZBannerAd>();
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

		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void showWithTag(string position, string tag)
		{
			HZBannerShowOptions hZBannerShowOptions = new HZBannerShowOptions();
			hZBannerShowOptions.Position = position;
			hZBannerShowOptions.Tag = tag;
			ShowWithOptions(hZBannerShowOptions);
		}

		[Obsolete("Use ShowWithOptions() to show ads instead of this deprecated method.")]
		public static void show(string position)
		{
			HZBannerShowOptions hZBannerShowOptions = new HZBannerShowOptions();
			hZBannerShowOptions.Position = position;
			ShowWithOptions(hZBannerShowOptions);
		}

		[Obsolete("Use the GetCurrentBannerDimensions(out Rect) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static bool getCurrentBannerDimensions(out Rect banner)
		{
			return GetCurrentBannerDimensions(out banner);
		}

		[Obsolete("Use the Hide() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void hide()
		{
			Hide();
		}

		[Obsolete("Use the Destroy() method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void destroy()
		{
			Destroy();
		}

		[Obsolete("Use the SetDisplayListener(AdDisplayListener) method instead - it uses the proper PascalCase for C#. Older versions of our SDK used incorrect casing.")]
		public static void setDisplayListener(AdDisplayListener listener)
		{
			SetDisplayListener(listener);
		}
	}
}
