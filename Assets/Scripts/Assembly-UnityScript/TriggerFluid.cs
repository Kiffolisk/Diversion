using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class TriggerFluid : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024DoDamage_0024696 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal TriggerFluid _0024self__0024697;

			public _0024(TriggerFluid self_)
			{
				_0024self__0024697 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					_0024self__0024697.damageDone = true;
					result = (Yield(2, new WaitForSeconds(1f)) ? 1 : 0);
					break;
				case 2:
					_0024self__0024697.damageDone = false;
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal TriggerFluid _0024self__0024698;

		public _0024DoDamage_0024696(TriggerFluid self_)
		{
			_0024self__0024698 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024698);
		}
	}

	public Transform splashPrefab;

	public AudioClip splashSound;

	public AudioClip damageSound;

	private int damage;

	private bool vibrateWhenHit;

	private bool damageDone;

	private bool showAtImpact;

	private GameControl gameControl;

	private Transform hitTransform;

	public TriggerFluid()
	{
		damage = 1;
		vibrateWhenHit = true;
		showAtImpact = true;
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
	}

	public virtual void OnTriggerEnter(Collider triggerObject)
	{
		if (!triggerObject.transform.parent || triggerObject.transform.parent.tag != "Player")
		{
			return;
		}
		hitTransform = triggerObject.transform.parent;
		if ((bool)hitTransform)
		{
			ShowSplash(hitTransform.position);
			if ((bool)splashSound)
			{
				gameControl.PlaySound(splashSound);
			}
		}
	}

	public virtual void ShowSplash(Vector3 splashPos)
	{
		if ((bool)splashPrefab)
		{
			Transform transform = null;
			transform = (Transform)UnityEngine.Object.Instantiate(splashPrefab, splashPos, Quaternion.identity);
			transform.parent = this.transform.parent;
		}
	}

	public virtual void OnTriggerStay(Collider triggerObject)
	{
		if (damageDone || !triggerObject.transform.parent || triggerObject.transform.parent.tag != "Player")
		{
			return;
		}
		hitTransform = triggerObject.transform.parent;
		if ((bool)gameControl && hitTransform == gameControl.playerControl.transform && gameControl.playerControl.shield == 0)
		{
			StartCoroutine(DoDamage());
			if (vibrateWhenHit)
			{
				gameControl.Shake(1f, true);
			}
			if ((bool)damageSound)
			{
				gameControl.PlaySound(damageSound);
			}
			if (damage > 0)
			{
				hitTransform.SendMessage("AddDamage", damage, SendMessageOptions.DontRequireReceiver);
			}
		}
	}

	public virtual IEnumerator DoDamage()
	{
		return new _0024DoDamage_0024696(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
