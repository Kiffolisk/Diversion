using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;
using UnityScript.Lang;

[Serializable]
public class AnimatedCharacter : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024PlayKey_0024453 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal AnimatedCharacter _0024self__0024454;

			public _0024(AnimatedCharacter self_)
			{
				_0024self__0024454 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (!string.IsNullOrEmpty(_0024self__0024454.animationKeys[_0024self__0024454.keyID]))
					{
						_0024self__0024454.myAnimation.CrossFade(_0024self__0024454.animationKeys[_0024self__0024454.keyID]);
					}
					if (!string.IsNullOrEmpty(_0024self__0024454.audioKeysString[_0024self__0024454.keyID]))
					{
						_0024self__0024454.gameControl.PlaySound((AudioClip)Resources.Load(_0024self__0024454.gameControl.appName + "/" + _0024self__0024454.audioKeysString[_0024self__0024454.keyID]));
					}
					else if ((bool)_0024self__0024454.audioKeys[_0024self__0024454.keyID])
					{
						_0024self__0024454.gameControl.PlaySound(_0024self__0024454.audioKeys[_0024self__0024454.keyID]);
					}
					result = (Yield(2, new WaitForSeconds(_0024self__0024454.durationKeys[_0024self__0024454.keyID])) ? 1 : 0);
					break;
				case 2:
					_0024self__0024454.NextKey();
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal AnimatedCharacter _0024self__0024455;

		public _0024PlayKey_0024453(AnimatedCharacter self_)
		{
			_0024self__0024455 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024455);
		}
	}

	public float[] durationKeys;

	public string[] animationKeys;

	public AudioClip[] audioKeys;

	public string[] audioKeysString;

	public bool loopAnimation;

	public Animation myAnimation;

	private int keyID;

	private GameControl gameControl;

	public virtual void Awake()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		StartCoroutine(PlayKey());
	}

	public virtual IEnumerator PlayKey()
	{
		return new _0024PlayKey_0024453(this).GetEnumerator();
	}

	public virtual void NextKey()
	{
		keyID++;
		if (keyID < Extensions.get_length((System.Array)animationKeys))
		{
			StartCoroutine(PlayKey());
		}
		else if (loopAnimation)
		{
			keyID = 0;
			StartCoroutine(PlayKey());
		}
	}

	public virtual void Main()
	{
	}
}
