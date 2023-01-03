using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TimedAudioResources : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024693 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TimedAudioResources _0024self__0024694;

			public _0024(TimedAudioResources self_)
			{
				_0024self__0024694 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024694.GetComponent<AudioSource>().loop = false;
					_0024self__0024694.gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
					if (!(_0024self__0024694.secondsBeforeStart <= 0f))
					{
						result = (Yield(2, new WaitForSeconds(_0024self__0024694.secondsBeforeStart)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (_0024self__0024694.secondsBetweenPlays != 0f)
					{
						_0024self__0024694.InvokeRepeating("PlaySound", 0.01f, _0024self__0024694.secondsBetweenPlays);
					}
					else
					{
						_0024self__0024694.PlaySound();
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

		internal TimedAudioResources _0024self__0024695;

		public _0024Start_0024693(TimedAudioResources self_)
		{
			_0024self__0024695 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024695);
		}
	}

	public string[] audioClipsToPlay;

	public float secondsBeforeStart;

	public float secondsBetweenPlays;

	private GameControl gameControl;

	public TimedAudioResources()
	{
		secondsBetweenPlays = 2.5f;
	}

	public virtual void Awake()
	{
		if (!GetComponent<AudioSource>())
		{
			MonoBehaviour.print("WARNING!!!! No audioSource attached to: " + gameObject.name);
		}
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_0024693(this).GetEnumerator();
	}

	public virtual void PlaySound()
	{
		if (Extensions.get_length((System.Array)audioClipsToPlay) > 0)
		{
			GetComponent<AudioSource>().clip = (AudioClip)Resources.Load(gameControl.appName + "/" + audioClipsToPlay[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)audioClipsToPlay))]);
		}
		GetComponent<AudioSource>().Play();
	}

	public virtual void Main()
	{
	}
}
