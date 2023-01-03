using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class ButtonActivated : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024TurnOff_0024475 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal ButtonActivated _0024self__0024476;

			public _0024(ButtonActivated self_)
			{
				_0024self__0024476 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.01f)) ? 1 : 0);
					break;
				case 2:
					if (_0024self__0024476.toggleGravity)
					{
						_0024self__0024476.GetComponent<Rigidbody>().useGravity = false;
					}
					if ((bool)_0024self__0024476.myAnimation && _0024self__0024476.offAnimation != string.Empty)
					{
						_0024self__0024476.myAnimation.CrossFade(_0024self__0024476.offAnimation, 0.5f);
					}
					if (_0024self__0024476.toggleVisibility)
					{
						_0024self__0024476.gameObject.SetActive(false);
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

		internal ButtonActivated _0024self__0024477;

		public _0024TurnOff_0024475(ButtonActivated self_)
		{
			_0024self__0024477 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024477);
		}
	}

	public bool toggleVisibility;

	public bool toggleGravity;

	public string onAnimation;

	public string offAnimation;

	private Animation myAnimation;

	public ButtonActivated()
	{
		toggleVisibility = true;
		onAnimation = string.Empty;
		offAnimation = string.Empty;
	}

	public virtual void Start()
	{
		myAnimation = (Animation)gameObject.GetComponentInChildren(typeof(Animation));
	}

	public virtual void TurnOn()
	{
		if (toggleVisibility)
		{
			gameObject.SetActive(true);
		}
		if (toggleGravity)
		{
			GetComponent<Rigidbody>().useGravity = true;
		}
		if ((bool)myAnimation && onAnimation != string.Empty)
		{
			myAnimation.Play(onAnimation);
		}
	}

	public virtual IEnumerator TurnOff()
	{
		return new _0024TurnOff_0024475(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
