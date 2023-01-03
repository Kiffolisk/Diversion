using System.Collections;
using System.Runtime.CompilerServices;
using UnityEngine;

public class eScreen : MonoBehaviour
{
	public delegate void ScreenEventHandler();

	public static eScreen Instance;

	public static bool isLandscape = true;

	[method: MethodImpl(32)]
	public static event ScreenEventHandler onScreenChanged;

	public static void Initialize()
	{
		Init();
	}

	private static void Init()
	{
		if (Instance == null)
		{
			GameObject gameObject = new GameObject("eScreen");
			Instance = gameObject.AddComponent(typeof(eScreen)) as eScreen;
		}
	}

	private void Awake()
	{
		Object.DontDestroyOnLoad(this);
		StartCoroutine(OrientationCheck());
	}

	private IEnumerator OrientationCheck()
	{
		while (true)
		{
			bool wasLandscape = isLandscape;
			if (Screen.width > Screen.height)
			{
				isLandscape = true;
			}
			else
			{
				isLandscape = false;
			}
			if (wasLandscape != isLandscape && eScreen.onScreenChanged != null)
			{
				eScreen.onScreenChanged();
			}
			yield return new WaitForSeconds(0.5f);
		}
	}
}
