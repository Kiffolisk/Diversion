using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class Bullet : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Start_0024472 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Bullet _0024self__0024473;

			public _0024(Bullet self_)
			{
				_0024self__0024473 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024473.charged = false;
					if (_0024self__0024473.usePhysics)
					{
						_0024self__0024473.GetComponent<Rigidbody>().velocity = _0024self__0024473.transform.TransformDirection(Vector3.forward) * _0024self__0024473.bulletSpeed;
					}
					result = (Yield(2, new WaitForSeconds(0.1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024473.charged = true;
					if (!(_0024self__0024473.airTime >= 0.1f))
					{
						_0024self__0024473.airTime = 0.1f;
					}
					result = (Yield(3, new WaitForSeconds(_0024self__0024473.airTime - 0.1f)) ? 1 : 0);
					break;
				case 3:
					UnityEngine.Object.Destroy(_0024self__0024473.gameObject);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal Bullet _0024self__0024474;

		public _0024Start_0024472(Bullet self_)
		{
			_0024self__0024474 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024474);
		}
	}

	public float airTime;

	public int bulletSpeed;

	public bool usePhysics;

	private bool charged;

	public Bullet()
	{
		airTime = 5f;
		bulletSpeed = 100;
	}

	public virtual IEnumerator Start()
	{
		return new _0024Start_0024472(this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (!usePhysics)
		{
			transform.Translate(0f, 0f, (float)bulletSpeed * Time.deltaTime);
		}
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (!(triggerObject.tag != "BulletEffected") && charged && (bool)triggerObject.transform.parent)
		{
			triggerObject.transform.parent.SendMessage("ShotByBullet", 1, SendMessageOptions.DontRequireReceiver);
			triggerObject.transform.SendMessage("ShotByBullet", 1, SendMessageOptions.DontRequireReceiver);
			charged = false;
		}
	}

	public virtual void Die()
	{
		UnityEngine.Object.Destroy(gameObject);
	}

	public virtual void Main()
	{
	}
}
