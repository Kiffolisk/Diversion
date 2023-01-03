using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class PromoControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024GetPromo_0024734 : GenericGenerator<WWW>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WWW>, IEnumerator
		{
			internal WWW _0024www_0024735;

			internal WWW _0024wwwIcon_0024736;

			internal string[] _0024tempArray_0024737;

			internal PromoControl _0024self__0024738;

			public _0024(PromoControl self_)
			{
				_0024self__0024738 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024738.debug)
					{
						MonoBehaviour.print("Promo: contacting website");
					}
					_0024self__0024738.status = "loading";
					_0024www_0024735 = new WWW(_0024self__0024738.promoDirectory + _0024self__0024738.promoURL);
					result = (Yield(2, _0024www_0024735) ? 1 : 0);
					break;
				case 2:
					_0024wwwIcon_0024736 = new WWW(_0024self__0024738.promoDirectory + _0024self__0024738.iconURL);
					result = (Yield(3, _0024wwwIcon_0024736) ? 1 : 0);
					break;
				case 3:
					if (!string.IsNullOrEmpty(_0024www_0024735.error) || !string.IsNullOrEmpty(_0024wwwIcon_0024736.error))
					{
						_0024self__0024738.status = "disconnected";
						if (_0024self__0024738.debug)
						{
							MonoBehaviour.print("Promo: error contacting website");
						}
					}
					else
					{
						_0024self__0024738.promoTexture = _0024wwwIcon_0024736.texture;
						Debug.Log(_0024www_0024735.text);
						_0024self__0024738.rawText = string.Empty + _0024www_0024735.text;
						if (PlayerPrefs.GetString("lastOffer", string.Empty) == _0024self__0024738.rawText && !_0024self__0024738.testing)
						{
							_0024self__0024738.status = "stale";
						}
						else
						{
							_0024tempArray_0024737 = _0024self__0024738.rawText.Split(char.Parse("|"));
							if (Extensions.get_length((System.Array)_0024tempArray_0024737) != 5)
							{
								_0024self__0024738.status = "Read the offer, but not formatted correctly";
							}
							else
							{
								_0024self__0024738.amount = _0024tempArray_0024737[0];
								_0024self__0024738.offerURL = _0024tempArray_0024737[1];
								_0024self__0024738.offer = "\n" + _0024tempArray_0024737[2];
								_0024self__0024738.noString = _0024tempArray_0024737[3];
								_0024self__0024738.yesString = _0024tempArray_0024737[4];
								_0024self__0024738.status = "loaded";
							}
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

		internal PromoControl _0024self__0024739;

		public _0024GetPromo_0024734(PromoControl self_)
		{
			_0024self__0024739 = self_;
		}

		public override IEnumerator<WWW> GetEnumerator()
		{
			return new _0024(_0024self__0024739);
		}
	}

	public bool testing;

	public string promoDirectory;

	public GUISkin mySkin;

	public AudioClip soundShow;

	public AudioClip soundHide;

	private string status;

	private string rawText;

	private string offer;

	private string amount;

	private string offerURL;

	private string noString;

	private string yesString;

	private Texture2D promoTexture;

	private string promoURL;

	private string iconURL;

	private float offsetWidth;

	private float offsetHeight;

	private float screenScale;

	private float zoomScale;

	private float zoomVelocity;

	private float deltaT;

	private Matrix4x4 scaledMatrix;

	private bool debug;

	public PromoControl()
	{
		promoDirectory = "http://ezone.com/promo/snowboard";
		status = "off";
		rawText = string.Empty;
		offer = string.Empty;
		amount = string.Empty;
		offerURL = string.Empty;
		noString = "No Thanks";
		yesString = "Get App Now";
		promoURL = "appoffer.txt";
		iconURL = "appicon.png";
		screenScale = 1f;
		zoomScale = 0.5f;
		deltaT = 0.033f;
		scaledMatrix = Matrix4x4.identity;
		debug = true;
	}

	public virtual void Start()
	{
		UnityEngine.Object.DontDestroyOnLoad(this);
		GameControl gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		if ((bool)gameControl)
		{
			if (gameControl.platform == "amazon")
			{
				promoDirectory += "-amazon/";
			}
			else
			{
				promoDirectory += "-android/";
			}
		}
		else
		{
			promoDirectory += "-android/";
		}
		if (!((float)Screen.width * 1f / (float)Screen.height <= 1.5f))
		{
			screenScale = (float)Screen.height / 640f;
			offsetWidth = ((float)Screen.width - 960f * screenScale) * 0.5f;
		}
		else
		{
			screenScale = (float)Screen.width / 960f;
			offsetHeight = ((float)Screen.height - 640f * screenScale) * 0.5f;
		}
		scaledMatrix.SetTRS(new Vector3(offsetWidth, offsetHeight, 0f), Quaternion.identity, new Vector3(screenScale, screenScale, screenScale));
		CheckForPromo();
	}

	private void CheckForPromo()
	{
		if (!(status != "off"))
		{
			string text = DateTime.Now.ToString("MM/dd/yyyy");
			if (PlayerPrefs.GetString("lastDayChecked") != text || testing)
			{
				PlayerPrefs.SetString("lastDayChecked", text);
				StartCoroutine(GetPromo());
			}
		}
	}

	private IEnumerator GetPromo()
	{
		return new _0024GetPromo_0024734(this).GetEnumerator();
	}

	private void CollectPrize()
	{
		status = "hide";
		GetComponent<AudioSource>().PlayOneShot(soundHide);
		gameObject.SendMessage("PromoDone", 0, SendMessageOptions.DontRequireReceiver);
		Application.OpenURL(offerURL);
	}

	public virtual void ShowPromo()
	{
		if (status == "loaded")
		{
			status = "show";
			PlayerPrefs.SetString("lastOffer", rawText);
			GetComponent<AudioSource>().PlayOneShot(soundShow);
			gameObject.SendMessage("PromoShowing", SendMessageOptions.DontRequireReceiver);
		}
		else
		{
			MonoBehaviour.print("Promo not loaded. Status: " + status);
			CheckForPromo();
		}
	}

	private void ChangeScale()
	{
		if (status == "show")
		{
			zoomVelocity += (100f * (1f - zoomScale) - 7f * zoomVelocity) * deltaT;
			zoomScale += zoomVelocity * deltaT;
		}
		else
		{
			zoomScale += (0f - zoomScale) * deltaT * 10f;
			if (!(zoomScale >= 0.1f))
			{
				if (testing)
				{
					status = "loaded";
				}
				else
				{
					status = "off";
				}
			}
		}
		scaledMatrix.SetTRS(new Vector3(offsetWidth + screenScale * 480f * (1f - zoomScale), offsetHeight + screenScale * 320f * (1f - zoomScale), 0f), Quaternion.identity, new Vector3(screenScale * zoomScale, screenScale * zoomScale, screenScale * zoomScale));
	}

	public virtual void OnGUI()
	{
		if (status == "show" || status == "hide")
		{
			ChangeScale();
			GUI.depth = -1;
			GUI.matrix = scaledMatrix;
			GUI.skin = mySkin;
			GUI.Box(new Rect(-200f, -200f, 1360f, 1040f), string.Empty, "Matte");
			GUI.Box(new Rect(190f, 180f, 580f, 300f), offer);
			if ((GUI.Button(new Rect(220f, 370f, 250f, 80f), noString) || eInput.rightPadRight || eInput.Start) && status == "show")
			{
				gameObject.SendMessage("PromoDone", 0, SendMessageOptions.DontRequireReceiver);
				status = "hide";
				GetComponent<AudioSource>().PlayOneShot(soundHide);
			}
			if ((GUI.Button(new Rect(480f, 370f, 250f, 80f), yesString) || eInput.rightPadDown) && status == "show")
			{
				CollectPrize();
			}
			GUI.Label(new Rect(380f, 90f, 200f, 200f), promoTexture);
		}
	}

	public virtual void Main()
	{
	}
}
