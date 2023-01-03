using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class TimedAudio : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024690 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TimedAudio _0024self__0024691;

			public _0024(TimedAudio self_)
			{
				_0024self__0024691 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024691.GetComponent<AudioSource>().loop = false;
					if (!(_0024self__0024691.secondsBeforeStart <= 0f))
					{
						result = (Yield(2, new WaitForSeconds(_0024self__0024691.secondsBeforeStart)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					if (_0024self__0024691.secondsBetweenPlays != 0f)
					{
						_0024self__0024691.InvokeRepeating("PlaySound", 0.01f, _0024self__0024691.secondsBetweenPlays);
					}
					else
					{
						_0024self__0024691.PlaySound();
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

		internal TimedAudio _0024self__0024692;

		public _0024Start_0024690(TimedAudio self_)
		{
			_0024self__0024692 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024692);
		}
	}

	public AudioClip[] audioClipsToPlay;

	public float secondsBeforeStart;

	public float secondsBetweenPlays;

	public TimedAudio()
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
		return new _0024Start_0024690(this).GetEnumerator();
	}

	public virtual void PlaySound()
	{
		if (!GetComponent<AudioSource>().enabled)
		{
			CancelInvoke("PlaySound");
			return;
		}
		if (Extensions.get_length((System.Array)audioClipsToPlay) > 0)
		{
			GetComponent<AudioSource>().clip = audioClipsToPlay[UnityEngine.Random.Range(0, Extensions.get_length((System.Array)audioClipsToPlay))];
		}
		if (GetComponent<AudioSource>().enabled)
		{
			GetComponent<AudioSource>().Play();
		}
	}

	public virtual void PlaySoundInList(string soundName)
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

	public virtual void Main()
	{
	}
}
