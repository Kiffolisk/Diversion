using UnityEngine;

namespace Heyzap
{
	public class HeyzapAdsAndroid : MonoBehaviour
	{
		public static void Start(string publisher_id, int options = 0)
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("start", publisher_id, options);
			}
		}

		public static bool IsNetworkInitialized(string network)
		{
			//Discarded unreachable code: IL_003a
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				return androidJavaClass.CallStatic<bool>("isNetworkInitialized", new object[1] { network });
			}
		}

		public static bool OnBackPressed()
		{
			//Discarded unreachable code: IL_0036
			if (Application.platform != RuntimePlatform.Android)
			{
				return false;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				return androidJavaClass.CallStatic<bool>("onBackPressed", new object[0]);
			}
		}

		public static void ShowMediationTestSuite()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showNetworkActivity");
			}
		}

		public static string GetRemoteData()
		{
			//Discarded unreachable code: IL_003a
			if (Application.platform != RuntimePlatform.Android)
			{
				return "{}";
			}
			AndroidJNIHelper.debug = false;
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				return androidJavaClass.CallStatic<string>("getCustomPublisherData", new object[0]);
			}
		}

		public static void ShowDebugLogs()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("showDebugLogs");
			}
		}

		public static void HideDebugLogs()
		{
			if (Application.platform != RuntimePlatform.Android)
			{
				return;
			}
			using (AndroidJavaClass androidJavaClass = new AndroidJavaClass("com.heyzap.sdk.extensions.unity3d.UnityHelper"))
			{
				androidJavaClass.CallStatic("hideDebugLogs");
			}
		}
	}
}
