using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PlayerControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowBoardOLD_0024634 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024_0024323_0024635;

			internal Vector3 _0024_0024324_0024636;

			internal bool _0024turnOn_0024637;

			internal PlayerControl _0024self__0024638;

			public _0024(bool turnOn, PlayerControl self_)
			{
				_0024turnOn_0024637 = turnOn;
				_0024self__0024638 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024turnOn_0024637)
					{
						if ((bool)_0024self__0024638.boardModel)
						{
							_0024self__0024638.boardModel.enabled = true;
						}
						if (_0024self__0024638.playerData.trail == "none")
						{
							if ((bool)_0024self__0024638.trailLeft)
							{
								_0024self__0024638.trailLeft.SetActive(false);
							}
							if ((bool)_0024self__0024638.trailRight)
							{
								_0024self__0024638.trailRight.SetActive(false);
							}
						}
						else if (_0024self__0024638.playerData.trail == "mono")
						{
							if ((bool)_0024self__0024638.trailLeft)
							{
								_0024self__0024638.trailLeft.SetActive(false);
							}
							if ((bool)_0024self__0024638.trailRight)
							{
								_0024self__0024638.trailRight.SetActive(true);
							}
							if ((bool)_0024self__0024638.trailRight)
							{
								int num = (_0024_0024323_0024635 = 0);
								Vector3 vector = (_0024_0024324_0024636 = _0024self__0024638.trailRight.transform.localPosition);
								float num2 = (_0024_0024324_0024636.x = _0024_0024323_0024635);
								Vector3 vector3 = (_0024self__0024638.trailRight.transform.localPosition = _0024_0024324_0024636);
							}
						}
						else
						{
							if ((bool)_0024self__0024638.trailLeft)
							{
								_0024self__0024638.trailLeft.SetActive(true);
							}
							if ((bool)_0024self__0024638.trailRight)
							{
								_0024self__0024638.trailRight.SetActive(true);
							}
						}
						_0024self__0024638.boardCollider.SetActive(true);
						_0024self__0024638.GetComponent<Rigidbody>().freezeRotation = false;
						result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					}
					else
					{
						if ((bool)_0024self__0024638.boardModel)
						{
							_0024self__0024638.boardModel.enabled = false;
						}
						if ((bool)_0024self__0024638.trailLeft)
						{
							_0024self__0024638.trailLeft.SetActive(false);
						}
						if ((bool)_0024self__0024638.trailRight)
						{
							_0024self__0024638.trailRight.SetActive(false);
						}
						_0024self__0024638.footCollider.SetActive(true);
						_0024self__0024638.GetComponent<Rigidbody>().rotation = Quaternion.identity;
						result = (Yield(3, new WaitForSeconds(2f)) ? 1 : 0);
					}
					break;
				case 2:
					if (_0024self__0024638.boardCollider.activeSelf)
					{
						_0024self__0024638.footCollider.SetActive(false);
					}
					goto IL_0323;
				case 3:
					if (_0024self__0024638.footCollider.activeSelf)
					{
						_0024self__0024638.boardCollider.SetActive(false);
					}
					goto IL_0323;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0323:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024turnOn_0024639;

		internal PlayerControl _0024self__0024640;

		public _0024ShowBoardOLD_0024634(bool turnOn, PlayerControl self_)
		{
			_0024turnOn_0024639 = turnOn;
			_0024self__0024640 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024turnOn_0024639, _0024self__0024640);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DisableShield_0024641 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal int _0024i_0024642;

			internal PlayerControl _0024self__0024643;

			public _0024(PlayerControl self_)
			{
				_0024self__0024643 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(8f)) ? 1 : 0);
					break;
				case 2:
					_0024i_0024642 = 10;
					goto IL_00da;
				case 3:
					_0024self__0024643.shieldObject.SetActive(true);
					if ((bool)_0024self__0024643.shieldObject.GetComponent<AudioSource>())
					{
						_0024self__0024643.shieldObject.GetComponent<AudioSource>().Play();
					}
					result = (Yield(4, new WaitForSeconds((float)_0024i_0024642 * 0.02f)) ? 1 : 0);
					break;
				case 4:
					_0024self__0024643.shieldObject.SetActive(false);
					_0024i_0024642--;
					goto IL_00da;
				case 1:
					{
						result = 0;
						break;
					}
					IL_00da:
					if (_0024i_0024642 > 0)
					{
						result = (Yield(3, new WaitForSeconds((float)_0024i_0024642 * 0.02f)) ? 1 : 0);
						break;
					}
					_0024self__0024643.StopShield();
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__0024644;

		public _0024DisableShield_0024641(PlayerControl self_)
		{
			_0024self__0024644 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024644);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DisableX2_0024645 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PlayerControl _0024self__0024646;

			public _0024(PlayerControl self_)
			{
				_0024self__0024646 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(10f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024646.x2 = 0;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__0024647;

		public _0024DisableX2_0024645(PlayerControl self_)
		{
			_0024self__0024647 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024647);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DieNoSaveMe_0024648 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PlayerControl _0024self__0024649;

			public _0024(PlayerControl self_)
			{
				_0024self__0024649 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024649.myAction = "stand";
					result = (Yield(2, new WaitForSeconds(0.75f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024649.gameControl.missionAborted = true;
					if (_0024self__0024649.myMode == "foot")
					{
						_0024self__0024649.ShowBoard(false);
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

		internal PlayerControl _0024self__0024650;

		public _0024DieNoSaveMe_0024648(PlayerControl self_)
		{
			_0024self__0024650 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024650);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024BlinkColor_0024651 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Color _0024newColor_0024652;

			internal PlayerControl _0024self__0024653;

			public _0024(Color newColor, PlayerControl self_)
			{
				_0024newColor_0024652 = newColor;
				_0024self__0024653 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if ((bool)_0024self__0024653.myMaterial)
					{
						_0024self__0024653.tempColor = _0024self__0024653.myMaterial.color;
						_0024self__0024653.myMaterial.color = _0024newColor_0024652;
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					goto IL_0158;
				case 2:
					_0024self__0024653.myMaterial.color = _0024self__0024653.tempColor;
					result = (Yield(3, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 3:
					_0024self__0024653.myMaterial.color = _0024newColor_0024652;
					result = (Yield(4, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 4:
					_0024self__0024653.myMaterial.color = _0024self__0024653.tempColor;
					result = (Yield(5, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 5:
					_0024self__0024653.myMaterial.color = _0024newColor_0024652;
					result = (Yield(6, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 6:
					_0024self__0024653.myMaterial.color = _0024self__0024653.tempColor;
					goto IL_0158;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0158:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Color _0024newColor_0024654;

		internal PlayerControl _0024self__0024655;

		public _0024BlinkColor_0024651(Color newColor, PlayerControl self_)
		{
			_0024newColor_0024654 = newColor;
			_0024self__0024655 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024newColor_0024654, _0024self__0024655);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024FallDownHole_0024656 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024_0024331_0024657;

			internal Vector3 _0024_0024332_0024658;

			internal bool _0024soundIsOff_0024659;

			internal PlayerControl _0024self__0024660;

			public _0024(bool soundIsOff, PlayerControl self_)
			{
				_0024soundIsOff_0024659 = soundIsOff;
				_0024self__0024660 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
				{
					if (_0024self__0024660.inHole)
					{
						goto case 1;
					}
					_0024self__0024660.GetComponent<Rigidbody>().velocity = new Vector3(0f, -50f, 0f);
					float num = (_0024_0024331_0024657 = _0024self__0024660.transform.position.y - 10f);
					Vector3 vector = (_0024_0024332_0024658 = _0024self__0024660.transform.position);
					float num2 = (_0024_0024332_0024658.y = _0024_0024331_0024657);
					Vector3 vector3 = (_0024self__0024660.transform.position = _0024_0024332_0024658);
					if (!_0024soundIsOff_0024659)
					{
						_0024self__0024660.PlaySound("fall");
					}
					_0024self__0024660.footCollider.GetComponent<Collider>().isTrigger = true;
					_0024self__0024660.inHole = true;
					result = (Yield(2, new WaitForSeconds(0.4f)) ? 1 : 0);
					break;
				}
				case 2:
					_0024self__0024660.inHole = false;
					_0024self__0024660.footCollider.GetComponent<Collider>().isTrigger = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal bool _0024soundIsOff_0024661;

		internal PlayerControl _0024self__0024662;

		public _0024FallDownHole_0024656(bool soundIsOff, PlayerControl self_)
		{
			_0024soundIsOff_0024661 = soundIsOff;
			_0024self__0024662 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024soundIsOff_0024661, _0024self__0024662);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ShowLevelUp_0024663 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Vector3 _0024initialOffset_0024664;

			internal string _0024whichOutfit_0024665;

			internal string _0024whichExplosion_0024666;

			internal PlayerControl _0024self__0024667;

			public _0024(string whichOutfit, string whichExplosion, PlayerControl self_)
			{
				_0024whichOutfit_0024665 = whichOutfit;
				_0024whichExplosion_0024666 = whichExplosion;
				_0024self__0024667 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024initialOffset_0024664 = _0024self__0024667.gameControl.cameraOffset;
					Camera.main.BroadcastMessage("ChangeFollowDistance", "far");
					_0024self__0024667.gameControl.cameraOffset = new Vector3(4f, 0f, 0f);
					_0024self__0024667.gameControl.StopMusic();
					_0024self__0024667.gameControl.Blackout(true);
					_0024self__0024667.ChangeAnimation("levelupStart", 0f);
					_0024self__0024667.myClip = "levelup";
					result = (Yield(2, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 2:
					if (_0024whichOutfit_0024665.IndexOf("outfit_") != -1)
					{
						_0024self__0024667.StartCoroutine(_0024self__0024667.gameControl.ActivateItem(_0024whichOutfit_0024665));
					}
					Time.timeScale = 0.5f;
					UnityEngine.Object.Instantiate(Resources.Load(_0024whichExplosion_0024666), _0024self__0024667.modelTransform.position + new Vector3(0f, -2f, 0f), Quaternion.identity);
					_0024self__0024667.ChangeAnimation("levelupEnd", 0f);
					_0024self__0024667.myClip = "levelup";
					result = (Yield(3, new WaitForSeconds(2f)) ? 1 : 0);
					break;
				case 3:
					Time.timeScale = 1f;
					_0024self__0024667.ChangeAnimation("win", 0.35f);
					_0024self__0024667.gameControl.PlayMusic((AudioClip)Resources.Load("Music/MusicWin"));
					_0024self__0024667.gameControl.Blackout(false);
					_0024self__0024667.gameControl.cameraOffset = _0024initialOffset_0024664;
					Camera.main.BroadcastMessage("ChangeFollowDistance", "near");
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichOutfit_0024668;

		internal string _0024whichExplosion_0024669;

		internal PlayerControl _0024self__0024670;

		public _0024ShowLevelUp_0024663(string whichOutfit, string whichExplosion, PlayerControl self_)
		{
			_0024whichOutfit_0024668 = whichOutfit;
			_0024whichExplosion_0024669 = whichExplosion;
			_0024self__0024670 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichOutfit_0024668, _0024whichExplosion_0024669, _0024self__0024670);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024QueueAnimation_0024671 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string _0024whichClip_0024672;

			internal float _0024delayInSeconds_0024673;

			internal PlayerControl _0024self__0024674;

			public _0024(string whichClip, float delayInSeconds, PlayerControl self_)
			{
				_0024whichClip_0024672 = whichClip;
				_0024delayInSeconds_0024673 = delayInSeconds;
				_0024self__0024674 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(_0024delayInSeconds_0024673)) ? 1 : 0);
					break;
				case 2:
					if (!(_0024self__0024674.myClip == "levelup"))
					{
						if (_0024self__0024674.myAction == "stand" && _0024whichClip_0024672 == "stand")
						{
							_0024self__0024674.ChangeAnimation(_0024whichClip_0024672, 0.35f);
						}
						if (_0024self__0024674.myAction == "run" && _0024whichClip_0024672 == "run")
						{
							_0024self__0024674.myAnimation.CrossFade(_0024whichClip_0024672, 0.2f);
						}
						YieldDefault(1);
					}
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal string _0024whichClip_0024675;

		internal float _0024delayInSeconds_0024676;

		internal PlayerControl _0024self__0024677;

		public _0024QueueAnimation_0024671(string whichClip, float delayInSeconds, PlayerControl self_)
		{
			_0024whichClip_0024675 = whichClip;
			_0024delayInSeconds_0024676 = delayInSeconds;
			_0024self__0024677 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024whichClip_0024675, _0024delayInSeconds_0024676, _0024self__0024677);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResetJumpPressed_0024678 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PlayerControl _0024self__0024679;

			public _0024(PlayerControl self_)
			{
				_0024self__0024679 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.05f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024679.jumpPressed = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal PlayerControl _0024self__0024680;

		public _0024ResetJumpPressed_0024678(PlayerControl self_)
		{
			_0024self__0024680 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024680);
		}
	}

	public bool mainPlayer;

	public string myMode;

	public PlayerData playerData;

	public Transform targetTransform;

	public int maxGrabs;

	public GameObject modelObject;

	public Vector3 modelOffset;

	public GameObject shadowObject;

	public GameObject shieldObject;

	public float maxForce;

	public float maxTurningForce;

	public float resetY;

	public Vector3[] lastPosition;

	public Quaternion[] lastRotation;

	public string groundName;

	public float groundDist;

	public bool halfpipeAir;

	public string myClip;

	public Vector3 inputVector;

	public string myAction;

	public int level;

	public int xp;

	public AudioClip[] audioClips;

	public AudioClip soundFall;

	public AudioClip soundCollect;

	private Vector3 zeroAccel;

	private Vector3 lastForce;

	public Transform modelTransform;

	private bool burnout;

	private Animation myAnimation;

	private int maxReplayElements;

	private int replayID;

	private GameControl gameControl;

	public bool inair;

	private float inairCount;

	private int hoverCount;

	private int AICount;

	private Vector3 relativeWaypointPosition;

	private RaycastHit hit;

	private Vector3 startPos;

	private int layerMask;

	private bool hasScreamed;

	private string animSuffix;

	private Material myMaterial;

	private Vector3 groundNormal;

	private Transform groundTransform;

	private Quaternion lastModelRotation;

	private MeshRenderer boardModel;

	private GameObject trailLeft;

	private GameObject trailRight;

	private GameObject bodyModel;

	private MeshRenderer myRenderer;

	public GameObject boardCollider;

	public GameObject footCollider;

	private int collideCount;

	private Vector3 validPosition;

	private Vector3 groundPosition;

	public PlayerControl myOpponent;

	private bool inRange;

	private GameObject neckBone;

	private Quaternion lastNeckRot;

	public GameObject cameraTarget;

	private string groundTag;

	public string lastGroundTag;

	private GameObject hangObject;

	private Vector3 hangTargetPosition;

	private Quaternion hangTargetRotation;

	private GameObject lastHangObject;

	private string lastAudio;

	private float lastAudioTimer;

	private int lastAudioCount;

	private int hitCounter;

	private float jumpTimer;

	private bool waterJump;

	private bool jumpPressed;

	private float lockCount;

	private Vector3 groundVelocity;

	public float jumpTime;

	private bool flyingFox;

	private float slowDown;

	private Vector3 groundTransformPos;

	public float boost;

	public int health;

	public int shield;

	public int x2;

	private bool inHole;

	private bool tempBoolean;

	private AudioClip tempAudioClip;

	private Color tempColor;

	private string tempClip;

	private string newAction;

	private Vector3 origVelocity;

	private Quaternion targetQuaternion;

	private string tempString;

	private float tempFloat;

	private Vector3 tempVector3;

	private int tempInt;

	private string loopSoundName;

	private bool stop;

	private Transform stopTransform;

	private Transform groundStopTransform;

	private Vector3 headLookOffset;

	private float climbDelta;

	private RigidbodyConstraints lastConstraints;

	private bool freezePosZ;

	private float underY;

	private Vector3 halfPipePosition;

	private Vector3 halfpipeRight;

	private GameObject childModel;

	private Vector3 forwardValid;

	public PlayerControl()
	{
		myMode = "board";
		maxGrabs = 4;
		modelOffset = new Vector3(0f, 2f, 0f);
		maxForce = 3000f;
		maxTurningForce = 3000f;
		resetY = -200f;
		groundName = "none";
		myClip = "stand";
		inputVector = new Vector3(0f, 0f, 0f);
		myAction = "foot";
		level = 1;
		burnout = true;
		maxReplayElements = 500;
		relativeWaypointPosition = new Vector3(0f, 0f, 0f);
		animSuffix = string.Empty;
		groundNormal = new Vector3(1f, 1f, 1f);
		groundTag = "none";
		lastGroundTag = "none";
		lastAudio = string.Empty;
		lastAudioCount = 1;
		groundVelocity = Vector3.zero;
		slowDown = 0.5f;
		climbDelta = -10f;
	}

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if (!gameControl)
		{
			Application.LoadLevel("Splash");
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		if (playerData.characterName == "player")
		{
			InitPlayer();
		}
		Look("ahead");
	}

	public virtual void Start()
	{
		if (playerData.characterName != "player")
		{
			InitPlayer();
		}
		if (mainPlayer)
		{
			ChangeInputs();
		}
	}

	public virtual void InitPlayer()
	{
		if (!modelObject)
		{
			modelTransform = Camera.main.transform;
		}
		else
		{
			modelTransform = modelObject.transform;
		}
		inair = false;
		gameControl.inair = inair;
		groundName = "none";
		halfpipeAir = false;
		halfPipePosition = Vector3.zero;
		zeroAccel = new Vector3(0f, 0f, -1f);
		lastPosition = new Vector3[maxReplayElements];
		lastRotation = new Quaternion[maxReplayElements];
		layerMask = 4;
		layerMask = ~layerMask;
		playerData.InitializeCharacter();
		if (playerData.gender == "male")
		{
			animSuffix = "_male";
		}
		if (playerData.characterName == "player")
		{
			mainPlayer = true;
		}
		else
		{
			playerData.modelType += "npc";
		}
		childModel = (GameObject)UnityEngine.Object.Instantiate(Resources.Load(playerData.modelType + playerData.gender), modelTransform.position, modelTransform.rotation);
		childModel.transform.parent = modelTransform;
		myRenderer = (MeshRenderer)modelObject.GetComponentInChildren(typeof(MeshRenderer));
		if ((bool)myRenderer)
		{
			myMaterial = myRenderer.sharedMaterial;
			myMaterial.color = Color.white;
		}
		maxTurningForce = playerData.maxTurningForce;
		maxForce = playerData.maxForce;
		if (mainPlayer)
		{
			UpdateMainPlayer();
			gameControl.ChangeCameraTarget(modelTransform);
			trailLeft = GameObject.Find("trailLeft");
			trailRight = GameObject.Find("trailRight");
			GameObject gameObject = GameObject.FindWithTag("Board");
			if ((bool)gameObject)
			{
				boardModel = (MeshRenderer)gameObject.GetComponent(typeof(MeshRenderer));
			}
			bodyModel = GameObject.Find("Bip01 Pelvis");
			neckBone = GameObject.FindWithTag("Neck");
			cameraTarget = GameObject.FindWithTag("CameraFocus");
		}
		else
		{
			GameObject gameObject2 = GameObject.FindWithTag("BoardNPC");
			if ((bool)gameObject2)
			{
				boardModel = (MeshRenderer)gameObject2.GetComponent(typeof(MeshRenderer));
			}
			neckBone = GameObject.FindWithTag("NeckNPC");
			ChangeOutfit();
		}
		StopShield();
		InitAnimation();
		forwardValid = modelTransform.forward;
	}

	public virtual void PlaySound(string whichAudio)
	{
		if (whichAudio == lastAudio)
		{
			switch (whichAudio)
			{
			case "run":
				if (!(Time.time - lastAudioTimer >= 0.25f))
				{
					return;
				}
				break;
			case "walk":
				if (!(Time.time - lastAudioTimer >= 0.5f))
				{
					return;
				}
				break;
			case "catwalk":
				if (!(Time.time - lastAudioTimer >= 0.5f))
				{
					return;
				}
				break;
			case "hangStep":
				if (!(Time.time - lastAudioTimer >= 0.5f))
				{
					return;
				}
				break;
			case "swim":
				if (!(Time.time - lastAudioTimer >= 1.5f))
				{
					return;
				}
				break;
			default:
				if (!(Time.time - lastAudioTimer >= 1f))
				{
					return;
				}
				break;
			}
		}
		lastAudio = whichAudio;
		if (whichAudio == "jump")
		{
			whichAudio += UnityEngine.Random.Range(1, 9);
			whichAudio += animSuffix;
		}
		if (whichAudio == "ouch")
		{
			whichAudio += UnityEngine.Random.Range(1, 10);
			whichAudio += animSuffix;
		}
		if (whichAudio == "climb")
		{
			whichAudio += animSuffix;
		}
		if (whichAudio == "fall")
		{
			whichAudio += animSuffix;
		}
		switch (whichAudio)
		{
		case "run":
		case "walk":
		case "catwalk":
			lastAudioCount++;
			if (lastAudioCount > 2)
			{
				lastAudioCount = 1;
			}
			whichAudio = "footstep" + lastAudioCount;
			break;
		}
		if (whichAudio == "swim")
		{
			whichAudio += UnityEngine.Random.Range(1, 4);
		}
		if (whichAudio == "hangStep")
		{
			lastAudioCount++;
			if (lastAudioCount > 2)
			{
				lastAudioCount = 1;
			}
			whichAudio = "hangStep" + lastAudioCount;
		}
		tempAudioClip = (AudioClip)Resources.Load("Sounds/" + whichAudio, typeof(AudioClip));
		if ((bool)tempAudioClip)
		{
			lastAudioTimer = Time.time;
			if (mainPlayer)
			{
				gameControl.PlaySound(tempAudioClip);
			}
			else
			{
				GetComponent<AudioSource>().PlayOneShot(tempAudioClip);
			}
		}
		else
		{
			MonoBehaviour.print("Could not find Sounds/" + whichAudio);
		}
	}

	public virtual void PlayLoopSound(string whichSound)
	{
		loopSoundName = whichSound;
		GetComponent<AudioSource>().clip = (AudioClip)Resources.Load("Sounds/" + loopSoundName);
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
	}

	public virtual void ShowBoard(bool turnOn)
	{
		if (turnOn)
		{
			if ((bool)boardModel)
			{
				boardModel.enabled = true;
			}
			if (playerData.trail == "none")
			{
				if ((bool)trailLeft)
				{
					trailLeft.SetActive(false);
				}
				if ((bool)trailRight)
				{
					trailRight.SetActive(false);
				}
			}
			else if (playerData.trail == "mono")
			{
				if ((bool)trailLeft)
				{
					trailLeft.SetActive(false);
				}
				if ((bool)trailRight)
				{
					trailRight.SetActive(true);
				}
				if ((bool)trailRight)
				{
					int num = 0;
					Vector3 localPosition = trailRight.transform.localPosition;
					float num2 = (localPosition.x = num);
					Vector3 vector2 = (trailRight.transform.localPosition = localPosition);
				}
			}
			else
			{
				if ((bool)trailLeft)
				{
					trailLeft.SetActive(true);
				}
				if ((bool)trailRight)
				{
					trailRight.SetActive(true);
				}
			}
			if ((bool)boardCollider && (bool)footCollider)
			{
				boardCollider.SetActive(true);
				footCollider.SetActive(false);
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			}
			GetComponent<AudioSource>().volume = 0.5f;
			GetComponent<AudioSource>().pitch = 0.5f;
			PlayLoopSound("hoverfast");
		}
		else
		{
			if ((bool)boardModel)
			{
				boardModel.enabled = false;
			}
			if ((bool)trailLeft)
			{
				trailLeft.SetActive(false);
			}
			if ((bool)trailRight)
			{
				trailRight.SetActive(false);
			}
			if ((bool)boardCollider && (bool)footCollider)
			{
				footCollider.SetActive(true);
				boardCollider.SetActive(false);
				GetComponent<Rigidbody>().rotation = Quaternion.identity;
				GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
			}
			GetComponent<AudioSource>().volume = 1f;
			GetComponent<AudioSource>().pitch = 1f;
			GetComponent<AudioSource>().Stop();
		}
	}

	public virtual IEnumerator ShowBoardOLD(bool turnOn)
	{
		return new _0024ShowBoardOLD_0024634(turnOn, this).GetEnumerator();
	}

	public virtual Vector3 PointOnLine(Vector3 lineVector, Vector3 centerPoint, Vector3 checkPoint)
	{
		return centerPoint + lineVector.normalized * Vector3.Dot(lineVector.normalized, checkPoint - centerPoint);
	}

	public virtual void ChangeMode(string newMode)
	{
		switch (newMode)
		{
		case "foot":
			waterJump = false;
			GetComponent<Rigidbody>().useGravity = true;
			if (myMode == "dance" || myMode == "fight")
			{
				myMode = "foot";
				ChangeInputs();
				myAction = "stand";
				ChangeAnimation(myAction, 0.25f);
			}
			else if (myMode == "hang")
			{
				hangObject = null;
				myMode = "foot";
				ChangeInputs();
				hoverCount = 0;
			}
			else if ((mainPlayer || groundTag == "Water" || !inRange) && !(myAction == "getOff") && !(myAction == "getOff2"))
			{
				myAction = "getOff";
				UpdateAnimation();
			}
			break;
		case "fight":
			if (mainPlayer)
			{
				myOpponent = null;
				PlayerControl[] array = (PlayerControl[])UnityEngine.Object.FindObjectsOfType(typeof(PlayerControl));
				int i = 0;
				PlayerControl[] array2 = array;
				for (int length = array2.Length; i < length; i++)
				{
					if (!array2[i].mainPlayer)
					{
						myOpponent = array2[i];
						array2[i].myOpponent = this;
						Debug.Log("Found opponent!");
					}
				}
				if (!myOpponent)
				{
					Debug.Log("No opponent to fight!");
					break;
				}
			}
			else if (!inRange)
			{
				break;
			}
			hoverCount = 0;
			myMode = "fight";
			ShowBoard(false);
			ChangeInputs();
			myAction = "fightStand";
			myAnimation.CrossFade("fightStand", 0.25f);
			break;
		case "hang":
			GetComponent<Rigidbody>().useGravity = false;
			hoverCount = 0;
			myMode = "hang";
			ShowBoard(false);
			ChangeInputs();
			break;
		case "dance":
			if (mainPlayer || inRange)
			{
				hoverCount = 0;
				myMode = "dance";
				ShowBoard(false);
				ChangeInputs();
				myAnimation.CrossFade("dance1", 0.25f);
			}
			break;
		case "board":
			forwardValid = modelTransform.forward;
			if (myMode == "dance" || myMode == "fight")
			{
				myMode = "foot";
				ChangeInputs();
				myAction = "stand";
				myAnimation.CrossFade(myAction, 0.25f);
			}
			else if (myMode == "hang")
			{
				if (mainPlayer)
				{
					PlaySound("dud");
				}
			}
			else if (!(myAction == "getOn") && !(myAction == "getOn2") && (mainPlayer || !(groundTag == "Water")))
			{
				myAction = "getOn";
				myAnimation.Rewind("footToHover1");
				myAnimation.Play("footToHover1");
				PlaySound("boardOn");
			}
			break;
		}
	}

	public virtual void ChangeInputs()
	{
		if (!mainPlayer)
		{
			return;
		}
		PlayerInput playerInput = (PlayerInput)UnityEngine.Object.FindObjectOfType(typeof(PlayerInput));
		if (!playerInput)
		{
			return;
		}
		if (myMode == "foot")
		{
			gameControl.cameraType = "foot";
			if ((bool)playerInput)
			{
				playerInput.UpdateMode("foot");
			}
			if ((bool)playerInput)
			{
				playerInput.ChangeControl("joystick");
			}
		}
		else if (myMode == "hang")
		{
			gameControl.cameraType = "hang";
			if ((bool)playerInput)
			{
				playerInput.UpdateMode("hang");
			}
			if ((bool)playerInput)
			{
				playerInput.ChangeControl("joystick");
			}
		}
		else if (myMode == "board")
		{
			gameControl.cameraType = "board";
			if ((bool)playerInput)
			{
				playerInput.UpdateMode("board");
			}
			if ((bool)playerInput)
			{
				playerInput.ChangeControl("tilt");
			}
		}
		else if (myMode == "dance")
		{
			gameControl.cameraType = "dance";
			if ((bool)playerInput)
			{
				playerInput.UpdateMode("dance");
			}
			if ((bool)playerInput)
			{
				playerInput.ChangeControl("joystick");
			}
		}
		else if (myMode == "fight")
		{
			gameControl.cameraType = "fight";
			if ((bool)playerInput)
			{
				playerInput.UpdateMode("fight");
			}
			if ((bool)playerInput)
			{
				playerInput.ChangeControl("joystick");
			}
		}
	}

	public virtual void ChangeMaterialColor(Color newColor)
	{
	}

	public virtual void ChangeStop(bool whichWay)
	{
		if (whichWay)
		{
			stop = whichWay;
		}
	}

	public virtual void AdjustRotation(Quaternion newRotation)
	{
		transform.rotation = newRotation;
		modelTransform.rotation = transform.rotation;
	}

	public virtual void ChangeRotation(Vector3 rotateVector)
	{
		transform.Rotate(rotateVector, Space.World);
		modelTransform.rotation = transform.rotation;
		gameControl.PlaySound((AudioClip)Resources.Load("Sounds/boing"));
	}

	public virtual void AddVerticalForce(float howMuch)
	{
		float y = howMuch * 0.028f;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		float num = (velocity.y = y);
		Vector3 vector2 = (GetComponent<Rigidbody>().velocity = velocity);
		origVelocity = GetComponent<Rigidbody>().velocity;
		myAction = "jumpStart";
		PlaySound("jump");
		myAnimation.Rewind(myAction);
		ChangeAnimation(myAction, 0.15f);
	}

	public virtual void AddBoost(float howMuch)
	{
		boost = Mathf.Clamp(boost + howMuch, 0f, 100f);
	}

	public virtual void AddGems(int howMuch)
	{
		if (x2 > 0)
		{
			howMuch *= 2;
		}
		gameControl.missionGem += howMuch;
		gameControl.CheckBonusMilestone();
	}

	public virtual void AddStar(int howMuch)
	{
		gameControl.missionStar += howMuch;
	}

	public virtual void AddHealth(int howMuch)
	{
		health += howMuch;
		if (health > 3)
		{
			health = 3;
		}
	}

	public virtual void AddShield(int howMuch)
	{
		shield = 1;
		shieldObject.SetActive(true);
		if ((bool)shieldObject.GetComponent<AudioSource>())
		{
			shieldObject.GetComponent<AudioSource>().Play();
		}
		StopCoroutine("DisableShield");
		StartCoroutine("DisableShield");
	}

	public virtual IEnumerator DisableShield()
	{
		return new _0024DisableShield_0024641(this).GetEnumerator();
	}

	public virtual void StopShield()
	{
		StopCoroutine("DisableShield");
		shield = 0;
		shieldObject.SetActive(false);
	}

	public virtual void AddX2(int howMuch)
	{
		x2 = 1;
		StopCoroutine("DisableX2");
		StartCoroutine("DisableX2");
	}

	public virtual IEnumerator DisableX2()
	{
		return new _0024DisableX2_0024645(this).GetEnumerator();
	}

	public virtual void ShotByBullet(int howMuch)
	{
		AddDamage(100);
	}

	public virtual void AddDamage(int howMuch)
	{
		if (shield <= 0)
		{
			health -= howMuch;
			PlaySound("ouch");
			if (health <= 0)
			{
				Die();
			}
		}
	}

	public virtual void Die()
	{
		if (!(myAction == "die"))
		{
			stop = false;
			if (myMode != "foot")
			{
				ChangeMode("foot");
			}
			if (myAction == "flyingfox")
			{
				StopFlyingFox();
			}
			AddBoost(-100f);
			StopShield();
			lastConstraints = GetComponent<Rigidbody>().constraints;
			GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
			modelTransform.eulerAngles = new Vector3(0f, 0f, 0f);
			transform.rotation = modelTransform.rotation;
			lastModelRotation = modelTransform.rotation;
			int num = 70;
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			float num2 = (velocity.y = num);
			Vector3 vector2 = (GetComponent<Rigidbody>().velocity = velocity);
			health = 0;
			myAction = "die";
			ChangeAnimation(myAction, 0.5f);
			StartCoroutine(gameControl.ShowSaveMe(1.95f));
		}
	}

	public virtual IEnumerator DieNoSaveMe()
	{
		return new _0024DieNoSaveMe_0024648(this).GetEnumerator();
	}

	public virtual void SaveMe()
	{
		if (myMode == "foot")
		{
			ShowBoard(false);
		}
		myAction = "idle";
		health = 1;
		ResetToSafePosition();
		AddShield(100);
		AddBoost(100f);
	}

	public virtual IEnumerator BlinkColor(Color newColor)
	{
		return new _0024BlinkColor_0024651(newColor, this).GetEnumerator();
	}

	public virtual void BouncedBaddie(float howHigh)
	{
		jumpTime = Time.time;
		jumpPressed = false;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		float num = (velocity.y = howHigh);
		Vector3 vector2 = (GetComponent<Rigidbody>().velocity = velocity);
		myAction = "jumpStart";
		myAnimation.Rewind(myAction);
		ChangeAnimation(myAction, 0.15f);
	}

	public virtual IEnumerator FallDownHole(bool soundIsOff)
	{
		return new _0024FallDownHole_0024656(soundIsOff, this).GetEnumerator();
	}

	public virtual void UpdateMainPlayer()
	{
		if (mainPlayer)
		{
			if (gameControl.updateOutfit)
			{
				gameControl.updateOutfit = false;
				ChangeOutfit();
			}
			else
			{
				TurnOffUnusedOutfitObjects();
			}
			gameControl.playerControl = this;
			GetComponent<AudioSource>().volume = 1f;
		}
	}

	public virtual void TurnOffUnusedOutfitObjects()
	{
		OutfitControl outfitControl = (OutfitControl)UnityEngine.Object.FindObjectOfType(typeof(OutfitControl));
		if ((bool)outfitControl)
		{
			outfitControl.TurnOffObjects(childModel);
			outfitControl.DoAddOns();
		}
		ShowBoard(false);
	}

	public virtual void ChangeOutfit()
	{
		if ((bool)myMaterial)
		{
			OutfitControl outfitControl = (OutfitControl)UnityEngine.Object.FindObjectOfType(typeof(OutfitControl));
			if ((bool)outfitControl)
			{
				outfitControl.ChangeOutfit((Texture2D)myMaterial.mainTexture, playerData.outfit);
			}
		}
		TurnOffUnusedOutfitObjects();
	}

	public virtual void InitAnimation()
	{
		myAnimation = (Animation)modelObject.GetComponentInChildren(typeof(Animation));
		if ((bool)myAnimation)
		{
			myAnimation.wrapMode = WrapMode.Loop;
			for (int i = 0; i < maxGrabs; i++)
			{
				myAnimation["grab" + i].wrapMode = WrapMode.ClampForever;
			}
			myAnimation["jumpLand"].wrapMode = WrapMode.Once;
			myAnimation["hoverToFoot1"].wrapMode = WrapMode.Once;
			myAnimation["fightPunch"].wrapMode = WrapMode.Once;
			myAnimation["fightPunch"].speed = 1.5f;
			myAnimation["fightKick"].wrapMode = WrapMode.Once;
			myAnimation["fightKick"].speed = 1.5f;
			myAnimation["footToHover1"].wrapMode = WrapMode.Once;
			myAnimation["footToHover2"].wrapMode = WrapMode.Once;
			myAnimation["land"].wrapMode = WrapMode.ClampForever;
			myAnimation["land"].speed = 0.25f;
			myAnimation["jumpStart"].wrapMode = WrapMode.ClampForever;
			myAnimation["hangClimb"].wrapMode = WrapMode.Once;
			myAnimation["hangIdle"].wrapMode = WrapMode.ClampForever;
			myAnimation["hangClimbHalf"].wrapMode = WrapMode.Once;
			myAnimation["win"].speed = 1.2f;
			myAnimation["run"].speed = 1.5f;
			myAnimation["jumpLand"].speed = 1.5f;
			myAnimation["levelupStart"].wrapMode = WrapMode.Once;
			myAnimation["levelupStart"].speed = 0.5f;
			myAnimation["levelupEnd"].wrapMode = WrapMode.Once;
			if (myMode == "board")
			{
				myAction = "hover";
				myClip = "hover";
				myAnimation.Play(myClip);
				ShowBoard(true);
			}
			else if (myMode == "foot")
			{
				ShowBoard(false);
				myClip = "stand";
				myAnimation.Play(myClip);
			}
			else if ((bool)myAnimation[myClip + animSuffix])
			{
				myAnimation.Play(myClip + animSuffix);
			}
			else
			{
				myAnimation.Play(myClip);
			}
		}
	}

	public virtual void MakeMainPlayer()
	{
		mainPlayer = true;
		gameControl.playerControl = this;
	}

	public virtual void UpdateAction()
	{
		hoverCount++;
		if (myAction == "grind" || !(myAction == "getOff"))
		{
			return;
		}
		modelTransform.localEulerAngles = new Vector3(0f, modelTransform.localEulerAngles.y, 0f);
		lastModelRotation = modelTransform.rotation;
		if (!myAnimation.isPlaying)
		{
			ShowBoard(false);
			if (inair)
			{
				myAction = "jumpTop";
				myAnimation.Play(myAction);
			}
			else
			{
				myAction = "idle";
				myAnimation.Play("run");
			}
			myMode = "foot";
			ChangeInputs();
		}
	}

	public virtual void ChangeAnimation(string newClip, float crossfadeTime)
	{
		if (myClip == newClip || !myAnimation)
		{
			return;
		}
		if (newClip == "grind")
		{
			newClip = "grab0";
		}
		if (!myAnimation[newClip] && !(newClip == "winmini"))
		{
			Debug.Log("No AnimationClip for: " + newClip);
			return;
		}
		if (myClip == "jumpLand" && newClip == "run")
		{
			StartCoroutine(QueueAnimation("run", 0.1f));
			myClip = newClip;
			return;
		}
		switch (newClip)
		{
		case "land":
			hoverCount = 0;
			break;
		case "hoverToFoot1":
		case "hoverToFoot2":
			PlaySound("boardOff");
			break;
		case "newitem":
			StartCoroutine(QueueAnimation("stand", 3.5f));
			break;
		case "winmini":
			newClip = "win";
			StartCoroutine(QueueAnimation("stand", 2.1f));
			break;
		case "win":
			StartCoroutine(QueueAnimation("stand", 4.1f));
			break;
		case "lose":
			StartCoroutine(QueueAnimation("stand", 5f));
			break;
		}
		if (gameControl.inGame && newClip.IndexOf("stand") != -1)
		{
			newClip = "fightStand";
		}
		if (newClip == "hangClimb")
		{
			crossfadeTime = ((myClip.IndexOf("water") == -1) ? 0.2f : 0f);
			if (climbDelta <= 0f)
			{
			}
		}
		if (crossfadeTime == 0f)
		{
			myAnimation.Rewind(newClip);
			myAnimation.Play(newClip);
		}
		else
		{
			myAnimation.CrossFade(newClip, crossfadeTime);
		}
		myClip = newClip;
	}

	public virtual IEnumerator ShowLevelUp(string whichOutfit, string whichExplosion)
	{
		return new _0024ShowLevelUp_0024663(whichOutfit, whichExplosion, this).GetEnumerator();
	}

	public virtual IEnumerator QueueAnimation(string whichClip, float delayInSeconds)
	{
		return new _0024QueueAnimation_0024671(whichClip, delayInSeconds, this).GetEnumerator();
	}

	public virtual void UpdateAnimation()
	{
		if (!myAnimation)
		{
			return;
		}
		tempClip = "idle";
		float crossfadeTime = 0.35f;
		if (myAction == "grind")
		{
			return;
		}
		if (myAction == "die")
		{
			tempClip = "slide";
		}
		else if (myAction == "off")
		{
			tempClip = "offLoop";
		}
		else if (myAction == "getOff")
		{
			tempClip = "hoverToFoot1";
			crossfadeTime = 0f;
		}
		else if (myAction == "getOff2")
		{
			tempClip = "hoverToFoot2";
			crossfadeTime = 0f;
		}
		else if (myAction == "getOn")
		{
			tempClip = "footToHover1";
			crossfadeTime = 0f;
		}
		else if (myAction == "getOn2")
		{
			tempClip = "footToHover2";
			crossfadeTime = 0f;
		}
		else if (!(inairCount <= 0.25f))
		{
			if (myClip.IndexOf("grab") != -1)
			{
				tempClip = myClip;
			}
			else
			{
				tempClip = "grab0";
				tempInt = UnityEngine.Random.Range(0, maxGrabs);
				tempClip = "grab" + tempInt;
				crossfadeTime = 0.25f;
			}
		}
		else if (myClip.IndexOf("grab") != -1)
		{
			tempClip = "land";
			crossfadeTime = 0.25f;
		}
		else if (myClip == "land" && !(myAnimation["land"].time >= myAnimation["land"].length * 0.25f))
		{
			tempClip = "land";
			crossfadeTime = 0.25f;
			float x = Mathf.LerpAngle(modelTransform.localEulerAngles.x, 0f, Time.deltaTime * 10f);
			Vector3 localEulerAngles = modelTransform.localEulerAngles;
			float num = (localEulerAngles.x = x);
			Vector3 vector2 = (modelTransform.localEulerAngles = localEulerAngles);
		}
		else if (myClip == "offBalanceLoop" && !(myAnimation["offBalanceLoop"].time >= myAnimation["offBalanceLoop"].length * 0.25f))
		{
			tempClip = myClip;
		}
		else
		{
			crossfadeTime = 1f;
			if (!(GetComponent<Rigidbody>().velocity.magnitude >= 20f))
			{
				if (!(inputVector.x <= 0.9f))
				{
					tempClip = "hoverRight";
					hoverCount = 0;
				}
				else if (!(inputVector.x >= -0.9f))
				{
					tempClip = "hoverLeft";
					hoverCount = 0;
				}
			}
			else
			{
				if (!(GetComponent<Rigidbody>().velocity.magnitude <= 150f))
				{
					tempClip = "turbo";
				}
				else
				{
					tempClip = "hover";
				}
				if (!(inputVector.x <= 0.15f))
				{
					tempClip += "Right";
				}
				else if (!(inputVector.x >= -0.15f))
				{
					tempClip += "Left";
				}
			}
		}
		ChangeAnimation(tempClip, crossfadeTime);
	}

	public virtual void UpdateReplay()
	{
	}

	public virtual void GetInputAI()
	{
		if (!targetTransform)
		{
			targetTransform = gameControl.cameraTarget;
			return;
		}
		Vector3 vector = transform.position - targetTransform.position;
		vector.y = 0f;
		Vector3 vector2 = default(Vector3);
		vector2 = ((targetTransform.position.y <= transform.position.y + 5f) ? (targetTransform.position + vector.normalized * 15f) : (targetTransform.position + targetTransform.right * 20f));
		vector2.y = transform.position.y;
		Vector3 vector3 = modelTransform.InverseTransformPoint(vector2);
		if (myMode == "foot" || myMode == "fight")
		{
			inputVector.x = Mathf.Clamp(vector3.x / vector3.magnitude, -1f, 1f);
			float num = 1f;
			if (!(vector3.magnitude >= 50f) && myMode == "foot")
			{
				num = 0.5f;
			}
			inputVector.y = Mathf.Clamp(vector3.z / 10f, 0f - num, num);
			if (!(vector3.magnitude >= 15f))
			{
				if (myAction.IndexOf("water") != -1)
				{
					inputVector = Vector3.zero;
				}
				inRange = true;
			}
			else
			{
				inRange = false;
			}
		}
		else
		{
			inputVector.x = Mathf.Clamp(vector3.x / vector3.magnitude, -1f, 1f);
			inputVector.y = Mathf.Clamp(vector3.z / 100f, -1f, 1f);
			if (!(Mathf.Abs(inputVector.x) <= 0.75f))
			{
				inputVector.y *= 0.1f;
			}
			if (!(vector3.magnitude >= 20f))
			{
				inputVector = Vector3.zero;
				inRange = true;
			}
			else
			{
				if (!(vector3.magnitude >= GetComponent<Rigidbody>().velocity.magnitude))
				{
					inputVector.y = 0f;
				}
				inRange = false;
			}
		}
		if (myMode != gameControl.playerControl.myMode && gameControl.playerControl.myMode != "hang")
		{
			ChangeMode(gameControl.playerControl.myMode);
		}
	}

	public virtual void Look(string whichWay)
	{
		if (whichWay == "up")
		{
			headLookOffset = new Vector3(0f, 5f, 0f);
		}
		else if (whichWay == "right")
		{
			headLookOffset = new Vector3(0f, -14f, -20f);
		}
		else
		{
			headLookOffset = new Vector3(0f, -14f, 0f);
		}
	}

	public virtual void PointHeadAt(Vector3 lookAtPoint)
	{
		if (!neckBone)
		{
			return;
		}
		if (myClip.IndexOf("stand") == -1)
		{
			lastNeckRot = neckBone.transform.rotation;
			return;
		}
		targetQuaternion = neckBone.transform.rotation;
		tempVector3 = lookAtPoint - modelTransform.position;
		tempFloat = 90f;
		if (myMode == "board")
		{
			tempFloat = 50f;
		}
		if (!(Vector3.Angle(tempVector3, modelTransform.forward) >= tempFloat))
		{
			neckBone.transform.LookAt(lookAtPoint);
			neckBone.transform.Rotate(new Vector3(0f, -90f, -70f));
			targetQuaternion = neckBone.transform.rotation;
		}
		neckBone.transform.rotation = Quaternion.Slerp(lastNeckRot, targetQuaternion, Time.deltaTime * 5f);
		lastNeckRot = neckBone.transform.rotation;
	}

	public virtual void ScaleHead(float howMuch)
	{
		if ((bool)neckBone)
		{
			neckBone.transform.localScale = new Vector3(howMuch, howMuch, howMuch);
		}
	}

	public virtual void LateUpdate()
	{
		lockCount += Time.deltaTime;
		if (gameControl.watchCamera)
		{
			if ((bool)targetTransform)
			{
				PointHeadAt(targetTransform.position);
			}
			else
			{
				float y = Mathf.Clamp((30f - Vector3.Distance(Camera.main.transform.position, transform.position)) / 2f, 0f, 10f);
				PointHeadAt(Camera.main.transform.position + headLookOffset + new Vector3(0f, y, 0f));
			}
		}
		if (gameControl.headsize != 1f)
		{
			ScaleHead(gameControl.headsize);
		}
		if (myMode == "foot" || myMode == "fight")
		{
			Vector3 direction = transform.position - validPosition;
			if (Physics.Raycast(validPosition, direction, out hit, 5f, layerMask))
			{
				transform.position = new Vector3(validPosition.x, transform.position.y, validPosition.z);
				float y2 = GetComponent<Rigidbody>().velocity.y - 10f;
				Vector3 velocity = GetComponent<Rigidbody>().velocity;
				float num = (velocity.y = y2);
				Vector3 vector2 = (GetComponent<Rigidbody>().velocity = velocity);
				if (!(hit.normal.y >= 0.5f))
				{
					gameControl.jumpButton = false;
				}
			}
		}
		validPosition = transform.position;
		if ((groundName != "none" && myAction != "stand") || myAction == "jumpUp")
		{
			StoreReplay();
		}
		if (myAction == "hangClimb" || myAction == "hangIdle")
		{
			MoveToHanger();
			transform.position = hangTargetPosition;
			modelTransform.position = transform.position + modelOffset;
		}
		if (shield == 1 && (bool)bodyModel && (bool)shieldObject)
		{
			shieldObject.transform.position = bodyModel.transform.position + new Vector3(-2f, -10f, 0f);
		}
	}

	public virtual void UpdateFight()
	{
		hoverCount++;
		newAction = myAction;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		float num = 10f;
		if (!(groundDist <= 8.5f))
		{
			num = 20f;
		}
		if (mainPlayer)
		{
			inputVector = gameControl.inputVector;
			if (playerData.controltype == "point")
			{
				if (inputVector != Vector3.zero)
				{
					GetComponent<Rigidbody>().velocity = modelTransform.TransformDirection(inputVector.x, 0f, inputVector.y);
				}
				else
				{
					GetComponent<Rigidbody>().velocity = Vector3.zero;
				}
			}
			else
			{
				GetComponent<Rigidbody>().velocity = Camera.main.transform.TransformDirection(inputVector.x, 0f, inputVector.y);
			}
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * num;
		}
		else
		{
			Vector3 vector = transform.position - targetTransform.position;
			Vector3 position = targetTransform.position + vector.normalized * 5f;
			Vector3 vector2 = modelTransform.InverseTransformPoint(position);
			inputVector.x = Mathf.Clamp(vector2.x / vector2.magnitude, -1f, 1f);
			float num2 = 1f;
			inputVector.y = Mathf.Clamp(vector2.z / 10f, 0f - num2, num2);
			if (!(vector2.magnitude >= 10f))
			{
				inputVector = Vector3.zero;
				inRange = true;
			}
			else
			{
				inRange = false;
			}
			GetComponent<Rigidbody>().velocity = modelTransform.TransformDirection(inputVector.x, 0f, inputVector.y);
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 5f;
			if (myMode != gameControl.playerControl.myMode)
			{
				ChangeMode(gameControl.playerControl.myMode);
			}
		}
		float y = velocity.y;
		Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
		float num3 = (velocity2.y = y);
		Vector3 vector4 = (GetComponent<Rigidbody>().velocity = velocity2);
		CheckGroundFoot();
		modelTransform.position = transform.position + modelOffset;
		transform.LookAt(myOpponent.transform);
		transform.localEulerAngles = new Vector3(0f, transform.localEulerAngles.y, 0f);
		modelTransform.rotation = transform.rotation;
		lastModelRotation = modelTransform.rotation;
		newAction = "fightStand";
		string text = myAction;
		if (text == "fightPunch")
		{
			if (myAnimation.isPlaying)
			{
				newAction = myAction;
			}
		}
		else if (text == "fightKick")
		{
			if (myAnimation.isPlaying)
			{
				newAction = myAction;
			}
		}
		else if (mainPlayer)
		{
			if (!(GetComponent<Rigidbody>().velocity.magnitude >= 1f))
			{
				newAction = "fightStand";
			}
			else
			{
				Vector3 vector5 = modelTransform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
				newAction = "fightWalk";
				if (!(vector5.z >= 0f))
				{
					newAction = "fightWalkBack";
				}
			}
			if (gameControl.touchButton[1])
			{
				gameControl.touchButton[1] = false;
				newAction = "fightPunch";
			}
			if (gameControl.touchButton[2])
			{
				gameControl.touchButton[2] = false;
				newAction = "fightKick";
			}
			if (gameControl.touchButton[0] && !(groundDist >= 10f))
			{
				gameControl.touchButton[0] = false;
				int num4 = 50;
				Vector3 velocity3 = GetComponent<Rigidbody>().velocity;
				float num5 = (velocity3.y = num4);
				Vector3 vector7 = (GetComponent<Rigidbody>().velocity = velocity3);
				newAction = "jumpUp";
			}
		}
		else if (hoverCount % 300 == 0)
		{
			if (inRange)
			{
				if (UnityEngine.Random.Range(0, 2) == 0)
				{
					newAction = "fightPunch";
				}
				else
				{
					newAction = "fightKick";
				}
			}
		}
		else if (!(GetComponent<Rigidbody>().velocity.magnitude >= 1f))
		{
			newAction = "fightStand";
		}
		else
		{
			Vector3 vector8 = modelTransform.InverseTransformDirection(GetComponent<Rigidbody>().velocity);
			newAction = "fightWalk";
			if (!(vector8.z >= 0f))
			{
				newAction = "fightWalkBack";
			}
		}
		if (!(groundDist <= 8.5f))
		{
			if (!(Mathf.Abs(GetComponent<Rigidbody>().velocity.y) >= 10f))
			{
				newAction = "jumpTop";
			}
			else if (!(GetComponent<Rigidbody>().velocity.y >= 0f))
			{
				newAction = "jumpDown";
			}
			else
			{
				newAction = "jumpUp";
			}
		}
		if (newAction != myAction)
		{
			myAction = newAction;
			myAnimation.CrossFade(myAction, 0.25f);
		}
	}

	public virtual void EndStop()
	{
		jumpTime = Time.time - 0.2f;
		jumpPressed = false;
		stop = false;
	}

	public virtual void UpdateFoot()
	{
		hoverCount++;
		if (!myAnimation)
		{
			InitAnimation();
		}
		if (!(transform.position.y > resetY) && resetY != 0f)
		{
			ResetToSafePosition();
		}
		if (myAction != "slide" && loopSoundName == "slide")
		{
			GetComponent<AudioSource>().Stop();
		}
		if (myAction != "jumpFly" && loopSoundName == "jumpFly")
		{
			GetComponent<AudioSource>().Stop();
		}
		newAction = myAction;
		origVelocity = GetComponent<Rigidbody>().velocity;
		if (myAction == "stand" && GetComponent<Rigidbody>().IsSleeping())
		{
			GetComponent<Rigidbody>().WakeUp();
		}
		if (inHole)
		{
			int num = 0;
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			float num2 = (velocity.x = num);
			Vector3 vector2 = (GetComponent<Rigidbody>().velocity = velocity);
			int num3 = 0;
			Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
			float num4 = (velocity2.z = num3);
			Vector3 vector4 = (GetComponent<Rigidbody>().velocity = velocity2);
			if (!(GetComponent<Rigidbody>().velocity.y >= -100f))
			{
				int num5 = -100;
				Vector3 velocity3 = GetComponent<Rigidbody>().velocity;
				float num6 = (velocity3.y = num5);
				Vector3 vector6 = (GetComponent<Rigidbody>().velocity = velocity3);
			}
			gameControl.touchButton[0] = false;
			modelTransform.position = transform.position + modelOffset;
			myAction = "jumpDown";
			ChangeAnimation(myAction, 0.35f);
			return;
		}
		if (stop)
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			if (!stopTransform)
			{
				EndStop();
				return;
			}
			float y = stopTransform.position.y;
			Vector3 position = modelTransform.position;
			float num7 = (position.y = y);
			Vector3 vector8 = (modelTransform.position = position);
			float y2 = modelTransform.position.y + (8f + modelOffset.y);
			Vector3 position2 = modelTransform.position;
			float num8 = (position2.y = y2);
			Vector3 vector10 = (modelTransform.position = position2);
			float y3 = modelTransform.position.y - modelOffset.y - 1f;
			Vector3 position3 = transform.position;
			float num9 = (position3.y = y3);
			Vector3 vector12 = (transform.position = position3);
			myAction = "stand";
			ChangeAnimation(myAction + animSuffix, 0.35f);
			if (gameControl.touchButton[0])
			{
				EndStop();
			}
			else
			{
				CheckGroundFoot();
				if (!groundTransform || !(groundStopTransform != groundTransform))
				{
					return;
				}
				EndStop();
			}
		}
		if (myAction == "hangClimb")
		{
			MoveToHanger();
			transform.position = hangTargetPosition;
			modelTransform.position = transform.position + modelOffset;
			shadowObject.GetComponent<Renderer>().enabled = false;
			if (!myAnimation.isPlaying)
			{
				waterJump = false;
				myAction = "run";
				ChangeAnimation(myAction, 0f);
				jumpPressed = false;
				shadowObject.GetComponent<Renderer>().enabled = true;
				transform.position = hangTargetPosition + new Vector3(0f, 13f, 0f) + modelTransform.forward * 3f;
				modelTransform.position = transform.position + modelOffset;
				GetComponent<Rigidbody>().velocity = modelTransform.up * 5f;
				groundTag = "none";
				lastGroundTag = "none";
			}
			return;
		}
		if (myAction == "flyingfox")
		{
			GetComponent<Rigidbody>().velocity = transform.forward * 60f;
			modelTransform.position = transform.position + modelOffset;
			if (gameControl.touchButton[0] && mainPlayer && hoverCount > 10)
			{
				StopFlyingFox();
			}
			return;
		}
		if ((groundNormal.y <= 0.8f || groundTag == "Ice") && !(groundDist >= 10f) && myAction != "die")
		{
			if (myAction.IndexOf("water") == -1)
			{
				if (groundTag == "Ice")
				{
					GetComponent<Rigidbody>().velocity = transform.forward * 50f;
				}
				else if (!(GetComponent<Rigidbody>().velocity.magnitude >= 5f))
				{
					GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + groundNormal.normalized * 1f;
				}
				modelTransform.position = transform.position + modelOffset;
				if (GetComponent<Rigidbody>().velocity != Vector3.zero)
				{
					targetQuaternion = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity, new Vector3(0f, 1f, 0f));
					modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetQuaternion, Time.deltaTime * 5f);
					lastModelRotation = Quaternion.identity;
					lastModelRotation.y = modelTransform.rotation.y;
				}
				newAction = "slide";
				jumpPressed = false;
				if (myAction != newAction)
				{
					myAction = newAction;
					ChangeAnimation("slide", 0.35f);
					PlayLoopSound("slide");
				}
				if (gameControl.touchButton[0] && mainPlayer)
				{
					jumpPressed = true;
					jumpTime = Time.time;
					int num10 = 40;
					Vector3 velocity4 = GetComponent<Rigidbody>().velocity;
					float num11 = (velocity4.y = num10);
					Vector3 vector14 = (GetComponent<Rigidbody>().velocity = velocity4);
					if (groundTag == "Ice")
					{
						int num12 = 55;
						Vector3 velocity5 = GetComponent<Rigidbody>().velocity;
						float num13 = (velocity5.y = num12);
						Vector3 vector16 = (GetComponent<Rigidbody>().velocity = velocity5);
					}
					if (loopSoundName == "slide")
					{
						GetComponent<AudioSource>().Stop();
					}
				}
				CheckGroundFoot();
				return;
			}
			gameControl.inputVector = Vector3.zero;
		}
		if (mainPlayer)
		{
			CheckRunIntoWall();
			inputVector = gameControl.inputVector;
			if (!(lockCount >= 0.5f))
			{
				inputVector = Vector3.zero;
			}
			if (playerData.controltype == "point")
			{
				if (!(inputVector.magnitude < 0.5f))
				{
					GetComponent<Rigidbody>().velocity = modelTransform.TransformDirection(inputVector.x, 0f, inputVector.y);
				}
			}
			else
			{
				if (gameControl.cameraType == "sidescroll")
				{
					GetComponent<Rigidbody>().velocity = modelTransform.TransformDirection(inputVector.x, 0f, inputVector.y);
					if (stop)
					{
						GetComponent<Rigidbody>().velocity = Vector3.zero;
					}
				}
				else
				{
					GetComponent<Rigidbody>().velocity = Camera.main.transform.TransformDirection(inputVector.x, 0f, inputVector.y);
				}
				int num14 = 0;
				Vector3 velocity6 = GetComponent<Rigidbody>().velocity;
				float num15 = (velocity6.y = num14);
				Vector3 vector18 = (GetComponent<Rigidbody>().velocity = velocity6);
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * inputVector.magnitude;
			}
		}
		else
		{
			GetInputAI();
			if (!(lockCount >= 0.5f))
			{
				inputVector = Vector3.zero;
			}
			GetComponent<Rigidbody>().velocity = modelTransform.TransformDirection(inputVector.x, 0f, inputVector.y);
		}
		if (inputVector == Vector3.zero)
		{
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
		}
		else
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 40f;
		}
		if (!(GetComponent<Rigidbody>().velocity.magnitude <= 15f))
		{
			targetQuaternion = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity, new Vector3(0f, 1f, 0f));
			modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetQuaternion, Time.deltaTime * 5f);
			modelTransform.localEulerAngles = new Vector3(0f, modelTransform.localEulerAngles.y, 0f);
			lastModelRotation = modelTransform.rotation;
			float y4 = origVelocity.y;
			Vector3 velocity7 = GetComponent<Rigidbody>().velocity;
			float num16 = (velocity7.y = y4);
			Vector3 vector20 = (GetComponent<Rigidbody>().velocity = velocity7);
			if (!(GetComponent<Rigidbody>().velocity.magnitude <= 38f))
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 40f;
				newAction = "run";
			}
			else
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 15f;
				newAction = "walk";
			}
			if (groundTag == "Catwalk")
			{
				if (myAction.IndexOf("jump") == -1 || waterJump)
				{
					GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 40f * slowDown;
				}
				newAction = "catwalk";
			}
			if (myAction.IndexOf("jump") != -1 && waterJump)
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 40f * slowDown;
			}
		}
		else
		{
			newAction = "stand";
		}
		float y5 = origVelocity.y;
		Vector3 velocity8 = GetComponent<Rigidbody>().velocity;
		float num17 = (velocity8.y = y5);
		Vector3 vector22 = (GetComponent<Rigidbody>().velocity = velocity8);
		modelTransform.position = transform.position + modelOffset;
		CheckGroundFoot();
		if (groundVelocity != Vector3.zero)
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + groundVelocity;
			if (myAction.IndexOf("jump") == -1)
			{
				float y6 = groundVelocity.y + 1f;
				Vector3 velocity9 = GetComponent<Rigidbody>().velocity;
				float num18 = (velocity9.y = y6);
				Vector3 vector24 = (GetComponent<Rigidbody>().velocity = velocity9);
				float y7 = groundPosition.y + 7.5f + modelOffset.y;
				Vector3 position4 = modelTransform.position;
				float num19 = (position4.y = y7);
				Vector3 vector26 = (modelTransform.position = position4);
			}
			else
			{
				float y8 = origVelocity.y;
				Vector3 velocity10 = GetComponent<Rigidbody>().velocity;
				float num20 = (velocity10.y = y8);
				Vector3 vector28 = (GetComponent<Rigidbody>().velocity = velocity10);
			}
		}
		if (Time.time - jumpTime > 0.1f || myAction == "jumpStart")
		{
			if (!(Mathf.Abs(GetComponent<Rigidbody>().velocity.y) >= 20f))
			{
				if (myAction.IndexOf("jump") != -1)
				{
					newAction = "jumpTop";
				}
			}
			else if (!(GetComponent<Rigidbody>().velocity.y >= 0f))
			{
				newAction = "jumpDown";
			}
			else
			{
				newAction = "jumpStart";
			}
		}
		if (myAction == "die" && !(GetComponent<Rigidbody>().velocity.y >= -60f))
		{
			int num21 = -60;
			Vector3 velocity11 = GetComponent<Rigidbody>().velocity;
			float num22 = (velocity11.y = num21);
			Vector3 vector30 = (GetComponent<Rigidbody>().velocity = velocity11);
		}
		if (groundTag == "Water")
		{
			tempBoolean = true;
			if (myAction.IndexOf("jump") == -1 && !(groundDist >= 10f))
			{
				newAction = "waterTread";
				if (!(GetComponent<Rigidbody>().velocity.magnitude <= 10f))
				{
					newAction = "waterSwim";
					PlaySound("swim");
				}
			}
			else
			{
				tempBoolean = false;
			}
			if (!(GetComponent<Rigidbody>().velocity.magnitude <= 10f) && tempBoolean)
			{
				GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * 40f * slowDown;
			}
			float y9 = origVelocity.y;
			Vector3 velocity12 = GetComponent<Rigidbody>().velocity;
			float num23 = (velocity12.y = y9);
			Vector3 vector32 = (GetComponent<Rigidbody>().velocity = velocity12);
		}
		else if (lastGroundTag == "Water")
		{
			if (!(groundNormal.y < 0.85f))
			{
				if (myAction.IndexOf("jump") == -1)
				{
					newAction = "hangClimb";
				}
			}
			else if (myAction.IndexOf("jump") == -1)
			{
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				newAction = "waterTread";
			}
			else
			{
				lockCount = 0f;
			}
		}
		if (mainPlayer)
		{
			if (myAction != "jumpFly" && !(boost <= 0f))
			{
				jumpPressed = false;
			}
			if (gameControl.touchButton[0] && !jumpPressed)
			{
				gameControl.touchButton[0] = false;
				if (!(Time.time - jumpTime >= 0.1f) && myAction.IndexOf("jump") == -1)
				{
					jumpPressed = true;
					if (groundTag == "Water" || groundTag == "Catwalk")
					{
						int num24 = 40;
						Vector3 velocity13 = GetComponent<Rigidbody>().velocity;
						float num25 = (velocity13.y = num24);
						Vector3 vector34 = (GetComponent<Rigidbody>().velocity = velocity13);
						waterJump = true;
					}
					else
					{
						float y10 = 50f + Mathf.Clamp(groundVelocity.y, 0f, 200f);
						Vector3 velocity14 = GetComponent<Rigidbody>().velocity;
						float num26 = (velocity14.y = y10);
						Vector3 vector36 = (GetComponent<Rigidbody>().velocity = velocity14);
						waterJump = false;
					}
					newAction = "jumpStart";
				}
				else if (!(boost <= 0f) && !(Time.time - jumpTime <= 0.5f) && !(groundDist <= 9f))
				{
					AddBoost(-50f * Time.deltaTime);
					GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 4f;
					int num27 = 0;
					Vector3 velocity15 = GetComponent<Rigidbody>().velocity;
					float num28 = (velocity15.y = num27);
					Vector3 vector38 = (GetComponent<Rigidbody>().velocity = velocity15);
					newAction = "jumpFly";
				}
			}
		}
		else if ((bool)targetTransform && gameControl.playerControl.myMode == "hang" && inRange && !(targetTransform.position.y <= transform.position.y + 3f) && !(groundDist >= 10f) && !(Time.time - jumpTimer <= 2f))
		{
			jumpTimer = Time.time;
			float y11 = 50f + groundVelocity.y;
			Vector3 velocity16 = GetComponent<Rigidbody>().velocity;
			float num29 = (velocity16.y = y11);
			Vector3 vector40 = (GetComponent<Rigidbody>().velocity = velocity16);
			newAction = "jumpStart";
		}
		if (groundTag != "Water" && myAction.IndexOf("jump") != -1 && !(myAction == "jumpLand") && newAction.IndexOf("jump") == -1 && !(groundNormal.y < 0.8f))
		{
			newAction = "jumpLand";
		}
		if (myAction == "getOn")
		{
			if (!myAnimation.isPlaying)
			{
				myAction = "getOn2";
				ShowBoard(true);
				myAnimation.Rewind("footToHover2");
				myAnimation.Play("footToHover2");
			}
		}
		else if (myAction == "getOn2")
		{
			if (!myAnimation.isPlaying)
			{
				myAnimation.Play("hover");
				myAction = "hover";
				myMode = "board";
				hoverCount = 0;
				ChangeInputs();
			}
		}
		else if (!(myAction == "die") && newAction != myAction && myMode == "foot")
		{
			if (newAction.IndexOf("water") != -1 && myAction.IndexOf("water") == -1)
			{
				PlaySound("splash");
				UnityEngine.Object.Instantiate(Resources.Load("waterSplash"), modelTransform.position + new Vector3(0f, -4f, 0f), Quaternion.identity);
				StartCoroutine(ResetJumpPressed());
			}
			myAction = newAction;
			if (myAction == "stand")
			{
				if (!(myClip == "newitem") && !(myClip == "win") && !(myClip == "lose") && !(myClip == "levelup"))
				{
					ChangeAnimation(myAction + animSuffix, 0.35f);
				}
				StartCoroutine(ResetJumpPressed());
			}
			else if (myAction == "jumpStart")
			{
				PlaySound("jump");
				myAnimation.Rewind(myAction);
				ChangeAnimation(myAction, 0.15f);
			}
			else if (myAction == "jumpTop" || myAction == "jumpDown")
			{
				ChangeAnimation(myAction, 0.5f);
			}
			else if (myAction == "hangClimb")
			{
				hangTargetPosition = groundPosition + new Vector3(0f, -6f, 0f);
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				PlaySound("climb");
				ChangeAnimation(myAction, 0f);
				transform.position = hangTargetPosition;
			}
			else if (myAction == "jumpFly")
			{
				ChangeAnimation(myAction, 0.35f);
				PlayLoopSound("jumpFly");
			}
			else if (myAction == "jumpLand")
			{
				jumpPressed = true;
				ChangeAnimation(myAction, 0f);
				PlaySound("land");
				StartCoroutine(ResetJumpPressed());
			}
			else
			{
				ChangeAnimation(myAction, 0.35f);
			}
		}
		GetComponent<Rigidbody>().MoveRotation(modelTransform.rotation);
		if (myAction == "run")
		{
			PlaySound("run");
		}
		else if (myAction == "walk")
		{
			PlaySound("walk");
		}
		else if (myAction == "catwalk")
		{
			PlaySound("catwalk");
		}
	}

	public virtual IEnumerator ResetJumpPressed()
	{
		return new _0024ResetJumpPressed_0024678(this).GetEnumerator();
	}

	public virtual void UpdateDance()
	{
		hoverCount++;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		transform.position = modelTransform.position - modelOffset;
		if (hoverCount > 100)
		{
			if (mainPlayer)
			{
				if (gameControl.inputVector != Vector3.zero)
				{
					ChangeMode("foot");
				}
			}
			else if (myMode != gameControl.playerControl.myMode)
			{
				ChangeMode(gameControl.playerControl.myMode);
			}
		}
		if (hoverCount % 400 == 0)
		{
			tempString = "dance" + UnityEngine.Random.Range(1, 4);
			myAnimation.CrossFade(tempString, 0.25f);
		}
	}

	public virtual bool CanStepUp()
	{
		tempBoolean = false;
		startPos = transform.position + new Vector3(0f, 8f, 0f) + transform.forward * 4f;
		MonoBehaviour.print("check can step: " + transform.position);
		if (Physics.Raycast(startPos, -Vector3.up, out hit, 3f, layerMask))
		{
			Debug.DrawLine(startPos, hit.point, Color.red);
			tempBoolean = true;
		}
		return tempBoolean;
	}

	public virtual bool CanStepUpHang()
	{
		tempBoolean = false;
		startPos = hangTargetPosition + new Vector3(0f, 8f, 0f) + transform.forward * 4f;
		if (Physics.Raycast(startPos, -Vector3.up, out hit, 3f, layerMask))
		{
			Debug.DrawLine(startPos, hit.point, Color.red);
			tempBoolean = true;
		}
		return tempBoolean;
	}

	public virtual void CheckRunIntoWall()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 vector = transform.position + new Vector3(0f, -3f, 0f);
		Vector3 forward = transform.forward;
		if (Physics.Raycast(vector, forward, out hitInfo, 5f, layerMask))
		{
			gameControl.inputVector.y = 0f;
			Debug.DrawLine(vector, vector + forward * 5f, Color.red);
		}
	}

	public virtual void UpdateHang()
	{
		if (myAction == "die")
		{
			return;
		}
		hoverCount++;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		shadowObject.SetActive(false);
		MoveToHanger();
		if (myAction.IndexOf("hangClimb") != -1)
		{
			if (myAction != "jumpFly" && loopSoundName == "jumpFly")
			{
				GetComponent<AudioSource>().Stop();
			}
			transform.position = hangTargetPosition;
			modelTransform.position = transform.position + modelOffset;
			if (!myAnimation.isPlaying)
			{
				myAction = "run";
				ChangeAnimation(myAction, 0f);
				jumpPressed = false;
				transform.position = hangTargetPosition + new Vector3(0f, 13f, 0f) + modelTransform.forward * 3f;
				modelTransform.position = transform.position + modelOffset;
				GetComponent<Rigidbody>().velocity = modelTransform.up * 5f;
				modelTransform.localEulerAngles = new Vector3(0f, modelTransform.localEulerAngles.y, 0f);
				lastModelRotation = modelTransform.rotation;
				transform.rotation = lastModelRotation;
				ChangeMode("foot");
			}
			return;
		}
		if (hoverCount > 2)
		{
			newAction = "hangIdle";
		}
		if (mainPlayer)
		{
			inputVector = gameControl.inputVector;
			gameControl.inair = false;
		}
		else
		{
			inputVector = Vector3.zero;
			if ((bool)targetTransform)
			{
				Vector3 vector = modelTransform.InverseTransformPoint(targetTransform.position);
				if (!(vector.magnitude <= 7f))
				{
					inputVector.x = Mathf.Clamp(vector.x / vector.magnitude, -0.5f, 0.5f);
					inputVector.y = Mathf.Clamp(vector.z / 10f, -1f, 1f);
				}
			}
		}
		if (hoverCount > 0)
		{
			if (mainPlayer)
			{
				if (gameControl.touchButton[0] && hoverCount > 10)
				{
					jumpTime = Time.time;
					gameControl.touchButton[0] = false;
					PlaySound("jump");
					ChangeMode("foot");
					jumpPressed = true;
					int num = 70;
					Vector3 velocity = GetComponent<Rigidbody>().velocity;
					float num2 = (velocity.y = num);
					Vector3 vector3 = (GetComponent<Rigidbody>().velocity = velocity);
					jumpTime = Time.time;
					myAction = "jumpStart";
					myAnimation.Rewind(myAction);
					ChangeAnimation(myAction, 0.15f);
					return;
				}
			}
			else if ((bool)targetTransform)
			{
				if (!(inputVector.y >= -0.9f) && !(targetTransform.position.y >= transform.position.y))
				{
					PlaySound("jump");
					ChangeMode("foot");
					return;
				}
				if (!(targetTransform.position.y <= transform.position.y + 10f))
				{
					int num3 = 60;
					Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
					float num4 = (velocity2.y = num3);
					Vector3 vector5 = (GetComponent<Rigidbody>().velocity = velocity2);
					PlaySound("jump");
					ChangeMode("foot");
					return;
				}
			}
			if (!(inputVector.y <= 0.9f))
			{
				if (CanStepUpHang())
				{
					newAction = "hangClimb";
				}
			}
			else
			{
				if (!(inputVector.y >= -0.9f))
				{
					ChangeMode("foot");
					return;
				}
				if (inputVector != Vector3.zero)
				{
					if (!(inputVector.x >= -0.4f))
					{
						PlaySound("hangStep");
						newAction = "hangLeft";
						hangTargetPosition += transform.right * Time.deltaTime * 10f * inputVector.x;
					}
					else if (!(inputVector.x <= 0.4f))
					{
						PlaySound("hangStep");
						newAction = "hangRight";
						hangTargetPosition += transform.right * Time.deltaTime * 10f * inputVector.x;
					}
				}
			}
		}
		transform.position = new Vector3(hangTargetPosition.x, transform.position.y + (hangTargetPosition.y - transform.position.y) * 10f * Time.deltaTime, hangTargetPosition.z);
		transform.rotation = hangTargetRotation;
		modelTransform.position = transform.position + modelOffset;
		modelTransform.rotation = transform.rotation;
		lastModelRotation = modelTransform.rotation;
		CheckGroundFoot();
		if (newAction != myAction)
		{
			myAction = newAction;
			if (myAction == "hangClimb")
			{
				PlaySound("climb");
				ChangeAnimation(myAction, 0f);
			}
			else
			{
				ChangeAnimation(myAction, 0.25f);
			}
		}
	}

	public virtual void Update()
	{
		if (!gameControl.paused)
		{
            if (gameControl.cheatsOn)
            {
                boost = int.MaxValue;
            }
            switch (myMode)
			{
			case "foot":
				UpdateFoot();
				break;
			case "hang":
				UpdateHang();
				break;
			case "fight":
				UpdateFight();
				break;
			case "dance":
				UpdateDance();
				break;
			case "locked":
				GetComponent<Rigidbody>().velocity = Vector3.zero;
				transform.position = modelTransform.position - modelOffset;
				break;
			default:
				UpdateBoard();
				break;
			}
		}
	}

	public virtual void UpdateBoard()
	{
		if (mainPlayer)
		{
			float num = Mathf.Clamp((200f - GetComponent<Rigidbody>().velocity.magnitude) / 50f, 1f, 2f);
			if (!(GetComponent<Rigidbody>().velocity.magnitude >= 2f))
			{
				num = 1f;
			}
			inputVector.y = Mathf.Clamp(gameControl.inputVector.y * num, 0f, 1f);
			inputVector.x = gameControl.inputVector.x;
			gameControl.inair = inair;
			if (playerData.controltype == "point" && (groundName == "halfpipe" || halfpipeAir))
			{
				inputVector.y = 1f;
				inputVector.x = Mathf.Clamp(Acceleration.acceleration.x * 2f, -1f, 1f);
			}
			if (halfpipeAir)
			{
				inputVector.y = 0f;
			}
		}
		else
		{
			GetInputAI();
		}
		UpdateAction();
		if (!(groundDist >= 20f) && myAction != "grind")
		{
			if (groundTag == "Water")
			{
				inputVector = Vector3.zero;
			}
			else
			{
				GetComponent<Rigidbody>().AddForce(modelTransform.forward * inputVector.y * Time.deltaTime * maxForce);
			}
		}
		if (!(GetComponent<Rigidbody>().velocity.magnitude <= 2f))
		{
			tempFloat = 1f;
			tempFloat = Mathf.Clamp(GetComponent<Rigidbody>().velocity.magnitude / 30f, 0.05f, 1f);
			if (!(groundDist <= 20f))
			{
				tempFloat = 0.45f;
			}
			if (halfpipeAir)
			{
				tempFloat = 0.15f;
			}
			if (myAction == "grind")
			{
				if (inputVector.y != 0f)
				{
					tempFloat = 2f;
				}
				else
				{
					tempFloat = 0f;
				}
			}
			if (!halfpipeAir)
			{
				GetComponent<Rigidbody>().AddForce(modelTransform.right * inputVector.x * Time.deltaTime * maxTurningForce * tempFloat);
			}
		}
		if ((groundName == "halfpipe" && !(groundDist <= 10f) && GetComponent<Rigidbody>().velocity.y > 20f) || (halfpipeAir && inair))
		{
			float num2 = GetComponent<Rigidbody>().velocity.y * groundDist;
			if (!halfpipeAir && !(num2 < 1400f))
			{
				float magnitude = GetComponent<Rigidbody>().velocity.magnitude;
				GetComponent<Rigidbody>().velocity = new Vector3(0f, magnitude, 0f);
				halfPipePosition = GetComponent<Rigidbody>().position + modelObject.transform.up.normalized * 3f;
				halfpipeAir = true;
				float x = halfPipePosition.x;
				Vector3 position = GetComponent<Rigidbody>().position;
				float num3 = (position.x = x);
				Vector3 vector2 = (GetComponent<Rigidbody>().position = position);
				float z = halfPipePosition.z;
				Vector3 position2 = GetComponent<Rigidbody>().position;
				float num4 = (position2.z = z);
				Vector3 vector4 = (GetComponent<Rigidbody>().position = position2);
			}
		}
		else
		{
			halfpipeAir = false;
			halfPipePosition = Vector3.zero;
		}
		if (!(GetComponent<Rigidbody>().velocity.magnitude >= 30f))
		{
			burnout = false;
		}
		if (inputVector.y == 0f && !(GetComponent<Rigidbody>().velocity.magnitude <= 1f) && !inair && myAction != "grind")
		{
			GetComponent<Rigidbody>().AddForce(-GetComponent<Rigidbody>().velocity.normalized * Time.deltaTime * maxForce * 0.5f);
		}
		if (myAction == "getOff" || myAction == "getOff2")
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.99f;
		}
		else if (groundTag == "Water" && myAction == "hover" && !inair)
		{
			GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * 0.995f;
			if (!(GetComponent<Rigidbody>().velocity.magnitude >= 10f))
			{
				ChangeMode("foot");
			}
		}
		if (halfpipeAir && halfPipePosition != Vector3.zero)
		{
			int num5 = 0;
			Vector3 velocity = GetComponent<Rigidbody>().velocity;
			float num6 = (velocity.x = num5);
			Vector3 vector6 = (GetComponent<Rigidbody>().velocity = velocity);
			int num7 = 0;
			Vector3 velocity2 = GetComponent<Rigidbody>().velocity;
			float num8 = (velocity2.z = num7);
			Vector3 vector8 = (GetComponent<Rigidbody>().velocity = velocity2);
		}
		modelTransform.position = transform.position + modelOffset;
		if (myAction == "grind")
		{
			float y = modelTransform.position.y - 3f;
			Vector3 position3 = modelTransform.position;
			float num9 = (position3.y = y);
			Vector3 vector10 = (modelTransform.position = position3);
		}
		CheckGround();
		if (!(GetComponent<Rigidbody>().velocity.magnitude <= 2f))
		{
			targetQuaternion = Quaternion.LookRotation(GetComponent<Rigidbody>().velocity, groundNormal);
			modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetQuaternion, Time.deltaTime * 5f);
			if (!(Mathf.Abs(GetComponent<Rigidbody>().velocity.y) >= Mathf.Abs(GetComponent<Rigidbody>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody>().velocity.z)))
			{
				forwardValid = GetComponent<Rigidbody>().velocity;
			}
		}
		else
		{
			targetQuaternion = Quaternion.LookRotation(forwardValid, groundNormal);
			modelTransform.rotation = Quaternion.Slerp(modelTransform.rotation, targetQuaternion, Time.deltaTime * 5f);
			modelTransform.Rotate(0f, inputVector.x * 250f * Time.deltaTime * 0.5f, 0f);
			forwardValid = Vector3.RotateTowards(forwardValid, modelTransform.forward, Time.deltaTime * 5f, 0f);
			GetComponent<Rigidbody>().velocity = new Vector3(0f, GetComponent<Rigidbody>().velocity.y, 0f);
		}
		lastModelRotation = modelTransform.rotation;
		if (inair)
		{
			inairCount += Time.deltaTime;
		}
		else
		{
			inairCount = 0f;
		}
		UpdateAnimation();
		if (resetY != 0f && !(transform.position.y > resetY))
		{
			ResetToSafePosition();
		}
		GetComponent<AudioSource>().pitch = Mathf.Clamp(0.5f + GetComponent<Rigidbody>().velocity.magnitude / 300f, 0.5f, 1f);
	}

	public virtual void MovePlayer(Transform targetTransform)
	{
		hoverCount = 0;
		transform.position = targetTransform.position;
		transform.rotation = targetTransform.rotation;
		modelTransform.position = targetTransform.position;
		modelTransform.rotation = targetTransform.rotation;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	public virtual void MovePlayerPosRot(Vector3 newPosition, Quaternion newRotation)
	{
		hoverCount = 0;
		transform.position = newPosition;
		modelTransform.position = newPosition;
		modelTransform.rotation = newRotation;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
	}

	public virtual bool NothingUnder()
	{
		bool result = true;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 2000f) && hit.transform.name.IndexOf("Lava") == -1 && hit.transform.name.IndexOf("Toxic") == -1)
		{
			underY = hit.point.y;
			result = false;
		}
		return result;
	}

	public virtual void FreezePositionZ()
	{
		freezePosZ = true;
	}

	public virtual void ForceZAxis(float forcePos)
	{
		string text = "Orig PosZ: " + transform.position.z + ", EulerY: " + modelTransform.eulerAngles.y + ", ";
		if (!(Mathf.Abs(transform.localPosition.x - forcePos) <= 0.1f))
		{
			Vector3 localPosition = transform.localPosition;
			float num = (localPosition.x = forcePos);
			Vector3 vector2 = (transform.localPosition = localPosition);
			Vector3 localPosition2 = modelTransform.localPosition;
			float num2 = (localPosition2.x = forcePos);
			Vector3 vector4 = (modelTransform.localPosition = localPosition2);
			int num3 = Mathf.FloorToInt(transform.eulerAngles.y / 90f) * 90;
			if (num3 != 270 && num3 != 90)
			{
				num3 = 270;
				int num4 = num3;
				Vector3 eulerAngles = transform.eulerAngles;
				float num5 = (eulerAngles.y = num4);
				Vector3 vector6 = (transform.eulerAngles = eulerAngles);
				int num6 = num3;
				Vector3 eulerAngles2 = modelTransform.eulerAngles;
				float num7 = (eulerAngles2.y = num6);
				Vector3 vector8 = (modelTransform.eulerAngles = eulerAngles2);
			}
		}
	}

	public virtual Vector3 BossPosition()
	{
		float num = -10000000f;
		Vector3 position = transform.position;
		float num2 = default(float);
		Vector3 result = position;
		BossControl[] array = ((BossControl[])UnityEngine.Object.FindObjectsOfType(typeof(BossControl))) as BossControl[];
		int i = 0;
		BossControl[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			num2 = array2[i].transform.position.x;
			if (!(num2 <= num))
			{
				num = num2;
				position = array2[i].transform.position;
			}
		}
		if (position != transform.position)
		{
			Vector3 vector = position;
			num = 1000000f;
			TurretControl[] array3 = ((TurretControl[])UnityEngine.Object.FindObjectsOfType(typeof(TurretControl))) as TurretControl[];
			int j = 0;
			TurretControl[] array4 = array3;
			for (int length2 = array4.Length; j < length2; j++)
			{
				num2 = array4[j].transform.position.x - vector.x;
				if (!(num2 <= 0f) && !(num2 >= num))
				{
					num = num2;
					position = array4[j].transform.position;
				}
			}
			result = position;
		}
		return result;
	}

	public virtual Vector3 RespawnPoint()
	{
		float num = -10000000f;
		Vector3 position = transform.position;
		float num2 = default(float);
		TriggerObject[] array = ((TriggerObject[])UnityEngine.Object.FindObjectsOfType(typeof(TriggerObject))) as TriggerObject[];
		int i = 0;
		TriggerObject[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			if (array2[i].transform.name == "RespawnPoint")
			{
				num2 = array2[i].transform.position.x;
				if (!(num2 <= num))
				{
					num = num2;
					position = array2[i].transform.position;
				}
			}
		}
		return position;
	}

	public virtual float SafeSaveHeight()
	{
		float result = default(float);
		float num = 1000000f;
		Vector3 vector = default(Vector3);
		float num2 = default(float);
		float num3 = default(float);
		DestroyTimer[] array = ((DestroyTimer[])UnityEngine.Object.FindObjectsOfType(typeof(DestroyTimer))) as DestroyTimer[];
		int i = 0;
		DestroyTimer[] array2 = array;
		for (int length = array2.Length; i < length; i++)
		{
			num2 = Mathf.Abs(transform.position.x - array2[i].transform.position.x);
			if (!(num2 >= num))
			{
				num = num2;
				vector = array2[i].transform.position;
				num3 = array2[i].transform.position.y;
			}
			num2 = Mathf.Abs(transform.position.x - array2[i].endPoint.x);
			if (!(num2 >= num))
			{
				num = num2;
				vector = array2[i].endPoint;
				if (!(vector.y >= num3))
				{
					vector.y = num3;
				}
			}
		}
		if (vector != Vector3.zero)
		{
			return vector.y;
		}
		return result;
	}

	public virtual void ResetToSafePosition()
	{
		if (freezePosZ)
		{
			ResetToSafePositionDiversion();
		}
		else
		{
			ResetToSafePositionOrig();
		}
	}

	public virtual void ResetToSafePositionDiversion()
	{
		MonoBehaviour.print("ResetToSafePositionDiversion");
		StopFlyingFox();
		hoverCount = 0;
		int num = 270;
		Vector3 eulerAngles = transform.eulerAngles;
		float num2 = (eulerAngles.y = num);
		Vector3 vector2 = (transform.eulerAngles = eulerAngles);
		int num3 = 0;
		Vector3 position = transform.position;
		float num4 = (position.z = num3);
		Vector3 vector4 = (transform.position = position);
		float y = SafeSaveHeight() + 30f;
		Vector3 position2 = transform.position;
		float num5 = (position2.y = y);
		Vector3 vector6 = (transform.position = position2);
		Vector3 vector7 = BossPosition();
		Vector3 vector8 = RespawnPoint();
		if (vector7 != transform.position && !(vector7.x <= transform.position.x))
		{
			transform.position = vector7 + new Vector3(20f, 10f, 0f);
			MonoBehaviour.print("There is a boss!");
		}
		else if (vector8 != transform.position)
		{
			transform.position = vector8 + new Vector3(20f, 10f, 0f);
			MonoBehaviour.print("There is a star/token!");
		}
		else if (NothingUnder())
		{
			transform.position += new Vector3(30f, 50f, 0f);
		}
		else
		{
			float y2 = underY + 10f;
			Vector3 position3 = transform.position;
			float num6 = (position3.y = y2);
			Vector3 vector10 = (transform.position = position3);
			transform.position += new Vector3(20f, 20f, 0f);
		}
		if (gameControl.goalPosition != Vector3.zero && !(transform.position.x >= gameControl.goalPosition.x))
		{
			transform.position = gameControl.goalPosition + new Vector3(10f, 20f, 0f);
			MonoBehaviour.print("Reset to the goal position!");
		}
		modelTransform.localRotation = Quaternion.identity;
		GetComponent<Rigidbody>().velocity = Vector3.zero;
		int num7 = -5;
		Vector3 velocity = GetComponent<Rigidbody>().velocity;
		float num8 = (velocity.y = num7);
		Vector3 vector12 = (GetComponent<Rigidbody>().velocity = velocity);
		shadowObject.GetComponent<Renderer>().enabled = true;
		if (mainPlayer)
		{
			Camera.main.transform.position = transform.position - modelTransform.forward * 30f;
		}
	}

	public virtual void ResetToSafePositionOrig()
	{
		MonoBehaviour.print("ResetToSafePositionOrig");
		StopFlyingFox();
		hoverCount = 0;
		replayID -= 50;
		if (replayID < 0)
		{
			replayID = maxReplayElements + replayID;
		}
		transform.position = lastPosition[replayID] + new Vector3(30f, 30f, 0f);
		transform.rotation = lastRotation[replayID];
		if (NothingUnder())
		{
			transform.position += new Vector3(30f, 50f, 0f);
			MonoBehaviour.print("Nothing under the respawn, so placing higher and back: " + transform.position.y);
		}
		modelTransform.position = transform.position + modelOffset;
		modelTransform.rotation = transform.rotation;
		GetComponent<Rigidbody>().velocity = modelTransform.forward;
		shadowObject.GetComponent<Renderer>().enabled = true;
		if (mainPlayer)
		{
			Camera.main.transform.position = transform.position - modelTransform.forward * 30f;
		}
	}

	public virtual void StoreReplay()
	{
		lastPosition[replayID] = transform.position;
		lastRotation[replayID] = modelTransform.rotation;
		replayID++;
		if (replayID >= maxReplayElements)
		{
			replayID = 0;
		}
	}

	public virtual void AdjustShadow(RaycastHit groundHit)
	{
		if (myAction.IndexOf("water") != -1)
		{
			shadowObject.SetActive(false);
			return;
		}
		shadowObject.SetActive(true);
		bool flag = false;
		if ((bool)boardModel && boardModel.enabled)
		{
			flag = true;
		}
		if (flag)
		{
			float x = shadowObject.transform.localScale.x + (1f - shadowObject.transform.localScale.x) * Time.deltaTime * 5f;
			Vector3 localScale = shadowObject.transform.localScale;
			float num = (localScale.x = x);
			Vector3 vector2 = (shadowObject.transform.localScale = localScale);
			float z = shadowObject.transform.localScale.z + (1f - shadowObject.transform.localScale.z) * Time.deltaTime * 5f;
			Vector3 localScale2 = shadowObject.transform.localScale;
			float num2 = (localScale2.z = z);
			Vector3 vector4 = (shadowObject.transform.localScale = localScale2);
			shadowObject.transform.position = groundHit.point + groundHit.normal * 1.5f;
			shadowObject.transform.rotation = Quaternion.LookRotation(modelTransform.forward, groundHit.normal);
		}
		else
		{
			float x2 = shadowObject.transform.localScale.x + (0.85f - shadowObject.transform.localScale.x) * Time.deltaTime * 5f;
			Vector3 localScale3 = shadowObject.transform.localScale;
			float num3 = (localScale3.x = x2);
			Vector3 vector6 = (shadowObject.transform.localScale = localScale3);
			float z2 = shadowObject.transform.localScale.z + (0.25f - shadowObject.transform.localScale.z) * Time.deltaTime * 5f;
			Vector3 localScale4 = shadowObject.transform.localScale;
			float num4 = (localScale4.z = z2);
			Vector3 vector8 = (shadowObject.transform.localScale = localScale4);
			shadowObject.transform.position = groundHit.point + groundHit.normal * 0.1f;
			shadowObject.transform.up = groundHit.normal;
		}
	}

	public virtual void CheckGroundFoot()
	{
		tempVector3 = Vector3.up;
		if (groundName == "Loop")
		{
			tempVector3 = modelTransform.up;
		}
		lastGroundTag = groundTag;
		startPos = transform.position + tempVector3 * 2f;
		if (myAction == "waterSwim")
		{
			startPos += modelTransform.forward * 3f;
		}
		if (Physics.Raycast(startPos, -tempVector3, out hit, 20f, layerMask) && !inHole)
		{
			groundDist = Vector3.Distance(transform.position, hit.point);
			if (groundTransform == hit.transform)
			{
				if (groundTransformPos != Vector3.zero)
				{
					groundVelocity = (hit.transform.position - groundTransformPos) / Time.deltaTime;
					if (!(groundVelocity.magnitude >= 3f))
					{
						groundVelocity = Vector3.zero;
					}
					if (groundVelocity != Vector3.zero && myAction.IndexOf("jump") == -1)
					{
						groundDist = 8.5f;
					}
				}
				groundTransformPos = hit.transform.position;
			}
			else
			{
				groundTransformPos = Vector3.zero;
				groundVelocity = Vector3.zero;
			}
			groundTransform = hit.transform;
			groundName = hit.transform.name;
			groundNormal = hit.normal;
			groundPosition = hit.point;
			if (myAction == "waterSwim")
			{
				groundPosition.x = transform.position.x;
				groundPosition.z = transform.position.z;
				groundPosition += modelTransform.forward * 1f;
			}
			groundTag = hit.transform.tag;
			if (groundTag == "Slide")
			{
				groundVelocity = Vector3.zero;
			}
			AdjustShadow(hit);
		}
		else
		{
			groundTransform = null;
			groundName = "none";
			groundNormal = new Vector3(0f, 1f, 0f);
			groundDist = 1000f;
			if (groundTag != "Water")
			{
				groundTag = "none";
			}
			groundVelocity = Vector3.zero;
			shadowObject.SetActive(false);
		}
		if (!(groundDist <= 8.5f) && !stop)
		{
			if (!(groundVelocity.y >= 0f) && !(groundDist >= 11f) && myAction.IndexOf("jump") == -1)
			{
				jumpTime = Time.time;
			}
			groundTag = "none";
		}
		else
		{
			jumpTime = Time.time;
		}
		if (myAction != "die" && groundName == "stop" && myAction.IndexOf("jump") == -1 && !stop)
		{
			stop = true;
			ChangeHorizontalPosition(groundTransform);
		}
	}

	public virtual void ChangeHorizontalPosition(Transform newTransform)
	{
		Vector3 position = newTransform.position;
		stopTransform = newTransform;
		position.y = transform.position.y;
		position.z = 0f;
		transform.position = position;
		GetComponent<Rigidbody>().MovePosition(position);
		modelTransform.position = transform.position + modelOffset;
		groundStopTransform = groundTransform;
	}

	public virtual void CheckGround()
	{
		tempVector3 = Vector3.up;
		if (groundName == "Loop")
		{
			tempVector3 = modelTransform.up;
		}
		startPos = modelTransform.position + tempVector3 * 2f;
		lastGroundTag = groundTag;
		if (Physics.Raycast(startPos, -tempVector3, out hit, 200f, layerMask))
		{
			AdjustShadow(hit);
			groundName = hit.transform.name;
			groundDist = Vector3.Distance(transform.position, hit.point);
			groundNormal = hit.normal;
			groundTag = hit.transform.tag;
			if (hit.transform.tag == "Grind" && !(groundDist > 20f))
			{
				if (!(Vector3.Angle(GetComponent<Rigidbody>().velocity, hit.transform.forward) >= 90f))
				{
					GetComponent<Rigidbody>().velocity = hit.transform.forward.normalized * Mathf.Max(GetComponent<Rigidbody>().velocity.magnitude, 150f);
				}
				else
				{
					GetComponent<Rigidbody>().velocity = -hit.transform.forward.normalized * Mathf.Max(GetComponent<Rigidbody>().velocity.magnitude, 150f);
				}
				myAction = "grind";
				ChangeAnimation("grind", 0.25f);
			}
			else if (myAction == "grind")
			{
				myAction = "hover";
			}
			hasScreamed = false;
		}
		else
		{
			groundName = "none";
			groundNormal = new Vector3(0f, 0f, 0f);
			groundDist = 1000f;
		}
	}

	public virtual void MoveToHanger()
	{
		if (!(myMode != "hang") && (bool)hangObject)
		{
			hangTargetPosition = PointOnLine(hangObject.transform.forward, hangObject.transform.position, transform.position);
			hangTargetPosition -= hangObject.transform.right * 1.7f;
			hangTargetPosition -= hangObject.transform.up * 6f;
			hangTargetRotation.SetLookRotation(hangObject.transform.right, Vector3.up);
		}
	}

	public virtual void StartFlyingFox()
	{
		if (!(myAction == "die"))
		{
			hoverCount = 0;
			GetComponent<Rigidbody>().useGravity = false;
			hangTargetPosition = PointOnLine(hangObject.transform.forward, hangObject.transform.position, transform.position);
			float num = Vector3.Distance(hangObject.transform.position, hangTargetPosition);
			hangTargetPosition = hangObject.transform.position + num * hangObject.transform.forward;
			hangTargetPosition -= hangObject.transform.up * 7f;
			hangTargetRotation = hangObject.transform.rotation;
			transform.position = hangTargetPosition;
			transform.rotation = hangTargetRotation;
			GetComponent<Rigidbody>().position = transform.position;
			GetComponent<Rigidbody>().rotation = transform.rotation;
			modelTransform.position = transform.position + modelOffset;
			modelTransform.rotation = transform.rotation;
			myAction = "flyingfox";
			ChangeAnimation("hangFox", 0.25f);
			PlayLoopSound("zipline");
		}
	}

	public virtual void StopFlyingFox()
	{
		GetComponent<Rigidbody>().useGravity = true;
		transform.up = Vector3.up;
		hoverCount = 0;
		hangObject = null;
		myAction = "jump";
		if (loopSoundName == "zipline")
		{
			GetComponent<AudioSource>().Stop();
		}
		PlaySound("climb");
		jumpPressed = true;
		jumpTime = Time.time - 0.1f;
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (myAction == "die")
		{
			return;
		}
		switch (triggerObject.tag)
		{
		case "Hang":
			if (myMode == "foot")
			{
				if (hangObject != triggerObject.gameObject)
				{
					hangObject = triggerObject.gameObject;
					climbDelta = transform.position.y - hangObject.transform.position.y;
					ChangeMode("hang");
				}
			}
			else if (myMode == "hang" && hangObject != triggerObject.gameObject)
			{
				hoverCount = 0;
				hangObject = triggerObject.gameObject;
				climbDelta = -10f;
				MoveToHanger();
			}
			break;
		case "FlyingFox":
			if (hangObject != triggerObject.gameObject)
			{
				hangObject = triggerObject.gameObject;
				StartFlyingFox();
			}
			break;
		case "Egg":
			PlaySound("collectEgg");
			triggerObject.SendMessage("Collect", SendMessageOptions.DontRequireReceiver);
			break;
		case "Fightring":
			if (mainPlayer)
			{
				if (myMode == "foot")
				{
					ChangeMode("fight");
				}
				else if (myMode != "fight")
				{
					gameControl.ShowHint("Need to be on foot to fight");
					Debug.Log("Need to be on foot to fight");
				}
			}
			break;
		case "Dancefloor":
			if (mainPlayer)
			{
				if (myMode == "foot")
				{
					ChangeMode("dance");
				}
				else if (myMode != "dance")
				{
					gameControl.ShowHint("Need to be on foot to dance");
					Debug.Log("Need to be on foot to dance");
				}
			}
			break;
		case "Warp":
			if (mainPlayer)
			{
				triggerObject.SendMessage("PlayerEnter", SendMessageOptions.DontRequireReceiver);
			}
			break;
		default:
			triggerObject.SendMessage("Activate", SendMessageOptions.DontRequireReceiver);
			break;
		}
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if (myAction == "die")
		{
			return;
		}
		switch (triggerObject.tag)
		{
		case "Hang":
			if (hangObject == triggerObject.gameObject)
			{
				hangObject = null;
				if (myMode == "hang")
				{
					ChangeMode("foot");
				}
			}
			break;
		case "FlyingFox":
			if (hangObject == triggerObject.gameObject)
			{
				StopFlyingFox();
			}
			break;
		case "Warp":
			if (mainPlayer)
			{
				gameControl.HideHint();
			}
			break;
		case "Button":
			if (mainPlayer)
			{
				gameControl.HideHint();
			}
			break;
		}
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		inair = false;
		if (myAction == "hover" && groundName != "halfpipe")
		{
			ContactPoint contactPoint = collision.contacts[0];
			if (!(contactPoint.normal.y >= 0.5f) && !(collision.relativeVelocity.magnitude <= 40f))
			{
				ChangeAnimation("offBalanceLoop", 0.35f);
			}
		}
		if (!mainPlayer)
		{
			hitCounter = 0;
		}
	}

	public virtual void OnCollisionExit()
	{
		inair = true;
	}

	public virtual void OnCollisionStay()
	{
		inair = false;
	}

	public virtual void Main()
	{
	}
}
