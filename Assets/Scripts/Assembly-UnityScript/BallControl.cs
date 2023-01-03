using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class BallControl : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024Kick_0024466 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal BallControl _0024self__0024467;

			public _0024(BallControl self_)
			{
				_0024self__0024467 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					result = (Yield(2, new WaitForSeconds(0.05f)) ? 1 : 0);
					break;
				case 2:
					if ((bool)_0024self__0024467.kickSound)
					{
						_0024self__0024467.gameControl.PlaySound(_0024self__0024467.kickSound);
					}
					_0024self__0024467.GetComponent<Rigidbody>().isKinematic = true;
					_0024self__0024467.transform.position = _0024self__0024467.playerTransform.position + _0024self__0024467.playerTransform.forward * 15f;
					_0024self__0024467.GetComponent<Rigidbody>().isKinematic = false;
					_0024self__0024467.GetComponent<Rigidbody>().AddExplosionForce(600f, _0024self__0024467.playerTransform.position, 0f, 20f);
					YieldDefault(1);
					goto case 1;
				case 1:
					result = 0;
					break;
				}
				return (byte)result != 0;
			}
		}

		internal BallControl _0024self__0024468;

		public _0024Kick_0024466(BallControl self_)
		{
			_0024self__0024468 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024self__0024468);
		}
	}

	public AudioClip kickSound;

	public Vector3 offsetVector;

	private Transform playerTransform;

	private GameControl gameControl;

	private string state;

	private SpringJoint myJoint;

	public BallControl()
	{
		offsetVector = new Vector3(0f, 0f, 0f);
		state = "free";
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		myJoint = (SpringJoint)GetComponent(typeof(SpringJoint));
		if ((bool)myJoint)
		{
			myJoint.spring = 0f;
		}
	}

	public virtual void OnCollisionEnter(Collision collision)
	{
		if (!(state != "free") && !(collision.transform.name != "Player") && !(collision.collider.name != "FootCollider"))
		{
			playerTransform = collision.transform;
			Vector3 position = transform.position;
			transform.position = playerTransform.position + playerTransform.forward * 7f - playerTransform.up * 6f;
			if ((bool)myJoint)
			{
				myJoint.connectedBody = playerTransform.GetComponent<Rigidbody>();
				myJoint.spring = 200f;
			}
			transform.position = position;
			state = "attached";
		}
	}

	public virtual void Update()
	{
		if (!(state == "free") && (bool)playerTransform && gameControl.touchButton[0])
		{
			if ((bool)myJoint)
			{
				myJoint.spring = 0f;
				myJoint.connectedBody = null;
			}
			state = "free";
			StartCoroutine(Kick());
		}
	}

	public virtual IEnumerator Kick()
	{
		return new _0024Kick_0024466(this).GetEnumerator();
	}

	public virtual void Main()
	{
	}
}
