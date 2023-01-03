using UnityEngine;

public class VungleComboUI : MonoBehaviour
{
	private void OnGUI()
	{
		beginGuiColomn();
		if (GUILayout.Button("Start"))
		{
			Vungle.init("com.prime31.Vungle", "vungleTest");
		}
		if (GUILayout.Button("Is Ad Available"))
		{
			Debug.Log("is ad available: " + Vungle.isAdvertAvailable());
		}
		if (GUILayout.Button("Disable Sound"))
		{
			Vungle.setSoundEnabled(false);
		}
		if (GUILayout.Button("Display Ad"))
		{
			Vungle.playAd(false, string.Empty);
		}
		if (GUILayout.Button("Display Insentivized Ad"))
		{
			Vungle.playAd(true, "user-tag");
		}
		endGuiColumn();
	}

	private void OnEnable()
	{
		Vungle.onAdStartedEvent += onAdStartedEvent;
		Vungle.onAdEndedEvent += onAdEndedEvent;
		Vungle.onAdViewedEvent += onAdViewedEvent;
		Vungle.onCachedAdAvailableEvent += onCachedAdAvailableEvent;
	}

	private void OnDisable()
	{
		Vungle.onAdStartedEvent -= onAdStartedEvent;
		Vungle.onAdEndedEvent -= onAdEndedEvent;
		Vungle.onAdViewedEvent -= onAdViewedEvent;
		Vungle.onCachedAdAvailableEvent -= onCachedAdAvailableEvent;
	}

	private void onAdStartedEvent()
	{
		Debug.Log("onAdStartedEvent");
	}

	private void onAdEndedEvent()
	{
		Debug.Log("onAdEndedEvent");
	}

	private void onAdViewedEvent(double watched, double length)
	{
		Debug.Log("onAdViewedEvent. watched: " + watched + ", length: " + length);
	}

	private void onCachedAdAvailableEvent()
	{
		Debug.Log("onCachedAdAvailableEvent");
	}

	private void beginGuiColomn()
	{
		int num = ((Screen.width < 960 && Screen.height < 960) ? 30 : 70);
		GUI.skin.label.fixedHeight = num;
		GUI.skin.label.margin = new RectOffset(0, 0, 10, 0);
		GUI.skin.label.alignment = TextAnchor.MiddleCenter;
		GUI.skin.button.margin = new RectOffset(0, 0, 10, 0);
		GUI.skin.button.fixedHeight = num;
		GUI.skin.button.fixedWidth = Screen.width / 2 - 20;
		GUI.skin.button.wordWrap = true;
		GUILayout.BeginArea(new Rect(10f, 10f, Screen.width / 2, Screen.height));
		GUILayout.BeginVertical();
	}

	private void endGuiColumn(bool hasSecondColumn = false)
	{
		GUILayout.EndVertical();
		GUILayout.EndArea();
		if (hasSecondColumn)
		{
			GUILayout.BeginArea(new Rect(Screen.width - Screen.width / 2, 10f, Screen.width / 2, Screen.height));
			GUILayout.BeginVertical();
		}
	}
}
