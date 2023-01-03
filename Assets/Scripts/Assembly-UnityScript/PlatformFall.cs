using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Boo.Lang;
using UnityEngine;

[Serializable]
public class PlatformFall : MonoBehaviour
{
	[Serializable]
	[CompilerGenerated]
	internal sealed class _0024OnCollisionEnter_0024629 : GenericGenerator<WaitForSeconds>
	{
		[Serializable]
		[CompilerGenerated]
		internal sealed class _0024 : GenericGeneratorEnumerator<WaitForSeconds>, IEnumerator
		{
			internal Collision _0024collision_0024630;

			internal PlatformFall _0024self__0024631;

			public _0024(Collision collision, PlatformFall self_)
			{
				_0024collision_0024630 = collision;
				_0024self__0024631 = self_;
			}

			public override bool MoveNext()
			{
				int result;
				switch (_state)
				{
				default:
					if (_0024self__0024631.state != "off")
					{
						goto case 1;
					}
					if (_0024collision_0024630.gameObject.name == "Player")
					{
						_0024self__0024631.state = "wiggle";
						_0024self__0024631.startTime = Time.time;
						if (_0024self__0024631.crackSoundName != string.Empty)
						{
							_0024self__0024631.gameControl.PlaySound((AudioClip)Resources.Load("Sounds/" + _0024self__0024631.crackSoundName));
						}
						result = (Yield(2, new WaitForSeconds(_0024self__0024631.fallAfterHowManySeconds)) ? 1 : 0);
						break;
					}
					goto IL_0109;
				case 2:
					_0024self__0024631.state = "fall";
					_0024self__0024631.gameControl.PlaySound((AudioClip)Resources.Load("Sounds/platformFall"));
					goto IL_0109;
				case 1:
					{
						result = 0;
						break;
					}
					IL_0109:
					YieldDefault(1);
					goto case 1;
				}
				return (byte)result != 0;
			}
		}

		internal Collision _0024collision_0024632;

		internal PlatformFall _0024self__0024633;

		public _0024OnCollisionEnter_0024629(Collision collision, PlatformFall self_)
		{
			_0024collision_0024632 = collision;
			_0024self__0024633 = self_;
		}

		public override IEnumerator<WaitForSeconds> GetEnumerator()
		{
			return new _0024(_0024collision_0024632, _0024self__0024633);
		}
	}

	public float fallAfterHowManySeconds;

	public string crackSoundName;

	private string state;

	private float mySpeed;

	private GameControl gameControl;

	private Vector3 startPos;

	private float startTime;

	private int terminalCount;

	public PlatformFall()
	{
		crackSoundName = "platformCrack";
		state = "off";
	}

	public virtual void Start()
	{
		gameControl = (GameControl)UnityEngine.Object.FindObjectOfType(typeof(GameControl));
		startPos = transform.position;
	}

	public virtual IEnumerator OnCollisionEnter(Collision collision)
	{
		return new _0024OnCollisionEnter_0024629(collision, this).GetEnumerator();
	}

	public virtual void Update()
	{
		if (state == "wiggle")
		{
			float num = 5f;
			transform.position = startPos + new Vector3(0f, UnityEngine.Random.Range(0f - num, num), 0f) * Time.deltaTime;
			mySpeed = -5f;
		}
		else
		{
			if (!(state == "fall"))
			{
				return;
			}
			mySpeed *= 1f + Time.deltaTime;
			mySpeed = Mathf.Clamp(mySpeed, -100f, 100f);
			float y = transform.position.y + mySpeed * Time.deltaTime;
			Vector3 position = transform.position;
			float num2 = (position.y = y);
			Vector3 vector2 = (transform.position = position);
			if (!(mySpeed > -100f))
			{
				terminalCount++;
				if (terminalCount > 100)
				{
					UnityEngine.Object.Destroy(gameObject);
					state = "off";
				}
			}
		}
	}

	public virtual void Main()
	{
	}
}
