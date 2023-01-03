using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class FadeInOut : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024HideMe_0024483 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024done_0024484;

			internal FadeInOut _0024self__0024485;

			public _0024(FadeInOut self_)
			{
				_0024self__0024485 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024done_0024484 = Time.realtimeSinceStartup + 0.5f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024done_0024484)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					_0024self__0024485.enabled = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FadeInOut _0024self__0024486;

		public _0024HideMe_0024483(FadeInOut self_)
		{
			_0024self__0024486 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024486);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024LoadNextScene_0024487 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024done_0024488;

			internal FadeInOut _0024self__0024489;

			public _0024(FadeInOut self_)
			{
				_0024self__0024489 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024done_0024488 = Time.realtimeSinceStartup + 0.5f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024done_0024488)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					Application.LoadLevel(_0024self__0024489.nextScene);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal FadeInOut _0024self__0024490;

		public _0024LoadNextScene_0024487(FadeInOut self_)
		{
			_0024self__0024490 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024490);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnLevelWasLoaded_0024491 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal float _0024done_0024492;

			internal FadeInOut _0024self__0024493;

			public _0024(FadeInOut self_)
			{
				_0024self__0024493 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024done_0024492 = Time.realtimeSinceStartup + 0.5f;
					goto case 2;
				case 2:
					if (Time.realtimeSinceStartup < _0024done_0024492)
					{
						result = (YieldDefault(2) ? 1 : 0);
						break;
					}
					if (!_0024self__0024493.initializedScene)
					{
						_0024self__0024493.fadeDir = -1;
						_0024self__0024493.gameControl.InitScene();
						_0024self__0024493.initializedScene = true;
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

		internal FadeInOut _0024self__0024494;

		public _0024OnLevelWasLoaded_0024491(FadeInOut self_)
		{
			_0024self__0024494 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024494);
		}
	}

	public Texture2D fadeOutTexture;

	private Texture2D logoTexture;

	public float fadeSpeed;

	public GUISkin guiSkin;

	public int drawDepth;

	private string nextScene;

	private float alpha;

	private int fadeDir;

	private GameControl gameControl;

	private int status;

	private float logoScale;

	private bool initializedScene;

	private int fadeTimer;

	private Matrix4x4 scaledMatrix;

	private float lastTime;

	public FadeInOut()
	{
		fadeSpeed = 0.3f;
		drawDepth = 1;
		nextScene = "Title";
		alpha = 1f;
		fadeDir = -1;
		status = 1;
		scaledMatrix = Matrix4x4.identity;
	}

	public virtual void Awake()
	{
		useGUILayout = false;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		logoScale = (float)Screen.width / 1024f;
		logoTexture = (Texture2D)Resources.Load(gameControl.appName + "/Logo");
		ResizeGUI();
	}

	public virtual void ResizeGUI()
	{
		float num = 1f;
		float num2 = 0f;
		float num3 = 0f;
		float num4 = Screen.height;
		float num5 = Screen.width;
		float num6 = 0f;
		float num7 = 0f;
		if (gameControl.devicemodel == "ouya")
		{
			num3 = num4 * 0.05f * 0.5f;
			num2 = num5 * 0.05f * 0.5f;
			num4 *= 0.95f;
			num5 *= 0.95f;
		}
		if (!(num5 * 1f / num4 <= 1.5f))
		{
			num = num4 / 640f;
			num2 += (num5 - 960f * num) * 0.5f;
		}
		else
		{
			num = num5 / 960f;
			num3 += (num4 - 640f * num) * 0.5f;
		}
		scaledMatrix.SetTRS(new Vector3(num2, num3, 0f), Quaternion.identity, new Vector3(num, num, num));
	}

	public virtual void OnGUI()
	{
		if (status == 1)
		{
			GUI.skin = guiSkin;
			GUI.matrix = scaledMatrix;
			float num = Time.realtimeSinceStartup - lastTime;
			if (!(num <= 0.1f))
			{
				num = 0.1f;
			}
			alpha += (float)fadeDir * fadeSpeed * num;
			lastTime = Time.realtimeSinceStartup;
			alpha = Mathf.Clamp01(alpha);
			float a = alpha;
			Color color = GUI.color;
			float num2 = (color.a = a);
			Color color3 = (GUI.color = color);
			GUI.depth = drawDepth;
			if ((bool)gameControl.backdropTexture)
			{
				GUI.DrawTexture(new Rect(-400f, -600f, 1760f, 1840f), gameControl.backdropTexture);
			}
			GUI.Label(new Rect(200f, 200f, 600f, 200f), gameControl.levelHint, "hint");
			GUI.DrawTexture(new Rect(0f, 300f, 328f, 400f), (Texture)Resources.Load(gameControl.appName + "/GarbotImage"));
			GUI.Label(new Rect(780f, 460f, 150f, 150f), string.Empty, "loading");
			if (fadeDir == 1 && !(alpha < 1f))
			{
				initializedScene = false;
				alpha = 1f;
				fadeTimer = 0;
				fadeDir = 0;
				float a2 = alpha;
				Color color4 = GUI.color;
				float num3 = (color4.a = a2);
				Color color6 = (GUI.color = color4);
				StartCoroutine(LoadNextScene());
			}
			else if (fadeDir == 0)
			{
				alpha = 1f;
			}
			else if (!(alpha > 0f))
			{
				status = 0;
				StartCoroutine(HideMe());
			}
		}
	}

	public virtual IEnumerator HideMe()
	{
		return new _0024HideMe_0024483(this).GetEnumerator();
	}

	public virtual IEnumerator LoadNextScene()
	{
		return new _0024LoadNextScene_0024487(this).GetEnumerator();
	}

	public virtual IEnumerator OnLevelWasLoaded(int level)
	{
		return new _0024OnLevelWasLoaded_0024491(this).GetEnumerator();
	}

	public virtual void fadeIn()
	{
		status = 1;
		fadeDir = -1;
		alpha = 1f;
	}

	public virtual void LoadScene(string whichScene, bool fadeOutFirst)
	{
		ResizeGUI();
		nextScene = whichScene;
		fadeDir = 1;
		alpha = 0f;
		if (!fadeOutFirst)
		{
			alpha = 1f;
		}
		status = 1;
	}

	public virtual void Main()
	{
	}
}
