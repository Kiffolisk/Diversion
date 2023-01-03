using System;
using UnityEngine;

[Serializable]
public class FollowCamera : MonoBehaviour
{
	public bool slideDisabled;

	public bool pinchDisabled;

	public float farClip;

	public GameObject followObject;

	private GameObject skyBoxObject;

	public float followDistance;

	public float minFollowDistance;

	public float maxFollowDistance;

	public float followHeight;

	public float minY;

	public string cameraType;

	public float targetOffsetAngle;

	public Vector3 sideviewVector;

	private Transform followTransform;

	private float heightAbove;

	private float lookUp;

	private Transform skyBoxTransform;

	private float deltaDist;

	private float moveSpeed;

	private float heightAboveOrig;

	private Vector3 targetPoint;

	private GameControl gameControl;

	private MenuControl menuControl;

	private int followObjectID;

	private Vector3 halfpipeVector;

	private float adjustedDeltaTime;

	private bool spinCamera;

	private Vector3 origForward;

	private Vector3 origPos;

	private Vector3 followVector;

	private float offsetAngle;

	private float followAngle;

	private bool touchingControls;

	private bool wasTouching;

	private float angleEase;

	private float followDistDefault;

	private float followHeightDefault;

	private string lastCameraType;

	private Vector3 skyOffset;

	private float actionOffset;

	private float targetOffset;

	private bool wasClimbing;

	private float easing;

	private Vector3 offsetVector3;

	private Vector2 lastMouse;

	private bool wasPanTouch;

	private float sideScrollOffset;

	private Vector2 tiltOffset;

	private float lastFollowDistance;

	private float targetFollowDistance;

	private float averageFollowDistance;

	private float climbCounter;

	private Vector3 targetLookAt;

	private int touchId;

	private float deltaAngle;

	public FollowCamera()
	{
		farClip = 400f;
		followDistance = 10f;
		minFollowDistance = 2f;
		maxFollowDistance = 60f;
		followHeight = 0.35f;
		minY = -50f;
		cameraType = "normal";
		sideviewVector = new Vector3(-30f, -15f, -50f);
		heightAbove = 5f;
		lookUp = 5f;
		moveSpeed = 10f;
		halfpipeVector = new Vector3(0f, 0f, 0f);
		adjustedDeltaTime = 0.01f;
		offsetAngle = 180f;
		followAngle = 180f;
		angleEase = 10f;
		lastCameraType = "none";
		easing = 1f;
		offsetVector3 = new Vector3(0f, 0f, 0f);
		sideScrollOffset = -20f;
		lastFollowDistance = 30f;
		targetFollowDistance = 30f;
		averageFollowDistance = 20f;
	}

	public virtual void Awake()
	{
		useGUILayout = false;
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		menuControl = (MenuControl)UnityEngine.Object.FindObjectOfType(typeof(MenuControl));
		if (!gameControl)
		{
			Application.LoadLevel(0);
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		skyBoxObject = GameObject.FindWithTag("Sky");
		if ((bool)skyBoxObject)
		{
			skyBoxTransform = skyBoxObject.transform;
			skyOffset = skyBoxTransform.position - transform.position;
		}
		if (gameControl.missionName == "Diversion")
		{
			followDistance = 1f;
			AdjustForHeadSize(gameControl.headsize);
			ChangeFollowDistance("near");
		}
		heightAbove = followDistance * followHeight;
		heightAboveOrig = heightAbove;
		followHeightDefault = followHeight;
		gameControl.farClip = farClip;
		gameControl.AdjustQuality();
		sideviewVector = new Vector3(-10f, -13.8f, -40f);
		targetFollowDistance = followDistance;
		eScreen.Initialize();
		eScreen.onScreenChanged += ScreenChanged;
		ScreenChanged();
	}

	public virtual void ScreenChanged()
	{
		if (eScreen.isLandscape)
		{
			sideviewVector = new Vector3(-10f, -13.8f, -40f);
		}
		else
		{
			sideviewVector = new Vector3(-28f, -13.8f, -19f);
		}
	}

	public virtual void AdjustForHeadSize(float newSize)
	{
		if (!(gameControl == null) && (gameControl.missionName == "Diversion" || gameControl.missionName == "Title"))
		{
			if (!(newSize < 2f))
			{
				minFollowDistance = 16f;
				followDistDefault = 25f;
				maxFollowDistance = 50f;
				lookUp = 10f;
			}
			else
			{
				minFollowDistance = 14f;
				followDistDefault = 18f;
				maxFollowDistance = 50f;
				lookUp = 6f;
			}
			if (!(followDistance >= followDistDefault))
			{
				ChangeFollowDistance("near");
			}
			averageFollowDistance = (minFollowDistance + maxFollowDistance) / 2f;
		}
	}

	public virtual void ChangeFollowDistance(string newDist)
	{
		if (newDist == "far")
		{
			if (!(gameControl.headsize < 2f))
			{
				followDistance = 40f;
			}
			else
			{
				followDistance = 21f;
			}
		}
		else if (!(gameControl.headsize < 2f))
		{
			followDistance = 30f;
		}
		else
		{
			followDistance = 16f;
		}
		targetFollowDistance = followDistance;
	}

	public virtual void ChangeTargetFollowDistance(float newValue)
	{
		MonoBehaviour.print("Change Follow ditance, old: " + followDistance + ", new: " + newValue);
		targetFollowDistance = newValue;
	}

	public virtual void NormalCamera()
	{
		PinchSlide();
		offsetAngle = Mathf.LerpAngle(offsetAngle, targetOffsetAngle, 0.05f);
		if (gameControl.inair && gameControl.cameraType == "board")
		{
			followAngle = Mathf.LerpAngle(followAngle, followTransform.eulerAngles.y, 0.01f);
		}
		else
		{
			followAngle = Mathf.LerpAngle(followAngle, followTransform.eulerAngles.y, 0.1f);
		}
		float num = offsetAngle + followAngle;
		followVector = new Vector3(Mathf.Sin(num * ((float)Math.PI / 180f)), 0f, Mathf.Cos(num * ((float)Math.PI / 180f)));
		if (gameControl.cameraType == "hang")
		{
			targetPoint = followTransform.position - followVector * followDistance + new Vector3(0f, heightAbove + lookUp - 10f, 0f);
		}
		else
		{
			targetPoint = followTransform.position - followVector * followDistance + new Vector3(0f, heightAbove + lookUp, 0f);
		}
		transform.position = targetPoint;
		if (gameControl.cameraType == "foot")
		{
			if (gameControl.playerControl.myAction.IndexOf("jump") != -1)
			{
				float y = origPos.y + (transform.position.y - origPos.y) * adjustedDeltaTime * 1f;
				Vector3 position = transform.position;
				float num2 = (position.y = y);
				Vector3 vector2 = (transform.position = position);
			}
			else
			{
				float y2 = origPos.y + (transform.position.y - origPos.y) * adjustedDeltaTime * 10f;
				Vector3 position2 = transform.position;
				float num3 = (position2.y = y2);
				Vector3 vector4 = (transform.position = position2);
			}
		}
		origForward = transform.forward;
		transform.LookAt(new Vector3(0f, lookUp, 0f) + followTransform.position);
	}

	public virtual void ChaseCamera()
	{
		float num = 0f;
		if (gameControl.playerControl.myAction == "hangClimb")
		{
			num = 13.4f;
		}
		PinchSlide();
		if (touchId != -1)
		{
			transform.RotateAround(followTransform.position, Vector3.up, deltaAngle);
		}
		Vector3 position = transform.position;
		float y = followTransform.position.y;
		Vector3 position2 = transform.position;
		float num2 = (position2.y = y);
		Vector3 vector2 = (transform.position = position2);
		transform.LookAt(followTransform.position);
		float maxDistanceDelta = Vector3.Distance(transform.position, followTransform.position) - followDistance;
		transform.position = Vector3.MoveTowards(transform.position, followTransform.position, maxDistanceDelta);
		float y2 = position.y + (followTransform.position.y + heightAbove + lookUp + num - position.y) * adjustedDeltaTime * 1f;
		Vector3 position3 = transform.position;
		float num3 = (position3.y = y2);
		Vector3 vector4 = (transform.position = position3);
		transform.LookAt(new Vector3(0f, lookUp, 0f) + followTransform.position);
		followAngle = followTransform.eulerAngles.y;
		if (gameControl.cameraType != "hang")
		{
			targetOffsetAngle = transform.eulerAngles.y - followAngle;
			offsetAngle = targetOffsetAngle;
		}
	}

	public virtual void ChangeTarget(Transform newTarget)
	{
		followTransform = newTarget;
	}

	public virtual void CheckAboveGround()
	{
		Vector3 up = Vector3.up;
		Vector3 origin = transform.position + up * 4f;
		if (Physics.Raycast(origin, -up, 7f))
		{
			followHeight += 0.05f;
			followHeight = Mathf.Clamp(followHeight, 0f, 1f);
			heightAbove = followDistance * followHeight;
		}
		else if (gameControl.touchingControls || gameControl.inputVector != Vector3.zero)
		{
			followHeight += (0.2f - followHeight) * 0.01f;
			heightAbove = followDistance * followHeight;
		}
	}

	public virtual void LateUpdate()
	{
		if (!followTransform)
		{
			if ((bool)gameControl.cameraTarget)
			{
				followTransform = gameControl.cameraTarget;
			}
			return;
		}
		followDistance += (targetFollowDistance - followDistance) / 10f;
		adjustedDeltaTime = 0.033f;
		if (gameControl.missionOver || Application.loadedLevelName == "Title")
		{
			EndCamera();
		}
		else if (gameControl.warpCamera)
		{
			WarpCamera();
		}
		else if (gameControl.cameraType == "board")
		{
			CheckAboveGround();
			ChaseCamera();
		}
		else if (gameControl.cameraType == "hang")
		{
			NormalCamera();
		}
		else if (gameControl.cameraType == "fight")
		{
			FightCamera();
		}
		else if (gameControl.cameraType == "sidescroll")
		{
			SideScrollCamera();
		}
		else
		{
			CheckAboveGround();
			ChaseCamera();
		}
		origForward = transform.forward;
		origPos = transform.position;
		offsetVector3 = Vector3.Lerp(offsetVector3, gameControl.cameraOffset, Time.deltaTime);
		transform.Rotate(offsetVector3);
		AdjustSky();
	}

	public virtual void AdjustSky()
	{
	}

	public virtual void WarpCamera()
	{
		AdjustSideScrollOffset();
		Vector3 b = followTransform.position - sideviewVector + new Vector3(0f, actionOffset, 0f);
		transform.position = Vector3.Lerp(transform.position, b, 0.08f);
		Quaternion b2 = Quaternion.LookRotation(followTransform.position + new Vector3(sideScrollOffset, 5f + actionOffset, 0f) - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, b2, 0.08f);
		targetLookAt = b;
	}

	public virtual void AdjustSideScrollOffset()
	{
		if (Mathf.Round(followTransform.eulerAngles.y) == 90f)
		{
			sideScrollOffset += (25f - sideScrollOffset) * Time.deltaTime * easing;
		}
		else
		{
			sideScrollOffset += (-20f - sideScrollOffset) * Time.deltaTime * easing;
		}
	}

	public virtual void SideScrollCamera()
	{
		followAngle = 0f;
		gameControl.targetOffsetAngle = -180f;
		targetOffsetAngle = -180f;
		int num99 = 0;
		if (gameControl.playerControl.myAction.IndexOf("hang") != -1)
		{
			targetLookAt += (followTransform.position + new Vector3(-2f, 13f, 0f) - sideviewVector - targetLookAt) * Time.deltaTime * 5f;
			wasClimbing = true;
			num99 = 20;
		}
		else
		{
			int num = num99 - 1;
			if (num > 0)
			{
				targetLookAt += (followTransform.position - sideviewVector - targetLookAt) * Time.deltaTime * 5f;
			}
			else
			{
				targetLookAt = followTransform.position - sideviewVector;
			}
		}
		float y = transform.position.y + (targetLookAt.y - transform.position.y) * Time.deltaTime;
		Vector3 position = transform.position;
		float num2 = (position.y = y);
		Vector3 vector2 = (transform.position = position);
		float x = targetLookAt.x;
		Vector3 position2 = transform.position;
		float num3 = (position2.x = x);
		Vector3 vector4 = (transform.position = position2);
		float z = targetLookAt.z;
		Vector3 position3 = transform.position;
		float num4 = (position3.z = z);
		Vector3 vector6 = (transform.position = position3);
		AdjustSideScrollOffset();
		transform.rotation = Quaternion.LookRotation(targetLookAt + sideviewVector + new Vector3(sideScrollOffset, 5f, 0f) - transform.position);
		if (!(gameControl.cameraShake <= 0f))
		{
			transform.position += new Vector3(UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake));
		}
	}

	public virtual void SideScrollCameraOLD()
	{
		followAngle = 0f;
		gameControl.targetOffsetAngle = -180f;
		targetOffsetAngle = -180f;
		MonoBehaviour.print(gameControl.playerControl.myAction + ":" + followTransform.position.y);
		if (gameControl.playerControl.myAction.IndexOf("hang") != -1)
		{
			targetOffset = 13.4f;
			actionOffset = targetOffset;
		}
		else
		{
			targetOffset = 0f;
			actionOffset = targetOffset;
		}
		easing = 1f;
		actionOffset += (targetOffset - actionOffset) / 10f;
		if (!(Mathf.Abs(actionOffset - targetOffset) <= 0.1f))
		{
			wasClimbing = true;
		}
		else
		{
			wasClimbing = false;
		}
		Vector3 position = followTransform.position - sideviewVector + new Vector3(0f, actionOffset, 0f);
		transform.position = position;
		AdjustSideScrollOffset();
		transform.rotation = Quaternion.LookRotation(followTransform.position + new Vector3(0f, actionOffset, 0f) + new Vector3(sideScrollOffset, 5f, 0f) - transform.position);
		if (!(gameControl.cameraShake <= 0f))
		{
			transform.position += new Vector3(UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake));
		}
	}

	public virtual void SideScrollCameraSIMPLE()
	{
		followAngle = 0f;
		gameControl.targetOffsetAngle = -180f;
		targetOffsetAngle = -180f;
		Vector3 vector = followTransform.position - new Vector3(-10f, -13.8f, -37f);
		float x = vector.x;
		Vector3 position = transform.position;
		float num = (position.x = x);
		Vector3 vector3 = (transform.position = position);
		float y = transform.position.y + (vector.y - transform.position.y) * Time.deltaTime * 2f;
		Vector3 position2 = transform.position;
		float num2 = (position2.y = y);
		Vector3 vector5 = (transform.position = position2);
		float z = vector.z;
		Vector3 position3 = transform.position;
		float num3 = (position3.z = z);
		Vector3 vector7 = (transform.position = position3);
		transform.rotation = Quaternion.LookRotation(followTransform.position + new Vector3(0f, actionOffset, 0f) + new Vector3(-20f, 5f, 0f) - transform.position);
		if (!(gameControl.cameraShake <= 0f))
		{
			transform.position += new Vector3(UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake), UnityEngine.Random.Range(0f - gameControl.cameraShake, gameControl.cameraShake));
		}
	}

	public virtual void DropOffCamera()
	{
		origForward = transform.forward;
		targetPoint = new Vector3(followTransform.position.x, followTransform.position.y + heightAbove, followTransform.position.z);
		transform.LookAt(new Vector3(0f, lookUp - heightAbove, 0f) + targetPoint);
		transform.forward = Vector3.Lerp(origForward, transform.forward, adjustedDeltaTime * 5f);
		cameraType = "dropoff";
	}

	public virtual void PinchSlide()
	{
		if (gameControl.scrollMenu)
		{
			return;
		}
		spinCamera = false;
		touchingControls = false;
		if (gameControl.cameraType == "dance")
		{
			targetOffsetAngle += 1f * adjustedDeltaTime * 30f;
		}
		if (gameControl.cameraType == "fight")
		{
			targetOffsetAngle = -90f;
			return;
		}
		if (!gameControl.paused && gameControl.isMiniGame && gameControl.inputVector.y != 0f && (gameControl.cameraType == "board" || gameControl.cameraType == "foot"))
		{
			touchingControls = true;
			gameControl.targetOffsetAngle = 0f;
			targetOffsetAngle = 0f;
		}
		if (gameControl.cameraType == "hang")
		{
			gameControl.targetOffsetAngle = 0f;
			targetOffsetAngle = 0f;
		}
		if (eInput.controlType != "touch")
		{
			if (eInput.rightJoyY != 0f)
			{
				targetFollowDistance += eInput.rightJoyY * 2f * adjustedDeltaTime * 20f;
				targetFollowDistance = Mathf.Clamp(targetFollowDistance, minFollowDistance, maxFollowDistance);
			}
			if (eInput.rightJoyX != 0f || eInput.R1 || eInput.L1)
			{
				touchId = 10;
				float num = eInput.rightJoyX;
				if (eInput.R1)
				{
					num = 1f;
				}
				if (eInput.L1)
				{
					num = -1f;
				}
				deltaAngle = num * 2f * adjustedDeltaTime * 20f * 2f;
				offsetAngle += deltaAngle;
				targetOffsetAngle = offsetAngle;
				wasPanTouch = true;
				return;
			}
		}
		bool flag = false;
		float x = Input.mousePosition.x;
		float y = Input.mousePosition.y;
		bool num2 = menuControl.menu == "game";
		if (!num2)
		{
			num2 = menuControl.menu == "missionPause";
		}
		bool flag2 = num2;
		if (Input.GetMouseButton(0) && !slideDisabled)
		{
			if (flag2 && !(y <= (float)Screen.height * 0.5f))
			{
				flag = true;
			}
			if (!flag2 && !(x >= (float)Screen.width * 0.6f))
			{
				flag = true;
			}
		}
		flag = false;
		Touch touch = default(Touch);
		bool flag3 = false;
		int i = 0;
		Touch[] touches = Input.touches;
		for (int length = touches.Length; i < length; i++)
		{
			if (touchId == -1 && touches[i].fingerId != gameControl.joyTouchID && ((flag2 && touches[i].position.y > (float)Screen.height * 0.5f) || (!flag2 && !(touches[i].position.x >= (float)Screen.width * 0.6f))))
			{
				touchId = touches[i].fingerId;
				touch = touches[i];
				flag3 = true;
				break;
			}
			if (touchId == touches[i].fingerId)
			{
				touch = touches[i];
				flag3 = true;
				break;
			}
		}
		if (!flag3)
		{
			touchId = -1;
		}
		if (flag3 && !slideDisabled)
		{
			flag = true;
		}
		if (flag)
		{
			deltaAngle = touch.deltaPosition.x * adjustedDeltaTime * 10f * gameControl.touchScale;
			offsetAngle += deltaAngle;
			targetOffsetAngle = offsetAngle;
			float num3 = (0f - touch.deltaPosition.y) * 0.01f * adjustedDeltaTime * 10f * gameControl.touchScale;
			followHeight += num3;
			if (!(num3 <= 0f) && (followHeight > 1f || !(targetFollowDistance >= averageFollowDistance)))
			{
				targetFollowDistance += gameControl.touchScale * 1f;
				targetFollowDistance = Mathf.Clamp(targetFollowDistance, minFollowDistance, maxFollowDistance);
			}
			else if (!(num3 >= 0f) && (followHeight < 0f || !(targetFollowDistance <= averageFollowDistance)))
			{
				targetFollowDistance -= gameControl.touchScale * 1f;
				targetFollowDistance = Mathf.Clamp(targetFollowDistance, minFollowDistance, maxFollowDistance);
			}
			followHeight = Mathf.Clamp(followHeight, 0f, 1f);
			heightAbove = followDistance * followHeight;
			wasPanTouch = true;
		}
		else
		{
			gameControl.targetOffsetAngle = 0f;
			wasPanTouch = false;
		}
		if (!pinchDisabled)
		{
		}
	}

	public virtual void EndCamera()
	{
		PinchSlide();
		if (gameControl.targetOffsetAngle != 0f)
		{
			targetOffsetAngle = gameControl.targetOffsetAngle;
		}
		if (wasTouching)
		{
			wasTouching = false;
		}
		offsetAngle = Mathf.LerpAngle(offsetAngle, targetOffsetAngle, adjustedDeltaTime * 2f);
		followAngle = Mathf.LerpAngle(followAngle, followTransform.eulerAngles.y, adjustedDeltaTime * 2f);
		tiltOffset.y += ((0f - Acceleration.acceleration.x) * 10f - tiltOffset.y) * 0.1f;
		tiltOffset.x += ((0.5f + Acceleration.acceleration.y) * 2f - tiltOffset.x) * 0.1f;
		float num = followAngle + offsetAngle + tiltOffset.y;
		followVector = new Vector3(Mathf.Sin(num * ((float)Math.PI / 180f)), 0f, Mathf.Cos(num * ((float)Math.PI / 180f)));
		targetPoint = followTransform.position - followVector * followDistance + new Vector3(0f, heightAbove + lookUp + tiltOffset.x, 0f);
		transform.position = Vector3.Lerp(transform.position, targetPoint, adjustedDeltaTime * 10f);
		if (gameControl.playerControl.myAction.IndexOf("jump") != -1)
		{
			float y = origPos.y + (transform.position.y - origPos.y) * adjustedDeltaTime * 10f;
			Vector3 position = transform.position;
			float num2 = (position.y = y);
			Vector3 vector2 = (transform.position = position);
		}
		transform.LookAt(new Vector3(0f, lookUp, 0f) + followTransform.position);
	}

	public virtual void ChaseCameraOLD()
	{
		float num = 0f;
		if (gameControl.playerControl.myAction == "hangClimb")
		{
			num = 13.4f;
		}
		PinchSlide();
		if (touchId != -1)
		{
			if (gameControl.targetOffsetAngle != 0f)
			{
				targetOffsetAngle = gameControl.targetOffsetAngle;
			}
			if (wasTouching)
			{
				wasTouching = false;
			}
			offsetAngle = Mathf.LerpAngle(offsetAngle, targetOffsetAngle, adjustedDeltaTime * 2f);
			followAngle = Mathf.LerpAngle(followAngle, followTransform.eulerAngles.y, adjustedDeltaTime * 2f);
			tiltOffset = new Vector2(0f, tiltOffset.y + ((0f - Acceleration.acceleration.x) * 50f - tiltOffset.y) * 0.1f);
			float num2 = followAngle + offsetAngle + tiltOffset.y;
			followVector = new Vector3(Mathf.Sin(num2 * ((float)Math.PI / 180f)), 0f, Mathf.Cos(num2 * ((float)Math.PI / 180f)));
			targetPoint = followTransform.position - followVector * followDistance + new Vector3(0f, heightAbove + lookUp + num + tiltOffset.x, 0f);
			transform.position = Vector3.Lerp(transform.position, targetPoint, adjustedDeltaTime * 10f);
			if (gameControl.playerControl.myAction.IndexOf("jump") != -1)
			{
				float y = origPos.y + (transform.position.y - origPos.y) * adjustedDeltaTime * 10f;
				Vector3 position = transform.position;
				float num3 = (position.y = y);
				Vector3 vector2 = (transform.position = position);
			}
			transform.LookAt(new Vector3(0f, lookUp + num, 0f) + followTransform.position);
		}
		else
		{
			targetPoint = followTransform.position;
			targetPoint.y = transform.position.y;
			followVector = targetPoint - transform.position;
			followVector = followVector.normalized;
			targetPoint = followTransform.position - followVector * followDistance + new Vector3(0f, heightAbove + lookUp + num, 0f);
			transform.position = Vector3.Lerp(transform.position, targetPoint, adjustedDeltaTime * 10f);
			if (gameControl.playerControl.myAction.IndexOf("jump") != -1)
			{
				float y2 = origPos.y + (transform.position.y - origPos.y) * adjustedDeltaTime * 10f;
				Vector3 position2 = transform.position;
				float num4 = (position2.y = y2);
				Vector3 vector4 = (transform.position = position2);
			}
			transform.LookAt(new Vector3(0f, lookUp + num, 0f) + followTransform.position);
			followAngle = followTransform.eulerAngles.y;
			if (gameControl.cameraType != "hang")
			{
				targetOffsetAngle = transform.eulerAngles.y - followAngle;
				offsetAngle = targetOffsetAngle;
			}
		}
	}

	public virtual void FightCamera()
	{
		origForward = transform.forward;
		Vector3 zero = Vector3.zero;
		if ((bool)gameControl.playerControl.myOpponent)
		{
			zero = gameControl.playerControl.transform.position + (gameControl.playerControl.myOpponent.transform.position - gameControl.playerControl.transform.position) * 0.5f;
			float b = Vector3.Distance(gameControl.playerControl.myOpponent.transform.position, gameControl.playerControl.transform.position) * 1.5f;
			followDistance = Mathf.Lerp(followDistance, b, adjustedDeltaTime);
		}
		else
		{
			zero = followTransform.position;
		}
		offsetAngle = Mathf.LerpAngle(offsetAngle, -90f, adjustedDeltaTime * 2f);
		followAngle = Mathf.LerpAngle(followAngle, followTransform.eulerAngles.y, adjustedDeltaTime * 2f);
		float num = followAngle + offsetAngle;
		followVector = new Vector3(Mathf.Sin(num * ((float)Math.PI / 180f)), 0f, Mathf.Cos(num * ((float)Math.PI / 180f)));
		targetPoint = zero - followVector * followDistance;
		zero.y -= 2f;
		transform.position = targetPoint;
		transform.LookAt(zero);
	}

	public virtual void HalfpipeCamera()
	{
		MonoBehaviour.print("Halfpipe camera");
		PinchSlide();
		origForward = transform.forward;
		if (cameraType != "halfpipe")
		{
			halfpipeVector = new Vector3(transform.forward.x, 0f, transform.forward.z);
			halfpipeVector = halfpipeVector.normalized;
		}
		targetPoint = followTransform.position - halfpipeVector * followDistance * 1f + new Vector3(0f, 10f, 0f);
		transform.position = Vector3.Lerp(transform.position, targetPoint, adjustedDeltaTime * 8f);
		transform.LookAt(new Vector3(followTransform.position.x, followTransform.position.y - heightAbove, followTransform.position.z));
		transform.forward = Vector3.Lerp(origForward, transform.forward, adjustedDeltaTime * 2f);
		cameraType = "halfpipe";
	}

	public virtual void Main()
	{
	}
}
