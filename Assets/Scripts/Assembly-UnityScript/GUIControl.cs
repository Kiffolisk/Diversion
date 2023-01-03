using System;
using UnityEngine;

[Serializable]
public class GUIControl : MonoBehaviour
{
	public TextMesh pauseGUI;

	public TextMesh healthGUI;

	public TextMesh gemGUI;

	public TextMesh boostGUI;

	public TextMesh x2GUI;

	public TextMesh starGUI;

	private GameControl gameControl;

	private TextMesh textMesh;

	private float unlockTime;

	private Vector3 unlockStartPos;

	private int unlockLast;

	private int unlockYincr;

	private int lastBoost;

	private Vector2 screenScale;

	private float screenRatio;

	private Vector2 pauseOffset;

	private Vector3 pauseGUIO;

	private Vector3 x2GUIO;

	private Vector3 starGUIO;

	private Vector3 gemGUIO;

	private Vector3 boostGUIO;

	public GUIControl()
	{
		screenRatio = 1.5f;
	}

	public virtual void Awake()
	{
		eScreen.Initialize();
		eScreen.onScreenChanged += ScreenChanged;
	}

	public virtual void ScreenChanged()
	{
		Resize();
	}

	public virtual void Start()
	{
		useGUILayout = false;
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		pauseGUIO = pauseGUI.transform.localPosition;
		x2GUIO = x2GUI.transform.localPosition;
		starGUIO = starGUI.transform.localPosition;
		gemGUIO = gemGUI.transform.localPosition;
		boostGUIO = boostGUI.transform.localPosition;
		Resize();
	}

	public virtual void Resize()
	{
		screenScale = new Vector2((float)Screen.width / 960f, (float)Screen.height / 640f);
		screenRatio = (float)Screen.width * 1f / (float)Screen.height;
		pauseOffset = new Vector2((float)Screen.width - 100f * screenScale.x, (float)Screen.height - 100f * screenScale.y);
		if ((bool)pauseGUI)
		{
			float x = pauseGUIO.x + (screenRatio - 1.5f) * 8.27f;
			Vector3 localPosition = pauseGUI.transform.localPosition;
			float num = (localPosition.x = x);
			Vector3 vector2 = (pauseGUI.transform.localPosition = localPosition);
		}
		if ((bool)x2GUI)
		{
			float x2 = x2GUIO.x + (screenRatio - 1.5f) * 8.27f;
			Vector3 localPosition2 = x2GUI.transform.localPosition;
			float num2 = (localPosition2.x = x2);
			Vector3 vector4 = (x2GUI.transform.localPosition = localPosition2);
		}
		if ((bool)starGUI)
		{
			float x3 = starGUIO.x + (screenRatio - 1.5f) * 8.27f;
			Vector3 localPosition3 = starGUI.transform.localPosition;
			float num3 = (localPosition3.x = x3);
			Vector3 vector6 = (starGUI.transform.localPosition = localPosition3);
		}
		if ((bool)gemGUI)
		{
			float x4 = gemGUIO.x + (screenRatio - 1.5f) * 8.27f;
			Vector3 localPosition4 = gemGUI.transform.localPosition;
			float num4 = (localPosition4.x = x4);
			Vector3 vector8 = (gemGUI.transform.localPosition = localPosition4);
		}
		if ((bool)boostGUI)
		{
			float x5 = boostGUIO.x - (screenRatio - 1.5f) * 8.27f;
			Vector3 localPosition5 = boostGUI.transform.localPosition;
			float num5 = (localPosition5.x = x5);
			Vector3 vector10 = (boostGUI.transform.localPosition = localPosition5);
		}
		if (eInput.controlType != "touch" && (bool)x2GUI)
		{
			float y = x2GUIO.y + 1.1f;
			Vector3 localPosition6 = x2GUI.transform.localPosition;
			float num6 = (localPosition6.y = y);
			Vector3 vector12 = (x2GUI.transform.localPosition = localPosition6);
		}
		if (gameControl.devicemodel == "ouya")
		{
			if ((bool)x2GUI)
			{
				x2GUI.transform.localPosition = x2GUI.transform.localPosition + new Vector3(-0.5f, -0.5f, 0f);
			}
			if ((bool)starGUI)
			{
				starGUI.transform.localPosition = starGUI.transform.localPosition + new Vector3(-0.5f, 0.5f, 0f);
			}
			if ((bool)gemGUI)
			{
				gemGUI.transform.localPosition = gemGUI.transform.localPosition + new Vector3(-0.5f, -0.5f, 0f);
			}
			if ((bool)boostGUI)
			{
				boostGUI.transform.localPosition = boostGUI.transform.localPosition + new Vector3(0.5f, 0.5f, 0f);
			}
		}
	}

	public virtual void HideAll()
	{
		if ((bool)healthGUI)
		{
			healthGUI.text = string.Empty;
		}
		if ((bool)gemGUI)
		{
			gemGUI.text = string.Empty;
		}
		if ((bool)boostGUI)
		{
			boostGUI.text = string.Empty;
		}
		if ((bool)x2GUI)
		{
			x2GUI.text = string.Empty;
		}
		if ((bool)pauseGUI)
		{
			pauseGUI.text = string.Empty;
		}
		if ((bool)starGUI)
		{
			starGUI.text = string.Empty;
		}
	}

	public virtual void Update()
	{
		string empty = string.Empty;
		string empty2 = string.Empty;
		if (!gameControl.missionStarted)
		{
			HideAll();
			return;
		}
		if ((bool)pauseGUI)
		{
			empty = "k";
			if (gameControl.missionOver || eInput.controlType != "touch")
			{
				empty = string.Empty;
			}
			pauseGUI.text = empty;
			if (empty == "k" && Input.GetMouseButtonDown(0) && !(Input.mousePosition.x <= pauseOffset.x) && !(Input.mousePosition.y <= pauseOffset.y))
			{
				MenuControl menuControl = null;
				menuControl = (MenuControl)UnityEngine.Object.FindObjectOfType(typeof(MenuControl));
				if ((bool)menuControl && !gameControl.disableInput)
				{
					menuControl.menu = "missionPause";
					StartCoroutine(gameControl.PauseGame(true));
				}
			}
		}
		if ((bool)x2GUI)
		{
			empty = string.Empty;
			if (gameControl.playerControl.x2 > 0)
			{
				empty = "b";
			}
			if (gameControl.missionOver)
			{
				empty = string.Empty;
			}
			if (empty != x2GUI.text)
			{
				x2GUI.text = empty;
				x2GUI.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
			if (!(x2GUI.transform.localScale.x <= 1f))
			{
				x2GUI.transform.localScale = x2GUI.transform.localScale * 0.9f;
			}
		}
		if ((bool)healthGUI)
		{
			empty = string.Empty;
			if (!gameControl.missionOver)
			{
				for (int num = 3; num > 0; num--)
				{
					empty = ((gameControl.playerControl.health < num) ? (empty + "g ") : (empty + "h "));
				}
			}
			if (empty != healthGUI.text)
			{
				healthGUI.text = empty;
				healthGUI.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
			if (!(healthGUI.transform.localScale.x <= 1f))
			{
				healthGUI.transform.localScale = healthGUI.transform.localScale * 0.9f;
			}
		}
		if ((bool)boostGUI)
		{
			empty = ((gameControl.playerControl.boost > 0f) ? ("d " + Mathf.Round(gameControl.playerControl.boost)) : string.Empty);
			if (gameControl.missionOver)
			{
				empty = string.Empty;
			}
			if (empty != boostGUI.text)
			{
				boostGUI.text = empty;
				if (!((float)lastBoost >= Mathf.Round(gameControl.playerControl.boost)))
				{
					boostGUI.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
				}
				lastBoost = (int)Mathf.Round(gameControl.playerControl.boost);
			}
			if (!(boostGUI.transform.localScale.x <= 1f))
			{
				boostGUI.transform.localScale = boostGUI.transform.localScale * 0.9f;
			}
		}
		if ((bool)starGUI)
		{
			empty = string.Empty;
			if (gameControl.missionStar == 1)
			{
				empty = "i i j";
			}
			if (gameControl.missionStar == 2)
			{
				empty = "i j j";
			}
			if (gameControl.missionStar == 3)
			{
				empty = "j j j";
			}
			if (gameControl.missionOver)
			{
				empty = string.Empty;
			}
			if (empty != starGUI.text)
			{
				starGUI.text = empty;
				starGUI.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
			if (!(starGUI.transform.localScale.x <= 1f))
			{
				starGUI.transform.localScale = starGUI.transform.localScale * 0.9f;
			}
		}
		if ((bool)gemGUI)
		{
			empty = ((!gameControl.showTotalGems) ? (gameControl.missionGem + " f") : (string.Empty + (gameControl.missionGem + gameControl.playerControl.playerData.gems) + " f"));
			if (gameControl.missionOver)
			{
				empty = string.Empty;
			}
			if (empty != gemGUI.text)
			{
				gemGUI.text = empty;
				gemGUI.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			}
			if (!(gemGUI.transform.localScale.x <= 1f))
			{
				gemGUI.transform.localScale = gemGUI.transform.localScale * 0.9f;
			}
		}
	}

	public virtual void Main()
	{
	}
}
