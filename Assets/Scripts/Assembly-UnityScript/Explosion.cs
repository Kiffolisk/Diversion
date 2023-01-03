using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Explosion : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OneShotEmitters_0024478 : GenericGenerator<object>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<object>, IEnumerator
		{
			internal int _0024i_0024479;

			internal Transform _0024child_0024480;

			internal Explosion _0024self__0024481;

			public _0024(Explosion self_)
			{
				_0024self__0024481 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (YieldDefault(2) ? 1 : 0);
					break;
				case 2:
					for (_0024i_0024479 = 0; _0024i_0024479 < _0024self__0024481.transform.childCount; _0024i_0024479++)
					{
						_0024child_0024480 = _0024self__0024481.transform.GetChild(_0024i_0024479);
						if ((bool)_0024child_0024480.GetComponent<ParticleEmitter>())
						{
							_0024child_0024480.GetComponent<ParticleEmitter>().emit = false;
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

		internal Explosion _0024self__0024482;

		public _0024OneShotEmitters_0024478(Explosion self_)
		{
			_0024self__0024482 = self_;
		}

		public override IEnumerator<object> GetEnumerator()
		{
			return new _0024(_0024self__0024482);
		}
	}

	public virtual void Start()
	{
		StartCoroutine(OneShotEmitters());
		UnityEngine.Object.Destroy(gameObject, 3f);
	}

	public virtual IEnumerator OneShotEmitters()
	{
		return new _0024OneShotEmitters_0024478(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
