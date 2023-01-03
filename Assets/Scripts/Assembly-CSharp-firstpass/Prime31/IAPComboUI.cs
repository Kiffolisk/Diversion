using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Prime31
{
	public class IAPComboUI : MonoBehaviourGUI
	{
		[CompilerGenerated]
		private sealed class _003COnGUI_003Ec__AnonStorey1
		{
			internal string productId;

			internal void _003C_003Em__8(bool didSucceed, string error)
			{
				Debug.Log("purchasing product " + productId + " result: " + didSucceed);
				if (!didSucceed)
				{
					Debug.Log("purchase error: " + error);
				}
			}
		}

		[CompilerGenerated]
		private sealed class _003COnGUI_003Ec__AnonStorey2
		{
			internal string productId;

			internal void _003C_003Em__9(bool didSucceed, string error)
			{
				Debug.Log("purchasing product " + productId + " result: " + didSucceed);
				if (!didSucceed)
				{
					Debug.Log("purchase error: " + error);
				}
			}
		}

		[CompilerGenerated]
		private static Action<List<IAPProduct>> _003C_003Ef__am_0024cache0;

		[CompilerGenerated]
		private static Action<string> _003C_003Ef__am_0024cache1;

		private void OnGUI()
		{
			beginColumn();
			if (GUILayout.Button("Init IAP System"))
			{
				string text = "your public key from the Android developer portal here";
				text = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAmffbbQPr/zqRjP3vkxr1601/eKsXm5kO2NzQge8m7PeUj5V+saeounyL34U8WoZ3BvCRKbw6DrRLs2DMoVuCLq7QtJggBHT/bBSHGczEXGIPjWpw6OQb24EWM0PaTRTH2x2mC/X6RwIKcPLJFmy68T38Eh0DXnF4jjiIoaD0W8AYLjLzv0WvbIfgtJlvmmwvI2/Kta1LRnW3/Ggi5jb9UmXZAUIBz8kQtSH5FUCmFOQHMzekfg8rQ4VO1nlWhnB58UPwsxWt/DNyDfqv2VMeA2+VJG0fkiMl/6vWA7+ianVTU3owXcvxJHseEDUVYo1wEKfhK7ErGB7sxDJx5wHXAwIDAQAB";
				IAP.init(text);
			}
			if (GUILayout.Button("Request Product Data"))
			{
				string[] androidSkus = new string[5] { "com.prime31.testproduct", "android.test.purchased", "android.test.purchased2", "com.prime31.managedproduct", "com.prime31.testsubscription" };
				string[] iosProductIdentifiers = new string[5] { "anotherProduct", "tt", "testProduct", "sevenDays", "oneMonthSubsciber" };
				if (_003C_003Ef__am_0024cache0 == null)
				{
					_003C_003Ef__am_0024cache0 = _003COnGUI_003Em__6;
				}
				IAP.requestProductData(iosProductIdentifiers, androidSkus, _003C_003Ef__am_0024cache0);
			}
			if (GUILayout.Button("Restore Transactions (iOS only)"))
			{
				if (_003C_003Ef__am_0024cache1 == null)
				{
					_003C_003Ef__am_0024cache1 = _003COnGUI_003Em__7;
				}
				IAP.restoreCompletedTransactions(_003C_003Ef__am_0024cache1);
			}
			if (GUILayout.Button("Purchase Consumable"))
			{
				_003COnGUI_003Ec__AnonStorey1 _003COnGUI_003Ec__AnonStorey = new _003COnGUI_003Ec__AnonStorey1();
				_003COnGUI_003Ec__AnonStorey.productId = "android.test.purchased";
				IAP.purchaseConsumableProduct(_003COnGUI_003Ec__AnonStorey.productId, _003COnGUI_003Ec__AnonStorey._003C_003Em__8);
			}
			if (GUILayout.Button("Purchase Non-Consumable"))
			{
				_003COnGUI_003Ec__AnonStorey2 _003COnGUI_003Ec__AnonStorey2 = new _003COnGUI_003Ec__AnonStorey2();
				_003COnGUI_003Ec__AnonStorey2.productId = "android.test.purchased2";
				IAP.purchaseNonconsumableProduct(_003COnGUI_003Ec__AnonStorey2.productId, _003COnGUI_003Ec__AnonStorey2._003C_003Em__9);
			}
			endColumn();
		}

		[CompilerGenerated]
		private static void _003COnGUI_003Em__6(List<IAPProduct> productList)
		{
			Debug.Log("Product list received");
			Utils.logObject(productList);
		}

		[CompilerGenerated]
		private static void _003COnGUI_003Em__7(string productId)
		{
			Debug.Log("restored purchased product: " + productId);
		}
	}
}
