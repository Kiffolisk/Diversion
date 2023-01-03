using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AnimationActions : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PlayNextAnimation_0024456 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AnimationActions _0024self__0024457;

			public _0024(AnimationActions self_)
			{
				_0024self__0024457 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!_0024self__0024457.ready)
					{
						goto case 1;
					}
					_0024self__0024457.animID++;
					if (_0024self__0024457.animID < Extensions.get_length((System.Array)_0024self__0024457.animationList))
					{
						if ((bool)_0024self__0024457.myAnimation)
						{
							_0024self__0024457.myAnimation.Play(_0024self__0024457.animationList[_0024self__0024457.animID]);
						}
					}
					else
					{
						_0024self__0024457.animID = Extensions.get_length((System.Array)_0024self__0024457.animationList) - 1;
						if (_0024self__0024457.pauseAnimationWhenOff && (bool)_0024self__0024457.myAnimation)
						{
							_0024self__0024457.myAnimation[_0024self__0024457.animationList[_0024self__0024457.animID]].speed = 1f;
						}
					}
					if (!_0024self__0024457.pauseAnimationWhenOff)
					{
						_0024self__0024457.ready = false;
						result = (Yield(2, new WaitForSeconds(0.5f)) ? 1 : 0);
						break;
					}
					goto IL_0157;
				case 2:
					_0024self__0024457.ready = true;
					goto IL_0157;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0157:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal AnimationActions _0024self__0024458;

		public _0024PlayNextAnimation_0024456(AnimationActions self_)
		{
			_0024self__0024458 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024458);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024StartFall_0024459 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal float _0024fallAfterHowManySeconds_0024460;

			internal float _0024startTime_0024461;

			internal float _0024howManySeconds_0024462;

			internal AnimationActions _0024self__0024463;

			public _0024(float howManySeconds, AnimationActions self_)
			{
				_0024howManySeconds_0024462 = howManySeconds;
				_0024self__0024463 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024463.state != "off")
					{
						goto case 1;
					}
					if ((bool)_0024self__0024463.myAnimation)
					{
						_0024self__0024463.myAnimation.Stop();
					}
					_0024fallAfterHowManySeconds_0024460 = 0f;
					_0024fallAfterHowManySeconds_0024460 = _0024howManySeconds_0024462;
					_0024self__0024463.state = "wiggle";
					_0024startTime_0024461 = Time.time;
					_0024self__0024463.startPos = _0024self__0024463.transform.position;
					_0024self__0024463.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/platformCrack"));
					result = (Yield(2, new WaitForSeconds(_0024fallAfterHowManySeconds_0024460)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024463.state = "fall";
					_0024self__0024463.GetComponent<AudioSource>().PlayOneShot((AudioClip)Resources.Load("Sounds/platformFall"));
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal float _0024howManySeconds_0024464;

		internal AnimationActions _0024self__0024465;

		public _0024StartFall_0024459(float howManySeconds, AnimationActions self_)
		{
			_0024howManySeconds_0024464 = howManySeconds;
			_0024self__0024465 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024howManySeconds_0024464, _0024self__0024465);
		}
	}

	public bool pauseAnimationWhenOff;

	public string[] animationList;

	public AudioClip[] audioClipsToPlay;

	public Transform explosionPrefab;

	private Animation myAnimation;

	private int animID;

	private string state;

	private Vector3 startPos;

	private float mySpeed;

	private int terminalCount;

	private bool ready;

	public AnimationActions()
	{
		animID = -1;
		state = "off";
		ready = true;
	}

	public virtual void Start()
	{
		myAnimation = (Animation)gameObject.GetComponent(typeof(Animation));
		StartCoroutine(PlayNextAnimation());
	}

	public virtual void Update()
	{
		if (state == "wiggle")
		{
			float num = 5f;
			transform.position = startPos + new Vector3(0f, UnityEngine.Random.Range(0f - num, num), 0f) * Time.deltaTime;
			mySpeed = -5f;
		}
		else
		{
			if (!(state == "fall"))
			{
				return;
			}
			mySpeed *= 1f + Time.deltaTime;
			mySpeed = Mathf.Clamp(mySpeed, -100f, 100f);
			float y = transform.position.y + mySpeed * Time.deltaTime;
			Vector3 position = transform.position;
			float num2 = (position.y = y);
			Vector3 vector2 = (transform.position = position);
			if (!(mySpeed > -100f))
			{
				terminalCount++;
				if (terminalCount > 100)
				{
					UnityEngine.Object.Destroy(gameObject);
					state = "off";
				}
			}
		}
	}

	public virtual void PlaySound()
	{
		if (GetComponent<AudioSource>().enabled)
		{
			GetComponent<AudioSource>().clip = audioClipsToPlay[0];
			GetComponent<AudioSource>().Play();
		}
	}

	public virtual void PlaySoundNamed(string soundName)
	{
		int num = 0;
		for (int i = 0; i < Extensions.get_length((System.Array)audioClipsToPlay); i++)
		{
			if (audioClipsToPlay[i].name == soundName)
			{
				num = i;
				break;
			}
		}
		GetComponent<AudioSource>().clip = audioClipsToPlay[num];
		GetComponent<AudioSource>().Play();
	}

	public virtual IEnumerator PlayNextAnimation()
	{
		return new _0024PlayNextAnimation_0024456(this).GetEnumerator();
	}

	public virtual IEnumerator StartFall(float howManySeconds)
	{
		return new _0024StartFall_0024459(howManySeconds, this).GetEnumerator();
	}

	public virtual void Explode()
	{
		if ((bool)explosionPrefab)
		{
			UnityEngine.Object.Instantiate(explosionPrefab, transform.position, transform.rotation);
		}
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void OnTriggerEnter()
	{
		StartCoroutine(PlayNextAnimation());
	}

	public virtual void OnCollisionEnter()
	{
		StartCoroutine(PlayNextAnimation());
	}

	public virtual void OnCollisionExit()
	{
		if (pauseAnimationWhenOff && (bool)myAnimation)
		{
			myAnimation[animationList[animID]].speed = 0f;
		}
	}

	public virtual void Main()
	{
	}
}
