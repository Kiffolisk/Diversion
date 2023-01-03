using System;
using UnityEngine;

public class eInput : MonoBehaviour
{
	public bool debugOn;

	public GUISkin mySkin;

	public static bool leftPadUp;

	public static bool leftPadLeft;

	public static bool leftPadDown;

	public static bool leftPadRight;

	public static bool leftAction;

	public static bool rightPadLeft;

	public static bool rightPadUp;

	public static bool rightPadDown;

	public static bool rightPadRight;

	public static bool rightAction;

	public static bool Select;

	public static bool Start;

	public static bool L1;

	public static bool L2;

	public static bool R1;

	public static bool R2;

	public static float leftJoyX;

	public static float leftJoyY;

	public static float rightJoyX;

	public static float rightJoyY;

	public Matrix4x4 scaledMatrix;

	public static string controlType = "touch";

	public static string rawName = string.Empty;

	private string activeButton = string.Empty;

	private bool notReady;

	private void CheckConnections()
	{
		controlType = "touch";
		if (Input.GetJoystickNames().Length > 0)
		{
			rawName = Input.GetJoystickNames()[0].ToLower();
			if (rawName.IndexOf("moga pro") != -1)
			{
				controlType = "mogapro";
			}
			else if (rawName.IndexOf("playstation") != -1)
			{
				controlType = "ps3";
			}
			else if (rawName.IndexOf("moga") != -1)
			{
				controlType = "moga";
			}
			else if (rawName.IndexOf("gamestick") != -1)
			{
				controlType = "gamestick";
			}
			else if (rawName.IndexOf("ouya") != -1)
			{
				controlType = "ouya";
			}
			else if (rawName.IndexOf("nvidia") != -1)
			{
				controlType = "nvidia";
			}
			else if (rawName.IndexOf("wiimote") != -1)
			{
				controlType = "wii";
			}
			else if (rawName.IndexOf("green") != -1)
			{
				controlType = "greenthrottle";
			}
			else if (rawName.IndexOf("icontrol") != -1)
			{
				controlType = "icontrolpad";
			}
			else if (rawName.IndexOf("samsung bluetooth hid") != -1)
			{
				controlType = "hid";
			}
			else if (rawName == string.Empty || rawName.IndexOf("xbox") != -1)
			{
				controlType = "xbox360";
			}
			else
			{
				controlType = "gamepad";
			}
		}
	}

	private void Awake()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		ResizeGUI();
		CheckConnections();
	}

	private void ResizeGUI()
	{
		float num = 1f;
		float y = 0f;
		float x = 0f;
		if ((float)Screen.width * 1f / (float)Screen.height > 1.5f)
		{
			num = (float)Screen.height / 640f;
			x = ((float)Screen.width - 960f * num) * 0.5f;
		}
		else
		{
			num = (float)Screen.width / 960f;
			y = ((float)Screen.height - 640f * num) * 0.5f;
		}
		scaledMatrix.SetTRS(new Vector3(x, y, 0f), Quaternion.identity, new Vector3(num, num, num));
	}

	private void OnGUI()
	{
		if (debugOn)
		{
			CheckButtons();
			GUI.skin = mySkin;
			GUI.matrix = scaledMatrix;
			GUI.Label(new Rect(100f, 580f, 1000f, 200f), activeButton + ":" + rawName);
			GUI.Label(new Rect(100f, 50f, 1000f, 200f), string.Empty + controlType + ": " + leftJoyX);
			GUI.Label(new Rect(700f, 50f, 1000f, 200f), string.Empty + leftJoyY);
			GUI.Label(new Rect(100f, 100f, 1000f, 200f), "Right Stick: " + rightJoyX);
			GUI.Label(new Rect(700f, 100f, 1000f, 200f), string.Empty + rightJoyY);
			GUI.Label(new Rect(100f, 200f, 1000f, 200f), "Up: " + leftPadUp);
			GUI.Label(new Rect(100f, 250f, 1000f, 200f), "Left: " + leftPadLeft);
			GUI.Label(new Rect(100f, 300f, 1000f, 200f), "Down: " + leftPadDown);
			GUI.Label(new Rect(100f, 350f, 1000f, 200f), "Right: " + leftPadRight);
			GUI.Label(new Rect(100f, 400f, 1000f, 200f), "L1: " + L1);
			GUI.Label(new Rect(100f, 500f, 1000f, 200f), "SELECT: " + Select);
			GUI.Label(new Rect(600f, 200f, 1000f, 200f), "RUp: " + rightPadUp);
			GUI.Label(new Rect(600f, 250f, 1000f, 200f), "RLeft: " + rightPadLeft);
			GUI.Label(new Rect(600f, 300f, 1000f, 200f), "RDown: " + rightPadDown);
			GUI.Label(new Rect(600f, 350f, 1000f, 200f), "RRight: " + rightPadRight);
			GUI.Label(new Rect(600f, 400f, 1000f, 200f), "R1: " + R1);
			GUI.Label(new Rect(600f, 500f, 1000f, 200f), "START: " + Start);
			if (Input.GetKeyDown("escape"))
			{
				Application.Quit();
			}
		}
	}

	private void Update()
	{
		switch (controlType)
		{
		case "hid":
			UpdateHID();
			break;
		case "ps3":
			UpdatePS3();
			break;
		case "xbox360":
			UpdateXbox360();
			break;
		case "mogahid":
			UpdateMogaHID();
			break;
		case "ios":
			UpdateIOS();
			break;
		case "mogapro":
		case "moga":
			UpdateMogaHID();
			break;
		case "gamestick":
			UpdateGamestick();
			break;
		case "ouya":
			UpdateOuya();
			break;
		case "nvidia":
			UpdateNvidia();
			break;
		case "xperia":
			UpdateXperia();
			break;
		case "icontrolpad":
			UpdateIControlPad();
			break;
		default:
			UpdateNormal();
			break;
		}
	}

	private void CheckButtons()
	{
		activeButton = string.Empty;
		for (int i = 0; i < 20; i++)
		{
			string value = "JoystickButton" + i;
			KeyCode key = (KeyCode)(int)Enum.Parse(typeof(KeyCode), value);
			if (Input.GetKey(key))
			{
				activeButton = value;
			}
		}
	}

	private void UpdateIControlPad()
	{
		leftPadUp = Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.UpArrow);
		leftPadLeft = Input.GetKey(KeyCode.JoystickButton2) || Input.GetKey(KeyCode.LeftArrow);
		leftPadDown = Input.GetKey(KeyCode.JoystickButton3) || Input.GetKey(KeyCode.DownArrow);
		leftPadRight = Input.GetKey(KeyCode.JoystickButton1) || Input.GetKey(KeyCode.RightArrow);
		rightPadDown = /*Input.GetKey(KeyCode.A) || */Input.GetKey(KeyCode.JoystickButton12) || Input.GetKey("space");
		rightPadRight = /*Input.GetKey(KeyCode.B) || */Input.GetKey(KeyCode.JoystickButton13) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		rightPadLeft = /*Input.GetKey(KeyCode.Y) || */Input.GetKey(KeyCode.JoystickButton11);
		rightPadUp = /*Input.GetKey(KeyCode.X) || */Input.GetKey(KeyCode.JoystickButton10);
		Select = Input.GetKey(KeyCode.JoystickButton8) || Input.GetKey(KeyCode.Space);
		Start = Input.GetKey(KeyCode.JoystickButton9) || Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		L1 = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton14) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton14) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateXbox360()
	{
		leftPadUp = Input.GetKey(KeyCode.JoystickButton5);
		leftPadLeft = Input.GetKey(KeyCode.JoystickButton7);
		leftPadDown = Input.GetKey(KeyCode.JoystickButton6);
		leftPadRight = Input.GetKey(KeyCode.JoystickButton8);
		leftAction = Input.GetKey(KeyCode.JoystickButton11);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton16);
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton17);
		rightPadLeft = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton18);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton19);
		rightAction = Input.GetKey(KeyCode.JoystickButton12);
		Select = Input.GetKey(KeyCode.JoystickButton10);
		Start = Input.GetKey(KeyCode.JoystickButton9);
		L1 = Input.GetKey(KeyCode.JoystickButton13) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton13) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton14) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton14) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdatePS3()
	{
		leftPadUp = Input.GetKey(KeyCode.JoystickButton4);
		leftPadLeft = Input.GetKey(KeyCode.JoystickButton7);
		leftPadDown = Input.GetKey(KeyCode.JoystickButton6);
		leftPadRight = Input.GetKey(KeyCode.JoystickButton5);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton14);
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton13);
		rightPadLeft = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton15);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton12);
		Select = Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey(KeyCode.JoystickButton13);
		Start = Input.GetKey(KeyCode.JoystickButton3);
		L1 = Input.GetKey(KeyCode.JoystickButton10) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton8) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton11) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton9) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateXperia()
	{
		leftPadUp = Input.GetKey(KeyCode.UpArrow);
		leftPadLeft = Input.GetKey(KeyCode.LeftArrow);
		leftPadDown = Input.GetKey(KeyCode.DownArrow);
		leftPadRight = Input.GetKey(KeyCode.RightArrow);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton3) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		rightPadLeft = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton1);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton2);
		Select = Input.GetKey(KeyCode.Pause);
		Start = Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Return);
		L1 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateOuya()
	{
		leftPadUp = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.JoystickButton8);
		leftPadLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.JoystickButton10);
		leftPadDown = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.JoystickButton9);
		leftPadRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.JoystickButton11);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton3);
		rightPadLeft = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton1);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton2);
		Select = Input.GetKey(KeyCode.JoystickButton3) || Input.GetKeyDown(KeyCode.Menu) || Input.GetKeyDown(KeyCode.Escape);
		Start = Input.GetKey(KeyCode.Escape);
		L1 = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton12) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton13) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateGamestick()
	{
		leftPadUp = Input.GetKey(KeyCode.UpArrow);
		leftPadLeft = Input.GetKey(KeyCode.LeftArrow);
		leftPadDown = Input.GetKey(KeyCode.DownArrow);
		leftPadRight = Input.GetKey(KeyCode.RightArrow);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton1) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		rightPadLeft = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton3);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton4);
		Select = Input.GetKeyDown(KeyCode.Escape);
		Start = Input.GetKey(KeyCode.JoystickButton11);
		L1 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateHID()
	{
		leftPadUp = (double)Input.GetAxis("LeftDPadVertical") > 0.5;
		leftPadLeft = (double)Input.GetAxis("LeftDPadHorizontal") < -0.5;
		leftPadDown = (double)Input.GetAxis("LeftDPadVertical") < -0.5;
		leftPadRight = (double)Input.GetAxis("LeftDPadHorizontal") > 0.5;
		rightPadDown = Input.GetKey(KeyCode.JoystickButton0);
		rightPadRight = Input.GetKey(KeyCode.JoystickButton1);
		rightPadLeft = Input.GetKey(KeyCode.JoystickButton3);
		rightPadUp = Input.GetKey(KeyCode.JoystickButton4);
		Start = Input.GetKey(KeyCode.JoystickButton11) || Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		L1 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateNvidia()
	{
		leftPadUp = (double)Input.GetAxis("LeftDPadVertical") > 0.5;
		leftPadLeft = (double)Input.GetAxis("LeftDPadHorizontal") < -0.5;
		leftPadDown = (double)Input.GetAxis("LeftDPadVertical") < -0.5;
		leftPadRight = (double)Input.GetAxis("LeftDPadHorizontal") > 0.5;
		rightPadDown = Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.JoystickButton1) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		rightPadLeft = Input.GetKey(KeyCode.JoystickButton3);
		rightPadUp = Input.GetKey(KeyCode.JoystickButton4);
		Select = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton11);
		Start = Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		L1 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
		if (notReady)
		{
			rightPadDown = false;
			if (!Input.GetKey(KeyCode.JoystickButton0))
			{
				notReady = false;
			}
		}
	}

	private void UpdateMogaHID()
	{
		leftPadUp = Input.GetKey(KeyCode.UpArrow);
		leftPadLeft = Input.GetKey(KeyCode.LeftArrow);
		leftPadDown = Input.GetKey(KeyCode.DownArrow);
		leftPadRight = Input.GetKey(KeyCode.RightArrow);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton1) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		rightPadLeft = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton2);
		rightPadUp = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton3);
		Select = Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton6);
		Start = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		L1 = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton4) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton5) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateIOS()
	{
		leftPadUp = Input.GetKey(KeyCode.JoystickButton4);
		leftPadLeft = Input.GetKey(KeyCode.JoystickButton7);
		leftPadDown = Input.GetKey(KeyCode.JoystickButton6);
		leftPadRight = Input.GetKey(KeyCode.JoystickButton5);
		rightPadDown = Input.GetKey(KeyCode.JoystickButton14);
		rightPadRight = Input.GetKey(KeyCode.JoystickButton13);
		rightPadLeft = Input.GetKey(KeyCode.JoystickButton15);
		rightPadUp = Input.GetKey(KeyCode.JoystickButton12);
		Select = Input.GetKey(KeyCode.JoystickButton0);
		Start = Input.GetKey(KeyCode.JoystickButton0);
		L1 = Input.GetKey(KeyCode.JoystickButton8);
		L2 = Input.GetKey(KeyCode.JoystickButton10);
		R1 = Input.GetKey(KeyCode.JoystickButton9);
		R2 = Input.GetKey(KeyCode.JoystickButton11);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void UpdateNormal()
	{
		leftPadUp = Input.GetKey(KeyCode.UpArrow);
		leftPadLeft = Input.GetKey(KeyCode.LeftArrow);
		leftPadDown = Input.GetKey(KeyCode.DownArrow);
		leftPadRight = Input.GetKey(KeyCode.RightArrow);
		rightPadDown = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.JoystickButton0) || Input.GetKey("space");
		rightPadRight = Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.JoystickButton1);
		rightPadLeft = Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.JoystickButton3);
		rightPadUp = Input.GetKey(KeyCode.Y) || Input.GetKey(KeyCode.JoystickButton4);
		Select = Input.GetKey(KeyCode.Home) || Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Pause) || Input.GetKeyDown(KeyCode.Return);
		Start = Input.GetKey(KeyCode.Space);
		L1 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		L2 = Input.GetKey(KeyCode.JoystickButton6) || Input.GetKey(KeyCode.LeftShift);
		R1 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		R2 = Input.GetKey(KeyCode.JoystickButton7) || Input.GetKey(KeyCode.RightShift);
		leftJoyX = Input.GetAxis("Horizontal");
		leftJoyY = Input.GetAxis("Vertical");
		rightJoyX = Input.GetAxis("RightHorizontal");
		rightJoyY = Input.GetAxis("RightVertical");
	}

	private void OnApplicationPause(bool pauseState)
	{
		rightPadDown = false;
		rightPadRight = false;
		if (controlType == "nvidia")
		{
			notReady = true;
		}
	}
}
