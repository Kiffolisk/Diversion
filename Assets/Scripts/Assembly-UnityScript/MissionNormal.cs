using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using Boo.Lang.Runtime;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class MissionNormal : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024625 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal PlayerInput _0024playerInput_0024626;

			internal MissionNormal _0024self__0024627;

			public _0024(MissionNormal self_)
			{
				_0024self__0024627 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024627.disableModeChange)
					{
						_0024playerInput_0024626 = (PlayerInput)UnityEngine.Object.FindObjectOfType(typeof(PlayerInput));
						if ((bool)_0024playerInput_0024626)
						{
							_0024playerInput_0024626.DisableMode();
						}
					}
					_0024self__0024627.gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
					_0024self__0024627.gameControl.missionStarted = true;
					_0024self__0024627.gameControl.InitMission();
					_0024self__0024627.gameControl.missionStarted = true;
					_0024self__0024627.gameControl.isMiniGame = true;
					_0024self__0024627.level = _0024self__0024627.gameControl.missionLevel;
					_0024self__0024627.ReadMissionData();
					_0024self__0024627.AdjustAssets();
					if (_0024self__0024627.forceMode != string.Empty)
					{
						result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
						break;
					}
					goto IL_013a;
				case 2:
					_0024self__0024627.gameControl.ChangeMode(_0024self__0024627.forceMode);
					goto IL_013a;
				case 1:
					{
						result = 0;
						break;
					}
					IL_013a:
					if (_0024self__0024627.forceControls != string.Empty)
					{
						_0024self__0024627.gameControl.ChangeControl(_0024self__0024627.forceControls);
					}
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal MissionNormal _0024self__0024628;

		public _0024Start_0024625(MissionNormal self_)
		{
			_0024self__0024628 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024628);
		}
	}

	public bool disableModeChange;

	public string forceMode;

	public string forceControls;

	public float autoAccelerate;

	public string forceAtlas;

	private string[] levelOutfit;

	private string[] levelSky;

	private string[] levelLight;

	private string[] levelAtlas;

	private string[] levelColor;

	private string[] levelMusic;

	private string[] levelDifficulty;

	private int level;

	private float difficulty;

	private GameControl gameControl;

	public MissionNormal()
	{
		forceMode = string.Empty;
		forceControls = string.Empty;
		forceAtlas = "AtlasDefault";
		difficulty = 0.5f;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_0024625(this).GetEnumerator();
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
		}
		levelOutfit = (string[])array5.ToBuiltin(typeof(string));
		levelSky = (string[])array6.ToBuiltin(typeof(string));
		levelLight = (string[])array7.ToBuiltin(typeof(string));
		levelAtlas = (string[])array8.ToBuiltin(typeof(string));
		levelColor = (string[])array9.ToBuiltin(typeof(string));
		levelMusic = (string[])array10.ToBuiltin(typeof(string));
	}

	public virtual void AdjustAssets()
	{
		UnityScript.Lang.Array defaultAssetArray = gameControl.defaultAssetArray;
		if (levelSky[level - 1] == "Sky")
		{
			string[] array = levelSky;
			int num = level - 1;
			object obj = defaultAssetArray[1];
			if (!(obj is string))
			{
				obj = RuntimeServices.Coerce(obj, typeof(string));
			}
			array[num] = (string)obj;
		}
		if (levelLight[level - 1] == "Light")
		{
			string[] array2 = levelLight;
			int num2 = level - 1;
			object obj2 = defaultAssetArray[2];
			if (!(obj2 is string))
			{
				obj2 = RuntimeServices.Coerce(obj2, typeof(string));
			}
			array2[num2] = (string)obj2;
		}
		if (levelAtlas[level - 1] == "Atlas")
		{
			string[] array3 = levelAtlas;
			int num3 = level - 1;
			object obj3 = defaultAssetArray[3];
			if (!(obj3 is string))
			{
				obj3 = RuntimeServices.Coerce(obj3, typeof(string));
			}
			array3[num3] = (string)obj3;
		}
		if (levelColor[level - 1] == "AtlasColor")
		{
			string[] array4 = levelColor;
			int num4 = level - 1;
			object obj4 = defaultAssetArray[4];
			if (!(obj4 is string))
			{
				obj4 = RuntimeServices.Coerce(obj4, typeof(string));
			}
			array4[num4] = (string)obj4;
		}
		GameObject gameObject = GameObject.FindWithTag("Sky");
		if ((bool)gameObject)
		{
			if (!(gameObject.name == levelSky[level - 1]))
			{
				UnityEngine.Object.Destroy(gameObject);
				UnityEngine.Object @object = UnityEngine.Object.Instantiate(Resources.Load("Sky/" + levelSky[level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
				@object.name = levelSky[level - 1];
			}
		}
		else
		{
			UnityEngine.Object @object = UnityEngine.Object.Instantiate(Resources.Load("Sky/" + levelSky[level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
			@object.name = levelSky[level - 1];
		}
		GameObject gameObject2 = GameObject.FindWithTag("Light");
		if ((bool)gameObject2)
		{
			if (!(gameObject2.name == levelLight[level - 1]))
			{
				UnityEngine.Object.Destroy(gameObject2);
				UnityEngine.Object @object = UnityEngine.Object.Instantiate(Resources.Load("Lights/" + levelLight[level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
				@object.name = levelLight[level - 1];
			}
		}
		else
		{
			UnityEngine.Object @object = UnityEngine.Object.Instantiate(Resources.Load("Lights/" + levelLight[level - 1]), new Vector3(0f, 0f, 0f), Quaternion.identity);
			@object.name = levelLight[level - 1];
		}
		BlackoutControl blackoutControl = (BlackoutControl)UnityEngine.Object.FindObjectOfType(typeof(BlackoutControl));
		if ((bool)blackoutControl)
		{
			if (forceAtlas != string.Empty)
			{
				blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/" + forceAtlas));
				blackoutControl.ChangeColor(levelColor[level - 1]);
			}
			else
			{
				blackoutControl.ChangeTexture((Texture2D)Resources.Load("Atlas/" + levelAtlas[level - 1]));
				blackoutControl.ChangeColor(levelColor[level - 1]);
			}
		}
		if (levelMusic[level - 1] == "Music")
		{
			gameControl.PlayMusic((AudioClip)Resources.Load(gameControl.appName + "/Music"));
		}
		else
		{
			gameControl.PlayMusic((AudioClip)Resources.Load("Music/" + levelMusic[level - 1]));
		}
		gameControl.doubleOutfit = levelOutfit[level - 1];
	}

	public virtual void Update()
	{
		if (autoAccelerate != 0f)
		{
			gameControl.inputVector.y = autoAccelerate;
		}
	}

	public virtual void Main()
	{
	}
}
