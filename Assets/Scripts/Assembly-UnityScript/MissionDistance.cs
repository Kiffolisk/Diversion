using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MissionDistance : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024InitializeLevel_0024611 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal string[] _0024tempArray_0024612;

			internal GameObject _0024skyBoxObject_0024613;

			internal GameObject _0024lightObject_0024614;

			internal BlackoutControl _0024atlasControl_0024615;

			internal string _0024tempString_0024616;

			internal UnityScript.Lang.Array _0024platformStarListJS_0024617;

			internal int _0024i_0024618;

			internal MissionDistance _0024self__0024619;

			public _0024(MissionDistance self_)
			{
				_0024self__0024619 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024619.testLevel != string.Empty)
					{
						_0024tempArray_0024612 = _0024self__0024619.testLevel.Split(char.Parse("-"));
						if (Extensions.get_length((System.Array)_0024tempArray_0024612) == 2)
						{
							_0024self__0024619.gameControl.worldID = UnityBuiltins.parseInt(_0024tempArray_0024612[0]);
							_0024self__0024619.gameControl.missionLevel = UnityBuiltins.parseInt(_0024tempArray_0024612[1]);
						}
						else
						{
							MonoBehaviour.print("To test a world-level, make sure the format is worldID-levelID");
						}
					}
					_0024self__0024619.ReadMissionData();
					_0024self__0024619.level = _0024self__0024619.gameControl.missionLevel;
					_0024self__0024619.goalMade = false;
					_0024self__0024619.StartCoroutine(_0024self__0024619.gameControl.PauseGame(false));
					result = (Yield(2, new WaitForSeconds(0.02f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024619.gameControl.InitMission();
					_0024self__0024619.gameControl.playerControl.FreezePositionZ();
					_0024tempArray_0024612 = (string[])_0024self__0024619.gameControl.defaultAssetArray.ToBuiltin(typeof(string));
					if (_0024self__0024619.levelSky[_0024self__0024619.level - 1] == "Sky")
					{
						_0024self__0024619.levelSky[_0024self__0024619.level - 1] = _0024tempArray_0024612[1];
					}
					if (_0024self__0024619.levelLight[_0024self__0024619.level - 1] == "Light")
					{
						_0024self__0024619.levelLight[_0024self__0024619.level - 1] = _0024tempArray_0024612[2];
					}
					if (_0024self__0024619.levelAtlas[_0024self__0024619.level - 1] == "Atlas")
					{
						_0024self__0024619.levelAtlas[_0024self__0024619.level - 1] = _0024tempArray_0024612[3];
					}
					if (_0024self__0024619.levelColor[_0024self__0024619.level - 1] == "AtlasColor")
					{
						_0024self__0024619.levelColor[_0024self__0024619.level - 1] = _0024tempArray_0024612[4];
					}
					_0024skyBoxObject_0024613 = GameObject.FindWithTag("Sky");
					if ((bool)_0024skyBoxObject_0024613)
					{
						if (!(_0024skyBoxObject_0024613.name == _0024self__0024619.levelSky[_0024self__0024619.level - 1]))
						{
							UnityEngine.Object.Destroy(_0024skyBoxObject_0024613);
							_0024self__0024619.lastTransform = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Sky/" + _0024self__0024619.levelSky[_0024self__0024619.level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
							_0024self__0024619.lastTransform.name = _0024self__0024619.levelSky[_0024self__0024619.level - 1];
						}
					}
					else
					{
						_0024self__0024619.lastTransform = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Sky/" + _0024self__0024619.levelSky[_0024self__0024619.level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
						_0024self__0024619.lastTransform.name = _0024self__0024619.levelSky[_0024self__0024619.level - 1];
					}
					_0024lightObject_0024614 = GameObject.FindWithTag("Light");
					if ((bool)_0024lightObject_0024614)
					{
						if (!(_0024lightObject_0024614.name == _0024self__0024619.levelLight[_0024self__0024619.level - 1]))
						{
							UnityEngine.Object.Destroy(_0024lightObject_0024614);
							_0024self__0024619.lastTransform = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Lights/" + _0024self__0024619.levelLight[_0024self__0024619.level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
							_0024self__0024619.lastTransform.name = _0024self__0024619.levelLight[_0024self__0024619.level - 1];
						}
					}
					else
					{
						_0024self__0024619.lastTransform = (GameObject)UnityEngine.Object.Instantiate(Resources.Load("Lights/" + _0024self__0024619.levelLight[_0024self__0024619.level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
						_0024self__0024619.lastTransform.name = _0024self__0024619.levelLight[_0024self__0024619.level - 1];
					}
					_0024atlasControl_0024615 = (BlackoutControl)UnityEngine.Object.FindObjectOfType(typeof(BlackoutControl));
					if ((bool)_0024atlasControl_0024615)
					{
						_0024atlasControl_0024615.ChangeTexture((Texture2D)Resources.Load("Atlas/" + _0024self__0024619.levelAtlas[_0024self__0024619.level - 1]));
						_0024atlasControl_0024615.ChangeColor(_0024self__0024619.levelColor[_0024self__0024619.level - 1]);
					}
					if (_0024self__0024619.levelMusic[_0024self__0024619.level - 1] == "Music")
					{
						_0024self__0024619.gameControl.PlayMusic((AudioClip)Resources.Load(_0024self__0024619.gameControl.appName + "/Music"));
					}
					else
					{
						_0024self__0024619.gameControl.PlayMusic((AudioClip)Resources.Load("Music/" + _0024self__0024619.levelMusic[_0024self__0024619.level - 1]));
					}
					_0024self__0024619.gameControl.doubleOutfit = _0024self__0024619.levelOutfit[_0024self__0024619.level - 1];
					_0024self__0024619.difficulty = 0.6f;
					if (_0024self__0024619.levelDifficulty[_0024self__0024619.level - 1] == "medium")
					{
						_0024self__0024619.difficulty = 0.75f;
					}
					else if (_0024self__0024619.levelDifficulty[_0024self__0024619.level - 1] == "hard")
					{
						_0024self__0024619.difficulty = 1f;
					}
					_0024self__0024619.gameControl.playerControl.GetComponent<Rigidbody>().constraints = _0024self__0024619.gameControl.playerControl.GetComponent<Rigidbody>().constraints | RigidbodyConstraints.FreezePositionZ;
					_0024self__0024619.missionCount = _0024self__0024619.gameControl.missionCount;
					_0024self__0024619.missionOver = false;
					_0024self__0024619.myDist = 0;
					_0024self__0024619.gemDist = 0f;
					_0024self__0024619.bombDist = 2000f;
					_0024self__0024619.shownOutfitHint = false;
					_0024self__0024619.shownTopScoreHint = false;
					_0024self__0024619.platformCount = 0;
					_0024self__0024619.platformGap = "normal";
					_0024self__0024619.platformDuration = 10;
					_0024self__0024619.endMusicPlaying = false;
					_0024tempString_0024616 = string.Empty;
					_0024tempString_0024616 = _0024self__0024619.levelPlatforms[_0024self__0024619.level - 1];
					if (_0024self__0024619.level <= Extensions.get_length((System.Array)_0024self__0024619.levelGaps))
					{
						_0024self__0024619.platformGap = _0024self__0024619.levelGaps[_0024self__0024619.level - 1];
					}
					if (_0024self__0024619.level <= Extensions.get_length((System.Array)_0024self__0024619.levelDuration))
					{
						_0024self__0024619.platformDuration = _0024self__0024619.levelDuration[_0024self__0024619.level - 1];
					}
					_0024self__0024619.platformList = _0024tempString_0024616.Split(","[0]);
					if (_0024self__0024619.levelOrdered[_0024self__0024619.level - 1].IndexOf("unordered") != -1)
					{
						_0024self__0024619.platformsOrdered = false;
					}
					else
					{
						_0024self__0024619.platformsOrdered = true;
						_0024self__0024619.platformDuration = Extensions.get_length((System.Array)_0024self__0024619.platformList);
					}
					if (_0024self__0024619.levelOrdered[_0024self__0024619.level - 1].IndexOf("showlast") != -1)
					{
						_0024self__0024619.showLastPlatform = true;
					}
					else
					{
						_0024self__0024619.showLastPlatform = false;
					}
					_0024self__0024619.MakeRandomPlatformList();
					_0024platformStarListJS_0024617 = new UnityScript.Lang.Array();
					if (_0024self__0024619.showLastPlatform)
					{
						for (_0024i_0024618 = 1; _0024i_0024618 < _0024self__0024619.platformDuration; _0024i_0024618++)
						{
							_0024platformStarListJS_0024617.Push(_0024i_0024618);
						}
						for (_0024i_0024618 = 3; _0024i_0024618 < _0024self__0024619.platformDuration; _0024i_0024618++)
						{
							_0024platformStarListJS_0024617.RemoveAt(UnityEngine.Random.Range(0, _0024platformStarListJS_0024617.length));
						}
						_0024platformStarListJS_0024617.Push(_0024self__0024619.platformDuration);
						_0024self__0024619.platformCharacter = UnityEngine.Random.Range(2, _0024self__0024619.platformDuration);
					}
					else if (_0024self__0024619.platformDuration == 0)
					{
						_0024self__0024619.platformCharacter = -1;
					}
					else if (_0024self__0024619.platformDuration <= 3)
					{
						for (_0024i_0024618 = 1; _0024i_0024618 <= _0024self__0024619.platformDuration; _0024i_0024618++)
						{
							_0024platformStarListJS_0024617.Push(_0024i_0024618);
						}
						_0024self__0024619.platformCharacter = 1;
					}
					else
					{
						for (_0024i_0024618 = 2; _0024i_0024618 <= _0024self__0024619.platformDuration; _0024i_0024618++)
						{
							_0024platformStarListJS_0024617.Push(_0024i_0024618);
						}
						for (_0024i_0024618 = 4; _0024i_0024618 < _0024self__0024619.platformDuration; _0024i_0024618++)
						{
							_0024platformStarListJS_0024617.RemoveAt(UnityEngine.Random.Range(0, _0024platformStarListJS_0024617.length));
						}
						_0024self__0024619.platformCharacter = UnityEngine.Random.Range(2, _0024self__0024619.platformDuration);
					}
					_0024self__0024619.platformStarList = (int[])_0024platformStarListJS_0024617.ToBuiltin(typeof(int));
					_0024self__0024619.lastTransform = (GameObject)UnityEngine.Object.Instantiate(_0024self__0024619.GetPlatform("platformStart"), new Vector3(0f, 0f, 0f), Quaternion.identity);
					_0024self__0024619.lastTransform.transform.parent = _0024self__0024619.transform;
					if (_0024self__0024619.platformGap == "higher")
					{
						_0024self__0024619.nextPosition = Vector3.zero + new Vector3(-215f, 10f, 0f);
					}
					else
					{
						_0024self__0024619.nextPosition = Vector3.zero + new Vector3(-215f, -10f, 0f);
					}
					_0024self__0024619.Spawn();
					_0024self__0024619.gameControl.missionStarted = true;
					if (_0024self__0024619.platformDuration == 0)
					{
						_0024self__0024619.preloadPlatforms = false;
					}
					else if (_0024self__0024619.platformDuration == 1)
					{
						_0024self__0024619.preloadPlatforms = true;
						_0024self__0024619.Spawn();
						_0024self__0024619.Spawn();
					}
					else
					{
						_0024self__0024619.preloadPlatforms = true;
						_0024self__0024619.Spawn();
						while (_0024self__0024619.platformCount <= _0024self__0024619.platformDuration)
						{
							_0024self__0024619.Spawn();
						}
					}
					if (_0024self__0024619.platformDuration == 0)
					{
						_0024self__0024619.gameControl.missionEndless = true;
					}
					else
					{
						_0024self__0024619.gameControl.missionEndless = false;
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

		internal MissionDistance _0024self__0024620;

		public _0024InitializeLevel_0024611(MissionDistance self_)
		{
			_0024self__0024620 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024620);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024EndMission_0024621 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal GameObject _0024tempGarbot_0024622;

			internal MissionDistance _0024self__0024623;

			public _0024(MissionDistance self_)
			{
				_0024self__0024623 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024623.missionOver = true;
					if (_0024self__0024623.platformDuration == 0)
					{
						_0024self__0024623.gameControl.missionWin = true;
					}
					_0024self__0024623.nextPosition = _0024self__0024623.gameControl.playerControl.transform.position + new Vector3(0f, -30f, 0f);
					_0024self__0024623.lastTransform = (GameObject)UnityEngine.Object.Instantiate(_0024self__0024623.GetPlatform("platformEnd"), _0024self__0024623.nextPosition, _0024self__0024623.gameControl.playerControl.transform.rotation);
					_0024self__0024623.lastTransform.transform.parent = _0024self__0024623.transform;
					result = (Yield(2, new WaitForSeconds(0.2f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024623.StartCoroutine(_0024self__0024623.gameControl.EndMission("missionEnd"));
					if (!_0024self__0024623.gameControl.garbot)
					{
						_0024tempGarbot_0024622 = GameObject.Find("Garbot1");
						if ((bool)_0024tempGarbot_0024622)
						{
							UnityEngine.Object.Destroy(_0024tempGarbot_0024622);
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

		internal MissionDistance _0024self__0024624;

		public _0024EndMission_0024621(MissionDistance self_)
		{
			_0024self__0024624 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024624);
		}
	}

	private int[] targetGemsPerLevel;

	private string[] levelPlatforms;

	private int[] levelDuration;

	private string[] levelOrdered;

	private string[] levelGaps;

	private string[] levelOutfit;

	private string[] levelSky;

	private string[] levelLight;

	private string[] levelAtlas;

	private string[] levelColor;

	private string[] levelMusic;

	private string[] levelDifficulty;

	public int testPlatform;

	public string testLevel;

	public bool preloadPlatforms;

	private GameControl gameControl;

	private Vector3 startPos;

	private int myDist;

	private float distanceBetween;

	private Vector3 nextPosition;

	private GameObject lastTransform;

	private float difficulty;

	private float maximumHeight;

	private float maximumLength;

	private float lengthRandom;

	private float heightRandom;

	private float myM;

	private int layerMask;

	private float gemDist;

	private float bombDist;

	private int missionCount;

	private bool missionOver;

	private bool shownOutfitHint;

	private bool shownTopScoreHint;

	private int platformStartID;

	private int platformEndID;

	private int platformCount;

	private string[] platformList;

	private int level;

	private string platformGap;

	private int platformDuration;

	private int[] platformStarList;

	private float spawnTime;

	private UnityScript.Lang.Array platformRandomList;

	private bool platformsOrdered;

	private bool endMusicPlaying;

	private int platformCharacter;

	private float fallTime;

	private bool showLastPlatform;

	private bool goalMade;

	public MissionDistance()
	{
		testLevel = string.Empty;
		preloadPlatforms = true;
		startPos = Vector3.zero;
		distanceBetween = 50f;
		nextPosition = Vector3.zero;
		maximumHeight = 15f;
		maximumLength = 45f;
		bombDist = 2000f;
		platformStartID = 1;
		platformEndID = 2;
		platformGap = "normal";
		platformDuration = 10;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if (!gameControl)
		{
			UnityEngine.Object.Destroy(gameObject);
			return;
		}
		ReadMissionData();
		gameControl.gameMenu = "hint";
		gameControl.cameraType = "sidescroll";
		gameControl.missionCount = 0;
		gameControl.isMiniGame = false;
		level = gameControl.missionLevel;
		myM = (0f - maximumLength * 0.25f) / maximumHeight;
		layerMask = 4;
		layerMask = ~layerMask;
		StartCoroutine(InitializeLevel());
	}

	public virtual void ReadMissionData()
	{
		TextAsset textAsset = null;
		string text = null;
		UnityScript.Lang.Array array = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array2 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array3 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array4 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array5 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array6 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array7 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array8 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array9 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array10 = new UnityScript.Lang.Array();
		UnityScript.Lang.Array array11 = new UnityScript.Lang.Array();
		textAsset = (TextAsset)Resources.Load(gameControl.appName + "/World" + gameControl.worldID, typeof(TextAsset));
		text = textAsset.text;
		string[] array12 = text.Split(char.Parse("\n"));
		int i = 0;
		string[] array13 = array12;
		for (int length = array13.Length; i < length; i++)
		{
			string[] array14 = array13[i].Split(char.Parse("|"));
			text = array14[0];
			array5.Add(text);
			text = array14[1];
			array6.Add(text);
			text = array14[2];
			array7.Add(text);
			text = array14[3];
			array8.Add(text);
			text = array14[4];
			array9.Add(text);
			text = array14[5];
			array10.Add(text);
			text = array14[6];
			array11.Add(text);
			text = array14[7];
			array.Add(UnityBuiltins.parseInt(text));
			text = array14[8];
			array2.Add(text);
			text = array14[9];
			array3.Add(text);
			text = array14[10];
			array4.Add(text);
		}
		levelOutfit = (string[])array5.ToBuiltin(typeof(string));
		levelSky = (string[])array6.ToBuiltin(typeof(string));
		levelLight = (string[])array7.ToBuiltin(typeof(string));
		levelAtlas = (string[])array8.ToBuiltin(typeof(string));
		levelColor = (string[])array9.ToBuiltin(typeof(string));
		levelMusic = (string[])array10.ToBuiltin(typeof(string));
		levelDifficulty = (string[])array11.ToBuiltin(typeof(string));
		levelDuration = (int[])array.ToBuiltin(typeof(int));
		levelOrdered = (string[])array2.ToBuiltin(typeof(string));
		levelGaps = (string[])array3.ToBuiltin(typeof(string));
		levelPlatforms = (string[])array4.ToBuiltin(typeof(string));
	}

	public virtual IEnumerator InitializeLevel()
	{
		return new _0024InitializeLevel_0024611(this).GetEnumerator();
	}

	public virtual void MakeRandomPlatformList()
	{
		platformRandomList = new UnityScript.Lang.Array((IEnumerable)platformList);
		if (showLastPlatform)
		{
			platformRandomList.Pop();
		}
	}

	public virtual GameObject GetPlatform(string platformName)
	{
		return (GameObject)Resources.Load("Platforms/" + platformName, typeof(GameObject));
	}

	public virtual bool NothingUnder()
	{
		bool result = true;
		if (Physics.Raycast(gameControl.playerControl.transform.position, -Vector3.up, 2000f))
		{
			result = false;
		}
		return result;
	}

	public virtual void LateUpdate()
	{
		if (!missionOver && !gameControl.missionOver && (gameControl.playerControl.myAction == "run" || gameControl.playerControl.myAction == "stand"))
		{
			gameControl.playerControl.ForceZAxis(0f);
		}
	}

	public virtual void Update()
	{
		if (!missionOver && !gameControl.missionOver)
		{
			float num = Vector3.Distance(gameControl.playerControl.transform.position, nextPosition);
			if (gameControl.missionStarted)
			{
				myDist = (int)Mathf.Round((startPos.x - gameControl.playerControl.transform.position.x) * 0.5f);
				if (!preloadPlatforms && !(num >= 600f) && !(Time.time - spawnTime <= 0.2f))
				{
					Spawn();
				}
			}
			UpdateInput();
			if (gameControl.playerControl.myAction == "jumpDown")
			{
				if (!(Time.time - fallTime <= 2.5f))
				{
					if (NothingUnder())
					{
						StartCoroutine(gameControl.ShowSaveMe(0f));
					}
					else
					{
						fallTime = Time.time;
					}
				}
			}
			else
			{
				fallTime = Time.time;
			}
			if (gameControl.missionAborted)
			{
				StartCoroutine(EndMission());
			}
			return;
		}
		gameControl.touchButton[0] = false;
		gameControl.inputVector = Vector3.zero;
		if (endMusicPlaying)
		{
			return;
		}
		endMusicPlaying = true;
		if (gameControl.missionWin)
		{
			if (gameControl.missionEndless)
			{
				gameControl.PlaySound((AudioClip)Resources.Load("Music/MusicIntermission"));
			}
			else
			{
				gameControl.PlayMusic((AudioClip)Resources.Load("Music/MusicWin"));
			}
		}
		else
		{
			gameControl.StopMusic();
		}
		gameObject.BroadcastMessage("RemoveObject", SendMessageOptions.DontRequireReceiver);
	}

	public virtual IEnumerator EndMission()
	{
		return new _0024EndMission_0024621(this).GetEnumerator();
	}

	public virtual void Spawn()
	{
		if (goalMade)
		{
			return;
		}
		spawnTime = Time.time;
		string text = null;
		lengthRandom = 15f;
		heightRandom = -10f;
		if (platformGap == "higher")
		{
			lengthRandom = 15f;
			heightRandom = 10f;
		}
		if (!gameControl.missionStarted)
		{
			text = "platform" + UnityEngine.Random.Range(1, 3);
		}
		else
		{
			difficulty = Mathf.Clamp(difficulty + 0.03f, 0.25f, 1f);
			if (platformGap == "lower")
			{
				heightRandom = (float)UnityEngine.Random.Range(-5, 1) * Mathf.Round(maximumHeight / 3f);
			}
			else if (platformGap == "higher")
			{
				heightRandom = (float)UnityEngine.Random.Range(1, 6) * Mathf.Round(maximumHeight / 3f);
			}
			else
			{
				heightRandom = (float)UnityEngine.Random.Range(-5, 6) * Mathf.Round(maximumHeight / 3f);
			}
			if (!(heightRandom <= 0f))
			{
				lengthRandom = myM * heightRandom + maximumLength * 0.2f;
				lengthRandom += maximumLength * 0.7f;
			}
			else
			{
				lengthRandom = maximumLength + heightRandom * myM * 0.25f;
			}
			lengthRandom = UnityEngine.Random.Range(lengthRandom * difficulty * 0.75f, lengthRandom * difficulty);
			platformCount++;
			gameControl.showStar = false;
			int i = 0;
			int[] array = platformStarList;
			for (int length = array.Length; i < length; i++)
			{
				if (platformCount == array[i])
				{
					gameControl.showStar = true;
				}
			}
			if (gameControl.milestoneReached && gameControl.missionEndless)
			{
				text = "platformCheckpoint";
				goalMade = true;
			}
			else if (platformCount > platformDuration && platformDuration != 0)
			{
				text = "platformGoal";
				goalMade = true;
			}
			else if (testPlatform != 0)
			{
				text = "platform" + testPlatform;
			}
			else if (showLastPlatform && platformDuration == platformCount)
			{
				text = "platform" + platformList[Extensions.get_length((System.Array)platformList) - 1];
			}
			else if (platformsOrdered)
			{
				text = "platform" + platformList[platformCount - 1];
			}
			else
			{
				if (platformRandomList.length <= 0)
				{
					MakeRandomPlatformList();
				}
				int index = UnityEngine.Random.Range(0, platformRandomList.length);
				object obj = platformRandomList[index];
				if (!(obj is string))
				{
					obj = RuntimeServices.Coerce(obj, typeof(string));
				}
				string rhs = (string)obj;
				platformRandomList.RemoveAt(index);
				if (platformDuration == 0 && platformCount % 5 == 0)
				{
					rhs = platformList[UnityEngine.Random.Range(0, 5)];
				}
				text = "platform" + rhs;
			}
		}
		GameObject platform = GetPlatform(text);
		if ((bool)platform)
		{
			lastTransform = (GameObject)UnityEngine.Object.Instantiate(platform, nextPosition, Quaternion.identity);
			lastTransform.transform.parent = this.transform;
		}
		else
		{
			MonoBehaviour.print("WARNING: Could not find prefab: " + text);
		}
		Vector3 vector = default(Vector3);
		Transform transform = lastTransform.transform.Find("EndPoint");
		if ((bool)transform)
		{
			vector = transform.position;
			nextPosition = transform.position + new Vector3(0f - lengthRandom, heightRandom, 0f);
			return;
		}
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 origin = nextPosition + new Vector3(-199f, 200f, 0f);
		if (Physics.Raycast(origin, -Vector3.up, out hitInfo, 500f))
		{
			nextPosition.y = hitInfo.point.y;
			vector = hitInfo.point;
			nextPosition += new Vector3(-200f - lengthRandom, heightRandom, 0f);
		}
		else
		{
			MonoBehaviour.print("Height adjustment for next platform unknown - check " + text + " length is 200!!!");
		}
	}

	public virtual void UpdateInput()
	{
		RaycastHit hitInfo = default(RaycastHit);
		Vector3 origin = gameControl.playerControl.transform.position + new Vector3(0f, -3f, 0f);
		Vector3 forward = gameControl.playerControl.transform.forward;
		if (Physics.Raycast(origin, forward, out hitInfo, 5f, layerMask))
		{
			gameControl.inputVector.y = 0f;
		}
		else
		{
			gameControl.inputVector.y = 1f;
		}
		if (gameControl.playerControl.myMode == "hang")
		{
			gameControl.inputVector.y = 1f;
		}
		if (gameControl.playerControl.health <= 0)
		{
			gameControl.inputVector.y = 1f;
		}
		if (gameControl.disableInput)
		{
			gameControl.touchButton[0] = false;
			gameControl.inputVector.y = 1f;
			return;
		}
		if (Input.GetMouseButton(0) || Input.touchCount > 0)
		{
			if (!(Input.mousePosition.x <= 40f) && !(Input.mousePosition.y >= (float)(Screen.height - 40)))
			{
				gameControl.touchButton[0] = true;
			}
			else
			{
				gameControl.touchButton[0] = false;
			}
		}
		else
		{
			gameControl.touchButton[0] = false;
		}
		if (eInput.rightPadDown)
		{
			gameControl.touchButton[0] = true;
		}
		if (!gameControl.missionStarted && gameControl.touchButton[0])
		{
			gameControl.missionStarted = true;
			startPos = gameControl.playerControl.transform.position;
		}
		if (gameControl.cheatsOn && (Input.GetKey("w") || eInput.rightPadUp) && !gameControl.missionWin)
		{
			gameControl.CheatWin();
		}
	}

	public virtual void Main()
	{
	}
}
