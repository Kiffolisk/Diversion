using System;
using UnityEngine;

[Serializable]
public class PlayerInput : MonoBehaviour
{
	public Texture2D joystickButton;

	public Texture2D joystickBackButton;

	public Texture2D tiltButton;

	public Texture2D footButton;

	public Texture2D boardButton;

	public Texture2D jumpButton;

	public Texture2D punchButton;

	public Texture2D kickButton;

	public Texture2D fireButton;

	public Texture2D dropButton;

	public GUITexture moveGUI;

	public GUITexture moveBackGUI;

	public GUITexture modeGUI;

	public GUITexture touch1GUI;

	public GUITexture touch2GUI;

	public GUITexture touch3GUI;

	public GameObject touchTarget;

	private float minX;

	private float maxX;

	private float minY;

	private float maxY;

	private float baseAlpha;

	private float touchAlpha;

	private float input;

	private GameControl gameControl;

	private Rect zeroRect;

	private Rect zeroPixelInset;

	private int touchId;

	private Vector3 myDelta;

	private string myMode;

	private string myControl;

	public Vector3 targetPoint;

	private float touchTimer;

	private string nextMode;

	private float scaleFactor;

	private bool lastPause;

	private bool modeActive;

	private bool iCadeActive;

	private bool notZeroedYet;

	public PlayerInput()
	{
		minX = -40f;
		maxX = 40f;
		minY = -40f;
		maxY = 40f;
		baseAlpha = 0.25f;
		touchAlpha = 0.5f;
		zeroRect = new Rect(0f, 0f, 0f, 0f);
		zeroPixelInset = new Rect(0f, 0f, 0f, 0f);
		touchId = -1;
		myMode = "board";
		myControl = "joystick";
		targetPoint = Vector3.zero;
		nextMode = "none";
		scaleFactor = 1f;
		modeActive = true;
		notZeroedYet = true;
	}

	public virtual void Awake()
	{
		useGUILayout = false;
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		ChangeControl(myControl);
		touchTarget.transform.position = new Vector3(-100000f, -1000000f, -1000000f);
		UpdateColor();
	}

	public virtual void UpdateColor()
	{
		ChangeTint(moveGUI);
		ChangeTint(moveBackGUI);
		ChangeTint(modeGUI);
		ChangeTint(touch1GUI);
		ChangeTint(touch2GUI);
		ChangeTint(touch3GUI);
	}

	public virtual void ChangeTint(GUITexture thisTexture)
	{
		Color color = gameControl.GetColor();
		color.a = 0.25f;
		thisTexture.color = color;
	}

	public virtual void DisableMode()
	{
		modeActive = false;
		modeGUI.enabled = false;
	}

	public virtual void UpdateMode(string newMode)
	{
		myMode = newMode;
		if (myMode == "foot")
		{
			nextMode = "board";
			modeGUI.enabled = true;
			modeGUI.texture = boardButton;
			touch1GUI.enabled = true;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
		}
		else if (myMode == "hang")
		{
			nextMode = "board";
			modeGUI.enabled = true;
			modeGUI.texture = boardButton;
			touch1GUI.enabled = true;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
		}
		else if (myMode == "board")
		{
			nextMode = "foot";
			modeGUI.enabled = true;
			modeGUI.texture = footButton;
			touch1GUI.enabled = false;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
		}
		else if (myMode == "dance")
		{
			nextMode = "foot";
			modeGUI.enabled = true;
			modeGUI.texture = footButton;
			touch1GUI.enabled = false;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
		}
		else if (myMode == "fight")
		{
			nextMode = "foot";
			modeGUI.enabled = true;
			modeGUI.texture = footButton;
			touch1GUI.enabled = true;
			touch2GUI.enabled = true;
			touch3GUI.enabled = true;
		}
		if (!modeActive)
		{
			modeGUI.enabled = false;
		}
		if (myControl == "tilt")
		{
			moveGUI.enabled = false;
			moveBackGUI.enabled = false;
			touchTarget.SetActive(false);
		}
		else if (myControl == "point")
		{
			moveGUI.enabled = false;
			moveBackGUI.enabled = false;
			touchTarget.SetActive(true);
		}
		else
		{
			moveGUI.enabled = true;
			moveBackGUI.enabled = true;
			touchTarget.SetActive(false);
		}
		if (eInput.controlType != "touch")
		{
			moveGUI.enabled = false;
			moveBackGUI.enabled = false;
			modeGUI.enabled = false;
			touch1GUI.enabled = false;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
		}
	}

	public virtual void ChangeControl(string newControl)
	{
		float num = 0f;
		myControl = newControl;
		UpdateMode(myMode);
		scaleFactor = (float)Screen.height / 320f;
		modeGUI.pixelInset = new Rect(-90f * scaleFactor, 230f * scaleFactor + num, 60f * scaleFactor, 60f * scaleFactor);
		touch1GUI.pixelInset = new Rect(-90f * scaleFactor, 20f * scaleFactor + num, 60f * scaleFactor, 60f * scaleFactor);
		touch2GUI.pixelInset = new Rect(-90f * scaleFactor, 90f * scaleFactor + num, 60f * scaleFactor, 60f * scaleFactor);
		touch3GUI.pixelInset = new Rect(-90f * scaleFactor, 160f * scaleFactor + num, 60f * scaleFactor, 60f * scaleFactor);
		minX = -40f * scaleFactor;
		maxX = 40f * scaleFactor;
		minY = -40f * scaleFactor;
		maxY = 40f * scaleFactor;
		baseAlpha = 0.25f;
		touchAlpha = 0.5f;
		if (notZeroedYet)
		{
			UpdateZeroRect(new Vector2(90f * scaleFactor, 70f * scaleFactor + num));
		}
	}

	public virtual void PauseToggle(bool pauseTheGame)
	{
		MonoBehaviour.print("playerInput Paused: " + pauseTheGame);
		if (pauseTheGame)
		{
			modeGUI.enabled = false;
			touch1GUI.enabled = false;
			touch2GUI.enabled = false;
			touch3GUI.enabled = false;
			moveGUI.enabled = false;
			moveBackGUI.enabled = false;
		}
		else
		{
			modeGUI.enabled = true;
			touch1GUI.enabled = true;
			touch2GUI.enabled = true;
			touch3GUI.enabled = true;
			moveGUI.enabled = true;
			moveBackGUI.enabled = true;
		}
		if (!modeActive)
		{
			modeGUI.enabled = false;
		}
	}

	public virtual void Update()
	{
		gameControl.touchingControls = false;
		if (!gameControl.paused)
		{
			CheckTouchButtons();
			if (myControl == "tilt")
			{
				UpdateTilt();
			}
			else if (myControl == "point")
			{
				UpdatePoint();
			}
			else if (myControl == "touch")
			{
				UpdateTouch();
			}
			else
			{
				UpdateJoystick();
			}
		}
	}

	public virtual void CheckTouchButtons()
	{
		gameControl.touchButton[0] = false;
		gameControl.touchButton[1] = false;
		gameControl.touchButton[2] = false;
		int i = 0;
		Touch[] touches = Input42069.touches;
		for (int length = touches.Length; i < length; i++)
		{
			if (modeActive && modeGUI.HitTest(touches[i].position))
			{
				gameControl.touchingControls = true;
				if (touches[i].phase == TouchPhase.Began)
				{
					gameControl.ChangeMode(nextMode);
				}
			}
			if (touch1GUI.enabled && touch1GUI.HitTest(touches[i].position))
			{
				gameControl.touchingControls = true;
				gameControl.touchButton[0] = true;
			}
			if (touch2GUI.enabled && touch2GUI.HitTest(touches[i].position))
			{
				gameControl.touchingControls = true;
				gameControl.touchButton[1] = true;
			}
			if (touch3GUI.enabled && touch3GUI.HitTest(touches[i].position))
			{
				gameControl.touchingControls = true;
				gameControl.touchButton[2] = true;
			}
		}
		if (eInput.rightPadDown)
		{
			gameControl.touchButton[0] = true;
		}
		if (eInput.rightPadLeft)
		{
			gameControl.touchButton[1] = true;
		}
		if (eInput.rightPadUp)
		{
			gameControl.touchButton[2] = true;
		}
		if (modeActive && gameControl.touchButton[2])
		{
			gameControl.ChangeMode(nextMode);
		}
		if (gameControl.touchButton[0])
		{
			float a = touchAlpha;
			Color color = touch1GUI.color;
			float num = (color.a = a);
			Color color3 = (touch1GUI.color = color);
			gameControl.touchingControls = true;
		}
		else
		{
			float a2 = baseAlpha;
			Color color4 = touch1GUI.color;
			float num2 = (color4.a = a2);
			Color color6 = (touch1GUI.color = color4);
		}
		if (gameControl.touchButton[1])
		{
			float a3 = touchAlpha;
			Color color7 = touch2GUI.color;
			float num3 = (color7.a = a3);
			Color color9 = (touch2GUI.color = color7);
			gameControl.touchingControls = true;
		}
		else
		{
			float a4 = baseAlpha;
			Color color10 = touch2GUI.color;
			float num4 = (color10.a = a4);
			Color color12 = (touch2GUI.color = color10);
		}
		if (gameControl.touchButton[2])
		{
			float a5 = touchAlpha;
			Color color13 = touch3GUI.color;
			float num5 = (color13.a = a5);
			Color color15 = (touch3GUI.color = color13);
			gameControl.touchingControls = true;
		}
		else
		{
			float a6 = baseAlpha;
			Color color16 = touch3GUI.color;
			float num6 = (color16.a = a6);
			Color color18 = (touch3GUI.color = color16);
		}
	}

	public virtual void UpdatePoint()
	{
		gameControl.inputVector = Vector3.zero;
		if (gameControl.paused)
		{
			return;
		}
		if (targetPoint != Vector3.zero)
		{
			Vector3 zero = Vector3.zero;
			zero = gameControl.playerControl.modelObject.transform.InverseTransformPoint(targetPoint);
			if (myMode == "foot")
			{
				gameControl.inputVector.x = Mathf.Clamp(zero.x / zero.magnitude, -1f, 1f);
				gameControl.inputVector.y = Mathf.Clamp(zero.z / 10f, -1f, 1f);
				if (!(zero.magnitude >= 5f))
				{
					gameControl.inputVector = Vector3.zero;
				}
			}
			else
			{
				gameControl.inputVector.x = Mathf.Clamp(zero.x / zero.magnitude, -1f, 1f);
				gameControl.inputVector.y = Mathf.Clamp(zero.z / 100f, -1f, 1f);
				if (!(Mathf.Abs(gameControl.inputVector.x) <= 0.75f))
				{
					gameControl.inputVector.y = gameControl.inputVector.y * 0.1f;
				}
				if (!(zero.magnitude >= 5f))
				{
					gameControl.inputVector = Vector3.zero;
				}
				else if (!(zero.magnitude >= gameControl.playerControl.GetComponent<Rigidbody>().velocity.magnitude))
				{
					gameControl.inputVector.y = 0f;
				}
			}
		}
		if (!gameControl.touchingControls && (Input.mousePosition.x >= 40f * scaleFactor || Input.mousePosition.y <= (float)Screen.height - 40f * scaleFactor) && Input.mousePosition.y >= 70f * scaleFactor && Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hitInfo = default(RaycastHit);
			if (Physics.Raycast(ray, out hitInfo))
			{
				targetPoint = hitInfo.point;
				touchTarget.transform.position = targetPoint;
				touchTarget.transform.up = hitInfo.normal;
				touchTarget.transform.position = touchTarget.transform.position + touchTarget.transform.up * 0.25f;
				gameControl.touchingControls = true;
			}
		}
	}

	public virtual void UpdateTilt()
	{
		input = 0f;
		gameControl.inputVector.x = eInput.leftJoyX;
		if (eInput.controlType == "touch")
		{
			gameControl.inputVector.x = (Application.isMobilePlatform ? Mathf.Clamp(Acceleration.acceleration.x * 2f, -1f, 1f) : Input.GetAxis("Horizontal"));
		}
		if (!(eInput.leftJoyY <= 0.5f))
		{
			input = eInput.leftJoyY;
		}
		if (gameControl.touchButton[0])
		{
			input = 1f;
		}
        if (!Application.isMobilePlatform)
        {
            input = Input.GetAxis("Vertical");
        }
        if (Input.GetMouseButton(0) && !(Input.mousePosition.y >= (float)Screen.height * 0.4f))
		{
			input = 1f;
		}
		/*if (eInput.rightPadDown || eInput.leftPadUp)
		{
			input = 1f;
		}*/
		if (eInput.leftPadRight)
		{
			gameControl.inputVector.x = 1f;
		}
		if (eInput.leftPadLeft)
		{
			gameControl.inputVector.x = -1f;
		}
		gameControl.inputVector.y = input;
		if (input == 1f)
		{
			float a = touchAlpha;
			Color color = moveGUI.color;
			float num = (color.a = a);
			Color color3 = (moveGUI.color = color);
			gameControl.touchingControls = true;
		}
		else
		{
			float a2 = baseAlpha;
			Color color4 = moveGUI.color;
			float num2 = (color4.a = a2);
			Color color6 = (moveGUI.color = color4);
		}
	}

	public virtual void UpdateZeroRect(Vector2 centerPos)
	{
		if (notZeroedYet)
		{
			zeroPixelInset = new Rect(centerPos.x - 40f * scaleFactor, centerPos.y - 40f * scaleFactor, 80f * scaleFactor, 80f * scaleFactor);
			moveGUI.pixelInset = zeroPixelInset;
			moveBackGUI.pixelInset = new Rect(centerPos.x - 50f * scaleFactor, centerPos.y - 50f * scaleFactor, 100f * scaleFactor, 100f * scaleFactor);
			zeroRect = moveGUI.GetScreenRect();
			notZeroedYet = false;
		}
	}

	public virtual void UpdateJoystick()
	{
		myDelta = Vector2.zero;
		bool flag = false;
		if (eInput.leftJoyX > 0.1f || !(eInput.leftJoyX >= -0.1f))
		{
			myDelta.x = eInput.leftJoyX * maxX;
		}
		if (eInput.leftJoyY > 0.1f || !(eInput.leftJoyY >= -0.1f))
		{
			myDelta.y = eInput.leftJoyY * maxY;
		}
		int i = 0;
		Touch[] touches = Input.touches;
		for (int length = touches.Length; i < length; i++)
		{
			if (touchId == -1 && !(touches[i].position.x >= (float)Screen.width * 0.3f))
			{
				UpdateZeroRect(touches[i].position);
				touchId = touches[i].fingerId;
				flag = true;
			}
			if (touchId == touches[i].fingerId)
			{
				myDelta.x = 0f - Mathf.Clamp(zeroRect.x + zeroRect.width * 0.5f - touches[i].position.x, minX, maxX);
				myDelta.y = 0f - Mathf.Clamp(zeroRect.y + zeroRect.height * 0.5f - touches[i].position.y, minY, maxY);
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			touchId = -1;
		}
		if (eInput.controlType != "touch")
		{
			touchId = 10;
		}
		if (myMode == "board" && eInput.rightPadDown)
		{
			myDelta.y = maxY;
		}
		if (maxX != 0f)
		{
			gameControl.inputVector.x = myDelta.x / maxX;
		}
		if (minY != 0f)
		{
			gameControl.inputVector.y = (0f - myDelta.y) / minY;
		}
		if (Mathf.Abs(gameControl.inputVector.y) == 1f)
		{
			gameControl.inputVector.x = gameControl.inputVector.x * 0.5f;
		}
		float num = Mathf.Lerp(moveGUI.pixelInset.x, zeroPixelInset.x + myDelta.x, Time.deltaTime * 10f);
		Rect pixelInset = moveGUI.pixelInset;
		float num3 = (pixelInset.x = num);
		Rect rect2 = (moveGUI.pixelInset = pixelInset);
		float num4 = Mathf.Lerp(moveGUI.pixelInset.y, zeroPixelInset.y + myDelta.y, Time.deltaTime * 10f);
		Rect pixelInset2 = moveGUI.pixelInset;
		float num6 = (pixelInset2.y = num4);
		Rect rect4 = (moveGUI.pixelInset = pixelInset2);
		if (myDelta != (Vector3)Vector2.zero)
		{
			float a = touchAlpha;
			Color color = moveGUI.color;
			float num7 = (color.a = a);
			Color color3 = (moveGUI.color = color);
			gameControl.touchingControls = true;
		}
		else
		{
			float a2 = baseAlpha;
			Color color4 = moveGUI.color;
			float num8 = (color4.a = a2);
			Color color6 = (moveGUI.color = color4);
		}
		gameControl.joyTouchID = touchId;
	}

	public virtual void UpdateTouch()
	{
		myDelta = Vector2.zero;
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (eInput.controlType == "touch")
		{
			int i = 0;
			Touch[] touches = Input.touches;
			for (int length = touches.Length; i < length; i++)
			{
				if (!(touches[i].position.y >= (float)Screen.height * 0.5f))
				{
					if (!(touches[i].position.x >= (float)Screen.width * 0.3f))
					{
						flag = true;
						flag3 = true;
					}
					if (!(touches[i].position.x <= (float)Screen.width * 0.7f))
					{
						flag2 = true;
						flag3 = true;
					}
				}
			}
			if (flag && flag2)
			{
				myDelta.y = maxY;
			}
			else if (flag)
			{
				myDelta.x = 0f - maxX;
			}
			else if (flag2)
			{
				myDelta.x = maxX;
			}
		}
		else
		{
			myDelta.x = eInput.leftJoyX * maxX;
			myDelta.y = eInput.leftJoyY * maxY;
			flag3 = true;
		}
		if (maxX != 0f)
		{
			gameControl.inputVector.x = myDelta.x / maxX;
		}
		if (minY != 0f)
		{
			gameControl.inputVector.y = (0f - myDelta.y) / minY;
		}
		if (myDelta != (Vector3)Vector2.zero)
		{
			gameControl.touchingControls = true;
		}
		gameControl.joyTouchID = -1;
	}

	public virtual void Main()
	{
	}
}
