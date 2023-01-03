using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TriggerStop : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnTriggerEnter_0024723 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collider _0024triggerObject_0024724;

			internal TriggerStop _0024self__0024725;

			public _0024(Collider triggerObject, TriggerStop self_)
			{
				_0024triggerObject_0024724 = triggerObject;
				_0024self__0024725 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024725.state != "idle" || !_0024triggerObject_0024724.transform.parent)
					{
						goto case 1;
					}
					_0024self__0024725.state = "on";
					if (_0024self__0024725.adjustRotation)
					{
						_0024triggerObject_0024724.transform.parent.SendMessage("AdjustRotation", _0024self__0024725.transform.rotation, SendMessageOptions.DontRequireReceiver);
						result = (Yield(2, new WaitForSeconds(0.01f)) ? 1 : 0);
						break;
					}
					goto case 2;
				case 2:
					_0024triggerObject_0024724.transform.parent.SendMessage("ChangeStop", true, SendMessageOptions.DontRequireReceiver);
					_0024triggerObject_0024724.transform.parent.SendMessage("ChangeHorizontalPosition", _0024self__0024725.transform, SendMessageOptions.DontRequireReceiver);
					_0024self__0024725.StartCoroutine(_0024self__0024725.ResetState());
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Collider _0024triggerObject_0024726;

		internal TriggerStop _0024self__0024727;

		public _0024OnTriggerEnter_0024723(Collider triggerObject, TriggerStop self_)
		{
			_0024triggerObject_0024726 = triggerObject;
			_0024self__0024727 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024triggerObject_0024726, _0024self__0024727);
		}
	}

	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024ResetState_0024728 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TriggerStop _0024self__0024729;

			public _0024(TriggerStop self_)
			{
				_0024self__0024729 = self_;
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
					_0024self__0024729.state = "idle";
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TriggerStop _0024self__0024730;

		public _0024ResetState_0024728(TriggerStop self_)
		{
			_0024self__0024730 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024730);
		}
	}

	private string state;

	public bool adjustRotation;

	public TriggerStop()
	{
		state = "idle";
	}

	public virtual void Start()
	{
		state = "idle";
	}

	public virtual IEnumerator OnTriggerEnter(Collider triggerObject)
	{
		return new _0024OnTriggerEnter_0024723(triggerObject, this).GetEnumerator();
	}

	public virtual void OnTriggerExit(Collider triggerObject)
	{
		if (!(state != "on") && (bool)triggerObject.transform.parent && !(triggerObject.transform.parent.tag != "Player"))
		{
			state = "off";
			StartCoroutine(ResetState());
		}
	}

	public virtual IEnumerator ResetState()
	{
		return new _0024ResetState_0024728(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
