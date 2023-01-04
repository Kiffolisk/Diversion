using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MenuControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartKeyboard_0024581 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024done_0024582;

			internal string _0024startText_0024583;

			internal MenuControl _0024self__0024584;

			public _0024(string startText, MenuControl self_)
			{
				_0024startText_0024583 = startText;
				_0024self__0024584 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					TouchScreenKeyboard.hideInput = true;
					_0024self__0024584.enteredCode = _0024startText_0024583;
					_0024self__0024584.keyboardActive = false;
					_0024done_0024582 = Time.realtimeSinceStartup + 0.5f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024done_0024582)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024584.keyboard = TouchScreenKeyboard.Open(_0024self__0024584.enteredCode, TouchScreenKeyboardType.EmailAddress, false);
					_0024self__0024584.keyboardActive = true;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024startText_0024585;

		internal MenuControl _0024self__0024586;

		public _0024StartKeyboard_0024581(string startText, MenuControl self_)
		{
			_0024startText_0024585 = startText;
			_0024self__0024586 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024startText_0024585, _0024self__0024586);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PreSelectOutfit_0024587 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_0024588;

			internal string _0024whichOutfit_0024589;

			internal MenuControl _0024self__0024590;

			public _0024(string whichOutfit, MenuControl self_)
			{
				_0024whichOutfit_0024589 = whichOutfit;
				_0024self__0024590 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					for (_0024i_0024588 = 0; _0024i_0024588 < Extensions.get_length((System.Array)_0024self__0024590.gameControl.shopList); _0024i_0024588++)
					{
						if (_0024self__0024590.gameControl.shopList[_0024i_0024588] == _0024whichOutfit_0024589)
						{
							_0024self__0024590.scrollOffset = 470f - (float)(_0024i_0024588 * 20) * _0024self__0024590.scaleFactor;
							_0024self__0024590.activeID = _0024i_0024588;
							_0024self__0024590.gameControl.ReviewItem(_0024whichOutfit_0024589);
							break;
						}
					}
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichOutfit_0024591;

		internal MenuControl _0024self__0024592;

		public _0024PreSelectOutfit_0024587(string whichOutfit, MenuControl self_)
		{
			_0024whichOutfit_0024591 = whichOutfit;
			_0024self__0024592 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichOutfit_0024591, _0024self__0024592);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartLevel_0024593 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024whichLevel_0024594;

			internal MenuControl _0024self__0024595;

			public _0024(int whichLevel, MenuControl self_)
			{
				_0024whichLevel_0024594 = whichLevel;
				_0024self__0024595 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!(Time.realtimeSinceStartup - _0024self__0024595.buttonPressedTimer >= 2f))
					{
						goto case 1;
					}
					_0024self__0024595.buttonPressedTimer = Time.realtimeSinceStartup;
					_0024self__0024595.gameControl.missionLevel = _0024whichLevel_0024594;
					_0024self__0024595.gameControl.levelHint = string.Empty;
					_0024self__0024595.menu = "loading";
					_0024self__0024595.gameControl.missionMilestone = 0;
					_0024self__0024595.StartCoroutine(_0024self__0024595.gameControl.PauseGame(false));
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024595.StartCoroutine(_0024self__0024595.gameControl.ChangeScene("Main", true));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal int _0024whichLevel_0024596;

		internal MenuControl _0024self__0024597;

		public _0024StartLevel_0024593(int whichLevel, MenuControl self_)
		{
			_0024whichLevel_0024596 = whichLevel;
			_0024self__0024597 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichLevel_0024596, _0024self__0024597);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowLevelup_0024598 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal MenuControl _0024self__0024599;

			public _0024(MenuControl self_)
			{
				_0024self__0024599 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024599.StartCoroutine(_0024self__0024599.gameControl.playerControl.ShowLevelUp("none", "levelUpExplosion"));
					if (_0024self__0024599.menu == "missionPause")
					{
						_0024self__0024599.gameControl.playerControl.ChangeStop(true);
						_0024self__0024599.menu = "unlockedItem";
						result = (Yield(2, new WaitForSeconds(4f)) ? 1 : 0);
					}
					else
					{
						_0024self__0024599.menu = "unlockedItem";
						result = (Yield(3, new WaitForSeconds(4f)) ? 1 : 0);
					}
					break;
				case 2:
					_0024self__0024599.gameControl.playerControl.ChangeStop(false);
					_0024self__0024599.menu = "game";
					goto IL_00fd;
				case 3:
					_0024self__0024599.menu = "options";
					goto IL_00fd;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00fd:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MenuControl _0024self__0024600;

		public _0024ShowLevelup_0024598(MenuControl self_)
		{
			_0024self__0024600 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024600);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024QuitGame_0024601 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024done_0024602;

			internal MenuControl _0024self__0024603;

			public _0024(MenuControl self_)
			{
				_0024self__0024603 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024603.menu = "quitting";
					Time.timeScale = 0f;
					_0024done_0024602 = Time.realtimeSinceStartup + 0.1f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024done_0024602)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					Application.Quit();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MenuControl _0024self__0024604;

		public _0024QuitGame_0024601(MenuControl self_)
		{
			_0024self__0024604 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024604);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResetLastSelected_0024605 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal MenuControl _0024self__0024606;

			public _0024(MenuControl self_)
			{
				_0024self__0024606 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.25f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024606.lastSelected = -1;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal MenuControl _0024self__0024607;

		public _0024ResetLastSelected_0024605(MenuControl self_)
		{
			_0024self__0024607 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024607);
		}
	}

	private Texture2D logoTexture;

	private Texture2D logoFront;

	public GUISkin menuSkin;

	private bool showMenu;

	private GameObject tempObject;

	private Rect buttonRect;

	private Rect buttonRectBase;

	public string menu;

	private string keyboardInput;

	private bool isShop;

	private string lastScene;

	private float logoScale;

	private string newName;

	private Rect topLeftRect;

	private Rect pauseRect;

	private Rect backRect;

	private Rect characterRect;

	private string lastMenu;

	private float scrollOffset;

	private float scrollSpeed;

	private float scrollLimit;

	private Rect gemRect;

	private Rect tokenRect;

	private string hintWarp;

	private string hintText;

	private float hintTimer;

	private float hintY;

	private float hintDelta;

	private bool hideHint;

	private GameControl gameControl;

	private float scaleFactor;

	public string backMenu;

	private float smoothedSpeed;

	private bool lastTouching;

	private float offsetHeight;

	private float offsetWidth;

	private float screenWidth;

	private float screenHeight;

	private Matrix4x4 scaledMatrix;

	private float sideSwipe;

	private float lastMousePosX;

	private bool isTouching;

	private float missionXoffset;

	private float missionXtarget;

	private Rect fromLeftRect;

	private Rect fromRightRect;

	private Rect fromTopRect;

	private Rect fromBottomRect;

	public int activeID;

	private string tempString;

	private float lastMouseY;

	private int targetY;

	private float screenScale;

	private string[] categoryList;

	private int categoryID;

	private Rect categoryRect;

	private int submenu;

	private float nextSubMenuTime;

	private float[] bonusScale;

	private int bonusNote;

	private float bonusGem;

	private float bonusGemTarget;

	private float buttonTimer;

	private bool XperiaWasClosed;

	private int buttonID;

	private int maxID;

	private Rect activeRect;

	private Rect tempRect;

	private bool isSelected;

	private float keySpeed;

	private float pressTimer;

	private string quitReturnMenu;

	private UnityScript.Lang.Array menuList;

	private bool saveMenuList;

	private UnityScript.Lang.Array keyboardList;

	private int lastSelected;

	private TouchScreenKeyboard keyboard;

	private bool keyboardActive;

	private string enteredCode;

	private string iCadeStateLast;

	private float joystickTimer;

	private int previewWorldID;

	private Rect secretRect;

	private string cloudText;

	private string cloudAction;

	private float bonusBar;

	private float bonusTimer;

	private int bonusCount;

	private bool showBonus;

	private GameObject bonusAudio;

	private bool showActive;

	private float touchTimer;

	private string shopMessage;

	private bool pageUp;

	private bool pageDown;

	private float saveTimer;

	public Color menuColor;

	public bool levelSelected;

	private bool videoReady;

	private float buttonPressedTimer;

	public MenuControl()
	{
		buttonRectBase = new Rect(618f, 620f, 300f, 64f);
		menu = "load";
		lastScene = "Splash";
		logoScale = 1f;
		newName = string.Empty;
		topLeftRect = new Rect(10f, 10f, 180f, 70f);
		lastMenu = "none";
		scrollOffset = 470f;
		scrollLimit = 1000f;
		hintWarp = string.Empty;
		hintText = string.Empty;
		hintY = -60f;
		scaleFactor = 1f;
		backMenu = "title";
		screenWidth = 960f;
		screenHeight = 640f;
		scaledMatrix = Matrix4x4.identity;
		fromLeftRect = new Rect(0f, 0f, 0f, 0f);
		fromRightRect = new Rect(0f, 0f, 0f, 0f);
		fromTopRect = new Rect(0f, 0f, 0f, 0f);
		fromBottomRect = new Rect(0f, 0f, 0f, 0f);
		activeID = -1;
		tempString = string.Empty;
		targetY = 490;
		categoryList = new string[15]
		{
			"outfit", "accessories", "backpack", "boots", "earrings", "face", "gloves", "hair", "haircolor", "mask",
			"pants", "shirt", "skin", "board", "weapons"
		};
		categoryRect = new Rect(910f, 10f, 35f, 35f);
		bonusScale = new float[7];
		XperiaWasClosed = true;
		maxID = 1;
		activeRect = new Rect(0f, 0f, 0f, 0f);
		tempRect = new Rect(0f, 0f, 0f, 0f);
		quitReturnMenu = "title";
		saveMenuList = true;
		lastSelected = -1;
		enteredCode = string.Empty;
		iCadeStateLast = string.Empty;
		previewWorldID = -1;
		cloudText = "Cloud";
		cloudAction = "load";
		showBonus = true;
		showActive = true;
		shopMessage = string.Empty;
	}

	public virtual void Awake()
	{
		useGUILayout = false;
		menuList = new UnityScript.Lang.Array();
		keyboardList = new UnityScript.Lang.Array("q", "w", "e", "r", "t", "y", "u", "i", "o", "p", "a", "s", "d", "f", "g", "h", "j", "k", "l", "*", "z", "x", "c", "v", "b", "n", "m", "<", "*");
		eScreen.Initialize();
		eScreen.onScreenChanged += ScreenChanged;
	}

	public virtual void ScreenChanged()
	{
		ResizeGUI();
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		logoScale = 1f;
		ResizeGUI();
		logoTexture = (Texture2D)Resources.Load(gameControl.appName + "/LogoBack");
		logoFront = (Texture2D)Resources.Load(gameControl.appName + "/LogoFront");
		cloudText = "Cloud";
		TouchScreenKeyboard.hideInput = true;
	}

	public virtual void ResizeGUI()
	{
		scaleFactor = 2f;
		screenScale = 1f;
		offsetHeight = 0f;
		offsetWidth = 0f;
		float num = Screen.height;
		float num2 = Screen.width;
		float num3 = 0f;
		float num4 = 0f;
		bool flag = false;
		if (gameControl.adsOn == 1)
		{
			flag = true;
		}
		if (menu == "loading")
		{
			flag = false;
		}
		if (menu == "hint")
		{
			flag = false;
		}
		if (gameControl.devicemodel == "ouya")
		{
			offsetHeight = num * 0.05f * 0.5f;
			offsetWidth = num2 * 0.05f * 0.5f;
			num *= 0.95f;
			num2 *= 0.95f;
		}
		if (flag)
		{
			offsetHeight = num * 0.05f * 0.5f;
			num *= 0.9f;
		}
		if (!(num2 * 1f / num <= 1.5f))
		{
			screenScale = num / 640f;
			offsetWidth += (num2 - 960f * screenScale) * 0.5f;
		}
		else
		{
			screenScale = num2 / 960f;
			offsetHeight += (num - 640f * screenScale) * 0.5f;
		}
		if (flag)
		{
			offsetHeight -= screenScale * 20f;
		}
		scaledMatrix.SetTRS(new Vector3(offsetWidth, offsetHeight, 0f), Quaternion.identity, new Vector3(screenScale, screenScale, screenScale));
		buttonRect = new Rect(screenWidth * 0.8f - 75f * scaleFactor, -10f * scaleFactor, 150f * scaleFactor, 32f * scaleFactor);
		backRect = new Rect(20f, 520f, 100f, 100f);
		characterRect = new Rect(20f, 80f, 100f, 100f);
		gemRect = new Rect(20f, 20f, 200f, 60f);
		tokenRect = new Rect(230f, 20f, 150f, 60f);
		pauseRect = new Rect(2f, 2f, 32f * scaleFactor, 32f * scaleFactor);
		secretRect = new Rect(840f, 520f, 100f, 100f);
	}

	public virtual IEnumerator StartKeyboard(string startText)
	{
		return new _0024StartKeyboard_0024581(startText, this).GetEnumerator();
	}

	public virtual void CheckKeyboard()
	{
	}

	public virtual void ShowLoading()
	{
		menu = "load";
	}

	public virtual void Restart(string whichScene)
	{
		gameControl.updateOutfit = true;
		gameControl.Save("items");
		StartCoroutine(gameControl.ChangeScene(whichScene, true));
	}

	public virtual bool NoUnlockMenu()
	{
		bool flag = true;
		gameControl.UnlockNext();
		if (!(gameControl.unlockedItem == "none") && !(gameControl.unlockedItem == string.Empty))
		{
			flag = false;
			lastMenu = "missionEnd";
			menu = "unlockedItem";
		}
		if (flag)
		{
			StartCoroutine(gameControl.RecordingStop());
		}
		return flag;
	}

	public virtual void MenuChanged()
	{
		joystickTimer = Time.realtimeSinceStartup + 0.25f;
		ResizeGUI();
		if (lastMenu == "none")
		{
			saveMenuList = false;
		}
		if (lastMenu == "load")
		{
			saveMenuList = false;
		}
		if (lastMenu == "hint")
		{
			saveMenuList = false;
		}
		if (lastMenu == "quit")
		{
			saveMenuList = false;
		}
		if (lastMenu == "game")
		{
			saveMenuList = false;
		}
		if (lastMenu == "missionPause")
		{
			saveMenuList = false;
		}
		if (lastMenu == "facebookprize")
		{
			saveMenuList = false;
		}
		if (lastMenu == "remotesave")
		{
			saveMenuList = false;
		}
		if (lastMenu == "gamesave")
		{
			saveMenuList = false;
		}
		if (lastMenu == "gamesaved")
		{
			saveMenuList = false;
		}
		if (lastMenu == "update")
		{
			saveMenuList = false;
		}
		if (saveMenuList)
		{
			menuList.Push(lastMenu);
			if (menu == "title")
			{
				menuList = new UnityScript.Lang.Array();
			}
		}
		else
		{
			saveMenuList = true;
		}
		if (menu != "missionEnd")
		{
			hintY = -100f;
			hintDelta = -1f;
		}
		else
		{
			joystickTimer = Time.realtimeSinceStartup + 2f;
		}
		if (menu == "unlockedLevel" || menu == "unlockedItem" || menu == "redeemerror")
		{
			gameControl.cameraOffset = new Vector3(4f, 0f, 0f);
		}
		else if (menu == "missionPause" || menu == "hint" || menu == "game" || menu == "load")
		{
			gameControl.cameraOffset = new Vector3(0f, 0f, 0f);
		}
		else
		{
			gameControl.cameraOffset = new Vector3(5f, 13f, 0f);
		}
		if (lastMenu == "characters" && menu == "bonus")
		{
			submenu = 10;
		}
		else
		{
			submenu = -1;
			nextSubMenuTime = Time.realtimeSinceStartup;
		}
		bonusNote = 0;
		bonusGem = 0f;
		bonusGemTarget = 0f;
		scrollSpeed = 0f;
		if (menu == "chooseWorld")
		{
			int num = gameControl.worldID;
			if (num == 100)
			{
				num = gameControl.maxWorlds;
			}
			missionXtarget = -480 * (num - 1);
			gameControl.ReadMissionLevels();
			gameControl.CheckDailyPrize();
		}
		missionXoffset = missionXtarget;
		lastMenu = menu;
		gameControl.scrollMenu = false;
		if (menu == "redeem")
		{
			gameControl.scrollMenu = true;
			enteredCode = string.Empty;
			keyboardActive = false;
		}
		if (menu == "chooseLevel")
		{
			gameControl.scrollMenu = true;
		}
		if (menu == "chooseWorld")
		{
			gameControl.scrollMenu = true;
		}
		if (menu == "characters")
		{
			ScrollToActiveOutfit();
		}
		if (menu == "store" && gameControl.storeApproved == 0)
		{
			menu = "storecheck";
		}
		if (menu == "saveme")
		{
			saveTimer = Time.realtimeSinceStartup;
		}
		gameControl.RevertItem();
		gameControl.AdjustDailyXPStatus();
		if ((bool)gameControl.playerControl)
		{
			gameControl.playerControl.Look("ahead");
		}
		if ((bool)bonusAudio)
		{
			UnityEngine.Object.Destroy(bonusAudio, 0.1f);
		}
		buttonID = 1;
		isSelected = false;
		videoReady = eAds.VideoIsReady();
	}

	public virtual void GetInputs()
	{
		int num = default(int);
		if (eInput.controlType != "touch")
		{
			num = buttonID;
			if (buttonID <= 0)
			{
				buttonID = maxID;
			}
			if (buttonID > maxID)
			{
				buttonID = 1;
			}
			buttonTimer = Time.realtimeSinceStartup * 30f;
			float num2 = Mathf.Abs(Mathf.Sin(buttonTimer * 0.15f));
			activeRect = new Rect(-10f * num2, -10f * num2, 20f * num2, 20f * num2);
			if (!(Mathf.Abs(Time.realtimeSinceStartup - joystickTimer) >= 0.5f))
			{
				return;
			}
			if (menu == "redeem")
			{
				if (eInput.leftJoyY < -0.5f || eInput.leftPadDown)
				{
					if (buttonID == 1 || buttonID == 11)
					{
						buttonID += 10;
					}
					else if (buttonID >= 21)
					{
						buttonID = maxID;
					}
					else
					{
						buttonID += 9;
					}
				}
				if (eInput.leftJoyY > 0.5f || eInput.leftPadUp)
				{
					buttonID -= 9;
				}
				if (eInput.leftJoyX > 0.5f || eInput.leftPadRight)
				{
					buttonID++;
				}
				if (eInput.leftJoyX < -0.5f || eInput.leftPadLeft)
				{
					buttonID--;
				}
			}
			else if (menu == "chooseLevel")
			{
				if (eInput.leftJoyY < -0.5f || eInput.leftPadDown)
				{
					if (buttonID == 1)
					{
						buttonID += 5;
					}
					else if (buttonID < 6)
					{
						buttonID += 5;
					}
					else if (buttonID == maxID)
					{
						buttonID = 1;
					}
					else if (buttonID >= 6)
					{
						buttonID = maxID - 1;
					}
					else
					{
						buttonID += 5;
					}
				}
				if (eInput.leftJoyY > 0.5f || eInput.leftPadUp)
				{
					if (buttonID == 1)
					{
						buttonID--;
					}
					else if (buttonID < 6)
					{
						buttonID = 0;
					}
					else if (buttonID == maxID)
					{
						buttonID--;
					}
					else
					{
						buttonID -= 5;
					}
				}
				if (eInput.leftJoyX > 0.5f || eInput.leftPadRight)
				{
					if ((buttonID == 1 && maxID <= 3) || buttonID == 10 || buttonID == 5)
					{
						pageUp = true;
					}
					else
					{
						buttonID++;
					}
				}
				if (eInput.leftJoyX < -0.5f || eInput.leftPadLeft)
				{
					if (buttonID == 1 || buttonID == 6)
					{
						pageDown = true;
					}
					else
					{
						buttonID--;
					}
				}
			}
			else if (menu == "chooseWorld")
			{
				if (eInput.leftJoyY < -0.5f || eInput.leftPadDown)
				{
					buttonID++;
				}
				if (eInput.leftJoyY > 0.5f || eInput.leftPadUp)
				{
					buttonID--;
				}
			}
			else if (menu == "characters")
			{
				if (eInput.leftJoyX > 0.5f || eInput.leftPadRight)
				{
					buttonID++;
				}
				if (eInput.leftJoyX < -0.5f || eInput.leftPadLeft)
				{
					buttonID--;
				}
				if (eInput.leftJoyY < -0.2f || eInput.leftJoyY > 0.2f || eInput.leftPadUp || eInput.leftPadDown)
				{
					buttonID = 1;
				}
			}
			else
			{
				if (eInput.leftJoyY < -0.5f || eInput.leftPadDown)
				{
					buttonID++;
				}
				if (eInput.leftJoyX > 0.5f || eInput.leftPadRight)
				{
					buttonID++;
				}
				if (eInput.leftJoyY > 0.5f || eInput.leftPadUp)
				{
					buttonID--;
				}
				if (eInput.leftJoyX < -0.5f || eInput.leftPadLeft)
				{
					buttonID--;
				}
			}
		}
		else
		{
			buttonID = 0;
			maxID = 1;
			activeRect = new Rect(0f, 0f, 0f, 0f);
		}
		if (buttonID != num)
		{
			joystickTimer = Time.realtimeSinceStartup;
		}
	}

	public virtual void ScrollToActiveOutfit()
	{
		if (!showActive)
		{
			showActive = true;
			return;
		}
		for (int i = 0; i < Extensions.get_length((System.Array)gameControl.shopList); i++)
		{
			if (gameControl.shopList[i] == gameControl.activeOutfit)
			{
				scrollOffset = 470f - (float)(i * 20) * scaleFactor;
				activeID = i;
				gameControl.ReviewItem(gameControl.activeOutfit);
				break;
			}
		}
	}

	public virtual IEnumerator PreSelectOutfit(string whichOutfit)
	{
		return new _0024PreSelectOutfit_0024587(whichOutfit, this).GetEnumerator();
	}

	public virtual void UpdateScrollOffset()
	{
		float num = 0f;
		bool flag = false;
		bool num2 = eInput.leftJoyY < -0.5f;
		if (!num2)
		{
			num2 = eInput.leftPadDown;
		}
		bool flag2 = num2;
		bool num3 = eInput.leftJoyY > 0.5f;
		if (!num3)
		{
			num3 = eInput.leftPadUp;
		}
		bool flag3 = num3;
		if (Input.GetMouseButton(0))
		{
			float num4 = Input.mousePosition.x / (float)Screen.width;
			float num5 = Input.mousePosition.y / (float)Screen.height;
			if (!(num4 <= 0.65f))
			{
				if (!(num5 <= 0.45f) && !(num5 >= 0.55f))
				{
					flag3 = true;
				}
				else if (!(num5 >= 0.15f))
				{
					flag2 = true;
				}
			}
		}
		if (Input.GetMouseButton(0) && !(Input.mousePosition.x <= (float)Screen.width * 0.6f) && !(Input.mousePosition.y >= (float)Screen.height * 0.8f))
		{
			flag = true;
			gameControl.scrollMenu = true;
			if (lastTouching)
			{
				num += (lastMouseY - Input.mousePosition.y) / screenScale;
			}
		}
		else
		{
			gameControl.scrollMenu = false;
		}
		if (flag3 && !(scrollLimit <= screenHeight - 80f * scaleFactor))
		{
			flag = true;
			if (!lastTouching)
			{
				keySpeed = -3.5f;
			}
			else if (!(Time.realtimeSinceStartup - pressTimer <= 0.25f))
			{
				keySpeed -= 0.1f;
			}
			num = keySpeed;
			gameControl.scrollMenu = true;
		}
		else if (flag2 && !(scrollOffset >= (float)(targetY + 0)))
		{
			flag = true;
			if (!lastTouching)
			{
				keySpeed = 3.5f;
			}
			else if (!(Time.realtimeSinceStartup - pressTimer <= 0.25f))
			{
				keySpeed += 0.1f;
			}
			num = keySpeed;
			gameControl.scrollMenu = true;
		}
		else
		{
			keySpeed = 0f;
			pressTimer = Time.realtimeSinceStartup;
			lastTouching = false;
		}
		keySpeed = Mathf.Clamp(keySpeed, -20f, 20f);
		if (flag)
		{
			scrollSpeed = num;
			if (!lastTouching)
			{
				smoothedSpeed = num;
			}
			else
			{
				smoothedSpeed += (num - smoothedSpeed) * 0.1f;
			}
		}
		else
		{
			if (lastTouching)
			{
				scrollSpeed = smoothedSpeed;
			}
			else
			{
				scrollSpeed += (0f - scrollSpeed) * 0.1f;
			}
			if (!(scrollOffset <= (float)(targetY - 0)))
			{
				scrollSpeed = ((float)(targetY - 0) - scrollOffset) * 0.1f;
			}
			else if (!(scrollLimit >= screenHeight - 80f * scaleFactor))
			{
				scrollSpeed = (screenHeight - 80f * scaleFactor - scrollLimit) * 0.1f;
			}
			else if (!(Mathf.Abs(scrollSpeed) >= 1f))
			{
				scrollOffset = Mathf.Round(scrollOffset / 40f) * 40f;
				scrollSpeed = 0f;
			}
		}
		scrollOffset += scrollSpeed;
		lastTouching = flag;
		lastMouseY = Input.mousePosition.y;
	}

	public virtual void ShowWarp(string warpScene, string promptText)
	{
		hintWarp = warpScene;
		hintText = promptText;
		hintDelta = 1f;
		hideHint = false;
	}

	public virtual void ShowHint(string promptText, float howLong)
	{
		hintWarp = string.Empty;
		hintText = promptText;
		hintDelta = 1f;
		hintTimer = Time.realtimeSinceStartup + howLong;
		hideHint = true;
	}

	public virtual void HideHint()
	{
		hintTimer = Time.realtimeSinceStartup + 3f;
		hideHint = true;
	}

	public virtual Rect AddRect(Rect rect1, Rect rect2)
	{
		Rect result = rect1;
		result.x += rect2.x;
		result.y += rect2.y;
		result.width += rect2.width;
		result.height += rect2.height;
		return result;
	}

	public virtual IEnumerator StartLevel(int whichLevel)
	{
		return new _0024StartLevel_0024593(whichLevel, this).GetEnumerator();
	}

	public virtual void StartScene(string whichScene)
	{
		StartCoroutine(gameControl.ChangeScene(whichScene, true));
	}

	public virtual void ThrowGems()
	{
		tempObject = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("gemBonus"), Camera.main.transform.TransformPoint(0.94f, -0.32f, 1.8f), Quaternion.identity);
		tempObject.transform.parent = Camera.main.transform;
		tempObject.transform.LookAt(Camera.main.transform);
	}

	public virtual void CalcCategoryRect()
	{
		categoryRect = new Rect(screenWidth - 51f, 10f + (float)categoryID * (screenHeight * 1f / (float)(Extensions.get_length((System.Array)categoryList) + 0) - 1.7f), 35f, 35f);
	}

	public virtual void CheckCategory()
	{
		int num = -1;
		if (Input.GetMouseButton(0) && !(Input.mousePosition.x <= (float)Screen.width * 0.95f + offsetWidth))
		{
			float num2 = ((float)Screen.height - Input.mousePosition.y - offsetHeight) * 1f;
			num = Mathf.FloorToInt(num2 / ((float)Screen.height - 2f * offsetHeight) * (float)Extensions.get_length((System.Array)categoryList));
			num = Mathf.Clamp(num, 0, Extensions.get_length((System.Array)categoryList) - 1);
		}
		else if (gameControl.reviewItemCategory != categoryList[categoryID])
		{
			for (int i = 0; i < Extensions.get_length((System.Array)categoryList); i++)
			{
				if (gameControl.reviewItemCategory == categoryList[i])
				{
					categoryID = i;
					CalcCategoryRect();
					break;
				}
			}
		}
		if (num == -1)
		{
			return;
		}
		categoryID = num;
		if (!(gameControl.reviewItemCategory != categoryList[categoryID]))
		{
			return;
		}
		int num3 = -1;
		for (int i = 0; i < Extensions.get_length((System.Array)gameControl.shopList); i++)
		{
			tempString = gameControl.shopList[i];
			string[] array = tempString.Split(char.Parse("_"));
			if (array[0] == categoryList[categoryID])
			{
				num3 = i;
				break;
			}
		}
		if (num3 != -1)
		{
			activeID = num3;
			gameControl.ReviewItem(gameControl.shopList[activeID]);
			gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dullclick"));
			scrollOffset = targetY - 10 - activeID * 40;
			CalcCategoryRect();
		}
	}

	public virtual void FindXOffset(int buttonsPerPage, int totalButtons)
	{
		if (Input.GetMouseButton(0))
		{
			sideSwipe = (Input.mousePosition.x - lastMousePosX) * gameControl.touchScale;
			touchTimer = Time.realtimeSinceStartup;
		}
		else
		{
			sideSwipe = 0f;
		}
		lastMousePosX = Input.mousePosition.x;
		float num = 1f;
		int num2 = (int)((Mathf.Ceil((float)totalButtons / ((float)buttonsPerPage * 1f)) - 1f) * 960f);
		if (buttonsPerPage == 1)
		{
			num = 0.5f;
			num2 = (totalButtons - 1) * 480;
		}
		float num3 = scrollSpeed;
		bool flag = isTouching;
		scrollSpeed = 0f;
		isTouching = false;
		if (sideSwipe != 0f || Input.GetMouseButton(0))
		{
			isTouching = true;
			if (!flag)
			{
				sideSwipe = 0f;
			}
			else
			{
				scrollSpeed = sideSwipe * 2f;
				missionXoffset = Mathf.Clamp(missionXoffset + scrollSpeed, -num2 - 90, 90f);
			}
		}
		else
		{
			scrollSpeed = 0f;
		}
		if (eInput.controlType != "touch" && !(Mathf.Abs(Time.realtimeSinceStartup - joystickTimer) <= 0.5f))
		{
			float num4 = 0f;
			if (menu == "chooseWorld" && (eInput.leftJoyX > 0.5f || eInput.rightJoyX > 0.5f || eInput.leftPadRight || eInput.R1))
			{
				if (missionXtarget != (float)(-num2))
				{
					num4 = -210f;
				}
				buttonID = 1;
			}
			if ((menu == "chooseWorld" && (eInput.leftJoyX < -0.5f || eInput.rightJoyX < -0.5f)) || eInput.leftPadLeft || eInput.L1)
			{
				if (missionXtarget != 0f)
				{
					num4 = 210f;
				}
				buttonID = 1;
			}
			if (menu == "chooseLevel" && (eInput.rightJoyX > 0.5f || eInput.R1 || pageUp))
			{
				if (missionXtarget != (float)(-num2))
				{
					num4 = -210f;
				}
				buttonID = 1;
			}
			if (menu == "chooseLevel" && (eInput.rightJoyX < -0.5f || eInput.L1 || pageDown))
			{
				if (missionXtarget != 0f)
				{
					num4 = 210f;
				}
				buttonID = 1;
			}
			if (num4 != 0f)
			{
				pageUp = false;
				pageDown = false;
				isTouching = false;
				flag = true;
				missionXoffset = missionXtarget + num4;
				joystickTimer = Time.realtimeSinceStartup;
			}
		}
		if (isTouching)
		{
			return;
		}
		if (flag)
		{
			float num5 = missionXtarget - missionXoffset;
			if (Mathf.Abs(num5) <= 200f)
			{
				return;
			}
			int num6 = (int)(0f - Mathf.Round(num5 / (960f * num)));
			if (!(num5 <= 0f))
			{
				if (num6 == 0)
				{
					num6 = -1;
				}
				missionXtarget = Mathf.Clamp(Mathf.Round((missionXtarget + 960f * num * (float)num6) / (960f * num)) * 960f * num, -num2, 0f);
			}
			else
			{
				if (num6 == 0)
				{
					num6 = 1;
				}
				missionXtarget = Mathf.Clamp(Mathf.Round((missionXtarget + 960f * num * (float)num6) / (960f * num)) * 960f * num, -num2, 0f);
			}
		}
		else
		{
			float num7 = Mathf.Clamp((missionXtarget - missionXoffset) * Time.deltaTime * 20f, -40f, 40f);
			missionXoffset += num7;
		}
	}

	public virtual void ShowRating()
	{
		if (gameControl.platform == "amazon")
		{
			Application.OpenURL("amzn://apps/android?p=com.ezone." + gameControl.appName);
		}
		else
		{
			Application.OpenURL("https://market.android.com/details?id=com.ezone." + gameControl.appName);
		}
	}

	public virtual void CheckRating()
	{
		if (!gameControl.showLinks)
		{
			backMenu = menu;
			isShop = true;
			gameControl.MakeList("outfit", isShop);
			menu = "characters";
		}
		else if (PlayerPrefs.GetInt("Rating" + gameControl.buildVersion, 0) == 0)
		{
			PlayerPrefs.SetInt("Rating" + gameControl.buildVersion, 1);
			menu = "rating";
		}
		else
		{
			backMenu = menu;
			isShop = true;
			gameControl.MakeList("outfit", isShop);
			menu = "characters";
		}
	}

	public virtual IEnumerator ShowLevelup()
	{
		return new _0024ShowLevelup_0024598(this).GetEnumerator();
	}

	public virtual void Upgrade()
	{
		if (SystemInfo.deviceModel.IndexOf("iPad") != -1)
		{
			Application.OpenURL("http://ezone.com/app/dhd");
		}
		else
		{
			Application.OpenURL("http://ezone.com/app/d");
		}
	}

	public virtual IEnumerator QuitGame()
	{
		return new _0024QuitGame_0024601(this).GetEnumerator();
	}

	public virtual void CheckBack()
	{
		if (TouchScreenKeyboard.visible)
		{
			return;
		}
		switch (menu)
		{
		case "quit":
			menu = quitReturnMenu;
			break;
		case "game":
			StartCoroutine(gameControl.PauseGame(true));
			menu = "missionPause";
			break;
		case "hint":
			gameControl.HintAbort();
			break;
		case "saveme":
			gameControl.DieNoSaveMe();
			break;
		case "quitting":
			break;
		case "unlockedItem":
			break;
		case "bonus":
			break;
		case "unlockedLevel":
			break;
		case "missionEnd":
			if (NoUnlockMenu())
			{
				saveMenuList = false;
				menu = "chooseLevel";
			}
			break;
		case "store":
			ShowLastMenu();
			break;
		case "missionPause":
			if (gameControl.isMiniGame)
			{
				gameControl.EndMiniGameScene();
				break;
			}
			menu = "game";
			StartCoroutine(gameControl.PauseGame(false));
			break;
		case "title":
			quitReturnMenu = menu;
			menu = "quit";
			break;
		case "chooseLevel":
			menu = "chooseWorld";
			break;
		case "chooseWorld":
			menu = "title";
			break;
		case "upgrade":
			menu = backMenu;
			break;
		default:
			ShowLastMenu();
			break;
		}
	}

	public virtual void ShowLastMenu()
	{
		if (menuList.length > 0)
		{
			object obj = menuList.Pop();
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			menu = (string)obj;
		}
		else
		{
			menu = "title";
		}
		saveMenuList = false;
	}

	public virtual void OnApplicationPause(bool pauseState)
	{
		joystickTimer = Time.realtimeSinceStartup;
	}

	public virtual void AdjustRect(Rect whichRect, int whichID)
	{
		tempRect = whichRect;
		isSelected = false;
		if (eInput.controlType != "touch")
		{
			if (buttonID == whichID)
			{
				tempRect = AddRect(tempRect, activeRect);
			}
			if (!(Time.realtimeSinceStartup - joystickTimer <= 0.5f) && buttonID == whichID && eInput.rightPadDown)
			{
				isSelected = true;
				joystickTimer = Time.realtimeSinceStartup;
				lastSelected = whichID;
				StartCoroutine(ResetLastSelected());
			}
		}
	}

	public virtual IEnumerator ResetLastSelected()
	{
		return new _0024ResetLastSelected_0024605(this).GetEnumerator();
	}

	public virtual string TimeUntilMidnight()
	{
		string empty = string.Empty;
		int num = 0;
		string text = DateTime.Now.ToString("T");
		string[] array = text.Split(char.Parse(":"));
		num = 23 - UnityBuiltins.parseInt(array[0]);
		empty += string.Empty + num;
		num = 59 - UnityBuiltins.parseInt(array[1]);
		empty = ((num >= 10) ? (empty + (":" + num)) : (empty + (":0" + num)));
		num = 59 - UnityBuiltins.parseInt(array[2]);
		if (num < 10)
		{
			return empty + (":0" + num);
		}
		return empty + (":" + num);
	}

	public virtual void StartBonusXP()
	{
		if (gameControl.canEarnDaily)
		{
			gameControl.playerControl.Look("up");
			bonusAudio = new GameObject("Bonus audio");
			bonusAudio.AddComponent(typeof(AudioSource));
			bonusAudio.GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sounds/tone");
			bonusAudio.GetComponent<AudioSource>().loop = true;
			bonusAudio.GetComponent<AudioSource>().Play();
		}
	}

	public virtual bool TintButton(Rect position, string text, string buttonType)
	{
		GUI.backgroundColor = menuColor;
		bool result = GUI.Button(position, text, buttonType);
		GUI.backgroundColor = Color.white;
		return result;
	}

	public virtual bool TintButton(Rect position, Texture2D text, string buttonType)
	{
		GUI.contentColor = menuColor;
		bool result = GUI.Button(position, text, buttonType);
		GUI.contentColor = Color.white;
		return result;
	}

	public virtual void TintLabel(Rect position, string text, string buttonType)
	{
		GUI.backgroundColor = menuColor;
		GUI.Label(position, text, buttonType);
		GUI.backgroundColor = Color.white;
	}

	public virtual void TintLabel(Rect position, Texture2D text, string buttonType)
	{
		GUI.contentColor = menuColor;
		GUI.Label(position, text, buttonType);
		GUI.contentColor = Color.white;
	}

	public virtual void OnGUI()
	{
		GUI.depth = 0;
		GUI.skin = menuSkin;
		GUI.matrix = scaledMatrix;
		GetInputs();
		buttonRect = buttonRectBase;
		if (lastMenu != menu)
		{
			if (menu == "title")
			{
				gameControl.CheckAppOfTheDay();
			}
			MenuChanged();
		}
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		switch (menu)
		{
		case "saveme":
			maxID = 2;
			flag = true;
			AdjustRect(new Rect(280f, 480f, 400f, 120f), 1);
			if (TintButton(tempRect, "Save Me!       x " + gameControl.savePrice + " ", "button") || isSelected)
			{
				gameControl.SaveMe();
			}
			GUI.Label(new Rect(497f, 510f, 50f, 50f), string.Empty, "token");
			AdjustRect(new Rect(700f, 480f, 120f, 120f), maxID);
			if (TintButton(tempRect, string.Empty, "skip") || isSelected)
			{
				gameControl.DieNoSaveMe();
			}
			break;
		case "moretokens":
		{
			flag = true;
			maxID = 2;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			shopMessage = string.Empty + (gameControl.savePrice - gameControl.tokens) + " tokens for the save me.";
			tempString = "\n\n\nYou need " + (gameControl.savePrice - gameControl.tokens) + " more tokens to afford the save me.";
			GUI.Label(new Rect(568f, 170f, 380f, 300f), tempString, "heading");
			GUI.Label(new Rect(695f, 180f, 120f, 90f), (Texture)Resources.Load("tokens_100"));
			buttonRect.y -= 240f;
			AdjustRect(buttonRect, 1);
			string text4 = "Get More Tokens";
			if (!gameControl.store)
			{
				text4 = "Sorry!";
			}
			if (TintButton(tempRect, text4, "button") || isSelected)
			{
				if (gameControl.store)
				{
					menu = "store";
				}
				else
				{
					gameControl.DieNoSaveMe();
				}
			}
			if (videoReady && TintButton(new Rect(695f, 500f, 120f, 120f), string.Empty, "freegems"))
			{
				gameControl.VideoShow();
			}
			break;
		}
		case "message":
			maxID = 1;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "title";
			}
			tempString = gameControl.redeemMessage;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		case "cloudemail":
			maxID = 1;
			saveMenuList = false;
			GUI.Label(new Rect(40f, 10f, 700f, 60f), "Email:", "headingleft");
			GUI.SetNextControlName("email");
			gameControl.cloudEmail = GUI.TextField(new Rect(230f, 10f, 500f, 60f), gameControl.cloudEmail, 40, "enterText");
			GUI.Label(new Rect(40f, 80f, 700f, 60f), "Password:", "headingleft");
			GUI.SetNextControlName("password");
			gameControl.cloudPassword = GUI.TextField(new Rect(230f, 80f, 500f, 60f), gameControl.cloudPassword, 40, "enterText");
			AdjustRect(new Rect(760f, 10f, 130f, 130f), maxID);
			if (GUI.Button(tempRect, "Submit") || isSelected)
			{
				if (cloudAction == "load")
				{
					StartCoroutine(gameControl.RemoteDataLoad());
				}
				else
				{
					StartCoroutine(gameControl.RemoteDataSave());
				}
			}
			AdjustRect(backRect, maxID - 1);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				CheckBack();
			}
			break;
		case "cloudemailOLD":
			maxID = 1;
			saveMenuList = false;
			CheckKeyboard();
			if (keyboard != null && keyboardActive)
			{
				GUI.Label(new Rect(10f, 10f, 940f, 60f), "EMAIL: " + keyboard.text.ToUpper(), "heading");
				if (keyboard.done)
				{
					enteredCode = keyboard.text;
					if (enteredCode == string.Empty)
					{
						ShowLastMenu();
					}
					else
					{
						gameControl.cloudEmail = enteredCode;
						StartCoroutine(StartKeyboard(gameControl.cloudPassword));
						menu = "cloudpassword";
					}
				}
			}
			else
			{
				GUI.Label(new Rect(10f, 10f, 940f, 60f), "EMAIL: ", "heading");
			}
			AdjustRect(new Rect(280f, 330f, 400f, 70f), maxID);
			if (GUI.Button(tempRect, "Show Keyboard") || isSelected)
			{
				StartCoroutine(StartKeyboard(gameControl.cloudEmail));
			}
			AdjustRect(backRect, maxID - 1);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				keyboard.active = false;
				keyboardActive = false;
				ShowLastMenu();
			}
			break;
		case "cloudpassword":
			maxID = 1;
			saveMenuList = false;
			CheckKeyboard();
			if (keyboard != null && keyboardActive)
			{
				GUI.Label(new Rect(10f, 10f, 940f, 60f), "YOUR PASSWORD: " + keyboard.text.ToUpper(), "heading");
				if (keyboard.done)
				{
					enteredCode = keyboard.text;
					if (enteredCode == string.Empty)
					{
						ShowLastMenu();
					}
					else
					{
						gameControl.cloudPassword = enteredCode;
						if (cloudAction == "load")
						{
							StartCoroutine(gameControl.RemoteDataLoad());
						}
						else
						{
							StartCoroutine(gameControl.RemoteDataSave());
						}
					}
				}
			}
			else
			{
				GUI.Label(new Rect(10f, 10f, 940f, 60f), "YOUR PASSWORD: ", "heading");
			}
			AdjustRect(new Rect(280f, 330f, 400f, 70f), maxID);
			if (GUI.Button(tempRect, "Show Keyboard") || isSelected)
			{
				StartCoroutine(StartKeyboard(gameControl.cloudPassword));
			}
			AdjustRect(backRect, maxID - 1);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				keyboard.active = false;
				keyboardActive = false;
				ShowLastMenu();
			}
			break;
		case "cloudcontact":
			maxID = 1;
			saveMenuList = false;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "Account: " + gameControl.cloudEmail, "heading");
			if (gameControl.redeemMessage == "Password incorrect")
			{
				maxID++;
				GUI.Label(new Rect(548f, 350f, 400f, 190f), "\n" + "Password incorrect\n\nEmail your password?", "heading");
				buttonRect.y -= 40f * scaleFactor;
				AdjustRect(buttonRect, maxID);
				if (GUI.Button(tempRect, "Email Me") || isSelected)
				{
					StartCoroutine(gameControl.RemoteForgotPassword());
				}
			}
			else
			{
				GUI.Label(new Rect(548f, 350f, 400f, 190f), "\n" + gameControl.redeemMessage, "heading");
			}
			AdjustRect(backRect, 1);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			break;
		case "gamesave":
			maxID = 3;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "Save Game Data to " + cloudText + "?", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "No Thanks", "button") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Save", "button") || isSelected)
			{
				cloudAction = "save";
				menu = "cloudemail";
			}
			buttonRect.y = 100f;
			buttonRect.height = 330f;
			GUI.Label(buttonRect, "\nAre you sure\nyou want to save this game to " + cloudText + "?\n\nNote: this will replace any existing " + cloudText + " game data", "heading");
			break;
		case "gamesaved":
			maxID = 1;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "Game Data Saved", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			GUI.Label(new Rect(548f, 350f, 400f, 190f), "\n\nYour Game Progress has been saved", "heading");
			break;
		case "gameload":
			maxID = 3;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "Load Game Data from " + cloudText + "?", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "No Thanks", "button") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Load", "button") || isSelected)
			{
				cloudAction = "load";
				menu = "cloudemail";
			}
			buttonRect.y = 100f;
			buttonRect.height = 330f;
			GUI.Label(buttonRect, "\nAre you sure\nyou want to load from " + cloudText + "?\n\nNote: this will replace all progress in this current game!", "heading");
			break;
		case "gameloaderror":
			maxID = 1;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "Game Data Not Loaded", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			GUI.Label(new Rect(548f, 350f, 400f, 190f), gameControl.loaderror, "heading");
			break;
		case "appoftheday":
			maxID = 2;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "STARTER PACK UNLOCKED!!", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Thanks!", "button") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y = 110f;
			buttonRect.height = 310f;
			GUI.Label(buttonRect, "\n\n6 Worlds!\n\n10 characters!\n\n10 save tokens!", "hint");
			break;
		case "remotesave":
			maxID = 3;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), cloudText + " Game Data Save / Load", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "Load", "button") || isSelected)
			{
				menu = "gameload";
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Save", "button") || isSelected)
			{
				menu = "gamesave";
			}
			buttonRect.y = 110f;
			buttonRect.height = 310f;
			GUI.Label(buttonRect, "save your gems, scores and items to your " + cloudText + " account so you can access them on your other devices", "hint");
			break;
		case "secret":
			maxID = 2;
			flag2 = true;
			flag = true;
			if (gameControl.redeem)
			{
				maxID++;
				AdjustRect(new Rect(20f, 100f, 100f, 100f), maxID - 1);
				if (TintButton(tempRect, string.Empty, "redeem") || isSelected)
				{
					menu = "redeem";
				}
			}
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			tempString = "Daily Double";
			if (TintButton(tempRect, tempString, "button") || isSelected)
			{
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			buttonRect.y = 140f;
			buttonRect.height = 360f;
			GUI.Label(buttonRect, string.Empty, "hint");
			if (GUI.Button(new Rect(720f, 260f, 100f, 100f), string.Empty, "facebook"))
			{
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			tempString = "Collect gems to fill the bonus bar and activate the mega bonus area!\n\n\n\n\n\n\nLike us on facebook to discover today's 'daily double' level and play it to earn double gems!";
			GUI.Label(buttonRect, tempString, "medium");
			break;
		case "facebookprize":
			maxID = 2;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "500 Free Gems for you!", "heading");
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Like Us!", "button") || isSelected)
			{
				gameControl.Redeem("gems_500");
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			buttonRect.y = 140f;
			buttonRect.height = 360f;
			GUI.Label(buttonRect, string.Empty, "hint");
			if (GUI.Button(new Rect(660f, 260f, 100f, 100f), string.Empty, "facebook"))
			{
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			if (GUI.Button(new Rect(770f, 265f, 120f, 90f), (Texture)Resources.Load("gems_10000"), "label"))
			{
				gameControl.Redeem("gems_500");
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			GUI.Label(buttonRect, "Thanks for playing and telling all your friends about the game!\n\n\n\n\n\n\nTo thank you, here are 500 free gems just for 'Liking us'\non Facebook!", "medium");
			break;
		case "storecheck":
			maxID = 2;
			saveMenuList = false;
			AdjustRect(backRect, 1);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			AdjustRect(characterRect, 2);
			if (GUI.Button(tempRect, string.Empty, "options") || isSelected)
			{
				menu = "settings";
			}
			tempString = "The Gem Store Is Closed";
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			GUI.Label(new Rect(548f, 130f, 380f, 460f), "\n\n\nTo make in-game purchases please turn on the gem store in the options menu.\n\nOnce you have completed your transaction, we suggest you turn off the gem store to prevent accidental purchases.", "heading");
			GUI.Label(new Rect(680f, 140f, 120f, 90f), (Texture)Resources.Load("gems_10000"));
			break;
		case "store":
		{
			maxID = 1;
			flag = true;
			showActive = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			if (videoReady && TintButton(characterRect, string.Empty, "freegems"))
			{
				gameControl.VideoShow();
			}
			int num2 = 150;
			if (gameControl.adsOn == 1)
			{
				GUI.Label(new Rect(140f, 80f, 810f, 64f), "ANY PURCHASE REMOVES IN-GAME ADS...FOREVER!!!", "heading");
			}
			buttonRect = new Rect(548f, 620f, 400f, 94f);
			if (RuntimeServices.EqualityOperator(gameControl.storePrices[0], 0))
			{
				maxID++;
				if (gameControl.storeStatus == "contacting")
				{
					GUI.Label(new Rect(548f, 350f, 400f, 180f), "\n\nContacting Store...", "heading");
				}
				else
				{
					GUI.Label(new Rect(548f, 350f, 400f, 180f), "\nSorry, the store could\nnot be contacted,\nplease try again later.", "heading");
				}
				break;
			}
			int num3 = 150;
			for (int i = 0; i < gameControl.storePrices.length; i++)
			{
				if (RuntimeServices.EqualityOperator(gameControl.storeTitles[i], string.Empty))
				{
					continue;
				}
				maxID++;
				int num4 = 140;
				int num5 = 150 + i * num3;
				if (i > 2)
				{
					num4 = 548;
					num5 = 150 + (i - 3) * num3;
				}
				buttonRect = new Rect(num4, num5, 400f, 140f);
				AdjustRect(buttonRect, maxID);
				if (GUI.Button(tempRect, string.Empty + gameControl.storeTitles[i], "heading") || isSelected)
				{
					saveMenuList = false;
					GameControl obj = gameControl;
					object obj2 = gameControl.storeItems[i];
					if (!(obj2 is string))
					{
						obj2 = RuntimeServices.Coerce(obj2, typeof(string));
					}
					obj.BuyItem((string)obj2);
				}
				TintLabel(new Rect(num4 + 135, num5 + 60, 250f, 64f), "BUY: " + gameControl.storePrices[i], "button");
				object obj3 = gameControl.storeItems[i];
				if (!(obj3 is string))
				{
					obj3 = RuntimeServices.Coerce(obj3, typeof(string));
				}
				string text2 = (string)obj3;
				string[] array = text2.Split(char.Parse("."));
				text2 = array[Extensions.get_length((System.Array)array) - 1];
				GUI.Label(new Rect(num4 + 10, num5 + 40, 120f, 80f), (Texture)Resources.Load(text2));
			}
			break;
		}
		case "storecontact":
			maxID = 1;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "store";
			}
			tempString = "Contacting Store...";
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		case "storeFailed":
			maxID = 1;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "store";
			}
			GUI.Label(new Rect(10f, 10f, 940f, 60f), gameControl.redeemMessage, "heading");
			break;
		case "redeem":
		{
			maxID = keyboardList.length + 2;
			saveMenuList = false;
			int num24 = 0;
			int num25 = 0;
			int num26 = 0;
			int num27 = 10;
			for (int i = 0; i < keyboardList.length; i++)
			{
				if (i < num27)
				{
					num25 = 0;
					num24 = i;
					num26 = 0;
				}
				else if (i < num27 * 2)
				{
					num25 = 1;
					num24 = i - num27;
					num26 = 40;
				}
				else
				{
					num25 = 2;
					num24 = i - num27 * 2;
					num26 = 80;
				}
				tempRect = new Rect(17 + num26 + num24 * 91, 170 + num25 * 100, 95f, 95f);
				AdjustRect(tempRect, i + 1);
				if (RuntimeServices.EqualityOperator(keyboardList[i], "*") || (!TintButton(tempRect, string.Empty + keyboardList[i], "button") && !isSelected))
				{
					continue;
				}
				if (RuntimeServices.EqualityOperator(keyboardList[i], "<"))
				{
					if (Extensions.get_length(enteredCode) != 0)
					{
						enteredCode = enteredCode.Substring(0, Extensions.get_length(enteredCode) - 1);
						gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dullclick"));
					}
				}
				else if (RuntimeServices.EqualityOperator(keyboardList[i], "clear"))
				{
					enteredCode = string.Empty;
				}
				else
				{
					enteredCode += keyboardList[i];
					enteredCode = enteredCode.ToUpper();
					gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dullclick"));
				}
			}
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "ENTER CHEAT CODE: " + enteredCode.ToUpper(), "heading");
			AdjustRect(new Rect(840f, 520f, 100f, 100f), maxID);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				StartCoroutine(gameControl.GetPrize(enteredCode.ToUpper()));
				enteredCode = string.Empty;
			}
			if (gameControl.showLinks)
			{
				AdjustRect(new Rect(280f, 530f, 400f, 70f), maxID - 1);
				if (TintButton(tempRect, "Need a cheat code?", "button") || isSelected)
				{
					keyboardActive = false;
					Application.OpenURL("http://www.facebook.com/ezonecom");
				}
			}
			AdjustRect(backRect, maxID - 2);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				keyboardActive = false;
				ShowLastMenu();
			}
			break;
		}
		case "redeemNativeKeyboard":
			maxID = 2;
			saveMenuList = false;
			CheckKeyboard();
			GUI.Label(new Rect(10f, 10f, 940f, 60f), "ENTER CHEAT CODE: " + enteredCode.ToUpper(), "heading");
			if (keyboard != null && keyboardActive && keyboard.done)
			{
				keyboardActive = false;
				enteredCode = keyboard.text;
				if (enteredCode == string.Empty)
				{
					ShowLastMenu();
				}
				else
				{
					StartCoroutine(gameControl.GetPrize(enteredCode.ToUpper()));
				}
			}
			AdjustRect(new Rect(280f, 110f, 400f, 70f), maxID);
			if (GUI.Button(tempRect, "Need a cheat code?") || isSelected)
			{
				keyboardActive = false;
				Application.OpenURL("http://www.facebook.com/ezonecom");
			}
			AdjustRect(backRect, maxID - 1);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				keyboardActive = false;
				ShowLastMenu();
			}
			AdjustRect(new Rect(280f, 330f, 400f, 70f), maxID);
			if (GUI.Button(tempRect, "Show Keyboard") || isSelected)
			{
				keyboardActive = false;
				menu = "redeemKeyboard";
			}
			break;
		case "redeemcheck":
			maxID = 1;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "redeem";
			}
			tempString = "Contacting prize server...";
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		case "redeemerror":
			maxID = 1;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			tempString = gameControl.redeemMessage;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		case "bonus":
			maxID = 1;
			saveMenuList = true;
			if (!(Time.realtimeSinceStartup <= nextSubMenuTime))
			{
				submenu++;
				nextSubMenuTime = Time.realtimeSinceStartup + 5f;
				switch (submenu)
				{
				case 0:
					StartCoroutine(gameControl.playerControl.ShowLevelUp(gameControl.unlockedItem, "levelUpDaily"));
					break;
				case 1:
					ThrowGems();
					gameControl.PlaySound((AudioClip)Resources.Load("Sounds/sparkle", typeof(AudioClip)));
					break;
				}
			}
			if (submenu < 1)
			{
				break;
			}
			gameControl.unlockedItem = "none";
			if (gameControl.hoverLevels)
			{
				AdjustRect(new Rect(620f, 460f, 300f, 150f), 1);
				if (TintButton(tempRect, "Play Mega\nBonus Area", "button") || isSelected)
				{
					StartCoroutine(gameControl.ChangeScene("BonusPool", true));
				}
			}
			else
			{
				AdjustRect(new Rect(680f, 460f, 150f, 150f), 1);
				if (GUI.Button(tempRect, string.Empty, "continue") || isSelected)
				{
					menu = "missionEnd";
				}
			}
			tempString = gameControl.redeemMessage;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			buttonRect.y = 90f;
			buttonRect.height = 360f;
			GUI.Label(buttonRect, string.Empty, "hint");
			if (gameControl.showLinks)
			{
				maxID++;
				AdjustRect(new Rect(720f, buttonRect.y + 120f, 100f, 100f), maxID);
				if (GUI.Button(tempRect, string.Empty, "facebook") || isSelected)
				{
					Application.OpenURL("http://www.facebook.com/ezonecom");
				}
			}
			else if (!GUI.Button(new Rect(720f, buttonRect.y + 120f, 100f, 100f), string.Empty, "facebook"))
			{
			}
			if (gameControl.hoverLevels)
			{
				tempString = "You filled the bonus bar and have activated the mega bonus area!\n\n\n\n\n\n\nLike us on facebook to discover today's 'daily double' level and play it to earn double gems!";
			}
			else
			{
				tempString = "Play everyday to win new characters, gems or tokens!\n\n\n\n\n\n\n\nLike us on facebook to discover today's 'daily double' level and play it to earn double gems!";
			}
			GUI.Label(buttonRect, tempString, "medium");
			maxID++;
			AdjustRect(characterRect, maxID);
			if (TintButton(tempRect, string.Empty, "character") || isSelected)
			{
				backMenu = menu;
				isShop = true;
				gameControl.MakeList("outfit", isShop);
				menu = "characters";
			}
			break;
		case "redeemed":
			maxID = 1;
			saveMenuList = false;
			if (!(Time.realtimeSinceStartup <= nextSubMenuTime))
			{
				submenu++;
				nextSubMenuTime = Time.realtimeSinceStartup + 5f;
				switch (submenu)
				{
				case 0:
					if (gameControl.redeemMessage.IndexOf("DAILY ") != -1)
					{
						StartCoroutine(gameControl.playerControl.ShowLevelUp(gameControl.unlockedItem, "levelUpDaily"));
					}
					else
					{
						StartCoroutine(gameControl.playerControl.ShowLevelUp(gameControl.unlockedItem, "levelUpExplosion"));
					}
					break;
				case 1:
					ThrowGems();
					if (gameControl.redeemMessage.IndexOf("DAILY ") != -1)
					{
						gameControl.PlaySound((AudioClip)Resources.Load("Sounds/sparkle", typeof(AudioClip)));
					}
					else
					{
						gameControl.PlaySound((AudioClip)Resources.Load("Sounds/unlockitem", typeof(AudioClip)));
					}
					break;
				}
			}
			if (submenu < 1)
			{
				break;
			}
			gameControl.unlockedItem = "none";
			AdjustRect(new Rect(690f, 460f, 150f, 150f), 1);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				enteredCode = string.Empty;
				if (gameControl.awardSpecial)
				{
					menu = "characters";
				}
				else
				{
					ShowLastMenu();
				}
			}
			tempString = gameControl.redeemMessage;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			if (tempString.IndexOf("DAILY ") != -1)
			{
				buttonRect.y = 100f;
				buttonRect.height = 340f;
				GUI.Label(buttonRect, string.Empty, "hint");
				if (GUI.Button(new Rect(720f, buttonRect.y + 100f, 100f, 100f), string.Empty, "facebook") && gameControl.showLinks)
				{
					Application.OpenURL("http://www.facebook.com/ezonecom");
				}
				tempString = "Collect gems to fill up the bonus bar and unlock characters, gems and the hoverboard mega bonus area!\n\n\n\n\n\n\nLike us on facebook to discover today's 'daily double' level and play it to earn double gems!";
				GUI.Label(buttonRect, tempString, "medium");
			}
			else if (gameControl.awardSpecial)
			{
				buttonRect.y = 110f;
				buttonRect.height = 310f;
				GUI.Label(buttonRect, "All Worlds Unlocked!\n\n10 characters!\n\n10 save tokens!\n\n1000 Gems!", "hint");
			}
			break;
		case "missionEndPrize":
			maxID = 1;
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (GUI.Button(tempRect, "Continue") || isSelected)
			{
				gameControl.NextWinMenu();
			}
			tempString = gameControl.missionMessage;
			GUI.Label(new Rect(600f, 20f, 340f, 300f), tempString, "hint");
			break;
		case "quit":
			maxID = 2;
			GUI.Label(new Rect(screenWidth - (float)logoTexture.width * logoScale - 20f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoTexture, "label");
			TintLabel(new Rect(screenWidth - (float)logoTexture.width * logoScale - 20f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoFront, "label");
			buttonRect.y -= 80f * scaleFactor;
			buttonRect.height *= 2f;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "Quit", "button") || isSelected)
			{
				StartCoroutine(QuitGame());
			}
			AdjustRect(backRect, 1);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = quitReturnMenu;
			}
			buttonRect.y = 200f;
			buttonRect.height = 220f;
			GUI.Label(buttonRect, "\nAre you sure you want to leave the game?", "hint");
			break;
		case "googlePlay":
			saveMenuList = false;
			maxID = 2;
			GUI.Label(new Rect(screenWidth - (float)logoTexture.width * logoScale - 20f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoTexture, "label");
			TintLabel(new Rect(screenWidth - (float)logoTexture.width * logoScale - 20f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoFront, "label");
			buttonRect.y -= 80f * scaleFactor;
			buttonRect.height *= 2f;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "USE GOOGLE PLAY", "button") || isSelected)
			{
				ShowLastMenu();
				gameControl.InitScoreManager();
			}
			AdjustRect(backRect, 1);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			buttonRect.y = 200f;
			buttonRect.height = 220f;
			GUI.Label(buttonRect, "\nUse Google Play Games for scores & achievements?", "hint");
			break;
		case "skip":
		{
			backMenu = "missionEnd";
			flag = true;
			if (gameControl.store)
			{
				maxID = 4;
				AdjustRect(characterRect, 3);
				if ((TintButton(tempRect, string.Empty, "store") || isSelected) && NoUnlockMenu())
				{
					menu = "store";
				}
			}
			else
			{
				maxID = 3;
			}
			AdjustRect(backRect, maxID);
			if ((TintButton(tempRect, string.Empty, "back") || isSelected) && NoUnlockMenu())
			{
				menu = "missionEnd";
			}
			int num31 = Mathf.Clamp(gameControl.missionLevel * 100, 100, 1000);
			if (gameControl.playerControl.playerData.gems >= num31)
			{
				buttonRect.y -= 40f * scaleFactor;
				AdjustRect(buttonRect, 2);
				if (TintButton(tempRect, "Buy: " + num31, "button") || isSelected)
				{
					saveMenuList = false;
					gameControl.SkipLevel(num31);
					if (gameControl.missionLevel < Extensions.get_length((System.Array)gameControl.levelUnlocked))
					{
						if (NoUnlockMenu())
						{
							StartCoroutine(StartLevel(gameControl.missionLevel + 1));
						}
					}
					else if (NoUnlockMenu())
					{
						gameControl.worldID++;
						menu = "chooseWorld";
					}
				}
			}
			else
			{
				buttonRect.y -= 40f * scaleFactor;
				GUI.Label(buttonRect, "Cost: " + num31, "heading");
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Maybe Later", "button") || isSelected)
			{
				menu = "missionEnd";
			}
			buttonRect.y = 180f;
			buttonRect.height = 240f;
			if (gameControl.worldID == 100)
			{
				tempString = "B-" + gameControl.missionLevel;
			}
			else
			{
				tempString = string.Empty + gameControl.worldID + "-" + gameControl.missionLevel;
			}
			GUI.Label(new Rect(600f, 18f, 350f, 60f), "Skip Level " + tempString + "?", "heading");
			GUI.Label(buttonRect, "\nWould you like to use gems to unlock the next level?", "hint");
			break;
		}
		case "unlockedItem":
		{
			maxID = 1;
			saveMenuList = false;
			if (!(Time.realtimeSinceStartup <= nextSubMenuTime))
			{
				submenu++;
				nextSubMenuTime = Time.realtimeSinceStartup + 5f;
				if (submenu == 0)
				{
					StartCoroutine(gameControl.playerControl.ShowLevelUp(gameControl.unlockedItem, "levelUpExplosion"));
				}
			}
			if (submenu < 1)
			{
				break;
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(new Rect(780f, 460f, 150f, 150f), 1);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				gameControl.unlockedItem = "none";
				if (gameControl.unlockedLevel == "none")
				{
					if (NoUnlockMenu())
					{
						CheckRating();
					}
				}
				else
				{
					menu = "unlockedLevel";
					gameControl.PlaySound((AudioClip)Resources.Load("Sounds/unlockitem", typeof(AudioClip)));
					gameControl.playerControl.ChangeAnimation("dance1", 0.35f);
				}
			}
			string[] array = gameControl.unlockedItem.Split(char.Parse("_"));
			if (Extensions.get_length((System.Array)array) >= 2)
			{
				tempString = gameControl.unlockedReason + array[1] + " unlocked!";
			}
			else
			{
				tempString = gameControl.unlockedReason + " character unlocked!";
			}
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		}
		case "rating":
			maxID = 2;
			GUI.Label(new Rect(screenWidth - (float)logoTexture.width * logoScale - 10f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoTexture, "label");
			TintLabel(new Rect(screenWidth - (float)logoTexture.width * logoScale - 10f, 20f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoFront, "label");
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 1);
			if (TintButton(tempRect, "Yes, rate it!", "button") || isSelected)
			{
				ShowRating();
				menu = "missionEnd";
			}
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(buttonRect, 2);
			if (TintButton(tempRect, "No Thanks", "button") || isSelected)
			{
				menu = "missionEnd";
			}
			buttonRect.y = 220f;
			buttonRect.height = 230f;
			GUI.Label(buttonRect, "You're Doing Great!", "hint");
			GUI.Label(buttonRect, "\n\n\n\nIf you are enjoying this game please add a positive rating so we can keep the free updates coming.", "medium");
			break;
		case "unlockedLevel":
		{
			maxID = 1;
			saveMenuList = false;
			buttonRect.y -= 40f * scaleFactor;
			AdjustRect(new Rect(780f, 460f, 150f, 150f), 1);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				gameControl.playerControl.ChangeAnimation("stand", 0.35f);
				gameControl.unlockedLevel = "none";
				if (NoUnlockMenu())
				{
					gameControl.worldID = gameControl.newWorldID;
					menu = "chooseWorld";
				}
			}
			string text8 = string.Empty + gameControl.newWorldID;
			if (text8 == "100")
			{
				text8 = "Bonus";
			}
			tempString = "New Level Unlocked: " + text8 + "-" + gameControl.newLevelID;
			GUI.Label(new Rect(10f, 10f, 940f, 60f), tempString, "heading");
			break;
		}
		case "settings":
		{
			backMenu = "title";
			flag = true;
			flag2 = true;
			flag3 = true;
			GUI.Label(new Rect(600f, 600f, 280f, 30f), "v." + gameControl.buildVersion + " " + gameControl.devicemodel + " - " + eInput.controlType, "bestscore");
			float num28 = 120f;
			int num29 = 1;
			GUI.Label(new Rect(550f, num28, 400f, 70f), "Menu Color", "optionheading");
			AdjustRect(new Rect(780f, num28 + 12f, 150f, 40f), num29);
			num29++;
			num28 += 80f;
			if (TintButton(tempRect, string.Empty, "setting") || isSelected)
			{
				gameControl.MenuColor(1);
			}
			if (gameControl.remoteSave)
			{
				AdjustRect(new Rect(550f, num28, 400f, 60f), num29);
				num29++;
				num28 += 70f;
				string text9 = cloudText + " Game Save >>";
				if (GUI.Button(tempRect, text9, "heading") || isSelected)
				{
					menu = "remotesave";
				}
			}
			GUI.Label(new Rect(550f, num28, 400f, 70f), "Game Music", "optionheading");
			AdjustRect(new Rect(780f, num28 + 12f, 150f, 40f), num29);
			num29++;
			num28 += 80f;
			if (GUI.Button(tempRect, string.Empty, "toggle" + gameControl.musicOn) || isSelected)
			{
				gameControl.AdjustMusic((gameControl.musicOn != 1) ? 1 : 0);
			}
			GUI.Label(new Rect(550f, num28, 400f, 70f), "Sound", "optionheading");
			AdjustRect(new Rect(780f, num28 + 12f, 150f, 45f), num29);
			num29++;
			num28 += 80f;
			string text4 = "Off";
			if (gameControl.soundOn == 1)
			{
				text4 = "Low";
			}
			if (gameControl.soundOn == 2)
			{
				text4 = "Medium";
			}
			if (gameControl.soundOn == 3)
			{
				text4 = "High";
			}
			if (GUI.Button(tempRect, text4, "setting") || isSelected)
			{
				gameControl.soundOn++;
				if (gameControl.soundOn > 3)
				{
					gameControl.soundOn = 0;
				}
				gameControl.AdjustSound();
				if (gameControl.soundOn != 0)
				{
					gameControl.PlaySound((AudioClip)Resources.Load("Sounds/boing"));
				}
			}
			GUI.Label(new Rect(550f, num28, 400f, 70f), "Graphics", "optionheading");
			AdjustRect(new Rect(780f, num28 + 12f, 150f, 45f), num29);
			num29++;
			num28 += 80f;
			text4 = "Low";
			if (gameControl.quality == 0)
			{
				text4 = "Low";
			}
			if (gameControl.quality == 1)
			{
				text4 = "Medium";
			}
			if (gameControl.quality == gameControl.maxQuality)
			{
				text4 = "High";
			}
			if (GUI.Button(tempRect, text4, "setting") || isSelected)
			{
				gameControl.quality++;
				if (gameControl.quality > gameControl.maxQuality)
				{
					gameControl.quality = 0;
				}
				gameControl.AdjustQuality();
			}
			AdjustRect(backRect, num29);
			num29++;
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			AdjustRect(characterRect, num29);
			num29++;
			if (TintButton(tempRect, string.Empty, "character") || isSelected)
			{
				isShop = true;
				gameControl.MakeList("outfit", isShop);
				menu = "characters";
			}
			float num30 = 185f;
			if (gameControl.store)
			{
				AdjustRect(new Rect(20f, num30, 100f, 100f), num29);
				num29++;
				if (TintButton(tempRect, string.Empty, "store") || isSelected)
				{
					menu = "store";
				}
				num30 += 105f;
			}
			if (gameControl.redeem)
			{
				AdjustRect(new Rect(20f, num30, 100f, 100f), num29);
				num29++;
				if (TintButton(tempRect, string.Empty, "redeem") || isSelected)
				{
					menu = "redeem";
				}
				num30 += 105f;
			}
			maxID = num29 - 1;
			break;
		}
		case "title":
		{
			maxID = 0;
			backMenu = "quit";
			flag = true;
			flag3 = true;
			GUI.Label(new Rect(screenWidth - (float)logoTexture.width * logoScale - 130f, -10f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoTexture, "label");
			if (TintButton(new Rect(screenWidth - (float)logoTexture.width * logoScale - 130f, -10f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoFront, "label") && gameControl.cheatsOn)
			{
				menu = "options";
			}
			buttonRect.height *= 2f;
			buttonRect.y -= 80f * scaleFactor;
			maxID++;
			AdjustRect(buttonRect, maxID);
			if (TintButton(tempRect, "Play", "button") || isSelected)
			{
				if (gameControl.firstTime || gameControl.maxWorlds == 1)
				{
					Restart("Main");
				}
				else
				{
					menu = "chooseWorld";
				}
			}
			buttonRect.height /= 2f;
			Rect whichRect = new Rect(20f, 80f, 100f, 100f);
			maxID++;
			AdjustRect(whichRect, maxID);
			if (TintButton(tempRect, string.Empty, "options") || isSelected)
			{
				if (gameControl.reviewItemName == "Scuba" && (eInput.rightPadUp || Input.deviceOrientation == DeviceOrientation.FaceDown))
				{
					gameControl.cheatsOn = true;
					gameControl.PlaySound((AudioClip)Resources.Load("Sounds/sparkle"));
				}
				else
				{
					menu = "settings";
				}
			}
			if (gameControl.store)
			{
				whichRect.y += 105f;
				maxID++;
				AdjustRect(whichRect, maxID);
				if (TintButton(tempRect, string.Empty, "store") || isSelected)
				{
					menu = "store";
				}
			}
			if (gameControl.hoverLevels)
			{
				whichRect.y += 105f;
				maxID++;
				AdjustRect(whichRect, maxID);
				if (TintButton(tempRect, string.Empty, "hoverDemo") || isSelected)
				{
					StartCoroutine(gameControl.ChangeScene("GemFields", true));
				}
			}
			if (videoReady)
			{
				whichRect.y += 105f;
				maxID++;
				AdjustRect(whichRect, maxID);
				if (TintButton(tempRect, string.Empty, "freegems") || isSelected)
				{
					gameControl.VideoShow();
				}
			}
			if (maxID < 6)
			{
				if (gameControl.showLinks || gameControl.adsOn == 1)
				{
					maxID++;
					whichRect = new Rect(20f, 500f, 110f, 110f);
					AdjustRect(whichRect, maxID);
					if (GUI.Button(tempRect, string.Empty, "brothers") || isSelected)
					{
						gameControl.ShowMoreApps();
					}
				}
				else
				{
					GUI.Label(new Rect(20f, 500f, 110f, 110f), string.Empty, "brothers");
				}
			}
			if (gameControl.cheatsOn)
			{
				maxID++;
				AdjustRect(new Rect(620f, 200f, 300f, 70f), maxID);
				if (GUI.Button(tempRect, "Test Bonus") || isSelected)
				{
					StartCoroutine(gameControl.ChangeScene("BonusPool", true));
				}
			}
			if (gameControl.SpecialShow() && GUI.Button(new Rect(620f, 160f, 300f, 300f), (Texture)Resources.Load(gameControl.appName + "/special"), "label"))
			{
				gameControl.SpecialActivate();
			}
			if (gameControl.demo)
			{
				GUI.Label(new Rect(630f, 610f, 280f, 30f), "DEMO VERSION", "bestscore");
			}
			else if (gameControl.cheatsOn)
			{
				GUI.Label(new Rect(630f, 610f, 280f, 30f), "CHEATS ENABLED", "bestscore");
			}
			GUI.Label(new Rect(630f, 610f, 280f, 30f), "v." + gameControl.buildVersion + " (c) 2011-16 Ezone.com", "bestscore");
			break;
		}
		case "upgrade":
			GUI.Label(new Rect(550f, 100f, 350f, 300f), string.Empty, "button");
			if (GUI.Button(new Rect(570f, 115f, 300f, 300f), (Texture)Resources.Load(gameControl.appName + "/upgradebig"), "label"))
			{
				Upgrade();
				CheckBack();
			}
			if (GUI.Button(new Rect(550f, 430f, 350f, 70f), "Upgrade!"))
			{
				Upgrade();
				CheckBack();
			}
			if (GUI.Button(new Rect(550f, 510f, 350f, 70f), "Maybe Later"))
			{
				CheckBack();
			}
			break;
		case "missionPause":
			flag = true;
			flag2 = false;
			maxID = 0;
			if (Application.loadedLevelName.IndexOf(gameControl.appName) == -1)
			{
				GUI.Label(new Rect(390f, 17f, 400f, 60f), "GAME PAUSED", "heading");
			}
			else if (gameControl.worldID == 100)
			{
				GUI.Label(new Rect(390f, 17f, 400f, 60f), "Bonus - " + gameControl.missionLevel + " PAUSED", "heading");
			}
			else
			{
				GUI.Label(new Rect(390f, 17f, 400f, 60f), "Level " + gameControl.worldID + "-" + gameControl.missionLevel + " PAUSED", "heading");
			}
			maxID++;
			AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				menu = "game";
				StartCoroutine(gameControl.PauseGame(false));
			}
			if (gameControl.videoReplay)
			{
				maxID++;
				AdjustRect(new Rect(20f, 80f, 100f, 100f), maxID);
				if ((TintButton(tempRect, string.Empty, "VideoReplay") || isSelected) && NoUnlockMenu())
				{
					gameControl.RecordingShowLast();
				}
			}
			maxID++;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "exit") || isSelected)
			{
				if (!gameControl.isMiniGame)
				{
					gameControl.LeaveMission();
				}
				else
				{
					gameControl.EndMiniGameScene();
				}
			}
			if (!gameControl.isMiniGame)
			{
				maxID++;
				AdjustRect(new Rect(620f, 470f, 150f, 150f), maxID);
				if (TintButton(tempRect, string.Empty, "retry") || isSelected)
				{
					menu = "hint";
					StartCoroutine(StartLevel(gameControl.missionLevel));
				}
			}
			if (gameControl.lite && GUI.Button(new Rect(10f, 10f, 140f, 140f), (Texture)Resources.Load(gameControl.appName + "/upgrade"), "label"))
			{
				Upgrade();
			}
			break;
		case "chooseWorld":
		{
			maxID = 0;
			backMenu = "title";
			flag = true;
			flag2 = true;
			flag3 = true;
			int buttonsPerPage = 1;
			int num6 = gameControl.maxWorlds;
			if (gameControl.hoverLevels)
			{
				num6++;
			}
			FindXOffset(buttonsPerPage, num6);
			bool flag4 = false;
			int value = (int)Mathf.Ceil((240f - missionXoffset) / 480f);
			value = Mathf.Clamp(value, 1, num6);
			for (int i = 1; i <= num6; i++)
			{
				if (value == i)
				{
					GUI.Label(new Rect(480f - (float)(50 * num6) * 0.5f + (float)((i - 1) * 50), 550f, 40f, 40f), string.Empty, "pageOn");
				}
				else if (GUI.Button(new Rect(480f - (float)(50 * num6) * 0.5f + (float)((i - 1) * 50), 550f, 40f, 40f), string.Empty, "pageOff"))
				{
					missionXtarget = -480 * (i - 1);
				}
			}
			if (value != previewWorldID)
			{
				previewWorldID = value;
				gameControl.PreviewWorld(previewWorldID);
			}
			for (int j = 1; j <= num6; j++)
			{
				float f = (float)(480 * (j - 1)) + missionXoffset;
				flag4 = false;
				if (!(Mathf.Abs(f) >= 10f))
				{
					flag4 = true;
				}
				if (j > gameControl.maxWorlds)
				{
					if (gameControl.lite)
					{
						GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f), string.Empty, "button");
						tempRect = new Rect((float)(305 + 480 * (j - 1)) + missionXoffset + 20f, 205f, 300f, 300f);
						isSelected = false;
						if (flag4)
						{
							maxID++;
							if (j == value)
							{
								AdjustRect(tempRect, maxID);
							}
						}
						if ((GUI.Button(tempRect, (Texture)Resources.Load(gameControl.appName + "/upgradebig"), "label") || isSelected) && flag4)
						{
							Upgrade();
						}
					}
					else
					{
						if (!gameControl.hoverLevels)
						{
							continue;
						}
						GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f), "\nExplore \n\n\n\n\n\n\n      Now!       ", "heading");
						tempRect = new Rect((float)(305 + 480 * (j - 1)) + missionXoffset + 110f, 275f, 128f, 128f);
						isSelected = false;
						if (flag4)
						{
							maxID++;
							if (j == value)
							{
								AdjustRect(tempRect, maxID);
							}
						}
						if ((GUI.Button(tempRect, string.Empty, "hoverDemo") || isSelected) && flag4)
						{
							gameControl.missionLevel = 1;
							gameControl.worldID = 1;
							StartScene("GemFields");
						}
					}
					continue;
				}
				if (j == gameControl.maxWorlds)
				{
					if (gameControl.worldLocked[j - 1] && gameControl.newWorldID != 100 && !gameControl.cheatsOn && !gameControl.demo)
					{
						TintLabel(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f), "Endless\nBonus World\n\n\n", "button");
						GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset + 120f, 340f, 100f, 120f), string.Empty, "levelLocked");
						continue;
					}
					tempRect = new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f);
					isSelected = false;
					if (flag4)
					{
						maxID++;
						if (j == value)
						{
							AdjustRect(tempRect, maxID);
						}
					}
					if ((TintButton(tempRect, "Endless\nBonus World\n\nScore: " + gameControl.worldScores[j - 1], "button") || isSelected) && flag4)
					{
						gameControl.PreviewWorld(j);
						gameControl.worldID = 100;
						gameControl.ReadMissionLevels();
						missionXtarget = 0f;
						if (Extensions.get_length((System.Array)gameControl.levelGems) == 1)
						{
							StartCoroutine(StartLevel(1));
						}
						else
						{
							menu = "chooseLevel";
						}
					}
					if (gameControl.newWorldID == 100)
					{
						GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset - 10f, 180f, 80f, 80f), string.Empty, "newstar");
					}
					continue;
				}
				if (gameControl.worldLocked[j - 1] && gameControl.newWorldID != j && !gameControl.cheatsOn && !gameControl.demo)
				{
					tempRect = new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f);
					isSelected = false;
					if (flag4)
					{
						maxID++;
						if (j == value)
						{
							AdjustRect(tempRect, maxID);
						}
					}
					if ((TintButton(tempRect, "World " + j + "\n\n\n\n\nUnlock Early:\n[5] Tokens", "button") || isSelected) && flag4)
					{
						gameControl.BuyWorld(j);
					}
					GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset + 120f, 280f, 100f, 120f), string.Empty, "levelLocked");
				}
				else
				{
					tempString = "Stars: " + gameControl.worldStars[j - 1] + "/" + gameControl.worldLevels[j - 1] * 3 + "\nScore: " + gameControl.worldScores[j - 1];
					tempRect = new Rect((float)(305 + 480 * (j - 1)) + missionXoffset, 190f, 350f, 300f);
					isSelected = false;
					if (flag4)
					{
						maxID++;
						if (j == value)
						{
							AdjustRect(tempRect, maxID);
						}
					}
					if ((TintButton(tempRect, "World " + j + "\n\n" + tempString, "button") || isSelected) && flag4)
					{
						gameControl.PreviewWorld(j);
						gameControl.worldID = j;
						gameControl.ReadMissionLevels();
						missionXtarget = 0f;
						menu = "chooseLevel";
					}
				}
				if (gameControl.newWorldID == j)
				{
					GUI.Label(new Rect((float)(305 + 480 * (j - 1)) + missionXoffset - 10f, 180f, 80f, 80f), string.Empty, "newstar");
				}
			}
			maxID++;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "title";
			}
			if (gameControl.lite)
			{
				maxID++;
				AdjustRect(new Rect(830f, 500f, 130f, 130f), maxID);
				if (GUI.Button(tempRect, (Texture)Resources.Load(gameControl.appName + "/upgrade"), "labelleft") || isSelected)
				{
					Upgrade();
				}
			}
			else if (gameControl.showLinks)
			{
				maxID++;
				AdjustRect(secretRect, maxID);
				if (TintButton(tempRect, string.Empty, "secret") || isSelected)
				{
					menu = "secret";
				}
			}
			maxID++;
			AdjustRect(characterRect, maxID);
			if (TintButton(tempRect, string.Empty, "character") || isSelected)
			{
				backMenu = menu;
				isShop = true;
				gameControl.MakeList("outfit", isShop);
				menu = "characters";
			}
			break;
		}
		case "chooseLevel":
		{
			maxID = 0;
			backMenu = "chooseWorld";
			flag = true;
			flag2 = true;
			flag3 = true;
			if (gameControl.worldID == 100)
			{
				GUI.Label(new Rect(330f, 80f, 300f, 90f), "Bonus Levels", "hint");
			}
			else
			{
				GUI.Label(new Rect(330f, 80f, 300f, 90f), "World " + gameControl.worldID, "hint");
			}
			int num13 = 140;
			Rect rect = default(Rect);
			Rect rect2 = default(Rect);
			Vector2 vector = default(Vector2);
			int num14 = 0;
			int num15 = 0;
			int num16 = 160;
			int num17 = 200;
			int num18 = 0;
			Vector2 vector2 = new Vector2(0f, 0f);
			int num19 = 0;
			int num20 = 10;
			int num21 = Extensions.get_length((System.Array)gameControl.levelGems);
			int num22 = (int)Mathf.Ceil((float)num21 * 1f / (float)num20);
			if (num21 < 30 || gameControl.lite)
			{
				FindXOffset(num20, num21 + num20);
				if (gameControl.lite)
				{
					GUI.Label(new Rect((float)(305 + 480 * (num22 * 2)) + missionXoffset, 190f, 350f, 300f), string.Empty, "button");
					if (GUI.Button(new Rect((float)(305 + 480 * (num22 * 2)) + missionXoffset + 20f, 205f, 300f, 300f), (Texture)Resources.Load(gameControl.appName + "/upgradebig"), "label"))
					{
						Upgrade();
					}
				}
				else
				{
					GUI.Label(new Rect((float)(305 + 480 * (num22 * 2)) + missionXoffset, 190f, 350f, 300f), "\nComing Soon!\n\n\n\n\n\n\nMore Levels!", "heading");
					GUI.Label(new Rect((float)(305 + 480 * (num22 * 2)) + missionXoffset + 110f, 275f, 128f, 128f), string.Empty, "brothers");
				}
			}
			else
			{
				FindXOffset(num20, num21);
			}
			if (num21 > num20)
			{
				int value3 = (int)Mathf.Ceil((480f - missionXoffset) / 960f);
				value3 = Mathf.Clamp(value3, 1, num22);
				for (int i = 1; i <= num22; i++)
				{
					if (value3 == i)
					{
						GUI.Label(new Rect(480f - (float)(50 * num22) * 0.5f + (float)((i - 1) * 50), 550f, 40f, 40f), string.Empty, "pageOn");
					}
					else if (GUI.Button(new Rect(480f - (float)(50 * num22) * 0.5f + (float)((i - 1) * 50), 550f, 40f, 40f), string.Empty, "pageOff"))
					{
						missionXtarget = -960 * (i - 1);
					}
				}
			}
			for (int k = 0; k < num21; k++)
			{
				if (k % num20 == 0)
				{
					vector2 = new Vector2(k / num20 * 960, 0f);
					num19 = k;
				}
				if (k - num19 < 5)
				{
					vector.x = missionXoffset + vector2.x + (float)((k - num19) * num16);
					vector.y = 0f;
				}
				else if (k - num19 < 10)
				{
					vector.x = missionXoffset + vector2.x + (float)((k - num19 - 5) * num16);
					vector.y = num17 - 30;
				}
				else
				{
					vector.x = missionXoffset + vector2.x + (float)((k - num19 - 10) * num16);
					vector.y = (num17 - 30) * 2;
				}
				rect = new Rect(vector.x + 90f, 30f + vector.y + (float)num13 + 10f, (float)num16 * 0.8f, (float)num17 * 0.8f);
				if (rect.x <= (float)(-num16) || rect.x >= screenWidth + (float)num16 * 0.5f)
				{
					continue;
				}
				num14 = 0;
				if (k <= Extensions.get_length((System.Array)gameControl.levelStars))
				{
					num14 = Mathf.Clamp(gameControl.levelStars[k], 0, 3);
				}
				int num23 = 0;
				if (k <= Extensions.get_length((System.Array)gameControl.levelUnlocked))
				{
					num23 = gameControl.levelUnlocked[k];
				}
				bool flag6 = false;
				if (gameControl.worldID == gameControl.newWorldID && gameControl.newLevelID - 1 == k)
				{
					flag6 = true;
				}
				if (num23 == 0 && !gameControl.cheatsOn && !gameControl.demo)
				{
					tempRect = AddRect(rect, fromRightRect);
					isSelected = false;
					maxID++;
					AdjustRect(rect, maxID);
					if (GUI.Button(AddRect(tempRect, fromRightRect), string.Empty, "levelLocked") || isSelected)
					{
						gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dud"));
					}
				}
				else
				{
					tempRect = AddRect(rect, fromRightRect);
					isSelected = false;
					maxID++;
					AdjustRect(rect, maxID);
					if ((TintButton(tempRect, (k + 1).ToString(), "levelStar" + num14) && Mathf.Abs(scrollSpeed) < 3f) || isSelected)
					{
						StartCoroutine(StartLevel(k + 1));
					}
					rect2 = AddRect(rect, new Rect(10f, 83f, -20f, -170f));
					GUI.Label(rect2, string.Empty + gameControl.levelGems[k], "bestscore");
				}
				if (flag6)
				{
					tempRect = AddRect(rect, new Rect(-30f, -30f, -48f, -80f));
					GUI.Label(AddRect(tempRect, fromRightRect), string.Empty, "newstar");
				}
			}
			maxID++;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				menu = "chooseWorld";
			}
			maxID++;
			AdjustRect(characterRect, maxID);
			if (TintButton(tempRect, string.Empty, "character") || isSelected)
			{
				backMenu = menu;
				isShop = true;
				gameControl.MakeList("outfit", isShop);
				menu = "characters";
			}
			if (gameControl.lite)
			{
				maxID++;
				AdjustRect(new Rect(830f, 500f, 130f, 130f), maxID);
				if (GUI.Button(tempRect, (Texture)Resources.Load(gameControl.appName + "/upgrade"), "labelleft") || isSelected)
				{
					Upgrade();
				}
			}
			else if (gameControl.showLinks || Application.isEditor)
			{
				maxID++;
				AdjustRect(secretRect, maxID);
				if (TintButton(tempRect, string.Empty, "secret") || isSelected)
				{
					menu = "secret";
				}
			}
			break;
		}
		case "milestone":
			flag = true;
			flag2 = false;
			maxID = 0;
			GUI.Label(new Rect(390f, 17f, 400f, 60f), "Bonus - " + gameControl.missionLevel + " CHECKPOINT", "heading");
			maxID++;
			AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
			if (GUI.Button(tempRect, string.Empty, "continue") || isSelected)
			{
				StartCoroutine(gameControl.ChangeScene("Main", true));
			}
			if (gameControl.videoReplay)
			{
				maxID++;
				AdjustRect(new Rect(20f, 80f, 100f, 100f), maxID);
				if ((GUI.Button(tempRect, string.Empty, "VideoReplay") || isSelected) && NoUnlockMenu())
				{
					gameControl.RecordingShowLast();
				}
			}
			break;
		case "missionEnd":
		{
			maxID = 0;
			backMenu = "chooseLevel";
			bool flag5 = true;
			if (gameControl.worldID != 100 && gameControl.worldID < Extensions.get_length((System.Array)gameControl.worldLocked))
			{
				if (gameControl.missionLevel < Extensions.get_length((System.Array)gameControl.levelUnlocked))
				{
					if (gameControl.levelUnlocked[gameControl.missionLevel] == 1)
					{
						flag5 = false;
						buttonRect.y -= 40f * scaleFactor;
						maxID++;
						AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
						if ((TintButton(tempRect, string.Empty, "next") || isSelected) && NoUnlockMenu())
						{
							StartCoroutine(StartLevel(gameControl.missionLevel + 1));
						}
					}
					else
					{
						flag5 = false;
						buttonRect.y -= 40f * scaleFactor;
						maxID++;
						AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
						if ((TintButton(tempRect, string.Empty, "skip") || isSelected) && NoUnlockMenu())
						{
							menu = "skip";
						}
					}
				}
				else if (gameControl.worldLocked[gameControl.worldID] && !gameControl.missionWin && gameControl.worldID != gameControl.maxWorlds - 1)
				{
					flag5 = false;
					buttonRect.y -= 40f * scaleFactor;
					maxID++;
					AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
					if ((TintButton(tempRect, string.Empty, "skip") || isSelected) && NoUnlockMenu())
					{
						menu = "skip";
					}
				}
				else
				{
					flag5 = false;
					buttonRect.y -= 40f * scaleFactor;
					maxID++;
					AdjustRect(new Rect(790f, 470f, 150f, 150f), maxID);
					if ((TintButton(tempRect, string.Empty, "next") || isSelected) && NoUnlockMenu())
					{
						gameControl.worldID++;
						if (gameControl.worldID == gameControl.maxWorlds)
						{
							gameControl.worldID = 100;
						}
						menu = "chooseWorld";
					}
				}
			}
			maxID++;
			AdjustRect(characterRect, maxID);
			if ((TintButton(tempRect, string.Empty, "character") || isSelected) && NoUnlockMenu())
			{
				backMenu = menu;
				isShop = true;
				gameControl.MakeList("outfit", isShop);
				menu = "characters";
				StartCoroutine(PreSelectOutfit(gameControl.doubleOutfit));
			}
			Rect whichRect = new Rect(20f, 80f, 100f, 100f);
			if (gameControl.remoteSave || gameControl.store)
			{
				maxID++;
				whichRect.y += 110f;
				AdjustRect(whichRect, maxID);
				if (gameControl.remoteSave)
				{
					if ((TintButton(tempRect, string.Empty, "save") || isSelected) && NoUnlockMenu())
					{
						menu = "gamesave";
					}
				}
				else if (gameControl.store && (TintButton(tempRect, string.Empty, "store") || isSelected) && NoUnlockMenu())
				{
					menu = "store";
				}
			}
			if (gameControl.videoReplay)
			{
				maxID++;
				whichRect.y += 110f;
				AdjustRect(whichRect, maxID);
				if ((TintButton(tempRect, string.Empty, "VideoReplay") || isSelected) && NoUnlockMenu())
				{
					gameControl.RecordingShowLast();
				}
			}
			if (videoReady)
			{
				maxID++;
				whichRect.y += 110f;
				AdjustRect(whichRect, maxID);
				if (TintButton(tempRect, string.Empty, "freegems") && NoUnlockMenu())
				{
					gameControl.VideoShow();
				}
			}
			else if (gameControl.showLinks)
			{
				maxID++;
				whichRect.y += 110f;
				AdjustRect(whichRect, maxID);
				if ((TintButton(tempRect, string.Empty, "rating") || isSelected) && NoUnlockMenu())
				{
					menu = "rating";
				}
			}
			maxID++;
			AdjustRect(backRect, maxID);
			if ((TintButton(tempRect, string.Empty, "back") || isSelected) && NoUnlockMenu())
			{
				StartCoroutine(gameControl.ShowInterstitial());
				if (Extensions.get_length((System.Array)gameControl.levelGems) == 1)
				{
					menu = "title";
				}
				else
				{
					menu = "chooseLevel";
				}
				if (gameControl.lite)
				{
					backMenu = menu;
					menu = "upgrade";
				}
			}
			if (gameControl.missionWin)
			{
				if (submenu >= 5)
				{
					if (gameControl.missionDouble == "character")
					{
						GUI.Label(new Rect(150f, 530f, 400f, 80f), "this character earned you double gems!!", "messagesmall");
					}
					else if (gameControl.missionDouble == "level")
					{
						GUI.Label(new Rect(150f, 530f, 400f, 80f), "today's daily double level earned you double gems!!", "messagesmall");
					}
					else
					{
						maxID++;
						AdjustRect(new Rect(150f, 530f, 400f, 80f), maxID);
						string[] array = gameControl.doubleOutfit.Split(char.Parse("_"));
						if ((GUI.Button(tempRect, "Use '" + array[1] + "' to\nearn double gems!!", "messagesmall") || isSelected) && NoUnlockMenu())
						{
							backMenu = menu;
							isShop = true;
							gameControl.MakeList("outfit", isShop);
							menu = "characters";
							StartCoroutine(PreSelectOutfit(gameControl.doubleOutfit));
						}
					}
					if (gameControl.missionGem >= gameControl.levelGems[gameControl.missionLevel - 1])
					{
						bonusScale[5] = Mathf.Clamp(bonusScale[5] + 5f * Time.deltaTime, 0f, 1f);
						GUI.Label(new Rect(625f - 160f * bonusScale[5] + 160f, 290f - 40f * bonusScale[5] + 40f, 320f * bonusScale[5], 80f * bonusScale[5]), string.Empty, "bonushighscore");
					}
					else
					{
						GUI.Label(new Rect(625f, 330f, 320f, 80f), "(Best: " + gameControl.levelGems[gameControl.missionLevel - 1] + ")", "label");
					}
					flag = true;
				}
			}
			else
			{
				flag = true;
				if (gameControl.missionDouble == "character")
				{
					GUI.Label(new Rect(150f, 530f, 400f, 80f), "this character earned you double gems!!", "messagesmall");
				}
				else if (gameControl.missionDouble == "level")
				{
					GUI.Label(new Rect(150f, 530f, 400f, 80f), "today's daily double level earned you double gems!!", "messagesmall");
				}
				else
				{
					maxID++;
					AdjustRect(new Rect(150f, 530f, 400f, 80f), maxID);
					string[] array = gameControl.doubleOutfit.Split(char.Parse("_"));
					if ((GUI.Button(tempRect, "Use '" + array[1] + "' to\nearn double gems!!", "messagesmall") || isSelected) && NoUnlockMenu())
					{
						backMenu = menu;
						isShop = true;
						gameControl.MakeList("outfit", isShop);
						menu = "characters";
						StartCoroutine(PreSelectOutfit(gameControl.doubleOutfit));
					}
				}
			}
			int num7 = 170;
			if (flag5)
			{
				num7 += 90;
			}
			maxID++;
			AdjustRect(new Rect(450 + num7, 470f, 150f, 150f), maxID);
			if ((TintButton(tempRect, string.Empty, "retry") || isSelected) && NoUnlockMenu())
			{
				menu = "hint";
				StartCoroutine(StartLevel(gameControl.missionLevel));
			}
			bonusGem = Mathf.Clamp(bonusGem + 30f * Time.deltaTime, 0f, bonusGemTarget);
			int num8 = (int)Mathf.Round(bonusGem);
			if (!(bonusGem >= bonusGemTarget) && num8 % 5 == 0)
			{
				gameControl.PlaySound((AudioClip)Resources.Load("Sounds/collectGem", typeof(AudioClip)));
			}
			tempString = "Score: " + num8;
			GUI.Label(new Rect(635f, 385f, 300f, 60f), tempString, "heading");
			if (gameControl.worldID == 100)
			{
				tempString = "B-" + gameControl.missionLevel;
			}
			else
			{
				tempString = string.Empty + gameControl.worldID + "-" + gameControl.missionLevel;
			}
			GUI.Label(new Rect(850f, 16f, 95f, 60f), tempString, "messagesmall");
			if (submenu == -1)
			{
				bonusBar = gameControl.lastXP;
				if (gameControl.missionWin)
				{
					bonusGem = gameControl.missionGemEnd;
					bonusGemTarget = gameControl.missionGemEnd;
				}
				else
				{
					submenu = 1;
					bonusGem = gameControl.missionGemEnd;
					bonusGemTarget = gameControl.missionGem;
					if (gameControl.bonusDone)
					{
						bonusGem = bonusGemTarget;
					}
					gameControl.bonusDone = true;
				}
				if (gameControl.missionWin && gameControl.bonusDone)
				{
					bonusGem = gameControl.missionGem;
					bonusGemTarget = gameControl.missionGem;
					submenu = 7;
				}
			}
			float num9 = 1f;
			if (gameControl.missionWin)
			{
				if (!(Time.realtimeSinceStartup <= nextSubMenuTime))
				{
					submenu++;
					nextSubMenuTime = Time.realtimeSinceStartup + num9;
					switch (submenu)
					{
					case 0:
						nextSubMenuTime -= 0.5f;
						gameControl.playerControl.Look("right");
						break;
					case 1:
						if (gameControl.missionGemEnd >= 50 && gameControl.worldID != 100)
						{
							bonusScale[1] = 0.01f;
							bonusNote++;
							gameControl.PlaySound((AudioClip)Resources.Load("Sounds/note" + bonusNote, typeof(AudioClip)));
							bonusGemTarget += 25f;
							ThrowGems();
						}
						else
						{
							nextSubMenuTime -= num9;
						}
						break;
					case 2:
						if (gameControl.missionStar >= 1)
						{
							bonusScale[2] = 0.01f;
							bonusNote++;
							gameControl.PlaySound((AudioClip)Resources.Load("Sounds/note" + bonusNote, typeof(AudioClip)));
							bonusGemTarget += 5f;
							ThrowGems();
						}
						else
						{
							nextSubMenuTime -= num9;
						}
						break;
					case 3:
						if (gameControl.missionStar >= 2)
						{
							bonusScale[3] = 0.01f;
							bonusNote++;
							gameControl.PlaySound((AudioClip)Resources.Load("Sounds/note" + bonusNote, typeof(AudioClip)));
							bonusGemTarget += 5f;
							ThrowGems();
						}
						else
						{
							nextSubMenuTime -= num9;
						}
						break;
					case 4:
						if (gameControl.missionStar >= 3)
						{
							bonusScale[4] = 0.01f;
							bonusNote++;
							gameControl.PlaySound((AudioClip)Resources.Load("Sounds/note" + bonusNote, typeof(AudioClip)));
							bonusGemTarget += 15f;
							ThrowGems();
						}
						else
						{
							nextSubMenuTime -= num9;
						}
						gameControl.playerControl.ChangeAnimation("win", 0.35f);
						break;
					case 5:
						if (gameControl.missionDouble != string.Empty)
						{
							bonusGemTarget *= 2f;
							ThrowGems();
						}
						else
						{
							nextSubMenuTime -= num9;
						}
						break;
					case 6:
						if (gameControl.missionGem >= gameControl.levelGems[gameControl.missionLevel - 1])
						{
							bonusScale[5] = 0.01f;
						}
						gameControl.PlaySound((AudioClip)Resources.Load("Sounds/sparkle", typeof(AudioClip)));
						gameControl.bonusDone = true;
						break;
					}
				}
				if (submenu >= 1 && gameControl.missionGemEnd >= 50 && gameControl.worldID != 100)
				{
					bonusScale[1] = Mathf.Clamp(bonusScale[1] + 5f * Time.deltaTime, 0f, 1f);
					GUI.Label(new Rect(690f - 90f * bonusScale[1] + 90f, 16f - 80f * bonusScale[1] + 80f, 180f * bonusScale[1], 160f * bonusScale[1]), string.Empty, "bonusgem");
				}
				if (submenu >= 2 && gameControl.missionStar >= 1)
				{
					bonusScale[2] = Mathf.Clamp(bonusScale[2] + 5f * Time.deltaTime, 0f, 1f);
					GUI.Label(new Rect(715f - 70f * bonusScale[2] + 70f, 165f - 70f * bonusScale[2] + 70f, 140f * bonusScale[2], 140f * bonusScale[2]), string.Empty, "bonusstar");
				}
				if (submenu >= 3 && gameControl.missionStar >= 2)
				{
					bonusScale[3] = Mathf.Clamp(bonusScale[3] + 5f * Time.deltaTime, 0f, 1f);
					GUI.Label(new Rect(615f - 70f * bonusScale[3] + 70f, 140f - 70f * bonusScale[3] + 70f, 140f * bonusScale[3], 140f * bonusScale[3]), string.Empty, "bonusstar");
				}
				if (submenu >= 4 && gameControl.missionStar >= 3)
				{
					bonusScale[4] = Mathf.Clamp(bonusScale[4] + 5f * Time.deltaTime, 0f, 1f);
					GUI.Label(new Rect(815f - 70f * bonusScale[4] + 70f, 140f - 70f * bonusScale[4] + 70f, 140f * bonusScale[4], 140f * bonusScale[4]), string.Empty, "bonusstar");
				}
			}
			if ((submenu >= 6 || !gameControl.missionWin) && gameControl.unlockedItems.length == 0)
			{
				if (!bonusAudio)
				{
					StartBonusXP();
				}
				if (gameControl.canEarnDaily)
				{
					float value2 = (float)(gameControl.dailyXP - gameControl.lastXP) / 2f * Time.deltaTime;
					value2 = Mathf.Clamp(value2, Time.deltaTime * 5f, Time.deltaTime * 20f);
					bonusBar = Mathf.Clamp(bonusBar + value2, 0f, gameControl.dailyXP);
					float width = Mathf.Clamp(280f * (bonusBar * 1f / 100f), 20f, 280f);
					if (!(bonusBar < 100f) && gameControl.awardMegaPrize != string.Empty)
					{
						if ((bool)bonusAudio)
						{
							bonusAudio.GetComponent<AudioSource>().Stop();
							UnityEngine.Object.Destroy(bonusAudio, 1f);
						}
						if (!(Time.realtimeSinceStartup <= bonusTimer))
						{
							bonusTimer = Time.realtimeSinceStartup + 0.2f;
							bonusCount++;
							if (bonusCount % 2 == 0)
							{
								showBonus = false;
							}
							else
							{
								showBonus = true;
							}
						}
						if (bonusCount > 10)
						{
							gameControl.Redeem(gameControl.awardMegaPrize);
						}
					}
					else
					{
						showBonus = true;
						bonusTimer = 0f;
						bonusCount = 0;
						if (!(bonusBar >= (float)gameControl.dailyXP))
						{
							if ((bool)bonusAudio)
							{
								bonusAudio.GetComponent<AudioSource>().pitch = 0.5f + bonusBar / 100f;
							}
						}
						else if ((bool)bonusAudio)
						{
							bonusAudio.GetComponent<AudioSource>().Stop();
							UnityEngine.Object.Destroy(bonusAudio, 1f);
							gameControl.playerControl.Look("ahead");
						}
					}
					if (showBonus)
					{
						GUI.Button(new Rect(390f, 16f, 440f, 60f), "bonus:", "headingleft");
						TintLabel(new Rect(530f, 30f, width, 26f), string.Empty, "bonusbar");
					}
				}
				else
				{
					GUI.Button(new Rect(390f, 16f, 420f, 60f), "next daily in   " + TimeUntilMidnight(), "headingleft");
					gameControl.playerControl.Look("ahead");
				}
			}
			if (gameControl.lite && GUI.Button(new Rect(455f, 470f, 150f, 150f), (Texture)Resources.Load(gameControl.appName + "/upgrade"), "label"))
			{
				Upgrade();
			}
			break;
		}
		case "loading":
			maxID = 1;
			if ((bool)gameControl.backdropTexture)
			{
				GUI.DrawTexture(new Rect(-400f, -600f, 1760f, 1840f), gameControl.backdropTexture);
			}
			GUI.Label(new Rect(200f, 200f, 600f, 200f), gameControl.levelHint, "hint");
			GUI.DrawTexture(new Rect(0f, 300f, 328f, 400f), (Texture)Resources.Load(gameControl.appName + "/GarbotImage"));
			GUI.Label(new Rect(780f, 460f, 150f, 150f), string.Empty, "loading");
			break;
		case "hint":
			maxID = 2;
			if ((bool)gameControl.backdropTexture)
			{
				GUI.DrawTexture(new Rect(-400f, -600f, 1760f, 1840f), gameControl.backdropTexture);
			}
			GUI.Label(new Rect(200f, 200f, 600f, 200f), gameControl.levelHint, "hint");
			GUI.DrawTexture(new Rect(0f, 300f, 328f, 400f), (Texture)Resources.Load(gameControl.appName + "/GarbotImage"));
			buttonRect.height *= 2f;
			buttonRect.y -= 70f * scaleFactor;
			AdjustRect(new Rect(780f, 460f, 150f, 150f), 1);
			if (TintButton(tempRect, string.Empty, "continue") || isSelected)
			{
				menu = "game";
				StartCoroutine(gameControl.PauseGame(false));
				gameControl.RecordingStart();
			}
			AdjustRect(backRect, 2);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				gameControl.HintAbort();
			}
			break;
		case "home":
			if (GUI.Button(pauseRect, string.Empty, "pause"))
			{
				menu = "dev";
				StartCoroutine(gameControl.PauseGame(true));
			}
			break;
		case "options":
			backMenu = "title";
			if (TintButton(backRect, string.Empty, "back"))
			{
				menu = "title";
			}
			GUI.Label(new Rect(screenWidth - (float)logoTexture.width * logoScale, 0f, (float)logoTexture.width * logoScale, (float)logoTexture.height * logoScale), logoTexture);
			if (gameControl.cheatsOn)
			{
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Reset Achievements"))
				{
				}
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "10,000 Gems"))
				{
					gameControl.AdjustGems(10000);
				}
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Clear iCloud"))
				{
					gameControl.RemoteDataClear();
				}
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Test Level Up"))
				{
					StartCoroutine(ShowLevelup());
				}
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Item List"))
				{
					isShop = true;
					gameControl.MakeList("outfit", isShop);
					menu = "shopitems";
				}
			}
			buttonRect.y -= 40f * scaleFactor;
			if (gameControl.cheatsOn)
			{
				if (GUI.Button(buttonRect, "Cheats Are On"))
				{
					gameControl.cheatsOn = !gameControl.cheatsOn;
				}
			}
			else if (GUI.Button(buttonRect, "Cheats Are Off"))
			{
				gameControl.cheatsOn = !gameControl.cheatsOn;
			}
			if (GUI.Button(topLeftRect, "Reset"))
			{
				menu = "reset";
			}
			break;
		case "reset":
			GUI.Label(new Rect(screenWidth * 0.5f - 200f * scaleFactor, screenHeight * 0.5f - 50f * scaleFactor, 400f * scaleFactor, 80f * scaleFactor), "DO YOU WANT TO RESET ALL YOUR ITEMS, LEVEL PROGRESS, SCORES AND START AGAIN?", "hint");
			if (GUI.Button(new Rect(screenWidth * 0.5f - 110f * scaleFactor, screenHeight * 0.5f + 50f * scaleFactor, 100f * scaleFactor, 32f * scaleFactor), "YES"))
			{
				gameControl.ResetPlayer();
				gameControl.levelHint = "Reset in Progress\n\nI really hope this is what you wanted!!!... ;)";
			}
			if (GUI.Button(new Rect(screenWidth * 0.5f + 10f * scaleFactor, screenHeight * 0.5f + 50f * scaleFactor, 100f * scaleFactor, 32f * scaleFactor), "NO!"))
			{
				menu = "options";
			}
			break;
		case "loginSummary":
			buttonRect.y += 40f;
			if (GUI.Button(buttonRect, "Done"))
			{
				menu = "home";
			}
			break;
		case "login":
			GUI.Label(new Rect(screenWidth * 0.5f - 100f * scaleFactor, 15f * scaleFactor, 200f * scaleFactor, 40f * scaleFactor), "PLEASE TYPE YOUR NAME:\n" + newName);
			CheckKeyboard();
			break;
		case "userexists":
			GUI.Label(new Rect(screenWidth * 0.5f - 200f * scaleFactor, 15f * scaleFactor, 400f * scaleFactor, 40f * scaleFactor), "A SAVE FILE FOR \"" + newName + "\" EXISTS\nDO YOU WANT TO CLEAR AND START AGAIN?");
			if (GUI.Button(new Rect(screenWidth * 0.5f - 110f * scaleFactor, 60f * scaleFactor, 100f * scaleFactor, 32f * scaleFactor), "USE IT"))
			{
				Restart("Title");
			}
			if (GUI.Button(new Rect(screenWidth * 0.5f + 10f * scaleFactor, 60f * scaleFactor, 100f * scaleFactor, 32f * scaleFactor), "CLEAR"))
			{
				gameControl.ClearFile(newName);
				menu = "gender";
			}
			break;
		case "characters":
		{
			maxID = 0;
			flag = true;
			shopMessage = string.Empty;
			GUI.Label(new Rect(420f, 530f, 140f, 80f), string.Empty, "zoomin");
			int num10 = 20;
			UpdateScrollOffset();
			buttonRect.width = 340f;
			buttonRect.x = buttonRect.x - 20f + (float)num10 - 25f;
			buttonRect.y = -20f * scaleFactor;
			buttonRect.y += scrollOffset;
			GUI.Label(new Rect(screenWidth - 410f + (float)num10, screenHeight - 270f, 375f, 250f), string.Empty, "white");
			int num11 = 0;
			for (int i = 0; i < Extensions.get_length((System.Array)gameControl.shopList); i++)
			{
				tempString = gameControl.shopList[i];
				string[] array = tempString.Split(char.Parse("_"));
				buttonRect.y += 20f * scaleFactor;
				if (!(buttonRect.y <= screenHeight * 0.5f) && !(buttonRect.y >= screenHeight - 30f))
				{
					if (!(Mathf.Abs(buttonRect.y - (float)targetY) >= 22f))
					{
						num11 = i;
					}
					int num12 = gameControl.FindItemSlot(tempString);
					string text5 = array[1];
					if (gameControl.cheatsOn && gameControl.itemRarity[num12] == 0)
					{
						text5 += "**";
					}
					if (gameControl.itemOwned[num12])
					{
						GUI.Label(buttonRect, text5);
					}
					else
					{
						GUI.Label(buttonRect, text5, "graytext");
					}
				}
			}
			if (num11 != activeID && num11 >= 0)
			{
				activeID = num11;
				gameControl.ReviewItem(gameControl.shopList[activeID]);
				gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dullclick"));
			}
			scrollLimit = buttonRect.y;
			tempString = gameControl.reviewItemName + "\n\n";
			if (gameControl.itemOwned[gameControl.reviewItemID])
			{
				tempString += gameControl.reviewItemDesc;
			}
			else if (gameControl.itemRarity[gameControl.reviewItemID] == 0)
			{
				tempString += gameControl.reviewItemDesc;
			}
			else
			{
				tempString += gameControl.reviewItemDesc;
			}
			GUI.Label(new Rect(screenWidth - 400f + (float)num10, screenHeight - 275f, 357f, 270f), string.Empty, "spinner");
			TintLabel(new Rect(screenWidth - 415f + (float)num10, 0f, 400f, 640f), tempString, "shop");
			if (gameControl.cheatsOn)
			{
				maxID++;
				AdjustRect(new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f), maxID);
				if (GUI.Button(tempRect, "Wear") || isSelected)
				{
					joystickTimer = Time.realtimeSinceStartup;
					gameControl.tryingItOn = false;
					gameControl.BuyItem(gameControl.reviewItemFilename, false);
					StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
					gameControl.MakeList("outfit", isShop);
				}
			}
			else if (!gameControl.itemOwned[gameControl.reviewItemID])
			{
				if (gameControl.itemRarity[gameControl.reviewItemID] == -1)
				{
					GUI.Label(new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f), "LOCKED", "heading");
					if (gameControl.itemAwardedDesc[gameControl.reviewItemID] != "none")
					{
						GUI.Label(new Rect(screenWidth - 420f + (float)num10, 200f, 380f, 40f), gameControl.itemAwardedDesc[gameControl.reviewItemID], "bestscore");
					}
				}
				else if (gameControl.worldLocked[gameControl.itemRarity[gameControl.reviewItemID] - 1])
				{
					GUI.Label(new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f), "UNLOCK WORLD " + gameControl.itemRarity[gameControl.reviewItemID], "heading");
				}
				else
				{
					if (gameControl.itemAwardedDesc[gameControl.reviewItemID] != "none")
					{
						GUI.Label(new Rect(screenWidth - 420f + (float)num10, 200f, 380f, 40f), gameControl.itemAwardedDesc[gameControl.reviewItemID], "bestscore");
					}
					string text6 = "Buy: " + gameControl.reviewItemCost;
					if (gameControl.reviewItemCost == 0)
					{
						text6 = "Free";
					}
					if (gameControl.playerData.gems < gameControl.reviewItemCost)
					{
						if (gameControl.store)
						{
							maxID++;
							tempRect = new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f);
							AdjustRect(tempRect, maxID);
							if (GUI.Button(tempRect, text6) || isSelected)
							{
								shopMessage = string.Empty + (gameControl.reviewItemCost - gameControl.playerData.gems) + " more gems for: " + gameControl.reviewItemName;
								menu = "moregems";
							}
						}
						else
						{
							tempRect = new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f);
							GUI.Label(tempRect, gameControl.reviewItemCost + " GEMS", "heading");
						}
					}
					else
					{
						maxID++;
						AdjustRect(new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f), maxID);
						if (GUI.Button(tempRect, text6) || isSelected)
						{
							gameControl.tryingItOn = false;
							gameControl.BuyItem(gameControl.reviewItemFilename, true);
							StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
							isShop = true;
							gameControl.MakeList("outfit", isShop);
							ScrollToActiveOutfit();
						}
					}
				}
			}
			else
			{
				maxID++;
				AdjustRect(new Rect(screenWidth - 380f + (float)num10, 220f, 310f, 64f), maxID);
				if (GUI.Button(tempRect, "Wear", "button") || isSelected)
				{
					joystickTimer = Time.realtimeSinceStartup;
					StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
				}
				if (gameControl.itemAwardedDesc[gameControl.reviewItemID] != "none")
				{
					GUI.Label(new Rect(screenWidth - 420f + (float)num10, 200f, 380f, 40f), gameControl.itemAwardedDesc[gameControl.reviewItemID], "bestscore");
				}
			}
			maxID++;
			AdjustRect(backRect, maxID);
			if (TintButton(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			Rect whichRect = new Rect(20f, -25f, 100f, 100f);
			if (gameControl.store)
			{
				maxID++;
				whichRect.y += 105f;
				AdjustRect(whichRect, maxID);
				if (TintButton(tempRect, string.Empty, "store") || isSelected)
				{
					backMenu = menu;
					menu = "store";
				}
			}
			if (videoReady)
			{
				whichRect.y += 105f;
				if (TintButton(whichRect, string.Empty, "freegems"))
				{
					gameControl.VideoShow();
				}
			}
			maxID++;
			AdjustRect(new Rect(450f, 12f, 90f, 90f), maxID);
			if (TintButton(tempRect, string.Empty, "gender") || isSelected)
			{
				string gender = "female";
				if (gameControl.gender == "female")
				{
					gender = "male";
				}
				gameControl.gender = gender;
				Restart("Title");
				gameControl.levelHint = "Gender Operation Underway\n\nBest not to rush these things... ;)";
			}
			pageUp = false;
			pageDown = false;
			if (gameControl.lite && GUI.Button(new Rect(10f, 80f, 140f, 140f), (Texture)Resources.Load(gameControl.appName + "/upgrade"), "label"))
			{
				Upgrade();
			}
			break;
		}
		case "moregems":
			flag = true;
			showActive = false;
			maxID = 2;
			saveMenuList = false;
			AdjustRect(backRect, maxID);
			if (GUI.Button(tempRect, string.Empty, "back") || isSelected)
			{
				ShowLastMenu();
			}
			tempString = "\n\n\nYou need " + (gameControl.reviewItemCost - gameControl.playerData.gems) + " more gems to purchase:\n" + gameControl.reviewItemName;
			GUI.Label(new Rect(568f, 170f, 380f, 300f), tempString, "heading");
			GUI.Label(new Rect(690f, 180f, 120f, 90f), (Texture)Resources.Load("gems_10000"));
			buttonRect.y -= 240f;
			AdjustRect(buttonRect, 1);
			if (GUI.Button(tempRect, "Get More Gems") || isSelected)
			{
				menu = "store";
			}
			break;
		case "shopitems":
		{
			GUI.Label(new Rect(410f, 530f, 140f, 80f), string.Empty, "zoomin");
			if (activeID == -1)
			{
				activeID = 0;
				scrollOffset = targetY;
				gameControl.ReviewItem(gameControl.shopList[activeID]);
			}
			UpdateScrollOffset();
			buttonRect.x -= 20f;
			buttonRect.y = -20f * scaleFactor;
			buttonRect.y += scrollOffset;
			if (GUI.Button(backRect, string.Empty, "back"))
			{
				ShowLastMenu();
			}
			GUI.Label(new Rect(screenWidth - 390f, screenHeight - 270f, 337f, 250f), string.Empty, "white");
			int num = 0;
			for (int i = 0; i < Extensions.get_length((System.Array)gameControl.shopList); i++)
			{
				tempString = gameControl.shopList[i];
				string[] array = tempString.Split(char.Parse("_"));
				buttonRect.y += 20f * scaleFactor;
				if (!(buttonRect.y <= screenHeight * 0.5f) && !(buttonRect.y >= screenHeight - 30f))
				{
					if (!(Mathf.Abs(buttonRect.y - (float)targetY) >= 22f))
					{
						num = i;
					}
					GUI.Label(buttonRect, array[1]);
				}
			}
			if (num != activeID && num >= 0)
			{
				activeID = num;
				gameControl.ReviewItem(gameControl.shopList[activeID]);
				gameControl.PlaySound((AudioClip)Resources.Load("Sounds/dullclick"));
			}
			scrollLimit = buttonRect.y;
			tempString = gameControl.reviewItemName + "\n\n" + gameControl.reviewItemDesc;
			if (isShop)
			{
				tempString += "\n\nCost: " + gameControl.reviewItemCost;
			}
			GUI.Label(new Rect(screenWidth - 385f, screenHeight - 275f, 332f, 270f), string.Empty, "spinner");
			GUI.Label(new Rect(screenWidth - 400f, 0f, 410f, 640f), tempString, "shop");
			GUI.Label(new Rect(screenWidth - 54f, 0f, 40f, 640f), tempString, "shopicons");
			GUI.Label(new Rect(screenWidth - 170f, 250f, 100f, 100f), (Texture)Resources.Load("GUI/" + gameControl.reviewItemCategory));
			if (isShop)
			{
				if (GUI.Button(new Rect(screenWidth - 220f, 20f, 150f, 64f), "Wear"))
				{
					gameControl.BuyItem(gameControl.reviewItemFilename, true);
					StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
					gameControl.MakeList("outfit", isShop);
				}
				GUI.Label(new Rect(10f, 10f, 500f, 64f), "Gems to Spend: " + gameControl.playerData.gems, "label");
			}
			else
			{
				if (GUI.Button(new Rect(screenWidth - 380f, 20f, 150f, 64f), "Wear"))
				{
					StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
				}
				if (GUI.Button(new Rect(screenWidth - 220f, 20f, 150f, 64f), "Shop"))
				{
					activeID = -1;
					isShop = true;
					gameControl.MakeList("outfit", isShop);
				}
			}
			CheckCategory();
			GUI.Label(categoryRect, string.Empty, "circle");
			break;
		}
		case "shopitemsOLD":
		{
			UpdateScrollOffset();
			buttonRect.y = -20f * scaleFactor;
			buttonRect.y += scrollOffset;
			if (GUI.Button(backRect, string.Empty, "back"))
			{
				ShowLastMenu();
			}
			if (activeID == -1)
			{
				activeID = 0;
				gameControl.ReviewItem(gameControl.shopList[activeID]);
			}
			string text7 = string.Empty;
			for (int i = 0; i < Extensions.get_length((System.Array)gameControl.shopList); i++)
			{
				tempString = gameControl.shopList[i];
				string[] array = tempString.Split(char.Parse("_"));
				if (text7 != array[0])
				{
					text7 = array[0];
					buttonRect.y += 40f * scaleFactor;
					if (!(buttonRect.y <= -60f * scaleFactor) && !(buttonRect.y >= screenHeight + 30f))
					{
						GUI.Label(buttonRect, text7, "heading");
					}
				}
				buttonRect.y += 40f * scaleFactor;
				if (buttonRect.y <= -60f * scaleFactor || buttonRect.y >= screenHeight + 30f)
				{
					continue;
				}
				if (isShop)
				{
					if (activeID == i)
					{
						if (!GUI.Button(buttonRect, array[1], "active"))
						{
						}
					}
					else if (GUI.Button(buttonRect, array[1]))
					{
						activeID = i;
						gameControl.ReviewItem(tempString);
					}
				}
				else if (GUI.Button(buttonRect, array[1]))
				{
					scrollSpeed = 0f;
					StartCoroutine(gameControl.ActivateItem(tempString));
				}
			}
			scrollLimit = buttonRect.y;
			if (isShop)
			{
				if (GUI.Button(new Rect(10f, 10f, 200f, 64f), "Try On"))
				{
					gameControl.TryOnItem(gameControl.reviewItemFilename);
				}
				if (gameControl.playerData.gems < gameControl.reviewItemCost)
				{
					GUI.Label(new Rect(230f, 10f, 350f, 64f), "Cost: " + gameControl.reviewItemCost, "heading");
				}
				else if (GUI.Button(new Rect(230f, 10f, 350f, 64f), "Buy: " + gameControl.reviewItemCost))
				{
					gameControl.BuyItem(gameControl.reviewItemFilename, true);
					StartCoroutine(gameControl.ActivateItem(gameControl.reviewItemFilename));
					gameControl.MakeList("outfit", isShop);
				}
				GUI.Label(new Rect(170f, 570f, 430f, 64f), "Gems to Spend: " + gameControl.playerData.gems, "hint");
			}
			else if (GUI.Button(new Rect(10f, 10f, 200f, 64f), "Shop"))
			{
				activeID = -1;
				isShop = true;
				gameControl.MakeList("outfit", isShop);
			}
			break;
		}
		case "shop":
			UpdateScrollOffset();
			buttonRect.y += scrollOffset;
			if (GUI.Button(backRect, string.Empty, "back"))
			{
				menu = "dev";
			}
			if (Application.isEditor)
			{
				if (GUI.Button(new Rect(screenWidth * 0.5f - 50f, screenHeight - 40f, 100f, 32f), "Randomize"))
				{
					gameControl.RandomizeOutfit(true);
					gameControl.MakeList("outfit", true);
				}
				if (GUI.Button(new Rect(screenWidth * 0.5f - 50f, screenHeight - 40f - 40f, 100f, 32f), "Print"))
				{
					gameControl.PrintOutfit();
				}
			}
			scrollLimit = buttonRect.y;
			break;
		case "dev":
		{
			if (GUI.Button(backRect, string.Empty, "back"))
			{
				menu = gameControl.gameMenu;
				StartCoroutine(gameControl.PauseGame(false));
			}
			GUI.Label(new Rect(screenWidth * 0.5f - 150f * scaleFactor, 5f, 300f * scaleFactor, 30f * scaleFactor), gameControl.playerName + "  LEVEL:" + gameControl.playerData.level + "     XP:" + gameControl.playerData.xp + "      GEMS:" + gameControl.playerData.gems);
			buttonRect.y -= 40f * scaleFactor;
			if (GUI.Button(buttonRect, "Inventory"))
			{
				isShop = false;
				gameControl.MakeList("all", isShop);
				menu = "shopitems";
			}
			buttonRect.y -= 40f * scaleFactor;
			if (GUI.Button(buttonRect, "Shop"))
			{
				isShop = true;
				gameControl.MakeList("all", isShop);
				menu = "shopitems";
			}
			buttonRect.y -= 40f * scaleFactor;
			string text3 = "point";
			if (GUI.Button(buttonRect, gameControl.controltype))
			{
				text3 = ((gameControl.playerData.controltype == "drag") ? "joystick" : ((gameControl.playerData.controltype == "joystick") ? "tilt" : ((!(gameControl.playerData.controltype == "tilt")) ? "joystick" : "point")));
				gameControl.ChangeControl(text3);
			}
			if (Application.loadedLevelName.IndexOf(gameControl.appName) != -1)
			{
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Title Menu"))
				{
					StartCoroutine(gameControl.ChangeScene("Title", true));
				}
			}
			else
			{
				buttonRect.y -= 40f * scaleFactor;
				if (GUI.Button(buttonRect, "Back to Main"))
				{
					StartCoroutine(gameControl.ChangeScene("Main", true));
				}
			}
			break;
		}
		case "gender":
		{
			buttonRect.y = screenHeight - 40f * scaleFactor;
			buttonRect.y -= 40f * scaleFactor;
			if (GUI.Button(buttonRect, gameControl.gender))
			{
				Restart("Main");
			}
			string text = "female";
			if (gameControl.gender == "female")
			{
				text = "male";
			}
			buttonRect.y -= 40f * scaleFactor;
			if (GUI.Button(buttonRect, text))
			{
				gameControl.gender = text;
				Restart("Main");
			}
			buttonRect.y -= 40f * scaleFactor;
			GUI.Label(buttonRect, "CHOOSE A GENDER");
			break;
		}
		case "onlinescores":
			GUI.Label(new Rect(screenWidth * 0.75f - 100f * scaleFactor, screenHeight * 0.5f + 20f * scaleFactor, 200f * scaleFactor, 40f * scaleFactor), "Would you like to activate online Leaderboards?");
			buttonRect = new Rect(screenWidth * 0.75f - 75f * scaleFactor, screenHeight - 50f * scaleFactor, 150f * scaleFactor, 32f * scaleFactor);
			if (GUI.Button(buttonRect, "Yes"))
			{
				gameControl.attemptLogin = true;
				Restart("Main");
			}
			buttonRect.y -= 40f * scaleFactor;
			if (GUI.Button(buttonRect, "Maybe Later"))
			{
				Restart("Main");
			}
			break;
		case "optionsOLD":
			GUI.Label(new Rect(screenWidth * 0.5f - 150f, 5f, 300f, 30f), gameControl.playerName + "  LEVEL:" + gameControl.playerData.level + "     XP:" + gameControl.playerData.xp + "      GEMS:" + gameControl.playerData.gems);
			GUI.Label(new Rect(screenWidth * 0.5f - 200f, 25f, 400f, 40f), "CREATE A NEW SAVE FILE?");
			if (GUI.Button(new Rect(screenWidth * 0.5f - 110f, 60f, 100f, 32f), "NO"))
			{
				menu = "title";
			}
			if (GUI.Button(new Rect(screenWidth * 0.5f + 10f, 60f, 100f, 32f), "YES"))
			{
				gameControl.ClearFile(newName);
				gameControl.playerName = newName;
				menu = "login";
			}
			break;
		}
		if (flag && (bool)gameControl.playerControl)
		{
			tempString = string.Empty + gameControl.playerControl.playerData.gems;
			if (GUI.Button(gemRect, tempString, "gemcount") && gameControl.store)
			{
				menu = "store";
			}
			tempString = string.Empty + gameControl.tokens;
			if (GUI.Button(tokenRect, tempString, "tokencount") && gameControl.store)
			{
				menu = "store";
			}
		}
		if (flag2)
		{
			float num32 = 390f;
			if (gameControl.canEarnDaily)
			{
				float width = Mathf.Clamp(280f * ((float)gameControl.dailyXP * 1f / 100f), 20f, 280f);
				GUI.Button(new Rect(num32, 16f, 440f, 60f), "BONUS:", "headingleft");
				TintLabel(new Rect(num32 + 140f, 30f, width, 26f), string.Empty, "bonusbar");
			}
			else
			{
				GUI.Button(new Rect(num32, 16f, 420f, 60f), "next daily in   " + TimeUntilMidnight(), "headingleft");
			}
		}
		if (flag3)
		{
			if (gameControl.globalScores == "google")
			{
				if (gameControl.loginState == "in")
				{
					maxID++;
					Rect whichRect = new Rect(860f, 20f, 50f, 50f);
					AdjustRect(whichRect, maxID);
					if (TintButton(tempRect, string.Empty, gameControl.globalScores) || isSelected)
					{
						gameControl.ShowScoreboard();
					}
					maxID++;
					whichRect = new Rect(860f, 70f, 50f, 50f);
					AdjustRect(whichRect, maxID);
					if (TintButton(tempRect, string.Empty, "achievements") || isSelected)
					{
						gameControl.ShowAchievements();
					}
				}
				else
				{
					maxID++;
					Rect whichRect = new Rect(850f, 20f, 90f, 90f);
					AdjustRect(whichRect, maxID);
					if (GUI.Button(tempRect, string.Empty, "google_plus") || isSelected)
					{
						gameControl.ShowScoreboard();
					}
				}
			}
			else if (gameControl.loginState == "in" || gameControl.cheatsOn)
			{
				maxID++;
				Rect whichRect = new Rect(850f, 20f, 90f, 90f);
				AdjustRect(whichRect, maxID);
				if (GUI.Button(tempRect, string.Empty, gameControl.globalScores) || isSelected)
				{
					gameControl.ShowScoreboard();
				}
			}
			else if (gameControl.showLinks)
			{
				maxID++;
				Rect whichRect = new Rect(850f, 25f, 90f, 90f);
				AdjustRect(whichRect, maxID);
				if (GUI.Button(tempRect, string.Empty, "facebook") || isSelected)
				{
					Application.OpenURL("http://www.facebook.com/ezonecom");
				}
			}
		}
		if (gameControl.devicemodel == "gamestick" && menu != "game")
		{
			GUI.Label(new Rect(110f, 603f, 200f, 30f), string.Empty, "gamestickbuttons");
		}
		if (!(hintWarp != string.Empty) || hintY < -100f)
		{
			return;
		}
		hintY = Mathf.Clamp(hintY + hintDelta * 0.03f * 100f, -100f, 10f);
		string lhs = "Touch here to ";
		if (eInput.controlType == "ouya")
		{
			lhs = "Press 'U' to ";
		}
		else if (eInput.controlType != "touch")
		{
			lhs = "Press 'X' to ";
		}
		if (hintWarp != string.Empty)
		{
			if (GUI.Button(new Rect(screenWidth * 0.5f - 200f * scaleFactor, hintY * scaleFactor, 360f * scaleFactor, 60f * scaleFactor), lhs + hintText, "hint") || eInput.rightPadLeft)
			{
				gameControl.missionOver = true;
				StartCoroutine(gameControl.ChangeScene(hintWarp, true));
				hintWarp = string.Empty;
			}
		}
		else if (!GUI.Button(new Rect(screenWidth * 0.5f - 200f * scaleFactor, hintY * scaleFactor, 360f * scaleFactor, 60f * scaleFactor), lhs + hintText, "hint"))
		{
		}
		if (!(Time.realtimeSinceStartup <= hintTimer) && hintY == 10f && hideHint)
		{
			hintDelta = -1f;
		}
	}

	public virtual void Main()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
	}
}
