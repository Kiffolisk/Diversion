using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Prime31
{
	public static class IAP
	{
		private const string CONSUMABLE_PAYLOAD = "consume";

		private const string NON_CONSUMABLE_PAYLOAD = "nonconsume";

		public static List<GooglePurchase> androidPurchasedItems;

		private static Action<List<IAPProduct>> _productListReceivedAction;

		private static Action<bool, string> _purchaseCompletionAction;

		private static Action<string> _purchaseRestorationAction;

		[CompilerGenerated]
		private static Action<List<GooglePurchase>, List<GoogleSkuInfo>> _003C_003Ef__am_0024cache4;

		[CompilerGenerated]
		private static Action<string> _003C_003Ef__am_0024cache5;

		[CompilerGenerated]
		private static Action<GooglePurchase> _003C_003Ef__am_0024cache6;

		[CompilerGenerated]
		private static Action<string, int> _003C_003Ef__am_0024cache7;

		[CompilerGenerated]
		private static Action<GooglePurchase> _003C_003Ef__am_0024cache8;

		[CompilerGenerated]
		private static Action<string> _003C_003Ef__am_0024cache9;

		static IAP()
		{
			androidPurchasedItems = new List<GooglePurchase>();
			if (_003C_003Ef__am_0024cache4 == null)
			{
				_003C_003Ef__am_0024cache4 = _003CIAP_003Em__0;
			}
			GoogleIABManager.queryInventorySucceededEvent += _003C_003Ef__am_0024cache4;
			if (_003C_003Ef__am_0024cache5 == null)
			{
				_003C_003Ef__am_0024cache5 = _003CIAP_003Em__1;
			}
			GoogleIABManager.queryInventoryFailedEvent += _003C_003Ef__am_0024cache5;
			if (_003C_003Ef__am_0024cache6 == null)
			{
				_003C_003Ef__am_0024cache6 = _003CIAP_003Em__2;
			}
			GoogleIABManager.purchaseSucceededEvent += _003C_003Ef__am_0024cache6;
			if (_003C_003Ef__am_0024cache7 == null)
			{
				_003C_003Ef__am_0024cache7 = _003CIAP_003Em__3;
			}
			GoogleIABManager.purchaseFailedEvent += _003C_003Ef__am_0024cache7;
			if (_003C_003Ef__am_0024cache8 == null)
			{
				_003C_003Ef__am_0024cache8 = _003CIAP_003Em__4;
			}
			GoogleIABManager.consumePurchaseSucceededEvent += _003C_003Ef__am_0024cache8;
			if (_003C_003Ef__am_0024cache9 == null)
			{
				_003C_003Ef__am_0024cache9 = _003CIAP_003Em__5;
			}
			GoogleIABManager.consumePurchaseFailedEvent += _003C_003Ef__am_0024cache9;
		}

		public static void init(string androidPublicKey)
		{
			GoogleIAB.init(androidPublicKey);
		}

		public static void requestProductData(string[] iosProductIdentifiers, string[] androidSkus, Action<List<IAPProduct>> completionHandler)
		{
			_productListReceivedAction = completionHandler;
			GoogleIAB.queryInventory(androidSkus);
		}

		public static void purchaseConsumableProduct(string productId, Action<bool, string> completionHandler)
		{
			_purchaseCompletionAction = completionHandler;
			_purchaseRestorationAction = null;
			GoogleIAB.purchaseProduct(productId, "consume");
		}

		public static void purchaseNonconsumableProduct(string productId, Action<bool, string> completionHandler)
		{
			_purchaseCompletionAction = completionHandler;
			_purchaseRestorationAction = null;
			GoogleIAB.purchaseProduct(productId, "nonconsume");
		}

		public static void restoreCompletedTransactions(Action<string> completionHandler)
		{
			_purchaseCompletionAction = null;
			_purchaseRestorationAction = completionHandler;
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__0(List<GooglePurchase> purchases, List<GoogleSkuInfo> skus)
		{
			androidPurchasedItems = purchases;
			List<IAPProduct> list = new List<IAPProduct>();
			foreach (GoogleSkuInfo sku in skus)
			{
				list.Add(new IAPProduct(sku));
			}
			if (_productListReceivedAction != null)
			{
				_productListReceivedAction(list);
			}
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__1(string error)
		{
			Debug.Log("fetching prouduct data failed: " + error);
			if (_productListReceivedAction != null)
			{
				_productListReceivedAction(null);
			}
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__2(GooglePurchase purchase)
		{
			if (purchase.developerPayload == "nonconsume")
			{
				if (_purchaseCompletionAction != null)
				{
					_purchaseCompletionAction(true, null);
				}
			}
			else
			{
				GoogleIAB.consumeProduct(purchase.productId);
			}
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__3(string error, int response)
		{
			Debug.Log("purchase failed: " + error);
			if (_purchaseCompletionAction != null)
			{
				_purchaseCompletionAction(false, error);
			}
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__4(GooglePurchase purchase)
		{
			if (_purchaseCompletionAction != null)
			{
				_purchaseCompletionAction(true, null);
			}
		}

		[CompilerGenerated]
		private static void _003CIAP_003Em__5(string error)
		{
			if (_purchaseCompletionAction != null)
			{
				_purchaseCompletionAction(false, null);
			}
		}
	}
}
