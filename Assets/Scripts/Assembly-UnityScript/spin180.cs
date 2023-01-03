using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class spin180 : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResetState_0024731 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal spin180 _0024self__0024732;

			public _0024(spin180 self_)
			{
				_0024self__0024732 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024732.state = "idle";
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal spin180 _0024self__0024733;

		public _0024ResetState_0024731(spin180 self_)
		{
			_0024self__0024733 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024733);
		}
	}

	public Vector3 changeRotation;

	public float playerBounceHeight;

	private string state;

	public spin180()
	{
		changeRotation = new Vector3(180f, 0f, 0f);
		state = "idle";
	}

	public virtual void Start()
	{
		state = "idle";
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (!(state != "idle") && (bool)triggerObject.transform.parent)
		{
			state = "on";
			triggerObject.transform.parent.SendMessage("ChangeRotation", changeRotation, SendMessageOptions.DontRequireReceiver);
			if (!(playerBounceHeight <= 0f))
			{
				triggerObject.transform.parent.SendMessage("BouncedBaddie", playerBounceHeight, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if (!(state != "on"))
		{
			StartCoroutine(ResetState());
		}
	}

	public virtual IEnumerator ResetState()
	{
		return new _0024ResetState_0024731(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
